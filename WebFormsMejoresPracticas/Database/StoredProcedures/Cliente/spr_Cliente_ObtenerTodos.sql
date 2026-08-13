CREATE OR ALTER PROCEDURE dbo.Cliente_ObtenerTodos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre
    FROM dbo.Clientes
    ORDER BY Nombre;
END;
GO