# Deploy Enjoyers

## Proyecto: TeamGitPractice

Práctica colaborativa de Git y GitHub (Práctica 1): flujo de trabajo con ramas personales, Pull Requests, revisión de código, resolución de conflictos y recuperación de cambios sobre un proyecto ASP.NET Core Web API.

## Integrantes

| Integrante | Nombre completo | Usuario GitHub | Rama personal |
|---|---|---|---|
| 1 | Sebastián Jesús Pérez Araujo | [SESASAN](https://github.com/SESASAN) | `sebastian-perez` |
| 2 | Kevin Daniel Mendoza Castillo | [kevindm1998](https://github.com/kevindm1998) | `kevin-mendoza` |
| 3 | Juan Felipe Torres Torres | [H3bito](https://github.com/H3bito) | `juan-torres` |
| 4 | Nathalie Gabriela Miranda Rejón | [NathyGaby04](https://github.com/NathyGaby04) | `nathalie-miranda` |
| 5 | Samuel Quiroz Rincón | [Samuzarter](https://github.com/Samuzarter) | `samuel-quiroz` |

## Cómo ejecutar la API

1. Clonar el repositorio.
2. Abrir `TeamGitPractice.slnx` en Visual Studio Community 2026 (o ejecutar `dotnet run` desde la carpeta `TeamGitPractice`).
3. Ejecutar el proyecto (F5 o `dotnet run`).
4. La API quedará disponible en la URL que indique la consola (por ejemplo `https://localhost:xxxx`).

## Endpoints desarrollados

| Endpoint | Responsable | Descripción |
|---|---|---|
| `GET /api/status` | Integrante 1 - Sebastián Pérez | Estado de la API. |
| `GET /api/status/team` | Integrante 1 - Sebastián Pérez | Estado del equipo. |
| `GET /api/members` | Integrante 2 - Kevin Mendoza | Lista de integrantes. |
| `GET /api/members/count` | Integrante 2 - Kevin Mendoza | Total de integrantes. |
| `GET /api/version` | Integrante 3 - Juan Torres | Versión de la aplicación. |
| `GET /api/version/platform` | Integrante 3 - Juan Torres | Plataforma del proyecto. |
| `GET /api/health` | Integrante 4 - Nathalie Miranda | Estado de salud de la API. |
| `GET /api/health/time` | Integrante 4 - Nathalie Miranda | Hora UTC actual. |
| `GET /api/info` | Integrante 5 - Samuel Quiroz | Información general del proyecto. |
| `GET /api/info/tools` | Integrante 5 - Samuel Quiroz | Herramientas utilizadas. |
