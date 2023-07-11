[CustomMessages]
DBConnectPage_Caption=Connect to Caretag Database Server
DBConnectPage_Description=Enter the information required to connect to the database server
DBConnectPage_lblServer_Caption0=Server name:
DBConnectPage_lblAuthType_Caption0=Log on credentials
DBConnectPage_lblUser_Caption0=User name:
DBConnectPage_lblPassword_Caption0=Password:
DBConnectPage_lblDatabase_Caption0=Database:
DBConnectPage_chkSQLAuth_Caption0=Use SQL Server Authentication
DBConnectPage_chkWindowsAuth_Caption0=Use Windows Authentication

[Code]
const
  adCmdUnspecified = $FFFFFFFF;
  adCmdUnknown = $00000008;
  adCmdText = $00000001;
  adCmdTable = $00000002;
  adCmdStoredProc = $00000004;
  adCmdFile = $00000100;
  adCmdTableDirect = $00000200;
  adOptionUnspecified = $FFFFFFFF;
  adAsyncExecute = $00000010;
  adAsyncFetch = $00000020;
  adAsyncFetchNonBlocking = $00000040;
  adExecuteNoRecords = $00000080;
  adExecuteStream = $00000400;
  adExecuteRecord = $00000800;

var
  lblServer: TLabel;
  lblAuthType: TLabel;
  lblUser: TLabel;
  lblPassword: TLabel;
  lblDatabase: TLabel;
  chkSQLAuth: TRadioButton;
  txtServer: TEdit;
  chkWindowsAuth: TRadioButton;
  txtUsername: TEdit;
  txtPassword: TPasswordEdit;
  lstDatabase: TComboBox;
  bIsNextEnabled: Boolean;

 var
  DBConnectPage: TWizardPage;

Procedure HighlightCredentials;
var
 highlightColor: TColor;
Begin
  highlightColor := $F7C9FF;
  txtUserName.Color := highlightColor;
  txtPassword.Color := highlightColor;
  WizardForm.ActiveControl := txtUserName;
End;

{ enable/disable child text boxes & functions when text has been entered into Server textbox. Makes no sense to populate child items unless a value exists for server. }
Procedure ServerOnChange (Sender: TObject);
begin                            
  lstDatabase.Items.Clear;
  lstDatabase.Text := '';
  bIsNextEnabled := False;
  WizardForm.NextButton.Enabled := bIsNextEnabled;
  if Length(txtServer.Text) > 0 then
  begin
    lblAuthType.Enabled := True;
    lblDatabase.Enabled := True;
    lstDatabase.Enabled := True;
    chkWindowsAuth.Enabled := True;
    chkSQLAuth.Enabled := True;
  end
  else
  begin
    lblAuthType.Enabled := False;
    lblDatabase.Enabled := False;
    lstDatabase.Enabled := False; 
    chkWindowsAuth.Enabled := False;
    chkSQLAuth.Enabled := False;
  end
end;

{ enable/disable user/pass text boxes depending on selected auth type. A user/pass is only required for SQL Auth }
procedure AuthOnChange (Sender: TObject);
begin
  if chkSQLAuth.Checked then
  begin
    lblUser.Enabled := true;
    lblPassword.Enabled := true;
    txtUsername.Enabled := true;
    txtPassword.Enabled := true;
  end
  Else
  begin
    lblUser.Enabled := false;
    lblPassword.Enabled := false;
    txtUsername.Enabled := false;
    txtPassword.Enabled := false;
  end
end;

{ Enable next button once a database name has been entered. }
Procedure DatabaseOnChange (Sender: TObject);
begin
  if (Length(lstDatabase.Text) > 0) and (lstDatabase.Enabled) then
  begin
    bIsNextEnabled := True;
    WizardForm.NextButton.Enabled := bIsNextEnabled;  
  end
  else
  begin
    bIsNextEnabled := False;
    WizardForm.NextButton.Enabled := bIsNextEnabled;  
  end
end;

function DBConnectPage_GetConnectionString(): String;
var  
  connString: String;
begin
    connString := 
      'Provider=SQLOLEDB;' +                      { provider }
      'Data Source=' + txtServer.Text + ';' +     { server name }
      'Initial Catalog=' + lstDatabase.Text + ';' +   { database name }
      'Application Name=' + '{#AppName};';     
    
    if chkWindowsAuth.Checked then
      connString := connString +
      'Integrated Security=SSPI;'                 { Windows Authentication }
    else
      connString := connString +
      'User Id=' + txtUsername.Text + ';' +       { user name }
      'Password=' + txtPassword.Text + ';';       { password }

    Result := connString;
end;

{ DBConnectPage_GetJSONConnectionString }
function DBConnectPage_GetJSONConnectionString(): String;
var  
  connString: String;
  serverString : String;
begin
    connString := 
      'Data Source=' + txtServer.Text + ';' +     { Connect via an IP address or server name }
      'Initial Catalog=' + lstDatabase.Text + ';' +   { database name }
      'Application Name=' + '{#AppName};';     
    
    if chkWindowsAuth.Checked then
      connString := connString +
      'Integrated Security=True;'                 { Windows Authentication }
    else
      connString := connString +
      'User ID=' + txtUsername.Text + ';' +       { user name }
      'Password=' + txtPassword.Text + ';';       { password }

    Result := connString;
end;

{ Retrieve a list of databases accessible on the server with the credentials specified. }
{ This list is shown in the database dropdown list }
procedure RetrieveDatabaseList(Sender: TObject);
var  
  ADOCommand: Variant;
  ADORecordset: Variant;
  ADOConnection: Variant;  
  errorMsg: String;
  highlightColor: TColor;
begin
  lstDatabase.Items.Clear;
  try
    ADOConnection := CreateOleObject('ADODB.Connection');
    ADOConnection.ConnectionString := DBConnectPage_GetConnectionString();
    ADOConnection.Open;
    try
      ADOCommand := CreateOleObject('ADODB.Command');
      ADOCommand.ActiveConnection := ADOConnection;
      ADOCommand.CommandText := 'SELECT name FROM master.dbo.sysdatabases WHERE HAS_DBACCESS(name) = 1 ORDER BY name';
      ADOCommand.CommandType := adCmdText;
      ADORecordset := ADOCommand.Execute;
      while not ADORecordset.eof do 
      begin
       lstDatabase.Items.Add(ADORecordset.Fields(0));
       ADORecordset.MoveNext;
      end;
    finally
      ADOConnection.Close;
    end;
  except
    errorMsg := GetExceptionMessage;
    if (errorMsg = 'Microsoft OLE DB Provider for SQL Server: Invalid authorization specification') then 
    begin
      // Invalid credentials Exception
      HighlightCredentials;
      exit;
    end;
    MsgBox(errorMsg, mbError, MB_OK);
  end;
end;


{ DBConnectPage_NextButtonClick }
{ Try to connect to supplied database. We don't need to catch errors, nor close conn On Error because a failed connection is never opened. }
function DBConnectPage_NextButtonClick(Page: TWizardPage): Boolean;
var  
  ADOConnection: Variant;  
  ADOSuccessfullConnection : Boolean;
begin
    { create the ADO connection object }
    ADOSuccessfullConnection := False;
    ADOConnection := CreateOleObject('ADODB.Connection');
    ADOConnection.ConnectionString := DBConnectPage_GetConnectionString();
    try
      ADOConnection.Open;
      ADOSuccessfullConnection := True;
    finally
      ADOConnection.Close;
    end;

    Result := ADOSuccessfullConnection;
end;

{ DBConnectPage_CreatePage }
function DBConnectPage_CreatePage(PreviousPageId: Integer): Integer;
begin
  // Default IsNext available
  bIsNextEnabled := false;

  DBConnectPage := CreateCustomPage(
                    PreviousPageId,
                    ExpandConstant('{cm:DBConnectPage_Caption}'),
                    ExpandConstant('{cm:DBConnectPage_Description}')
  );

  { lblServer }
  lblServer := TLabel.Create(DBConnectPage);
  with lblServer do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_lblServer_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(32);
    Width := ScaleX(68);
    Height := ScaleY(13);
    Enabled := True;
  end;

  { txtServer }
  txtServer := TEdit.Create(DBConnectPage);
  with txtServer do
  begin
    Parent := DBConnectPage.Surface;
    Left := ScaleX(112);
    Top := ScaleY(32);
    Width := ScaleX(273);
    Height := ScaleY(21);
    TabOrder := 1;
    Enabled := True;
    OnChange := @ServerOnChange;
  end;

  { lblAuthType }
  lblAuthType := TLabel.Create(DBConnectPage);
  with lblAuthType do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_lblAuthType_Caption0}');
    Left := ScaleX(24);
    Top := ScaleY(72);
    Width := ScaleX(87);
    Height := ScaleY(13);
    Enabled := False;
  end;

  { chkWindowsAuth }
  chkWindowsAuth := TRadioButton.Create(DBConnectPage);
  with chkWindowsAuth do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_chkWindowsAuth_Caption0}');
    Left := ScaleX(32);
    Top := ScaleY(88);
    Width := ScaleX(177);
    Height := ScaleY(17);
    Checked := True;
    TabOrder := 2;
    TabStop := True;
    OnClick := @AuthOnChange;
    Enabled := False;
  end;

  { chkSQLAuth }
  chkSQLAuth := TRadioButton.Create(DBConnectPage);
  with chkSQLAuth do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_chkSQLAuth_Caption0}');
    Left := ScaleX(32);
    Top := ScaleY(108);
    Width := ScaleX(185);
    Height := ScaleY(17);
    TabOrder := 3;
    OnClick := @AuthOnChange;
    Enabled := False;
  end;

  { lblUser }
  lblUser := TLabel.Create(DBConnectPage);
  with lblUser do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_lblUser_Caption0}');
    Left := ScaleX(56);
    Top := ScaleY(128);
    Width := ScaleX(58);
    Height := ScaleY(13);
    Enabled := False;
  end;

  { lblPassword }
  lblPassword := TLabel.Create(DBConnectPage);
  with lblPassword do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_lblPassword_Caption0}');
    Left := ScaleX(56);
    Top := ScaleY(152);
    Width := ScaleX(53);
    Height := ScaleY(13);
    Enabled := False;
  end;

  { txtUsername }
  txtUsername := TEdit.Create(DBConnectPage);
  with txtUsername do
  begin
    Parent := DBConnectPage.Surface;
    Left := ScaleX(120);
    Top := ScaleY(128);
    Width := ScaleX(241);
    Height := ScaleY(21);
    Enabled := False;
    TabOrder := 4;
  end;

  { txtPassword }
  txtPassword := TPasswordEdit.Create(DBConnectPage);
  with txtPassword do
  begin
    Parent := DBConnectPage.Surface;
    Left := ScaleX(120);
    Top := ScaleY(152);
    Width := ScaleX(241);
    Height := ScaleY(21);
    Enabled := False;
    TabOrder := 5;
  end;

   { lblDatabase }
  lblDatabase := TLabel.Create(DBConnectPage);
  with lblDatabase do
  begin
    Parent := DBConnectPage.Surface;
    Caption := ExpandConstant('{cm:DBConnectPage_lblDatabase_Caption0}');
    Left := ScaleX(56);
    Top := ScaleY(192);
    Width := ScaleX(53);
    Height := ScaleY(13);
    Enabled := False;
  end;

  { lstDatabase }
  lstDatabase := TComboBox.Create(DBConnectPage);
  with lstDatabase do
  begin
    Parent := DBConnectPage.Surface;
    Left := ScaleX(120);
    Top := ScaleY(192);
    Width := ScaleX(145);
    Height := ScaleY(21);
    Enabled := False;
    TabOrder := 6;    
    OnDropDown:= @RetrieveDatabaseList;
    OnChange:= @DatabaseOnChange;
  end;

  with DBConnectPage do
  begin
    OnNextButtonClick := @DBConnectPage_NextButtonClick;
  end;

  Result := DBConnectPage.ID;
end;

//
// Save the app settings, the connection string
//
procedure DBConnectPage_SaveDatabaseSettings();
var
  filePath: string;
  connectStr: string;
Begin
  filePath := ExpandConstant('{app}\appsettings.json');
  if FileExists(filePath) then
  begin
    if WizardSilent then
      connectStr := ExpandConstant('{param:connectStr|Missing commandline argument!!!}')
    else
      connectStr := DBConnectPage_GetJSONConnectionString();
    ReplaceJSONValue(filePath, 'ConnectionStrings.SQLServer', connectStr);
  end;
end;

//
// Read a SQL file and split the text using 'GO' keyword as delimiters
//
function LoadScriptFromFile(const FileName: string; out CommandList: TStrings): Integer;
var
  I: Integer;
  SQLCommand: string;
  ScriptFile: TStringList;
begin
  Result := 0;
  ScriptFile := TStringList.Create;
  try
    SQLCommand := '';
    ScriptFile.LoadFromFile(FileName);

    for I := 0 to ScriptFile.Count - 1 do
    begin
      if Pos('go', LowerCase(Trim(ScriptFile[I]))) = 1 then
      begin
        Result := Result + 1;
        CommandList.Add(SQLCommand);
        SQLCommand := '';
      end
      else
        SQLCommand := SQLCommand + ScriptFile[I] + #13#10;
    end;

    //If there is no 'GO' syntax present int the file 
    if SQLCommand <> '' then
    begin
      CommandList.Add(SQLCommand);
      Result:= Result + 1;
    end;
  finally
    ScriptFile.Free;
  end;
end;

function ParseFilenameNumber(const FileName : string) : Integer;
var 
  NumberStr : string;      
begin 
  NumberStr := Copy(FileName, Length(FileName)-6, 3);
  Result := StrToInt(NumberStr);
end;

//
// Opens the SQL file (FileName), and execute the SQL commands (from CommandList)
//
procedure RunScript(const FileName: string; const MigrationMax: Integer);
var
  I: Integer;
  CommandList: TStrings;
  ADOConnection: Variant;  
  ADOCommand: Variant;
  ADORecordset: Variant;
  MigrationNumber : Integer;
begin
  ADOConnection := CreateOleObject('ADODB.Connection');
  ADOConnection.ConnectionString := DBConnectPage_GetConnectionString();

  CommandList := TStringList.Create;
  try
    ADOConnection.Open;
    ADOCommand := CreateOleObject('ADODB.Command');
    ADOCommand.ActiveConnection := ADOConnection;

    MigrationNumber := ParseFilenameNumber(FileName);

    if (MigrationNumber > MigrationMax) and (LoadScriptFromFile(FileName, CommandList) > 0) then
      for I := 0 to CommandList.Count - 1 do
      begin
        if Length(CommandList[I]) = 0 then begin
          continue;
        end;
        ADOCommand.CommandText := CommandList[I];
        Log(CommandList[I]);
        ADOCommand.Execute(NULL, NULL, adCmdText or adExecuteNoRecords);
      end;

    ADOCommand.CommandText := 'INSERT INTO Migrations (MigrationNumberApplied) VALUES (' + IntToStr(MigrationNumber) + ')';
    ADOCommand.Execute(NULL, NULL, adCmdText or adExecuteNoRecords);
  finally
    ADOConnection.Close;
    CommandList.Free;
  end;
end;

function GetMigrationMax() : Integer;
var
  ADOConnection: Variant;  
  ADOCommand: Variant;
  ADORecordset: Variant;
begin
  ADOConnection := CreateOleObject('ADODB.Connection');
  ADOConnection.ConnectionString := DBConnectPage_GetConnectionString();

  try
    ADOConnection.Open;
    ADOCommand := CreateOleObject('ADODB.Command');
    ADOCommand.ActiveConnection := ADOConnection;

    //Get max migration applied
    ADOCommand.CommandText := 'if exists (select * from sysobjects where name=''Migrations'' and xtype=''U'') SELECT COALESCE(max(MigrationNumberApplied),0) FROM dbo.Migrations; else select 0;'
    ADOCommand.CommandType := adCmdText;
    ADORecordset := ADOCommand.Execute;
    Result := StrToInt(ADORecordset.Fields(0));
  finally
    ADOConnection.Close;
  end;
end;

procedure ListFiles(const Directory: string; Files: TStrings);
var
  FindRec: TFindRec;
  Path : String;
  BasePath : String;
begin
  Files.Clear;
  BasePath := ExpandConstant(Directory);
  Path := ExpandConstant(Directory + '*');
  if FindFirst(Path, FindRec) then
  try
    repeat
      if FindRec.Attributes and FILE_ATTRIBUTE_DIRECTORY = 0 then
        Files.Add(BasePath + FindRec.Name);
    until
      not FindNext(FindRec);
  finally
    FindClose(FindRec);
  end;
end;

procedure Run_Database_Changes();
var
  Files : TStrings;
  I : Integer;
Begin
  Files := TStringList.Create;
  ListFiles('{app}\updates\', Files);
  Log(IntToStr(Files.Count));


  for I := 0 to Files.Count - 1 do
  begin                                    
    RunScript(Files[I], GetMigrationMax());
  end;
end;
