# Genera el .exe, la version portable y (si Inno Setup esta instalado) el instalador.
# Uso (PowerShell, desde esta carpeta):  .\publicar.ps1
$ErrorActionPreference = "Stop"

dotnet publish Diegod.csproj -c Release -r win-x64 --self-contained true `
    -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true `
    -p:EnableCompressionInSingleFile=true -o publicar/win-x64

New-Item -ItemType Directory -Force publicar/portable | Out-Null
Copy-Item publicar/win-x64/Diegod.exe publicar/portable/ -Force
New-Item -ItemType File -Force publicar/portable/Diegod.portable | Out-Null
Compress-Archive -Path publicar/portable/* -DestinationPath publicar/Diegod-portable-win-x64.zip -Force

$iscc = Join-Path ${env:ProgramFiles(x86)} "Inno Setup 6\ISCC.exe"
if (Test-Path $iscc) {
    & $iscc "instalador\Diegod.iss"
    Write-Host "Instalador: instalador\salida\Diegod-Setup.exe"
} else {
    Write-Host "Inno Setup 6 no esta instalado: se omite el instalador (https://jrsoftware.org/isinfo.php)."
}
Write-Host "Ejecutable: publicar\win-x64\Diegod.exe"
Write-Host "Portable  : publicar\Diegod-portable-win-x64.zip"
