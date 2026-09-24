# Sistema de Contabilidad

Sistema de contabilidad desarrollado en C# con Windows Forms para gestionar operaciones contables básicas de una empresa, incluyendo cuentas, asientos contables, reportes financieros y administración de usuarios.

## Descripción

Este proyecto permite llevar el control financiero de una organización mediante una interfaz desktop en Windows. La aplicación conecta a una base de datos SQL Server y automatiza la creación inicial de la base de datos y la estructura necesaria para operar.

Incluye módulos para:

- Gestión de usuarios y autenticación
- Catálogo de cuentas contables
- Registro de asientos contables
- Libro diario y libro mayor
- Balance de comprobación
- Estado de resultados
- Balance general
- Dashboard financiero
- Cálculo y liquidación de IVA
- Salud financiera

## Stack tecnológico

- .NET 8
- C# / WinForms
- SQL Server (LocalDB por defecto)
- Microsoft.Data.SqlClient
- Visual Studio 2022

## Estructura del proyecto

```text
sistema-contabilidad/
├── sql/
│   ├── schema.sql
│   └── data.sql
├── sistema_contabilidad/
│   ├── Datos/
│   ├── Formularios/
│   ├── Modelos/
│   ├── Seguridad/
│   ├── Utilidades/
│   ├── App.config
│   ├── FrmPrincipal.cs
│   ├── Program.cs
│   └── sistema_contabilidad.csproj
├── .gitignore
├── sistema_contabilidad.sln
└── README.md
```

## Funcionalidades principales

### 1. Autenticación y seguridad

* Login de usuarios
* Manejo de sesión activa
* Hash de contraseñas para almacenamiento seguro

### 2. Catálogo de cuentas

* Registro y mantenimiento de cuentas contables
* Estructura jerárquica por código y tipo
* Identificación de naturaleza de la cuenta (débitos/créditos)

### 3. Asientos contables

* Registro de comprobantes contables
* Asociación de detalle por cuenta
* Debe y haber por movimiento

### 4. Consultas y reportes

* Libro diario
* Libro mayor
* Balance de comprobación
* Estado de resultados
* Balance general
* Dashboard con indicadores financieros

### 5. IVA y análisis financiero

* Calculadora de IVA
* Liquidación de impuesto
* Evaluación de salud financiera

## Base de datos

La aplicación usa una base de datos llamada `SistemaContabilidadDB` por defecto.

La inicialización se realiza automáticamente al iniciar la aplicación mediante la clase `InicializadorBD`, que crea la base e inserta los datos iniciales si es necesario.

También se incluyen scripts SQL en la carpeta `sql/`:

* `schema.sql`: estructura principal de la base de datos
* `data.sql`: carga de datos iniciales

## Requisitos

Antes de ejecutar el proyecto asegúrate de tener instalado:

* Windows 10 o superior
* Visual Studio 2022
* .NET desktop workload
* SQL Server LocalDB o SQL Server Express

## Instalación y configuración

1. Clona este repositorio:

```bash
git clone [https://github.com/Odil34/sistema-contabilidad.git](https://github.com/Odil34/sistema-contabilidad.git)
```

2. Abre la solución `sistema_contabilidad.sln` en Visual Studio.
3. Restaura los paquetes NuGet.
4. Verifica la cadena de conexión en `sistema_contabilidad/App.config`:

```xml
<add name="SistemaContabilidad"
     connectionString="Server=(localdb)\MSSQLLocalDB;Database=SistemaContabilidadDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True"
     providerName="Microsoft.Data.SqlClient" />
```

5. Ejecuta la aplicación.

La base de datos se creará automáticamente si no existe.

## Ejecución

Desde Visual Studio:

* Selecciona el proyecto `sistema_contabilidad`
* Presiona F5 o ejecuta con depuración

## Observaciones importantes

* La aplicación está diseñada para entornos Windows porque usa WinForms.
* El valor por defecto usa `LocalDB`, por lo que normalmente no requiere configuración adicional.
* Si usas otra instancia de SQL Server, puedes cambiar la cadena de conexión en `App.config` o definir la variable de entorno `SISTEMACONTABILIDAD_CONN`.

## Licencia

Este repositorio no incluye un archivo de licencia explícito en el proyecto detectado por GitHub. Si deseas reutilizar el código, primero conviene consultar al autor o agregar una licencia adecuada.

## Autor

* Odil34

## Estado del proyecto

Este repositorio parece ser un sistema desktop de contabilidad funcional con varias pantallas de gestión financiera, listo para ser ejecutado en un entorno de desarrollo Windows.
