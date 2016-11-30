
set H=R:\KSP_1.1.4_dev
echo %H%

copy /Y "bin\Debug\AllYAll.dll" "GameData\AllYAll\Plugins"
copy /Y AllYAll.version GameData\AllYAll

cd GameData
mkdir "%H%\GameData\AllYAll"
xcopy /y /s AllYAll "%H%\GameData\AllYAll"
