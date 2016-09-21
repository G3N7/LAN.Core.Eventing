@ECHO off
Setlocal EnableDelayedExpansion

SET /p apiKey=Enter API Key: %=%
.nuget\nuget setApiKey !apiKey!

SET /p deployEventing=Would you like to deploy the Core Project? (y/n) %=%
IF (!deployEventing!) EQU (y) (
	.nuget\nuget pack LAN.Core.Eventing\LAN.Core.Eventing.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
	@ECHO Finished Building: LAN.Core.Eventing

	SET /p eventingVersion=Enter Eventing Package Version? %=%
	@ECHO Publishing LAN.Core.Eventing.!eventingVersion!.nupkg
	.nuget\nuget push LAN.Core.Eventing.!eventingVersion!.nupkg
)

SET /p deploySignalR=Would you like to deploy the SignalR Project? (y/n) %=%
IF (!deploySignalR!) EQU (y) (
	.nuget\nuget pack LAN.Core.Eventing.SignalR\LAN.Core.Eventing.SignalR.csproj -IncludeReferencedProjects -ExcludeEmptyDirectories -Build -Symbols -Properties Configuration=Release
	@ECHO Finished Building: LAN.Core.Eventing.SignalR

	SET /p eventingSignalrVersion=Enter Eventing SignalR Package Version? %=%
	@ECHO Publishing LAN.Core.Eventing.SignalR.!eventingSignalrVersion!.nupkg
	.nuget\nuget push LAN.Core.Eventing.SignalR.!eventingSignalrVersion!.nupkg
)

@ECHO on