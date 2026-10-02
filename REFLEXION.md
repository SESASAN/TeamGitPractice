# Reflexión Técnica

## 1. ¿Cómo abordaron el proceso de despliegue?

El proceso completo abarcó desde la contenerización hasta la orquestación local:

1. Construcción de una imagen Docker versionada bajo la etiqueta practica2-api:v1.
2. Prueba de ejecución local del contenedor exponiendo el puerto 8080.
3. Traslado de la aplicación a un entorno local de Kubernetes utilizando un Namespace específico.
4. Orquestación mediante un Deployment y exposición del servicio a través de un Service.

## 2. ¿Qué errores encontraron y cómo los resolvieron?

- Inconveniente: Durante la validación del acceso mediante NodePort, el Service se creó correctamente, pero el acceso directo a través de localhost no funcionaba. Esto ocurrió debido a la configuración de Docker Desktop con kind, donde el nodo de Kubernetes se ejecuta como un contenedor y el puerto no se publica de forma directa hacia el equipo anfitrión.

- Solución: Se utilizó el comando kubectl port-forward para redirigir el puerto 80 del Service al puerto 8081 del equipo local, logrando acceder a la API mediante localhost:8081 para comprobar su correcto funcionamiento.

## 3. ¿Cómo se distribuyeron las responsabilidades del equipo?

El trabajo se dividió entre los integrantes del equipo para cubrir las distintas fases de la práctica de manera estructurada:

| Integrante | Nombre completo                 | Responsabilidad                   |
| ---------- | ------------------------------- | --------------------------------- |
| 1          | Sebastián Jesús Pérez Araujo    | Crear el Dockerfile para la API.  |
| 2          | Kevin Daniel Mendoza Castillo   | Resources y buenas prácticas.     |
| 3          | Juan Felipe Torres Torres       | README, evidencias y reflexión.   |
| 4          | Nathalie Gabriela Miranda Rejón | Deployment de Kubernetes.         |
| 5          | Samuel Quiroz Rincón            | Creación del Namespace y Service. |

Esta división facilitó la integración de los diferentes componentes y permitió validar cada etapa antes de consolidar la entrega.

## 4. ¿Qué decisiones relacionadas con la tecnología seleccionada influyeron en el Dockerfile o en la configuración del despliegue?

- Tecnología seleccionada: ASP.NET Core / .NET.

- Dockerfile: Se utilizó un Dockerfile de múltiples etapas (multi-stage build). Una primera etapa se basó en el SDK de .NET para restaurar dependencias, compilar y publicar la aplicación, y una segunda etapa se basó en ASP.NET Core Runtime para ejecutar la aplicación publicada. Esto permitió separar el entorno de construcción del entorno de ejecución final. Posteriormente, el contenedor se ejecutó exponiendo el puerto 8080, verificando su funcionamiento mediante el endpoint /api/status.

- Configuración del Despliegue (Kubernetes): Se emplearon un Namespace, un Deployment y un Service. El Deployment se configuró con una réplica de la API y imagePullPolicy: IfNotPresent para aprovechar la imagen Docker disponible localmente. Se establecieron solicitudes y límites de CPU y memoria (100m/250m para CPU y 128Mi/256Mi para memoria), ideales para una API pequeña sin pruebas de carga. Asimismo, se relacionaron los recursos mediante el label app: practica2-api de forma coherente entre el Deployment y el Service.
