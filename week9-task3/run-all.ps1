# Start all services in separate PowerShell windows
# Usage: Right-click -> Run with PowerShell or `.un-all.ps1`

$root = Split-Path -Parent $MyInvocation.MyCommand.Definition

$projects = @( 
    @{ Path = "ContactService"; Port = 5001 },
    @{ Path = "CategoryService"; Port = 5002 },
    @{ Path = "ApiGateway"; Port = 5000 }
)

foreach ($p in $projects) {
    $projPath = Join-Path $root $p.Path
    $cmd = "dotnet run --project `"$projPath`""
    Start-Process -FilePath "powershell.exe" -ArgumentList "-NoExit", "-Command", $cmd -WorkingDirectory $projPath
}

Write-Host "Started projects in separate PowerShell windows: ContactService(5001), CategoryService(5002), ApiGateway(5000)"