echo off
cls

if exist "C:\Program Files\dotnet" (

rd /s /q bin\
rd /s /q obj\
cls
dotnet build project.sln
pause

)else (

echo No .NET Core found!
echo Launching download...
start https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.302-windows-x64-installer
echo Start this batch file again, when installation is complete.
pause
)
