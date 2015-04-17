@echo off
@echo !! Rebuild in Release mode prior to running !!
echo.
.nuget\nuget pack LAN.Core.Eventing\LAN.Core.Eventing.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
echo.
@echo Finished Building: LAN.Core.Eventing
echo.
@echo ---------------------------------------------------
.nuget\nuget pack LAN.Core.Eventing.SignalR\LAN.Core.Eventing.SignalR.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories
echo.
@echo Finished Building: LAN.Core.Eventing.SignalR
echo.
@echo ---------------------------------------------------
echo.
@echo !! Rebuild in Release mode prior to running !!
echo.
pause