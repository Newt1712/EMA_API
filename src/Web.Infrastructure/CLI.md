## Add migration 
dotnet ef migrations add <migration-name> --context ApplicationDbContext  -o Migrations 


## Remove latest migration 
dotnet ef migrations remove --context ApplicationDbContext


## Update database on migration version
dotnet ef database update <previous-migration-name>  --context ApplicationDbContext


## Clean database (Reverting all migration)
dotnet ef database update 0 --context ApplicationDbContext 


** Note: You can remove [--context <your-db-context>] if there is only 1 DbContext **
Checkout https://learn.microsoft.com/en-us/dotnet/core/tools/ for more information