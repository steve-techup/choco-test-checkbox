[CustomMessages]
ApiUrlPage_Caption=Enter API URL
ApiUrlPage_Description=Enter the API URL.
ApiUrlPage_lblApiUrl_Caption0=API URL

[Code]
var
  lblApiUrl: TLabel;
  editApiUrlField: TEdit;
  ApiUrlPageINE: Boolean;

 var
  ApiUrlPage: TWizardPage;

function ApiUrlPage_NextButtonClick(Page: TWizardPage): Boolean;
begin
    Result := Length(editApiUrlField.Text) > 0;
end;

Procedure ApiUrlOnChange(Sender: TObject);
begin
  ApiUrlPageINE := Length(editApiUrlField.Text) > 0;
  WizardForm.NextButton.Enabled := ApiUrlPageINE;
end;

function ApiUrlPage_CreatePage(): Integer;
begin

  ApiUrlPage := CreateCustomPage(
    wpLicense,
    ExpandConstant('{cm:ApiUrlPage_Caption}'),
    ExpandConstant('{cm:ApiUrlPage_Description}')
  );

  { lblServer }
  lblApiUrl := TLabel.Create(ApiUrlPage);
  with lblApiUrl do
  begin
    Parent := ApiUrlPage.Surface;
    Caption := ExpandConstant('{cm:ApiUrlPage_lblApiUrl_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(32);
    Width := ScaleX(68);
    Height := ScaleY(13);
    Enabled := True;
  end;

  { txtServer }
  editApiUrlField := TEdit.Create(ApiUrlPage);
  with editApiUrlField do
  begin
    Parent := ApiUrlPage.Surface;
    Left := ScaleX(112);
    Top := ScaleY(32);
    Width := ScaleX(273);
    Height := ScaleY(21);
    TabOrder := 0;
    Enabled := True;
    OnChange := @ApiUrlOnChange;
    Text := ''; // *** TODO *** - Can't make it resolve AppName for use here
  end;

  with ApiUrlPage do
  begin
    OnNextButtonClick := @ApiUrlPage_NextButtonClick;
  end;

  Result := ApiUrlPage.ID;
end;

procedure ApiUrlPage_SaveApiUrlInSettings();
var
  filePath: string;
  ApiUrlStr: string;
Begin
  filePath := ExpandConstant('{app}\appsettings.json');
  if FileExists(filePath) then
  begin
    if WizardSilent then
      ApiUrlStr := ExpandConstant('{param:ApiUrl|MISSING COMMAND LINE ARGUMENT}')
    else 
      ApiUrlStr := editApiUrlField.Text;
    ReplaceJSONValue(filePath, 'ApiUrl', ApiUrlStr);
  end;
end;
