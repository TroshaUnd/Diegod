; Instalador de Diegod (Inno Setup 6). Requiere haber ejecutado antes la publicacion:
;   dotnet publish Diegod.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -o publicar/win-x64
#define AppName "Diegod"
#define AppVersion "1.0.0"
#define AppExe "Diegod.exe"

[Setup]
AppId={{6F0C3B52-4D7E-4C0B-9A53-7D1E2B8C41A9}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher=TroshaUnd
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir=salida
OutputBaseFilename=Diegod-Setup
SetupIconFile=..\Captura-de-pantalla-2025-09-01-183211.ico
UninstallDisplayIcon={app}\{#AppExe}
Compression=lzma2
SolidCompression=yes
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequiredOverridesAllowed=dialog
WizardStyle=modern

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"

[Files]
Source: "..\publicar\win-x64\{#AppExe}"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExe}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExe}"; Description: "{cm:LaunchProgram,{#AppName}}"; Flags: nowait postinstall skipifsilent

; Los datos viven en %LocalAppData%\Diegod\diegod.db y NO se borran al desinstalar.
