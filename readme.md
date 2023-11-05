# Ejemplo API de Menú Dinámico en .NET C#

## Proyecto personal
Este repositorio contiene un proyecto desarrollado en .NET C# que implementa un Menú Dinámico. La API está construida siguiendo las mejores prácticas de desarrollo y utiliza las siguientes tecnologías y patrones:

  - .NET Core
  - C#
  - Microsoft SQL Server
  - Entity Framework
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

# Caracteristicas

Este proyecto abarca tres componentes fundamentales: autenticación, un menú dinámico y operaciones CRUD básicas de Usuario, Rol y Menu.

## API de Menú

Este endpoint devuelve la estructura de un menú en formato JSON.

### Endpoint

GET api/itemmenu/menu

El endpoint devuelve una respuesta en formato JSON con la siguiente estructura:

| Campo              | Descripción                                 |
|--------------------|---------------------------------------------|
| `status`           | Indica si la solicitud fue exitosa (booleano) |
| `msg`              | Mensaje de estado de la solicitud (cadena)   |
| `value`            | Arreglo de ítems de menú                     |
| `token`            | Token (si aplica)                           |

#### Estructura de `value` (Arreglo de ítems de menú)

El campo `value` contiene un arreglo de objetos que representan los ítems del menú. Cada objeto tiene la siguiente estructura:

| Campo                | Descripción                                       |
|----------------------|---------------------------------------------------|
| `idItemMenu`         | Identificador del ítem de menú (entero)          |
| `idItemMenuPadre`    | Identificador del ítem de menú padre (entero o nulo) |
| `ruta`               | Ruta del ítem de menú (cadena)                   |
| `texto`              | Texto del ítem de menú, texto que se muestra de menu (cadena)                   |
| `visible`            | Indica si el ítem de menú es visible (booleano)  |
| `fechaRegistro`      | Fecha de registro del ítem de menú (formato ISO) |
| `esActivo`           | Indica si el ítem de menú está activo (booleano) |
| `submenu`            | Arreglo de subítems de menú (puede estar vacío)   |

#### Ejemplo de respuesta

```json
{
  "status": true,
  "msg": "OK",
  "value": [
    {
      "idItemMenu": 1,
      "idItemMenuPadre": null,
      "ruta": "",
      "texto": "Seguridad",
      "visible": true,
      "fechaRegistro": "0001-01-01T00:00:00",
      "esActivo": true,
      "submenu": [
        {
          "idItemMenu": 2,
          "idItemMenuPadre": 1,
          "ruta": "usuario",
          "texto": "Usuario",
          "visible": true,
          "fechaRegistro": "0001-01-01T00:00:00",
          "esActivo": true,
          "submenu": []
        },
        {
          "idItemMenu": 10,
          "idItemMenuPadre": 1,
          "ruta": "menu",
          "texto": "Menu",
          "visible": true,
          "fechaRegistro": "0001-01-01T00:00:00",
          "esActivo": true,
          "submenu": []
        }
      ]
    },
    {
      "idItemMenu": 3,
      "idItemMenuPadre": null,
      "ruta": "dashboard",
      "texto": "Dashboard",
      "visible": true,
      "fechaRegistro": "0001-01-01T00:00:00",
      "esActivo": true,
      "submenu": []
    },
    {
      "idItemMenu": 4,
      "idItemMenuPadre": null,
      "ruta": "",
      "texto": "Catálogo",
      "visible": true,
      "fechaRegistro": "0001-01-01T00:00:00",
      "esActivo": true,
      "submenu": [
        {
          "idItemMenu": 6,
          "idItemMenuPadre": 4,
          "ruta": "rol",
          "texto": "Rol",
          "visible": true,
          "fechaRegistro": "0001-01-01T00:00:00",
          "esActivo": true,
          "submenu": []
        }
      ]
    }
  ],
  "token": null
}
```

### Notas
- idItemMenuPadre es un campo que puede ser nulo para los ítems principales del menú.
- submenu es un arreglo de objetos que representa los subítems del menú.


## API de Autenticación

Este endpoint permite autenticar a los usuarios y devuelve un token de acceso en formato JSON.

### Endpoint

- POST api/authentication/


### Parámetros

Para autenticar a un usuario, debes proporcionar los siguientes parámetros en la solicitud POST:

- `usuario` (cadena): El nombre de usuario del usuario que desea autenticar.
- `pass` (cadena): La contraseña asociada al usuario.

Ejemplo de solicitud POST:

```json
{
    "usuario": "nombre_de_usuario",
    "pass": "contraseña_secreta"
}
```

### Respuesta

El endpoint devuelve una respuesta en formato JSON con la siguiente estructura:

| Campo              | Descripción                                   |
|--------------------|-----------------------------------------------|
| `status`           | Indica si la solicitud fue exitosa (booleano) |
| `msg`              | Mensaje de estado de la solicitud (cadena)   |
| `value`            | Datos del usuario autenticado               |
| `token`            | Token de acceso (cadena)                     |

#### Estructura de `value` (Datos del usuario autenticado)

El campo `value` contiene un objeto con los datos del usuario autenticado. Los campos incluyen:

| Campo              | Descripción                                   |
|--------------------|-----------------------------------------------|
| `idUsuario`        | Identificador del usuario (entero)           |
| `idRol`            | Identificador del rol del usuario (entero)  |
| `usuario1`         | Nombre de usuario (cadena)                   |
| `nombreRol`        | Nombre del rol del usuario (cadena)          |
| `pass`             | Contraseña (cadena)                          |
| `correo`           | Dirección de correo del usuario (cadena)     |
| `fechaRegistro`    | Fecha de registro del usuario (formato ISO) |
| `esActivo`         | Indica si el usuario está activo (booleano) |

#### Ejemplo de respuesta

```json
{
    "status": true,
    "msg": "ok",
    "value": {
        "idUsuario": 2,
        "idRol": 1,
        "usuario1": "admin",
        "nombreRol": "Administrador",
        "pass": "1234",
        "correo": "julio@gmail.com",
        "fechaRegistro": "2023-11-04T21:24:45.703",
        "esActivo": true
    },
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}

```

## Notas
El campo token se utiliza para autorizar solicitudes posteriores en nombre del usuario autenticado.
Asegúrate de que los usuarios comprendan cómo utilizar este token para autenticar sus solicitudes posteriores.

Este proyecto es básico y está diseñado para ser versátil y facilitar la personalización y reutilización en otros proyectos. Si decides utilizarlo como base para tu propia aplicación, ¡te animo a explorar las posibilidades y adaptarlo según tus necesidades!




