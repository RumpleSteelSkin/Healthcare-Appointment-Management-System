@echo off
setlocal

:: Variables
set "API_DIR=BackEnd\Healthcare Appointment Management System\src\projects\HAMS.Presentation"
set "REACT_DIR=FrontEnd\healthcare-appointment-management-system"
set "API_URL=http://localhost:5010/swagger"
set "REACT_URL=http://localhost:5173"
set "DOTNET_CMD=dotnet run"
set "NPM_CMD=npm run dev"
set "INSTALL_CMD=npm install"
set "INSTALL_LUCIDE=npm install lucide-react"
set "UPDATE_LUCIDE=npm update lucide-react"
set "API_INIT_TIMEOUT=5"
set "BROWSER_TIMEOUT=3"

:: Terminate previous instances
taskkill /IM "dotnet.exe" /F >nul 2>&1
taskkill /IM "node.exe" /F >nul 2>&1

:: Display menu
:menu
cd /d "%~dp0"
cls
echo ==================================
echo       HAMS Project Launcher
echo ==================================
echo [1] Start API and React
echo [2] Start API only
echo [3] Start React only
echo [4] Install required React modules
echo [5] Exit
echo ==================================
set /p choice=Enter your choice (1-5): 

if "%choice%"=="1" goto start_both
if "%choice%"=="2" goto start_api
if "%choice%"=="3" goto start_react
if "%choice%"=="4" goto install_modules
if "%choice%"=="5" goto exit_script

:: Invalid input, return to menu
echo Invalid choice! Please enter a number between 1 and 5.
pause
goto menu

:start_both
:: Start Web API
start cmd /k "cd /d %API_DIR% && %DOTNET_CMD%"

:: Wait for API to initialize
timeout /t %API_INIT_TIMEOUT% /nobreak >nul

:: Start React app
start cmd /k "cd /d %REACT_DIR% && %NPM_CMD%"

:: Open browser with API and React
timeout /t %BROWSER_TIMEOUT% /nobreak >nul
start "" "%API_URL%"
start "" "%REACT_URL%"
goto menu

:start_api
:: Start Web API
start cmd /k "cd /d %API_DIR% && %DOTNET_CMD%"

:: Open API in browser
timeout /t %BROWSER_TIMEOUT% /nobreak >nul
start "" "%API_URL%"
goto menu

:start_react
:: Start React app
start cmd /k "cd /d %REACT_DIR% && %NPM_CMD%"

:: Open React in browser
timeout /t %BROWSER_TIMEOUT% /nobreak >nul
start "" "%REACT_URL%"
goto menu

:install_modules
:: Install required React modules
echo Installing required React modules...
cd /d %REACT_DIR%
start cmd /k "%INSTALL_CMD%"
start cmd /k "%INSTALL_LUCIDE%"
start cmd /k "%UPDATE_LUCIDE%"
pause
goto menu

:exit_script
echo Exiting...
timeout /t 2 /nobreak >nul
exit
