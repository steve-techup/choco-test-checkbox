#define AppName "Caretag Checkbox Station"
#define AppFileName "CheckboxStation.exe"
#define AppVersion GetVersionNumbersString("..\..\..\CheckboxStation\bin\Debug\CheckboxStation.exe")

[Setup]
;Space needed 214Mb + 15% overhead
ExtraDiskSpaceRequired=243000000


#include "..\_common\InnoSetup.Global.CleanUp.iss"
#include "..\_common\InnoSetup.JSONRoutines.iss"
#include "..\_common\InnoSetup.Global.iss"
#include "..\_common\InnoSetup.StationName.iss"    
#include "..\_common\InnoSetup.ApiUrl.iss"
#include "..\_common\InnoSetup.ElasticUrl.iss"
#include "..\_common\InnoSetup.Global.Events.iss"


[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)

; Finish with a single }
AppId={{E7AD725B-2D77-434D-BC8E-94C3FAC6D605}
OutputBaseFilename=checkbox3-setup

[Files]
Source: "..\..\..\CheckboxStation\bin\Debug\*"; DestDir: "{app}"; Permissions: users-modify; Flags: ignoreversion recursesubdirs
