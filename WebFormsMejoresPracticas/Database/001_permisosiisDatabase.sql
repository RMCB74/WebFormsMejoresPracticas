USE [master];
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = N'IIS APPPOOL\WebFormsMejoresPracticas'
)
BEGIN
select ' no esta log  IIS APPPOOL\WebFormsMejoresPracticas' 
    CREATE LOGIN [IIS APPPOOL\WebFormsMejoresPracticas]
    FROM WINDOWS;
END
GO

USE [WebFormsMejoresPracticas];
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_principals
    WHERE name = N'IIS APPPOOL\WebFormsMejoresPracticas'
)
BEGIN
select ' no esta user  IIS APPPOOL\WebFormsMejoresPracticas' 
    CREATE USER [IIS APPPOOL\WebFormsMejoresPracticas]
    FOR LOGIN [IIS APPPOOL\WebFormsMejoresPracticas];
END
GO

ALTER ROLE db_datareader
ADD MEMBER [IIS APPPOOL\WebFormsMejoresPracticas];
GO

ALTER ROLE db_datawriter
ADD MEMBER [IIS APPPOOL\WebFormsMejoresPracticas];
GO

USE WebFormsMejoresPracticas;
GO

GRANT EXECUTE TO [IIS APPPOOL\WebFormsMejoresPracticas];
GO