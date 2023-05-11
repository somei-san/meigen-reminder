@echo off

rem 文字コードSJISじゃないと失敗するよ

rem wait
echo "wait中"
timeout /t 30 > nul

rem 実行
cd C:\MyTools\名言リマインダー\名言リマインダー\bin\Release\net5.0-windows10.0.19041.0
start 名言リマインダー.exe