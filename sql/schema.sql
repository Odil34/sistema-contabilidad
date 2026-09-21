-- SISTEMA CONTABLE BD
 USE Sistema_ContableDB;
 GO

/* ---------- Catálogo de cuentas ----------
   El primer dígito del código define la clasificación contable:
     1 = Activo, 2 = Pasivo, 3 = Capital, 4 = Costos y Gastos, 5 = Ingresos.
   Naturaleza: Deudora (Activo y Gastos) o Acreedora (Pasivo, Capital, Ingresos).
   EsDetalle: 1 = cuenta que admite movimientos; 0 = cuenta de agrupación. */
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

/* ---------- Asientos: cabecera de cada partida del Libro Diario ---------- */
IF OBJECT_ID('dbo.Asientos', 'U') IS NULL
CREATE TABLE dbo.Asientos (
    IdAsiento     INT           IDENTITY(1,1) PRIMARY KEY,
    Numero        INT           NOT NULL,
    Fecha         DATE          NOT NULL,
    Concepto      NVARCHAR(300) NOT NULL,
    FechaRegistro DATETIME      NOT NULL DEFAULT GETDATE()
);
GO

/* ---------- AsientoDetalle: movimientos (líneas) de cada asiento ----------
   Cada línea afecta una cuenta con un valor en el Debe o en el Haber.
   La suma de Debe debe ser igual a la suma de Haber (partida doble),
   validación que se aplica desde la aplicación antes de guardar. */
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
