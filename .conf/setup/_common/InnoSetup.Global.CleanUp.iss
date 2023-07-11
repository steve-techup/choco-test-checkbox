[Code]
procedure RemoveUserJSons();
var
  filePath: string;
begin
  filePath := ExpandConstant('{app}\appsettings.user.json');
  if FileExists(filePath) then
  begin
    DeleteFile(filePath);
  end;
  
  filePath := ExpandConstant('{app}\appsettings.user.template.json');
  if FileExists(filePath) then
  begin
    DeleteFile(filePath);
  end;
end;

procedure PerformCleanUp();
begin
  RemoveUserJSons();
end;

