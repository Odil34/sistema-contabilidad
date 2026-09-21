# Plan de desarrollo — Sistema de Contabilidad

Proyecto en C# (Windows Forms, MDI) con base de datos SQL Server.

## Avance por días

- [x] **Día 1 (lun 21/09):** Base de datos — script SQL con tablas núcleo (`Cuentas`, `Asientos`, `AsientoDetalle`) y catálogo de cuentas.
- [ ] **Día 2 (mar 22/09):** Capa de datos (conexión + DAL), ventana principal MDI y formulario de Catálogo de Cuentas.
- [ ] **Día 3 (mié 23/09):** Libro Diario (partida doble), Mayorización (Libro Mayor) y Balanza de Comprobación.
- [ ] **Día 4 (jue 24/09):** Estados financieros (Balance General y Estado de Resultados) y Liquidación de IVA.
- [ ] **Día 5 (vie 25/09):** Login + roles/usuarios, módulo de Salud Financiera, README/manual y ejecutable.

## Requisitos del proyecto

- Libro Diario con validación de partida doble (Debe = Haber).
- Mayorización automática (saldo Deudor/Acreedor por cuenta).
- Estados financieros por dígito del código: Balance (1 = 2 + 3) y Resultados (5 − 4).
- Módulo innovador útil.
- Reportes, README, historial de Git y ejecutable.
