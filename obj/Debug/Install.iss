; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "MySQL API CRUD Generator"
#define MyAppVersion "1.5"
#define MyAppPublisher "Multiverso Digital"
#define MyAppURL "http://www.multiversodigital.com.br/"
#define MyAppExeName "MyProg.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9D10E052-44BB-4DDE-B41C-76DBF45A7258}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=C:\vs2019\GeraNodeApi\obj\Debug\GeraNodeApi.csproj.FileListAbsolute.txt
InfoBeforeFile=C:\vs2019\GeraNodeApi\obj\Debug\GeraNodeApi.csproj.FileListAbsolute.txt
InfoAfterFile=C:\vs2019\GeraNodeApi\obj\Debug\GeraNodeApi.csproj.FileListAbsolute.txt
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputBaseFilename=mysetup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\2016\PRGs\Inno Setup 6\Examples\MyProg.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\vs2019\GeraNodeApi\obj\Debug\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
