IF DB_ID(N'SistemaContabilidadDB') IS NULL
    CREATE DATABASE [SistemaContabilidadDB];
GO

USE [SistemaContabilidadDB];
GO

IF OBJECT_ID('dbo.Cuentas', 'U') IS NULL
CREATE TABLE dbo.Cuentas (
    Codigo       NVARCHAR(10)  NOT NULL PRIMARY KEY,
    Nombre       NVARCHAR(150) NOT NULL,
    CodigoPadre  NVARCHAR(10)  NULL,
    Tipo         INT           NOT NULL,
    Naturaleza   NVARCHAR(10)  NOT NULL,
    EsDetalle    BIT           NOT NULL DEFAULT 1
);
GO

IF OBJECT_ID('dbo.Asientos', 'U') IS NULL
CREATE TABLE dbo.Asientos (
    IdAsiento     INT           IDENTITY(1,1) PRIMARY KEY,
    Numero        INT           NOT NULL,
    Fecha         DATE          NOT NULL,
    Concepto      NVARCHAR(300) NOT NULL,
    FechaRegistro DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

IF OBJECT_ID('dbo.AsientoDetalle', 'U') IS NULL
CREATE TABLE dbo.AsientoDetalle (
    IdDetalle    INT           IDENTITY(1,1) PRIMARY KEY,
    IdAsiento    INT           NOT NULL,
    CodigoCuenta NVARCHAR(10)  NOT NULL,
    Concepto     NVARCHAR(300) NULL,
    Debe         DECIMAL(18,2) NOT NULL DEFAULT 0,
    Haber        DECIMAL(18,2) NOT NULL DEFAULT 0,
    CONSTRAINT FK_Detalle_Asiento FOREIGN KEY (IdAsiento)
        REFERENCES dbo.Asientos(IdAsiento) ON DELETE CASCADE,
    CONSTRAINT FK_Detalle_Cuenta FOREIGN KEY (CodigoCuenta)
        REFERENCES dbo.Cuentas(Codigo)
);
GO
