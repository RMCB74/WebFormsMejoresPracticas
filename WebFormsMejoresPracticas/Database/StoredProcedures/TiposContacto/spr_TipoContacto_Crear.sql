USE [WebFormsMejoresPracticas]
GO
/****** Object:  StoredProcedure [dbo].[spr_TipoContacto_Crear]    Script Date: 13/08/2026 10:28:44 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spr_TipoContacto_Crear]
    @Descripcion NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.TiposContacto
    (
        Descripcion
    )
    VALUES
    (
        @Descripcion
    );

    SELECT CAST(SCOPE_IDENTITY() AS INT);
END;
