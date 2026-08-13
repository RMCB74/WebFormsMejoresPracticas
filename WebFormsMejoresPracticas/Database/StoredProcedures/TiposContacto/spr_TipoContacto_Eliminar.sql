USE [WebFormsMejoresPracticas]
GO
/****** Object:  StoredProcedure [dbo].[spr_TipoContacto_Eliminar]    Script Date: 13/08/2026 10:30:55 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spr_TipoContacto_Eliminar]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.TiposContacto
    WHERE Id = @Id;
END;
