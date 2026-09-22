# Plan de desarrollo — Sistema de Contabilidad

Proyecto en C# (Windows Forms, MDI) con base de datos SQL Server.
**Entrega: miércoles 23/09.**

## Avance por días

- [x] **Día 1 (lun 21/09):** Base de datos — script SQL con tablas núcleo (`Cuentas`, `Asientos`, `AsientoDetalle`) y catálogo de cuentas.
- [ ] **Día 2 (mar 22/09):** Capa de datos (conexión + DAL), **ventana principal MDI tipo dashboard** (con indicadores para que no se vea vacía) y formulario de Catálogo de Cuentas.
- [ ] **Día 3 (mié 23/09):** Libro Diario (partida doble), Mayorización (Libro Mayor), Balanza, Estados financieros (Balance y Resultados), Liquidación de IVA, Login + roles/usuarios, módulo de Salud Financiera, README y ejecutable.

> Nota: si hoy avanzamos rápido, adelantamos parte del Día 3 (Libro Diario / Mayor) para dejar el miércoles más liviano.

## Requisitos del proyecto

- Libro Diario con validación de partida doble (Debe = Haber).
- Mayorización automática (saldo Deudor/Acreedor por cuenta).
- Estados financieros por dígito del código: Balance (1 = 2 + 3) y Resultados (5 − 4).
- Módulo innovador útil (Panel de Salud Financiera).
- Dashboard en la ventana principal, reportes, README, historial de Git y ejecutable.
