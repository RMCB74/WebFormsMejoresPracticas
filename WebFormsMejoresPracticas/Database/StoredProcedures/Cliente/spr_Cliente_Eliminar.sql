CREATE PROCEDURE dbo.spr_Cliente_Eliminar
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Clientes
    WHERE Id = @Id;
END