CREATE OR ALTER PROCEDURE dbo.spr_Contacto_Actualizar
    @Id INT,
    @ClienteId INT,
    @TipoContactoId INT,
    @Valor NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Contactos
    SET
        ClienteId = @ClienteId,
        TipoContactoId = @TipoContactoId,
        Valor = @Valor
    WHERE Id = @Id;
END;
GO