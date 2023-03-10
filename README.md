# Web Application Login & Register (ASP.NET Core 7)

This Web Application was made with:
- ASP.NET Core 7
- SQL Server 2019
- Used razor view

Required packages:
- Microsoft.EntityFrameworkCore.SqlServer 7.0.0
- Microsoft.EntityFrameworkCore.Tools 7.0.0

Use the following command line to add our database context to our project:
- In Visual Studio, find the "Tools" tab > NuGet Package Manager > Package Manager Console. 
- And paste in the console -> Scaffold-DbContext "Server=(local); DataBase=db_webapplication01; Trusted_Connection=True; TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models
