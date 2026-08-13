CREATE PROCEDURE dbo.spr_Cliente_Actualizar
    @Id INT,
    @Nombre NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Clientes
    SET Nombre = @Nombre
    WHERE Id = @Id;
END