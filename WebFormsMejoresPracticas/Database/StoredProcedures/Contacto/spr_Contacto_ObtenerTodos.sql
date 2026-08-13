CREATE OR ALTER PROCEDURE dbo.spr_Contacto_ObtenerTodos
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        c.Id,
        c.ClienteId,
        c.TipoContactoId,
        c.Valor,
        cl.Nombre AS ClienteNombre,
        tc.Descripcion AS TipoContactoDescripcion
    FROM Contactos c
    INNER JOIN Clientes cl
        ON cl.Id = c.ClienteId
    INNER JOIN TipoContactos tc
        ON tc.Id = c.TipoContactoId
    ORDER BY c.Id;
END;
GO