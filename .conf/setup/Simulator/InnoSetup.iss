#define AppName "Caretag Simulator"
#define AppFileName "RFIDAbstractionLayer.Simulator.exe"
#define AppVersion "1.6.0"

[Setup]
;Space needed 60 mb + 15% overhead
ExtraDiskSpaceRequired=69000000

#include "..\common\InnoSetup.Global.iss"
#include "..\common\InnoSetup.DatabaseConnection.iss"
#include "..\common\InnoSetup.StationName.iss"
#include "..\common\InnoSetup.Global.Events.iss"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)

; Finish with a single }
AppId={{998A269A-A529-4B0D-BB1D-D89240573333}
OutputBaseFilename=SimulatorInstaller

[Files]
Source: "..\..\..\Common\RFIDAbstractionLayer.Simulator\bin\Debug\net5.0-windows\*"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
