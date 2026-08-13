CREATE DATABASE WebFormsMejoresPracticas
ON PRIMARY
(
    NAME = WebFormsMejoresPracticas_Data,
    FILENAME = 'D:\DEVS_SQL2022\sql_data\WebFormsMejoresPracticas\WebFormsMejoresPracticas.mdf',
    SIZE = 50MB,
    FILEGROWTH = 10MB
)
LOG ON
(
    NAME = WebFormsMejoresPracticas_Log,
    FILENAME = 'D:\DEVS_SQL2022\sql_data\WebFormsMejoresPracticas\WebFormsMejoresPracticas_log.ldf',
    SIZE = 25MB,
    FILEGROWTH = 10MB
);
GO