[Code]
function GetUninstallString: string;
var
  sUnInstPath: string;
  sUnInstallString: String;
begin
  Result := '';
  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppId")}_is1');
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;

function IsUpgrade: Boolean;
begin
  Result := (GetUninstallString() <> '');
end;

function InitializeSetup: Boolean;
var
  V: Integer;
  iResultCode: Integer;
  sUnInstallString: string;
begin
  Result := True; { in case when no previous version is found }
  if RegValueExists(HKEY_LOCAL_MACHINE,'Software\Microsoft\Windows\CurrentVersion\Uninstall\{#emit SetupSetting("AppId")}_is1', 'UninstallString') then  
  begin
    V := MsgBox(ExpandConstant('An older version of app was detected. Do you want to uninstall it?'), mbInformation, MB_YESNO); 
    if V = IDYES then
    begin
      sUnInstallString := GetUninstallString();
      sUnInstallString :=  RemoveQuotes(sUnInstallString);
      Exec(ExpandConstant(sUnInstallString), '', '', SW_SHOW, ewWaitUntilTerminated, iResultCode);
      Result := True; { if you want to proceed after uninstall }
      { Exit; //if you want to quit after uninstall }
    end
  end;
end;
