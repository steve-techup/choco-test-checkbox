[Code]
function SetTimer(hWnd, nIDEvent, uElapse, lpTimerFunc: LongWord): LongWord;
  external 'SetTimer@User32.dll stdcall';
function KillTimer(hWnd, nIDEvent: LongWord): LongWord;
  external 'KillTimer@User32.dll stdcall';

var
  SubmitPageTimer: LongWord;

procedure KillSubmitPageTimer;
begin
  KillTimer(0, SubmitPageTimer);
  SubmitPageTimer := 0;
end;  

procedure SubmitPageProc(
  H: LongWord; Msg: LongWord; IdEvent: LongWord; Time: LongWord);
begin
  WizardForm.NextButton.OnClick(WizardForm.NextButton);
  KillSubmitPageTimer;
end;

procedure CurPageChanged(CurPageID: Integer);
begin
  
  // Set initial status of next button. 
  // Should be disabled when page is first loaded, but should be enabled if user clicked back.
  if CurPageID = DBConnectPage.ID then
    WizardForm.NextButton.Enabled := bIsNextEnabled; 
  if CurPageID = StationNamePage.ID then
    WizardForm.NextButton.Enabled := StationNamePageINE; 
  if WizardSilent then 
  begin
    if CurPageID = wpReady then
      begin
        SubmitPageTimer := SetTimer(0, 0, 100, CreateCallback(@SubmitPageProc));
      end
    else
      begin
        if SubmitPageTimer <> 0 then
        begin
          KillSubmitPageTimer;
        end;
      end;
  end;
end;

function ShouldSkipPage(PageID: Integer): Boolean;
begin
  if WizardSilent then
    Result := True
  else 
    Result := False;
end;


// The preinstall step seems like the best time to do the actual install. 
// The problem is that this is not a traditional install. Nothing is copied to the users' pc
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if CurStep=ssPostInstall then
  begin
    //Run_Database_Changes();
    DBConnectPage_SaveDatabaseSettings();
    StationNamePage_SaveStationNameInSettings();
    PerformCleanUp();
  end;
end;

procedure InitializeWizard();
var
 DBConnectPageID: Integer;
 StationNamePageID: Integer;

begin
  DBConnectPageID := DBConnectPage_CreatePage(wpLicense);
  StationNamePageID := StationNamePage_CreatePage(DBConnectPageID);
end;

