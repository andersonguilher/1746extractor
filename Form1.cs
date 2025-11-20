using AngleSharp;
using AngleSharp.Dom;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemandasApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource? _cancellationTokenSource;
        private HttpClient _httpClient;
        private CookieContainer _cookieContainer;
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");

        public Form1()
        {
            CleanupOldLogEntries();
            InitializeComponent();
            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            _cookieContainer = new CookieContainer();
            _httpClient = new HttpClient(new HttpClientHandler { CookieContainer = _cookieContainer });
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            _httpClient.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8");
            _httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            btnStop.BackColor = System.Drawing.Color.Gray;
            try
            {
                this.Icon = new System.Drawing.Icon("logo.ico");
            }
            catch { /* Ignora se o ícone não for encontrado */ }
        }

        private void btnSettings_Click(object? sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                // Show the settings form modally
                settingsForm.ShowDialog(this);
            }
            Log("Formulário de configurações aberto e fechado.");
        }

        private void CleanupOldLogEntries()
        {
            try
            {
                if (!File.Exists(logFilePath))
                {
                    return;
                }

                var lines = File.ReadAllLines(logFilePath);
                var recentLines = new List<string>();
                var cutoffDate = DateTime.Now.AddDays(-3);

                foreach (var line in lines)
                {
                    // O formato da data é "dd/MM/yyyy HH:mm:ss" (19 caracteres)
                    if (line.Length > 20 && line[19] == ':')
                    {
                        if (DateTime.TryParse(line.Substring(0, 19), out DateTime entryDate))
                        {
                            if (entryDate >= cutoffDate)
                            {
                                recentLines.Add(line);
                            }
                        }
                        else
                        {
                            recentLines.Add(line); // Mantém linhas com formato inesperado
                        }
                    }
                }
                File.WriteAllLines(logFilePath, recentLines);
            }
            catch (Exception) { /* Ignora erros durante a limpeza do log */ }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                new LogForm(logFilePath).Show();
            }
        }

        private void Log(string message)
        {
            try
            {
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
            }
            catch (Exception)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Erro ao escrever no log.";
                }
            }
        }

        private async void btnStart_Click(object? sender, EventArgs e)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            var token = _cancellationTokenSource.Token;

            btnStart.Enabled = false;
            btnStart.Text = "PROCESSANDO...";
            btnStop.Enabled = true;
            btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            lblStatus.Text = "Iniciando...";
            Log("Processo iniciado.");

            // Reset UI
            lblTotal.Text = "Total a processar: 0";
            lblUpdated.Text = "Atualizados: 0";
            lblErrors.Text = "Erros: 0";
            progressBar.Value = 0;
            lblProgressPercentage.Text = "0%";
            lblTimeRemaining.Text = "Tempo estimado: Calculando...";


            try
            {
                var initialCookie = Properties.Settings.Default.AUTH_COOKIE;
                if (string.IsNullOrEmpty(initialCookie))
                {
                    lblStatus.Text = "Cookie não configurado.";
                    Log("Erro: O cookie de autenticação não está configurado. Por favor, configure-o em Settings.");
                    MessageBox.Show("O cookie de autenticação não está configurado. Por favor, vá em 'Settings' para configurá-lo.", "Cookie Necessário", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    return;
                }
                UpdateCookies(initialCookie);
                Log("Cookie de autenticação atualizado.");

                var connectionString = $"Server={Properties.Settings.Default.DB_HOST};Port={Properties.Settings.Default.DB_PORT};Database={Properties.Settings.Default.DB_NAME};Uid={Properties.Settings.Default.DB_USER};Pwd={Properties.Settings.Default.DB_PASS};";
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync(token);
                    Log("Conexão com o banco de dados estabelecida.");
                    var selectQuery = $"SELECT id_chamado FROM {Properties.Settings.Default.TABLE_NAME} WHERE status IN ('Aberto', 'Em andamento') AND (complemento IS NULL OR complemento = '') AND (referencia IS NULL OR referencia = '')";
                    var command = new MySqlCommand(selectQuery, connection)
                    {
                        CommandTimeout = 60 // Adiciona um timeout de 60 segundos para a consulta
                    };
                    using (var reader = await command.ExecuteReaderAsync(token))
                    {
                        var stopwatch = new Stopwatch();
                        stopwatch.Start();
                        var id_chamados = new List<string>();
                        while (await reader.ReadAsync(token))
                        {
                            var idValue = reader.GetValue(0)?.ToString();
                            if (!string.IsNullOrEmpty(idValue))
                            {
                                id_chamados.Add(idValue);
                            }
                        }
                        reader.Close();

                        int totalChamados = id_chamados.Count;
                        int updatedCount = 0;
                        int errorCount = 0;
                        lblTotal.Text = $"Total a processar: {totalChamados}";

                        for (int i = 0; i < totalChamados; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                lblStatus.Text = "Operação cancelada.";
                                Log("Operação cancelada pelo usuário durante o processamento.");
                                break;
                            }

                            var idChamado = id_chamados[i];
                            lblStatus.Text = $"Processando chamado: {idChamado}";
                            Log($"Processando chamado: {idChamado}");

                            try
                            {
                                var (complemento, referencia) = await ScrapeData(idChamado, token);
                                if (complemento != null && referencia != null)
                                {
                                    var updateQuery = $"UPDATE {Properties.Settings.Default.TABLE_NAME} SET complemento = CASE WHEN complemento IS NULL OR complemento = '' THEN @complemento ELSE complemento END, referencia = CASE WHEN referencia IS NULL OR referencia = '' THEN @referencia ELSE referencia END WHERE id_chamado = @id_chamado";
                                    using (var updateCommand = new MySqlCommand(updateQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@complemento", complemento);
                                        updateCommand.Parameters.AddWithValue("@referencia", referencia);
                                        updateCommand.Parameters.AddWithValue("@id_chamado", idChamado);
                                        await updateCommand.ExecuteNonQueryAsync(token);
                                    }
                                    updatedCount++;
                                    lblUpdated.Text = $"Atualizados: {updatedCount}";
                                    Log($"Chamado {idChamado} atualizado com sucesso.");
                                }
                            }
                            catch (OperationCanceledException)
                            {
                                // O usuário cancelou, então saímos do loop silenciosamente.
                                throw; // Lança novamente para ser pego pelo catch externo.
                            }
                            catch (PermissionException)
                            {
                                Log("Sessão expirada. Solicitando novo cookie.");
                                var newCookie = ShowInputDialog("Sessão expirada. Por favor, insira o novo cookie de autenticação.", "Cookie de Autenticação", Properties.Settings.Default.AUTH_COOKIE);
                                if (string.IsNullOrEmpty(newCookie))
                                {
                                    lblStatus.Text = "Operação cancelada.";
                                    Log("Operação cancelada pelo usuário ao inserir novo cookie.");
                                    break;
                                }
                                UpdateCookies(newCookie);
                                Log("Cookie de autenticação atualizado.");
                                // Retry
                                var (complemento, referencia) = await ScrapeData(idChamado, token);
                                if (complemento != null && referencia != null)
                                {
                                    var updateQuery = $"UPDATE {Properties.Settings.Default.TABLE_NAME} SET complemento = CASE WHEN complemento IS NULL OR complemento = '' THEN @complemento ELSE complemento END, referencia = CASE WHEN referencia IS NULL OR referencia = '' THEN @referencia ELSE referencia END WHERE id_chamado = @id_chamado";
                                    using (var updateCommand = new MySqlCommand(updateQuery, connection))
                                    {
                                        updateCommand.Parameters.AddWithValue("@complemento", complemento);
                                        updateCommand.Parameters.AddWithValue("@referencia", referencia);
                                        updateCommand.Parameters.AddWithValue("@id_chamado", idChamado);
                                        await updateCommand.ExecuteNonQueryAsync(token);
                                    }
                                    updatedCount++;
                                    lblUpdated.Text = $"Atualizados: {updatedCount}";
                                    Log($"Chamado {idChamado} atualizado com sucesso.");
                                }
                            }
                            catch (Exception ex)
                            {
                                lblStatus.Text = $"Erro ao processar {idChamado}: {ex.Message}";
                                Log($"Erro ao processar {idChamado}: {ex.Message}");
                                errorCount++;
                                lblErrors.Text = $"Erros: {errorCount}";
                                await Task.Delay(2000, token);
                            }
                            await Task.Delay(1500, token);

                            // Update progress bar
                            int progress = (int)(((double)(i + 1) / totalChamados) * 100);
                            progressBar.Value = progress;
                            lblProgressPercentage.Text = $"{progress}%";

                            // Calculate and display estimated time remaining
                            var elapsed = stopwatch.Elapsed;
                            var itemsProcessed = i + 1;
                            if (itemsProcessed > 0)
                            {
                                var avgTimePerItem = elapsed.TotalSeconds / itemsProcessed;
                                var itemsRemaining = totalChamados - itemsProcessed;
                                var estimatedSecondsRemaining = avgTimePerItem * itemsRemaining;
                                var remainingTimeSpan = TimeSpan.FromSeconds(estimatedSecondsRemaining);
                                lblTimeRemaining.Text = $"Tempo estimado: {remainingTimeSpan:hh\\:mm\\:ss}";
                            }
                        }
                    }
                }
            }
            catch (OperationCanceledException)
            {
                // Captura o cancelamento de forma limpa.
                lblStatus.Text = "Operação cancelada.";
                Log("Operação cancelada pelo usuário.");
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Erro: {ex.Message}";
                Log($"Erro fatal: {ex.Message}");
            }
            finally
            {
                btnStart.Text = "▶ INICIAR";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnStop.BackColor = System.Drawing.Color.Gray;
                // Se não foi cancelado e não houve erro, marca como concluído.
                if (!token.IsCancellationRequested && lblStatus.Text != "Operação cancelada." && !lblStatus.Text.StartsWith("Erro"))
                {
                    lblTimeRemaining.Text = "Tempo estimado: 00:00:00";
                    lblStatus.Text = "Concluído.";
                    Log("Processo concluído.");
                }
            }
        }

        private void btnStop_Click(object? sender, EventArgs e)
        {
            _cancellationTokenSource?.Cancel();
            Log("Botão de parar clicado.");
        }

        private async void btnExportFullTable_Click(object? sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog
            {
                Filter = "Arquivo Excel (*.xlsx)|*.xlsx|Arquivo CSV (*.csv)|*.csv",
                Title = "Exportar Tabela Completa",
                FileName = "TabelaCompleta.xlsx",
                FilterIndex = 1
            })
            {
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                lblStatus.Text = "Exportando tabela completa...";
                Log("Iniciando exportação da tabela completa.");
                btnExportFullTable.Enabled = false;

                try
                {
                    var connectionString = $"Server={Properties.Settings.Default.DB_HOST};Port={Properties.Settings.Default.DB_PORT};Database={Properties.Settings.Default.DB_NAME};Uid={Properties.Settings.Default.DB_USER};Pwd={Properties.Settings.Default.DB_PASS};";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        await connection.OpenAsync();
                        var selectQuery = $"SELECT * FROM {Properties.Settings.Default.TABLE_NAME}";
                        using (var command = new MySqlCommand(selectQuery, connection))
                        {
                            using (var adapter = new MySqlDataAdapter(command))
                            {
                                var dataTable = new DataTable();
                                await Task.Run(() => adapter.Fill(dataTable)); // Executa em uma thread de fundo

                                if (Path.GetExtension(sfd.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                                {
                                    using (var package = new ExcelPackage(new FileInfo(sfd.FileName)))
                                    {
                                        // Verifica se a planilha já existe e a remove se for o caso.
                                        var existingWorksheet = package.Workbook.Worksheets["Tabela Completa"];
                                        if (existingWorksheet != null)
                                        {
                                            package.Workbook.Worksheets.Delete(existingWorksheet);
                                        }
                                        var worksheet = package.Workbook.Worksheets.Add("Tabela Completa"); // Adiciona a nova planilha
                                        worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                                        await package.SaveAsync();
                                    }
                                }
                                else
                                {
                                    await ExportToCsvAsync(dataTable, sfd.FileName);
                                }

                            }
                        }
                    }
                    lblStatus.Text = "Tabela exportada com sucesso!";
                    Log($"Tabela completa exportada para: {sfd.FileName}");
                    MessageBox.Show($"Tabela exportada com sucesso para:\n{sfd.FileName}", "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    lblStatus.Text = $"Erro ao exportar: {ex.Message}";
                    Log($"Erro ao exportar tabela completa: {ex.Message}");
                    MessageBox.Show($"Ocorreu um erro ao exportar a tabela: {ex.Message}", "Erro de Exportação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    btnExportFullTable.Enabled = true;
                }
            }
        }

        private async Task ExportToCsvAsync(DataTable dataTable, string filePath)
        {
            var sb = new System.Text.StringBuilder();

            // Cabeçalhos
            var columnNames = dataTable.Columns.Cast<DataColumn>().Select(column => EscapeCsvField(column.ColumnName));
            sb.AppendLine(string.Join(";", columnNames));

            // Linhas
            foreach (DataRow row in dataTable.Rows)
            {
                var fields = row.ItemArray.Select(field => EscapeCsvField(field?.ToString() ?? ""));
                sb.AppendLine(string.Join(";", fields));
            }

            await File.WriteAllTextAsync(filePath, sb.ToString(), System.Text.Encoding.UTF8);
        }

        private string EscapeCsvField(string field)
        {
            if (field.Contains(';') || field.Contains('"') || field.Contains('\n'))
            {
                // Coloca o campo entre aspas e duplica as aspas existentes dentro dele
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }


        private void UpdateCookies(string cookie)
        {
            var cookieValues = cookie.Split(';');
            foreach (var cookieValue in cookieValues)
            {
                var parts = cookieValue.Split('=');
                if (parts.Length == 2)
                {
                    _cookieContainer.Add(new Cookie(parts[0].Trim(), parts[1].Trim(), "/", "sgrc.datametrica.com.br"));
                }
            }
        }

        private async Task<(string?, string?)> ScrapeData(string idChamado, CancellationToken token)
        {
            var url = $"https://sgrc.datametrica.com.br/PCRJ_Web_Monitoramento/Popup/Popup.aspx?objeto=chamado&id={idChamado}";
            Log($"Acessando URL: {url}");
            var response = await _httpClient.GetAsync(url, token);

            var pageContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode || pageContent.Contains("Um erro inesperado aconteceu"))
            {
                Log($"[ERRO] Servidor retornou erro (Status: {response.StatusCode}). Pulando ID {idChamado}...");
                return (null, null);
            }

            if (!pageContent.Contains("Detalhamento do Chamado") && !pageContent.Contains("Endereço"))
            {
                throw new PermissionException($"Sessão expirada ou página inesperada para o ID {idChamado}.");
            }

            response.EnsureSuccessStatusCode();

            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(pageContent), token);
            Log($"Página HTML para o chamado {idChamado} lida com sucesso.");

            string? complemento = null;
            string? referencia = null;

            var rows = document.QuerySelectorAll("tr");
            foreach (var row in rows)
            {
                var cells = row.QuerySelectorAll("td");
                if (cells.Length >= 2)
                {
                    var label = cells[0].TextContent.Trim().ToLower();
                    var value = cells[1].TextContent.Trim();

                    if (label.Contains("complemento"))
                    {
                        complemento = value;
                    }
                    else if (label.Contains("referencia") || label.Contains("ponto de referencia"))
                    {
                        referencia = value;
                    }
                }
            }

            if (string.IsNullOrEmpty(complemento) || string.IsNullOrEmpty(referencia))
            {
                var fullText = document.Body?.TextContent.Replace("\n", "|");
                if (!string.IsNullOrEmpty(fullText))
                {
                    if (string.IsNullOrEmpty(complemento))
                    {
                        var match = Regex.Match(fullText, @"Complemento.*?\|(.*?)\|", RegexOptions.IgnoreCase);
                        if (match.Success && match.Groups[1].Value.Length < 150)
                        {
                            complemento = match.Groups[1].Value.Trim();
                        }
                    }

                    if (string.IsNullOrEmpty(referencia))
                    {
                        var match = Regex.Match(fullText, @"Referencia.*?\|(.*?)\|", RegexOptions.IgnoreCase);
                        if (match.Success && match.Groups[1].Value.Length < 150)
                        {
                            referencia = match.Groups[1].Value.Trim();
                        }
                    }
                }
            }

            complemento = string.IsNullOrWhiteSpace(complemento) ? "-" : complemento;
            referencia = string.IsNullOrWhiteSpace(referencia) ? "-" : referencia;

            Log($"Dados extraídos para o chamado {idChamado}.");
            return (complemento, referencia);
        }

        private string ShowInputDialog(string text, string caption, string defaultValue = "")
        {
            using (Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            })
            {
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right, Text = defaultValue };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK, Anchor = AnchorStyles.Top | AnchorStyles.Right };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

    }

    [Serializable]
    public class PermissionException : Exception
    {
        public PermissionException(string message) : base(message) { }
    }
}