#define AppName "Caretag Admin"
#define AppFileName "AdminStation.exe"
#define AppVersion GetVersionNumbersString("..\..\..\AdminStation\bin\Debug\AdminStation.exe")

[Setup]
;Space needed 224 Mb + 15% overhead
ExtraDiskSpaceRequired=258000000

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
AppId={{BCDF8155-5314-4DE4-B410-D399A974812F}
OutputBaseFilename=AdminStationInstaller

[Files]
Source: "..\..\..\AdminStation\bin\Debug\*"; Excludes: "appsettings.user.json"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
