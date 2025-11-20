@echo off
title 1746 Extractor - Publish

echo Cleaning project...
dotnet clean

echo Publishing for distribution...
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true

echo.
echo Publish complete! The executable is in the 'bin\Release\net8.0-windows\win-x64\publish' folder.
pause