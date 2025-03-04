# Publicar
$folderPath = ".\ServerAspnet\wwwroot"

if (Test-Path $folderPath) {
    Remove-Item -Path $folderPath -Recurse -Force
}

dotnet publish AppWPF -c Release -o publish