[CustomMessages]
StationIDPage_Caption=Select Station ID
StationIDPage_Description=Enter a unique ID for this station.
StationIDPage_lblName_Caption0=Station ID

[Code]
var
  lblName: TLabel;
  editIDField: TEdit;
  StationIDPageINE: Boolean;

 var
  StationIDPage: TWizardPage;

function StationIDPage_NextButtonClick(Page: TWizardPage): Boolean;
begin
    Result := Length(editIDField.Text) > 0;
end;

Procedure NameOnChange(Sender: TObject);
begin
  StationIDPageINE := Length(editIDField.Text) > 0;
  WizardForm.NextButton.Enabled := StationIDPageINE;
end;

function StationIDPage_CreatePage(): Integer;
begin

  StationIDPage := CreateCustomPage(
    wpLicense,
    ExpandConstant('{cm:StationIDPage_Caption}'),
    ExpandConstant('{cm:StationIDPage_Description}')
  );

  { lblServer }
  lblName := TLabel.Create(StationIDPage);
  with lblName do
  begin
    Parent := StationIDPage.Surface;
    Caption := ExpandConstant('{cm:StationIDPage_lblName_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(32);
    Width := ScaleX(68);
    Height := ScaleY(13);
    Enabled := True;
  end;

  { txtServer }
  editIDField := TEdit.Create(StationIDPage);
  with editIDField do
  begin
    Parent := StationIDPage.Surface;
    Left := ScaleX(112);
    Top := ScaleY(32);
    Width := ScaleX(273);
    Height := ScaleY(21);
    TabOrder := 0;
    Enabled := True;
    OnChange := @NameOnChange;
    Text := ''; // *** TODO *** - Can't make it resolve AppName for use here
  end;

  with StationIDPage do
  begin
    OnNextButtonClick := @StationIDPage_NextButtonClick;
  end;

  Result := StationIDPage.ID;
end;

procedure StationIDPage_SaveStationIDInSettings();
var
  filePath: string;
  StationIDStr: string;
Begin
  filePath := ExpandConstant('{app}\appsettings.json');
  if FileExists(filePath) then
  begin
    if WizardSilent then
      StationIDStr := ExpandConstant('{param:stationName|MISSING COMMAND LINE ARGUMENT}')
    else 
      StationIDStr := editIDField.Text;
    ReplaceJSONValue(filePath, 'AppData.AppInstanceId', StationIDStr);
  end;
end;
