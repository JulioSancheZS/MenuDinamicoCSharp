# Ejemplo API de Menú Dinámico en .NET C#

## Proyecto personal
Este repositorio contiene un proyecto de API desarrollado en .NET C# que implementa un Menú Dinámico. La API está construida siguiendo las mejores prácticas de desarrollo y utiliza las siguientes tecnologías y patrones:

- **Tecnologías Utilizadas**:
  - .NET Core
  - C#
  - Microsoft SQL Server
  - Json Web Token
  - Patrón Repositorio
  - AutoMapper

## Requisitos

Asegúrate de tener instalados los siguientes requisitos antes de comenzar:

- SQL Server 2014 o superior
- Visual Studio 2022
## Configuración

1. Clona este repositorio en tu máquina local.

```bash
git clone https://github.com/JulioSancheZS/MenuDinamicoCSharp.git
```

2. Abre el proyecto en Visual Studio 2022

3.  [Acá esta el Script SQL, ejecutalo en SQL Server](https://github.com/TuUsuario/TuRepositorio/tree/main/SQLDB/mi_script.sql)

4. Configura la cadena de conexión a tu instancia de SQL Server en el archivo 
`appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=TuServidor;Database=MenuDB;User=TuUsuario;Password=TuContraseña;"
}
```

## Próximos Cambios

Estoy emocionado porque pienso trabajar en nuevas características y mejoras para esta API de Menú Dinámico. Algunos de los próximos cambios que incluiré son:


- **CRUD de Usuario**: Voy a desarrollar las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) para los usuarios, lo que facilitará la gestión de usuarios en el sistema.

- **CRUD de Rol**: Similar al CRUD de usuarios, Voy a desarrollar las operaciones CRUD para los roles, lo que simplificará la administración de roles de usuario.

- **Asignar Menú por Roles**: Esta característica permitirá asignar menús específicos a roles de usuario, brindando un control más detallado sobre qué menús pueden acceder los usuarios en función de sus roles.

Este proyecto está diseñado para ser versátil y facilitar la personalización y reutilización en otros proyectos. Si decides utilizarlo como base para tu propia aplicación, ¡te animo a explorar las posibilidades y adaptarlo según tus necesidades!
