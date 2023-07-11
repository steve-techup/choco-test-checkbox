#define AppName "Caretag Technical Station"
#define AppFileName "Technical_Station.exe"
#define AppVersion GetVersionNumbersString("..\..\..\TechnicalStation\bin\Debug\Technical_Station.exe")

[Setup]
;Space needed 214Mb + 15% overhead
ExtraDiskSpaceRequired=243000000

#include "..\common\InnoSetup.Global.CleanUp.iss"
#include "..\common\InnoSetup.JSONRoutines.iss"
#include "..\common\InnoSetup.Global.iss"
#include "..\common\InnoSetup.DatabaseConnection.iss"
#include "..\common\InnoSetup.StationName.iss"
#include "..\common\InnoSetup.Global.Events.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)

; Finish with a single }
AppId={{9AC446FA-4FD4-42F9-AF08-E088B6794BA4}
OutputBaseFilename=TechnicalStationInstaller

[Files]
Source: "..\..\..\TechnicalStation\bin\debug\*"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
