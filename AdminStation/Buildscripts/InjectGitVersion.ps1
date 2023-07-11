# InjectGitVersion.ps1
#
# Set the version in the projects AssemblyInfo.cs file
#


# Get version info from Git. example 1.2.3-45-g6789abc
$gitVersion = git describe --tags --long --always;

try {
    # Parse Git version info into semantic pieces
    $gitVersion -match '^((\d+\.\d+\.\d+))-(?:(RC\d+)-)?(\d+)-(\w+[0-9a-f]+)$';
    $gitTag = $Matches[1];
    $rcVersion = $Matches[3];
    echo "Got rcVersion " $rcVersion;
    if($rcVersion -ne $null) {
        $rcVersion = "-" + $rcVersion;
    }
}
catch
{
    $gitTag = "0.0.0";
    $rcVersion = "";
}

# Define file variables
$assemblyFile = $args[0] + "\AssemblyInfo.cs";
$templateFile =  $args[0] + "\AssemblyInfo_Template.cs";

# Read template file, overwrite place holders with git version info
$newAssemblyContent = Get-Content $templateFile |
    %{$_ -replace '\$FILEVERSION\$', ($gitTag) } |
    %{$_ -replace '\$INFOVERSION\$', ($gitTag + $rcVersion) };

# Write AssemblyInfo.cs file only if there are changes
If (-not (Test-Path $assemblyFile) -or ((Compare-Object (Get-Content $assemblyFile) $newAssemblyContent))) {
    echo "Injecting Git Version Info to AssemblyInfo.cs"
    $newAssemblyContent > $assemblyFile;       
}