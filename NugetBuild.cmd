@echo off

set /p apiKey=Enter API Key:%=%
.nuget\nuget setApiKey %apiKey%

echo.
echo.
.nuget\nuget pack LAN.Core.Eventing\LAN.Core.Eventing.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
echo.
echo.
@echo Finished Building: LAN.Core.Eventing
echo.
echo.
.nuget\nuget pack LAN.Core.Eventing.SignalR\LAN.Core.Eventing.SignalR.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
echo.
echo.
@echo Finished Building: LAN.Core.Eventing.SignalR
echo.
echo.

set /p eventingVersion=Enter DependencyInjection Package Version:%=%
.nuget\nuget push LAN.Core.Eventing.%eventingVersion%.nupkg
echo.
echo.
set /p eventingSignalrVersion=Enter Ninject Package Version:%=%
.nuget\nuget push LAN.Core.Eventing.SignalR.%eventingSignalrVersion%.nupkg

echo.