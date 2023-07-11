#define AppName "Caretag Packing Station"
#define AppFileName "Packing_Station_Big.exe"
#define AppVersion GetVersionNumbersString("..\..\..\PackingStation\bin\Debug\Packing_Station_Big.exe")

[Setup]
;Space needed 154 mb + 15% overhead
ExtraDiskSpaceRequired=177000000

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
AppId={{0E123499-ECC1-4C85-8777-D6874BC87A02}
OutputBaseFilename=PackingStationInstaller

[Files]
Source: "..\..\..\PackingStation\bin\Debug\*"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs