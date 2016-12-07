
set H=D:\ksp_current\
echo %H%

copy /Y "bin\Debug\AllYAll.dll" "GameData\AllYAll\Plugins"
copy /Y AllYAll.version GameData\AllYAll

cd GameData
mkdir "%H%\GameData\AllYAll"
xcopy /y /s AllYAll "%H%\GameData\AllYAll"
