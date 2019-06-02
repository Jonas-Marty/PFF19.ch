# PFF19.ch
Website des PFF19 - pff19.ch. 


# Installation / Getting Started:
 * Clone this repo
 * At the repo's root directory run `dotnet restore`
 * Restore Node dependencies by running `npm install`
 * Run the application (`dotnet run` or `npm run dev`)

# Database connection
 * MYSQL (recomended for linux)
   - Get mysql running on your system
   - Adjust `"Dev_MySql": "Server=localhost;Database=YOUR_DATABASE;User=YOUR_USER;Password=YOUR_PASSWORD"` in appsettings.json and appsettings.Development.json
   - Adjust `"UseMySql": true` in appsettings.json and appsettings.Development.json to true
 * MSSQL (for Windows Systems)
   - Get mysql running on your system
   - Adjust `"Dev": "Server=(localdb)\\mssqllocaldb;Database=YOUR_DATABASE;Trusted_Connection=True;ConnectRetryCount=0"` in appsettings.json and appsettings.Development.json



