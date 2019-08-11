@echo off 


if not exist \RelNEO\roms\neogeo.zip goto MissingRom

cd %2
\Utils\Vasm\vasmZ80_OldStyle_win32.exe %1  -chklabels -nocase -Dvasm=1  -L \BldNEO\ListingZ80.txt -DBuildCPC=1 -Fbin -o "X:\RelNEO\roms\ChibiAkumasGame\202-m1.m1"
rem  -gbz80 -Fbin -o "\BldMSX\boot.bin" -L \RelGB\Listing.txt
if not "%errorlevel%"=="0" goto Abandon


cd \BuildNEO

copy 202-p1.p1 \RelNEO\roms\ChibiAkumasGame\

\Utils\MakeNeoGeoHash.exe "\RelNEO\hash\neogeo.xml.template" "\RelNEO\hash\neogeo.xml" "\RelNEO\roms\ChibiAkumasGame"

cd \Emu\mame0200b_32bit
mame neogeo ChibiAkumasGame -video gdi -skip_gameinfo


exit
:MissingRom
echo No Neogeo Rom found.
echo put a MAME neogeo.zip file in \RelNEO\roms and try again!
:Abandon
if "%3"=="nopause" exit
pause
