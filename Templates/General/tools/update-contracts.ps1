Write-Host "Messages nuget package updating is starting"

cd ".\src\Contracts\SFC.GeneralTemplate.Contracts"

dotnet pack

cd ".\bin\Release"

$latest_nupkg_file = (Get-ChildItem -Attributes !Directory | Sort-Object -Descending -Property LastWriteTime | select -First 1)

$nupkg_file_name = $latest_nupkg_file.Name 

dotnet nuget push $nupkg_file_name --api-key GeneralTemplateNugetApiKey --source https://api.nuget.org/v3/index.json

cd "..\"

cd "..\"

cd "..\"

cd "..\"

cd "..\"

Write-Host "Messages nuget package updating is finished!"