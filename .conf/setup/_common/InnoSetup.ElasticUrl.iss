[CustomMessages]
ElasticUrlPage_Caption=Enter the Elastic URL
ElasticUrlPage_Description=Enter the Elastic URL.
ElasticUrlPage_lblElasticUrl_Caption0=Elastic URL

[Code]
var
  lblElasticUrl: TLabel;
  editElasticUrlField: TEdit;
  ElasticUrlPageINE: Boolean;

 var
  ElasticUrlPage: TWizardPage;

function ElasticUrlPage_NextButtonClick(Page: TWizardPage): Boolean;
begin
    Result := Length(editElasticUrlField.Text) > 0;
end;

Procedure UrlOnChange(Sender: TObject);
begin
  ElasticUrlPageINE := Length(editElasticUrlField.Text) > 0;
  WizardForm.NextButton.Enabled := ElasticUrlPageINE;
end;

function ElasticUrlPage_CreatePage(): Integer;
begin

  ElasticUrlPage := CreateCustomPage(
    wpLicense,
    ExpandConstant('{cm:ElasticUrlPage_Caption}'),
    ExpandConstant('{cm:ElasticUrlPage_Description}')
  );

  { lblServer }
  lblElasticUrl := TLabel.Create(ElasticUrlPage);
  with lblElasticUrl do
  begin
    Parent := ElasticUrlPage.Surface;
    Caption := ExpandConstant('{cm:ElasticUrlPage_lblElasticUrl_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(32);
    Width := ScaleX(68);
    Height := ScaleY(13);
    Enabled := True;
  end;

  { txtServer }
  editElasticUrlField := TEdit.Create(ElasticUrlPage);
  with editElasticUrlField do
  begin
    Parent := ElasticUrlPage.Surface;
    Left := ScaleX(112);
    Top := ScaleY(32);
    Width := ScaleX(273);
    Height := ScaleY(21);
    TabOrder := 0;
    Enabled := True;
    OnChange := @UrlOnChange;
    Text := ''; // *** TODO *** - Can't make it resolve AppName for use here
  end;

  with ElasticUrlPage do
  begin
    OnNextButtonClick := @ElasticUrlPage_NextButtonClick;
  end;

  Result := ElasticUrlPage.ID;
end;

procedure ElasticUrlPage_SaveApiUrlInSettings();
var
  filePath: string;
  ElasticUrlStr: string;
  AppSettingsFile : TStrings;
  JsonContent : string;

Begin
  filePath := ExpandConstant('{app}\appsettings.json');
  if FileExists(filePath) then
  begin
    if WizardSilent then
      ElasticUrlStr := ExpandConstant('{param:ElasticUrl|MISSING COMMAND LINE ARGUMENT}')
    else 
      ElasticUrlStr := editElasticUrlField.Text;


    AppSettingsFile := TStringList.Create;

    try

      try
        AppSettingsFile.LoadFromFile(filePath);
        JsonContent := AppSettingsFile.Text;

        { Only save if text has been changed. }
        if StringChangeEx(JsonContent, 'http://localhost:9200', ElasticUrlStr, True) > 0 then
        begin;
          AppSettingsFile.Text := JsonContent;
          AppSettingsFile.SaveToFile(filePath);
        end;
      except

      end;
    finally
      AppSettingsFile.Free;
  end;

    // ReplacePlainText(filePath, '"nodeUris": "http://localhost:9200"', ('"nodeUris": "' + ElasticUrlStr + '"'));  
  end;
end;
