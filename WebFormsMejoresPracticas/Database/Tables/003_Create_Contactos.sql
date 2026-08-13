USE WebFormsMejoresPracticas;
GO

CREATE TABLE Contactos
(
    Id INT IDENTITY(1,1) NOT NULL,

    ClienteId INT NOT NULL,

    TipoContactoId INT NOT NULL,

    Valor NVARCHAR(150) NOT NULL,

    CONSTRAINT PK_Contactos
        PRIMARY KEY (Id),

    CONSTRAINT FK_Contactos_Clientes
        FOREIGN KEY (ClienteId)
        REFERENCES Clientes(Id),

    CONSTRAINT FK_Contactos_TiposContacto
        FOREIGN KEY (TipoContactoId)
        REFERENCES TiposContacto(Id)
);
GO