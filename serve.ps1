# Iniciar servidor ASP.NET Core
Start-Process chrome -ArgumentList "http://localhost:4321"


Start-Process dotnet -ArgumentList "run --configuration Debug --project ServerAspnet"

# Iniciar Vite
npm --prefix AstroClient run dev

