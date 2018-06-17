Write-Host "Start Packing:"
$baseDir = Split-Path -parent $PSScriptRoot
Write-Host "Basepath is: $basedir"
$projectPath = "$baseDir/tests/tests.csproj"
dotnet test $projectPath -c "Release"  
