@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey%

.nuget\nuget pack LAN.Core.Eventing\LAN.Core.Eventing.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.Eventing

.nuget\nuget pack LAN.Core.Eventing.SignalR\LAN.Core.Eventing.SignalR.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
@echo Finished Building: LAN.Core.Eventing.SignalR

set /p eventingVersion=Enter Eventing Package Version:%=%
.nuget\nuget push LAN.Core.Eventing.%eventingVersion%.nupkg
set /p eventingSignalrVersion=Enter Eventing Signalr Package Version:%=%
.nuget\nuget push LAN.Core.Eventing.SignalR.%eventingSignalrVersion%.nupkg