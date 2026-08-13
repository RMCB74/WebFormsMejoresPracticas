USE [WebFormsMejoresPracticas]
GO
/****** Object:  StoredProcedure [dbo].[spr_TipoContacto_Actualizar]    Script Date: 13/08/2026 10:30:24 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spr_TipoContacto_Actualizar]
    @Id INT,
    @Descripcion NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE dbo.TiposContacto
    SET
        Descripcion = @Descripcion
    WHERE Id = @Id;
END;
