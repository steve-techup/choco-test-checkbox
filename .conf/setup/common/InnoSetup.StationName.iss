[CustomMessages]
StationNamePage_Caption=Select Station Name
StationNamePage_Description=Enter a unique name for this station.
StationNamePage_lblName_Caption0=Station Name

[Code]
var
  lblName: TLabel;
  editName: TEdit;
  StationNamePageINE: Boolean;

 var
  StationNamePage: TWizardPage;

function StationNamePage_NextButtonClick(Page: TWizardPage): Boolean;
begin
    Result := Length(editName.Text) > 0;
end;

Procedure NameOnChange(Sender: TObject);
begin
  StationNamePageINE := Length(editName.Text) > 0;
  WizardForm.NextButton.Enabled := StationNamePageINE;
end;

function StationNamePage_CreatePage(PreviousPageId: Integer): Integer;
begin

  StationNamePage := CreateCustomPage(
    PreviousPageId,
    ExpandConstant('{cm:StationNamePage_Caption}'),
    ExpandConstant('{cm:StationNamePage_Description}')
  );

  { lblServer }
  lblName := TLabel.Create(StationNamePage);
  with lblName do
  begin
    Parent := StationNamePage.Surface;
    Caption := ExpandConstant('{cm:StationNamePage_lblName_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(32);
    Width := ScaleX(68);
    Height := ScaleY(13);
    Enabled := True;
  end;

  { txtServer }
  editName := TEdit.Create(StationNamePage);
  with editName do
  begin
    Parent := StationNamePage.Surface;
    Left := ScaleX(112);
    Top := ScaleY(32);
    Width := ScaleX(273);
    Height := ScaleY(21);
    TabOrder := 0;
    Enabled := True;
    OnChange := @NameOnChange;
    Text := ''; // *** TODO *** - Can't make it resolve AppName for use here
  end;

  with StationNamePage do
  begin
    OnNextButtonClick := @StationNamePage_NextButtonClick;
  end;

  Result := StationNamePage.ID;
end;

procedure StationNamePage_SaveStationNameInSettings();
var
  filePath: string;
  stationNameStr: string;
Begin
  filePath := ExpandConstant('{app}\appsettings.json');
  if FileExists(filePath) then
  begin
    if WizardSilent then
      stationNameStr := ExpandConstant('{param:stationName|MISSING COMMAND LINE ARGUMENT}')
    else 
      stationNameStr := editName.Text;
    ReplaceJSONValue(filePath, 'StationUniqueID', stationNameStr);
  end;
end;
