[Files]
Source: "..\common\JSONRoutines.dll"; Flags: dontcopy
Source: "..\common\System.Collections.Immutable.dll"; Flags: dontcopy

[code]
procedure ReplaceJSONValue(filename, JSONPath, Key : string);
  external 'ReplaceJSONValue@files:JSONRoutines.dll stdcall';