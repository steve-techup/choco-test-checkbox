#define AppName "Caretag Service Station"
#define AppFileName "Service_Station.exe"
#define AppVersion GetVersionNumbersString("..\..\..\ServiceStation\bin\Debug\Service_Station.exe")

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
AppId={{C8E8FDAB-409F-4281-98FA-6E8B65B9ED7A}
OutputBaseFilename=ServiceInstaller

[Files]
Source: "..\..\..\ServiceStation\bin\Debug\*"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
