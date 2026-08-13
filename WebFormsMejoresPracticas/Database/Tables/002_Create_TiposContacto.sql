USE WebFormsMejoresPracticas;
GO

CREATE TABLE TiposContacto
(
    Id INT IDENTITY(1,1) NOT NULL,
    Descripcion NVARCHAR(50) NOT NULL,

    CONSTRAINT PK_TiposContacto
        PRIMARY KEY (Id)
);
GO