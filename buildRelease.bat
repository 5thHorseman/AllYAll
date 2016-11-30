﻿
@echo off

copy /Y "bin\Release\AllYAll.dll" "GameData\AllYAll\Plugins"
copy /Y AllYAll.version GameData\AllYAll
copy /Y ..\MiniAVC.dll GameData\AllYAll

set DEFHOMEDRIVE=d:
set DEFHOMEDIR=%DEFHOMEDRIVE%%HOMEPATH%
set HOMEDIR=
set HOMEDRIVE=%CD:~0,2%

set RELEASEDIR=d:\Users\jbb\release
set ZIP="c:\Program Files\7-zip\7z.exe"
echo Default homedir: %DEFHOMEDIR%

rem set /p HOMEDIR= "Enter Home directory, or <CR> for default: "

if "%HOMEDIR%" == "" (
set HOMEDIR=%DEFHOMEDIR%
) 
echo %HOMEDIR%

SET _test=%HOMEDIR:~1,1%
if "%_test%" == ":" (
set HOMEDRIVE=%HOMEDIR:~0,2%
)


type AllYAll.version
set /p VERSION= "Enter version: "


copy /y License.txt  GameData\AllYAll

copy /Y README.md GameData\AllYAll
 

set FILE="%RELEASEDIR%\AllYAll-%VERSION%.zip"
IF EXIST %FILE% del /F %FILE%
%ZIP% a -tzip %FILE% GameData
