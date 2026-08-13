CREATE OR ALTER PROCEDURE dbo.Cliente_ObtenerPorId
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre
    FROM dbo.Clientes
    WHERE Id = @Id;
END;
GO