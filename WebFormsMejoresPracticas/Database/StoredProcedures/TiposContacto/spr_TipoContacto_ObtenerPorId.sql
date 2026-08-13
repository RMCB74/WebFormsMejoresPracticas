USE [WebFormsMejoresPracticas]
GO
/****** Object:  StoredProcedure [dbo].[spr_TipoContacto_ObtenerPorId]    Script Date: 13/08/2026 10:27:59 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spr_TipoContacto_ObtenerPorId]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Descripcion
    FROM dbo.TiposContacto
    WHERE Id = @Id;
END;
