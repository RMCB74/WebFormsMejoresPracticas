USE WebFormsMejoresPracticas;
GO

CREATE TABLE Clientes
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,

    CONSTRAINT PK_Clientes
        PRIMARY KEY (Id)
);
GO