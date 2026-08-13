CREATE PROCEDURE dbo.spr_Cliente_Crear
    @Nombre NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Clientes (Nombre)
    VALUES (@Nombre);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
END