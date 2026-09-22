USE [SistemaContabilidadDB];
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Cuentas)
INSERT INTO dbo.Cuentas (Codigo, Nombre, CodigoPadre, Tipo, Naturaleza, EsDetalle) VALUES
('1101','Efectivo y Equivalente',NULL,1,'Deudora',0),
('110101','Caja','1101',1,'Deudora',1),
('110102','Banco','1101',1,'Deudora',1),
('1102','Cuentas por Cobrar',NULL,1,'Deudora',0),
('110201','Clientes','1102',1,'Deudora',1),
('1103','Inventarios',NULL,1,'Deudora',1),
('1104','IVA / Impuestos por Cobrar',NULL,1,'Deudora',0),
('110401','IVA Crédito Fiscal','1104',1,'Deudora',1),
('110402','IVA Remanente Fiscal','1104',1,'Deudora',1),
('1105','Gasto por Pago Anticipado',NULL,1,'Deudora',0),
('110501','Alquiler','1105',1,'Deudora',1),
('1201','Propiedad, Planta y Equipo',NULL,1,'Deudora',0),
('120101','Mobiliario y Equipo de Oficina','1201',1,'Deudora',1),
('120102','Equipo de Transporte','1201',1,'Deudora',1),
('2101','Cuentas por Pagar',NULL,2,'Acreedora',0),
('210101','Acreedores Varios','2101',2,'Acreedora',1),
('210102','Proveedores','2101',2,'Acreedora',1),
('2102','Préstamos Bancarios',NULL,2,'Acreedora',1),
('2103','IVA / Impuestos por Pagar',NULL,2,'Acreedora',0),
('210301','IVA Débito Fiscal','2103',2,'Acreedora',1),
('210302','IVA por Pagar','2103',2,'Acreedora',1),
('3101','Capital Social',NULL,3,'Acreedora',1),
('4101','Compras',NULL,4,'Deudora',1),
('4102','Gasto de Compra',NULL,4,'Deudora',1),
('4103','Devolución sobre Venta',NULL,4,'Deudora',1),
('4201','Gasto Administrativo',NULL,4,'Deudora',0),
('420101','Cheque','4201',4,'Deudora',1),
('4202','Gasto de Venta',NULL,4,'Deudora',0),
('420201','Facturas','4202',4,'Deudora',1),
('4301','Gasto Financiero',NULL,4,'Deudora',0),
('430101','Comisión','4301',4,'Deudora',1),
('5101','Ventas',NULL,5,'Acreedora',1),
('5102','Devolución sobre Compra',NULL,5,'Acreedora',1);
GO

SELECT Tipo, COUNT(*) AS Cuentas FROM dbo.Cuentas GROUP BY Tipo ORDER BY Tipo;
GO
