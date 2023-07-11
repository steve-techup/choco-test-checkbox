# InjectGitVersion.ps1
#
# Set the version in the projects AssemblyInfo.cs file
#


# Get version info from Git. example 1.2.3-45-g6789abc
$gitVersion = git describe --tags --long --always;

try {
    # Parse Git version info into semantic pieces
    $gitVersion -match '((\d\.)+\d)(-.*)?-(\d+)-(\w+)';
    $gitTag = $Matches[1];
    $extra = $Matches[3];
    $gitCount = $Matches[4];
    $gitSHA1 = $Matches[5];
}
catch
{
    $gitTag = "0.0.0";
    $extra = "";
    $gitCount = 0;
    $gitSHA1 = $gitVersion;
}

# Define file variables
$assemblyFile = $args[0] + "\Properties\AssemblyInfo.cs";
$templateFile =  $args[0] + "\Properties\AssemblyInfo_Template.cs";

# Read template file, overwrite place holders with git version info
$newAssemblyContent = Get-Content $templateFile |
    %{$_ -replace '\$FILEVERSION\$', ($gitTag + "." + $gitCount) } |
    %{$_ -replace '\$INFOVERSION\$', ($gitTag + $extra + "." + $gitCount + "-" + $gitSHA1) };

# Write AssemblyInfo.cs file only if there are changes
If (-not (Test-Path $assemblyFile) -or ((Compare-Object (Get-Content $assemblyFile) $newAssemblyContent))) {
    echo "Injecting Git Version Info to AssemblyInfo.cs"
    $newAssemblyContent > $assemblyFile;       
}