CREATE OR ALTER PROCEDURE dbo.spr_Contacto_ObtenerPorId
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        ClienteId,
        TipoContactoId,
        Valor
    FROM Contactos
    WHERE Id = @Id;
END;
GO