@echo off 
ver
echo Cpu Type: %PROCESSOR_ARCHITECTURE%
echo Running from... %cd%
echo.
if not exist \notepad++.bat goto ErrorDriveMapping

if not exist \Utils\Notepad++\notepad++.exe goto Errornotepad
if not exist \Utils\Vasm\vasm6502_oldstyle_win32.exe goto ErrorVasm

tasklist|find "notepad++.exe">nul
if %errorlevel%==0 goto AlreadyRunning

start "" \Utils\Notepad++\notepad++.exe
exit

:Errornotepad
echo Error: cannot find \Utils\Notepad++\notepad++.exe 
echo Did you extract the files correctly?
goto Error

:ErrorVasm
echo Error: cannot find \Utils\Vasm\6502_oldstyle_win32.exe
echo Did you extract the files correctly?
goto Error

:ErrorDriveMapping
echo Please check you're running from the virtual drive (usually Z:)
echo and run Notepad++.bat from that drive!
echo.
echo if you do not have the virtual drive, run the file Zdrive.bat (or similarly named)
goto Error

:Error
echo.
echo Sorry, there's something wrong with your setup, and the devtools won't work
echo if you need technical support please post on http://www.chibiakumas.com/forum
echo.
pause
exit

:AlreadyRunning
echo Another copy of Notepad++ is already running, please close it and try again.
pause
exit