# Caretag
The Caretag legacy system. 

## Structure
Common libraries are stored under /Common and the applications are in the root and named XXXStation. 

## Releases
Releases follow the versioning scheme 'Major.Minor.Bugfix' for actual releases and 'Major.Minor.Bugfix-RCNN' for release candidate NN. To create the release just push a tag with the format and a release is automatically created. 

### Installer parameters
The installer is made with InnoSetup and is packages as a Chocolatey package as well. 

#### Installing with InnoSetup
* For a regular install, just run the .exe file. 
* For a silent install (command line), run: `[InstallerName].exe /stationName=[station name] /connectStr=[SQL Server Connection String]`

#### Installing with Chocolatey
* To install with chocolatey, first chocolatey needs to be configured and installed: 

##### Install chocolatey:
```
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

##### Configure:
```
choco feature enable -n useRememberedArgumentsForUpgrades
choco feature enable -n allowGlobalConfirmation
choco source add -n="Caretag Feedz.io" -s=https://f.feedz.io/caretag/caretag-classic/nuget -u="Caretag Shared" -p="T-rdLvDCnWokJRncHxIkTk7mcmTXNkbmRZCY"
```

##### Installing the Caretag applications: 
```
choco install [app name] --params "'/stationName:[Station Name] /connectStr:[Connection String]'"
```
[app name] is one of the following: 
- technical-station
- admin-station
- packing-station
- checkbox

##### Upgrading the Caretag applications: 
When upgrading you should not need to specify parameters again, as they are automatically remembered by chocolatey, so to upgrade just type:
```
choco upgrade [app name]
```

## Database Migrations  
  
In order to use code-based migration, you need to execute the following commands in the *Package Manager Console* in *Visual Studio*:
  
* `Add-Migration` Creates a new migration class;
* `Update-Database` Executes the last migration file created by the  `Add-Migration`  command and applies changes to the database schema.

To use `Add-Migration` or `Update-Database` for your migrations please add the following flags to your command:

* `-ProjectName Main`
* `-ConnectionProviderName "System.Data.SqlClient"`
* `-ConnectionString "{your_connection_string}"` 
  
For example, to add a new migration from the root folder:  
  
`Add-Migration Initial -ProjectName Main -ConnectionString ""{your_connection_string}" -ConnectionProviderName "System.Data.SqlClient"`  

Or update database to latest migrations:
`Update-Database -ProjectName Main -ConnectionString "{your_connection_string}" -ConnectionProviderName "System.Data.SqlClient"`
  
More detail [here](https://www.entityframeworktutorial.net/code-first/code-based-migration-in-code-first.aspx)

