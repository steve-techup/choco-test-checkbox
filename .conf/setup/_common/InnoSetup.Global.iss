#define AppPublisher "Caretag"
#define AppURL "https://www.caretag.eu"
#define AppConnectionString "__ Database connection must be overwritten in appsettings.user.json or set from installer __"

[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL={#AppURL}
AppSupportURL={#AppURL}
AppUpdatesURL={#AppURL}
DefaultDirName={sd}\Caretag\{#AppName}
DefaultGroupName={#AppPublisher}
OutputDir=../output
SolidCompression=yes
PrivilegesRequired=Admin
DisableWelcomePage=no
LicenseFile=../common/InnoSetup.License.txt
WizardImageFile=../common/InnoSetup.WizardImage.bmp
SetupIconFile=../common/InnoSetup.Icon.ico
Compression=lzma2/ultra
InternalCompressLevel=ultra
RestartIfNeededByRun=False
AllowUNCPath=False
AllowNoIcons=yes
;Prevent installer from being run multiple times in parallel
SetupMutex=SetupMutex{#SetupSetting("AppId")}
DisableDirPage=no

[CustomMessages]
LaunchProgram=Start Caretag application after finishing installation

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppFileName}"; WorkingDir: "{app}"
Name: "{group}\Uninstall {#AppName}"; Filename: "{app}\unins000.exe"; WorkingDir: "{app}"
Name: "{userdesktop}\{#AppName}"; Filename: "{app}\{#AppFileName}"; WorkingDir: "{app}"

[Run]
Filename: "{app}\{#AppFileName}"; Description: {cm:LaunchProgram,{#AppName}}; Flags: nowait postinstall skipifsilent

;[Languages]
;Name: "english"; MessagesFile: "compiler:Default.isl"
;Name: "brazilianportuguese"; MessagesFile: "compiler:Languages\BrazilianPortuguese.isl"
;Name: "catalan"; MessagesFile: "compiler:Languages\Catalan.isl"
;Name: "corsican"; MessagesFile: "compiler:Languages\Corsican.isl"
;Name: "czech"; MessagesFile: "compiler:Languages\Czech.isl"
;Name: "danish"; MessagesFile: "compiler:Languages\Danish.isl"
;Name: "dutch"; MessagesFile: "compiler:Languages\Dutch.isl"
;Name: "finnish"; MessagesFile: "compiler:Languages\Finnish.isl"
;Name: "french"; MessagesFile: "compiler:Languages\French.isl"
;Name: "german"; MessagesFile: "compiler:Languages\German.isl"
;Name: "hebrew"; MessagesFile: "compiler:Languages\Hebrew.isl"
;Name: "italian"; MessagesFile: "compiler:Languages\Italian.isl"
;Name: "japanese"; MessagesFile: "compiler:Languages\Japanese.isl"
;Name: "norwegian"; MessagesFile: "compiler:Languages\Norwegian.isl"
;Name: "polish"; MessagesFile: "compiler:Languages\Polish.isl"
;Name: "portuguese"; MessagesFile: "compiler:Languages\Portuguese.isl"
;Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"
;Name: "slovenian"; MessagesFile: "compiler:Languages\Slovenian.isl"
;Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"
;Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"
;Name: "ukrainian"; MessagesFile: "compiler:Languages\Ukrainian.isl"

[Code]
{ Used to generate error code by sql script errors }

procedure ExitProcess(exitCode:integer);
  external 'ExitProcess@kernel32.dll stdcall';
