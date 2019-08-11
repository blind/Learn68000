@echo off
cd %2

if not exist \RelNEO\roms\neogeo.zip goto MissingRom

\Utils\Vasm\vasmm68k_mot_win32.exe %1 -chklabels -nocase -Fbin -m68000  -devpac -Dvasm=1  -L \BldNEO\Listing.txt -DBuildNEO=1 -o "\BuildNEO\cart.p"
rem -nocase


if not "%errorlevel%"=="0" goto Abandon

cd \BuildNEO

\Utils\byteswap \BuildNEO\cart.p 202-p1.p1
\Utils\pad 202-p1.p1 524288 25
copy 202-p1.p1 \RelNEO\roms\ChibiAkumasGame\

\Utils\MakeNeoGeoHash.exe "\RelNEO\hash\neogeo.xml.template" "\RelNEO\hash\neogeo.xml" "\RelNEO\roms\ChibiAkumasGame"

cd \Emu\mame0200b_32bit
mame neogeo ChibiAkumasGame -video gdi -skip_gameinfo
rem mame neogeo Grime -video gdi -skip_gameinfo


exit
:MissingRom
echo No Neogeo Rom found.
echo put a MAME neogeo.zip file in \RelNEO\roms and try again!
:Abandon
if "%3"=="nopause" exit
pause
