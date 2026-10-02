# Deploy Enjoyers

## Proyecto: TeamGitPractice

Práctica colaborativa de Git y GitHub (Práctica 1): flujo de trabajo con ramas personales, Pull Requests, revisión de código, resolución de conflictos y recuperación de cambios sobre un proyecto ASP.NET Core Web API.

## Integrantes

| Integrante | Nombre completo                 | Usuario GitHub                                | Rama personal      |
| ---------- | ------------------------------- | --------------------------------------------- | ------------------ |
| 1          | Sebastián Jesús Pérez Araujo    | [SESASAN](https://github.com/SESASAN)         | `sebastian-perez`  |
| 2          | Kevin Daniel Mendoza Castillo   | [kevindm1998](https://github.com/kevindm1998) | `kevin-mendoza`    |
| 3          | Juan Felipe Torres Torres       | [H3bito](https://github.com/H3bito)           | `juan-torres`      |
| 4          | Nathalie Gabriela Miranda Rejón | [NathyGaby04](https://github.com/NathyGaby04) | `nathalie-miranda` |
| 5          | Samuel Quiroz Rincón            | [Samuzarter](https://github.com/Samuzarter)   | `samuel-quiroz`    |

## Cómo ejecutar la API

1. Clonar el repositorio.
2. Abrir `TeamGitPractice.slnx` en Visual Studio Community 2026 (o ejecutar `dotnet run` desde la carpeta `TeamGitPractice`).
3. Ejecutar el proyecto (F5 o `dotnet run`).
4. La API quedará disponible en la URL que indique la consola (por ejemplo `https://localhost:xxxx`).

## Endpoints desarrollados

| Endpoint                    | Responsable                     | Descripción                       |
| --------------------------- | ------------------------------- | --------------------------------- |
| `GET /api/status`           | Integrante 1 - Sebastián Pérez  | Estado de la API.                 |
| `GET /api/status/team`      | Integrante 1 - Sebastián Pérez  | Estado del equipo.                |
| `GET /api/members`          | Integrante 2 - Kevin Mendoza    | Lista de integrantes.             |
| `GET /api/members/count`    | Integrante 2 - Kevin Mendoza    | Total de integrantes.             |
| `GET /api/version`          | Integrante 3 - Juan Torres      | Versión de la aplicación.         |
| `GET /api/version/platform` | Integrante 3 - Juan Torres      | Plataforma del proyecto.          |
| `GET /api/health`           | Integrante 4 - Nathalie Miranda | Estado de salud de la API.        |
| `GET /api/health/time`      | Integrante 4 - Nathalie Miranda | Hora UTC actual.                  |
| `GET /api/info`             | Integrante 5 - Samuel Quiroz    | Información general del proyecto. |
| `GET /api/info/tools`       | Integrante 5 - Samuel Quiroz    | Herramientas utilizadas.          |

# Práctica 2 · Despliegue de Software · 2026

## Descripción

En esta práctica se desarrolla el proceso de **containerización y despliegue de una API REST** utilizando Docker y Kubernetes.
La solución consiste en una API REST desarrollada con **ASP.NET Core**, la cual se empaqueta en una imagen Docker versionada y posteriormente se despliega en un clúster local de Kubernetes.
El despliegue utiliza un `Deployment`, un `Service` y un `Namespace`, además de configuraciones de recursos mediante `requests` y `limits`.

## Tecnologías utilizadas

- **C# / ASP.NET Core**
- **.NET 10**
- **Docker**
- **Kubernetes**
- **Docker Desktop**
- **Git / GitHub**

## Estructura del proyecto

```text
TeamGitPractice/
├── TeamGitPractice/
│   └── Código fuente de la API
│
├── k8s/
│   ├── namespace.yaml
│   ├── deployment.yaml
│   └── service.yaml
│
├── evidencias/
│   ├── docker/
│   │   ├── 01-docker-building.png
│   │   ├── 02-docker-images.png
│   │   ├── 03-docker-desktop-container.webp
│   │   └── 04-api-funcional.png
│   │
│   └── k8s/
│       ├── 01-kubectl-apply-deployment.png
│       ├── 02-kubectl-get-pods.png
│       ├── 03-kubectl-get-deploys-rs.png
│       ├── 04-kubectl-describe-deployment.png
│       ├── 05-manifiesto-deployment.png
│       ├── 06-kubectl-apply-namespace-service.png
│       ├── 07-kubectl-get-namespace.png
│       ├── 08-kubectl-get-svc.png
│       ├── 09-kubectl-get-endpoints.png
│       ├── 10-kubectl-describe-service.png
│       ├── 11-api-via-service-status.png
│       ├── 12-api-via-service-openapi.png
│       ├── 13-manifiesto-namespace.png
│       └── 14-manifiesto-service.png
│
├── Dockerfile
├── README.md
├── REFLEXION.md
└── EVIDENCIAS.md
```

## 1. Ejecución con Docker

La API se construye mediante un Dockerfile de múltiples etapas.
La primera etapa utiliza el SDK de .NET para restaurar dependencias, compilar y publicar el proyecto. La segunda utiliza la imagen de ASP.NET Core Runtime para ejecutar únicamente la aplicación publicada.
La imagen generada se identifica como:

```text
practica2-api:v1
```

### Construcción de la imagen

Desde la raíz del proyecto:

```bash
docker build -t practica2-api:v1 .
```

Para verificar la imagen creada:

```bash
docker images
```

### Ejecución del contenedor

El contenedor se ejecuta publicando el puerto `8080`:

```bash
docker run -d -p 8080:8080 --name practica2-api practica2-api:v1
```

Verificar que el contenedor se encuentre ejecutándose:

```bash
docker ps
```

### Verificación de la API

Con el contenedor activo, la API puede verificarse mediante:

```text
http://localhost:8080/api/status
```

La respuesta obtenida confirma que la API se encuentra funcionando.
También se cuenta con evidencia de la ejecución del contenedor desde Docker Desktop.

---

## 2. Despliegue en Kubernetes

El despliegue de Kubernetes se organiza dentro del namespace:

```text
practica2
```

La solución utiliza:

- **Namespace:** `practica2`
- **Deployment:** `practica2-api-deployment`
- **Service:** `practica2-api-service`
- **Imagen:** `practica2-api:v1`
- **Réplicas:** `1`

### Namespace

El namespace utilizado para aislar los recursos de la práctica es:

```yaml
apiVersion: v1
kind: Namespace
metadata:
  name: practica2
```

### Deployment

El Deployment utiliza la imagen local:

```text
practica2-api:v1
```

y establece:

```text
imagePullPolicy: IfNotPresent
```

Esto permite utilizar la imagen disponible localmente sin requerir su descarga desde un registro externo.
El contenedor expone el puerto:

```text
8080
```

Para comprobar el estado del Deployment y sus Pods:

```bash
kubectl get deployments -n practica2
kubectl get pods -n practica2
```

La ejecución correcta se evidencia mediante un Pod en estado:

```text
1/1 Running
```

### Service

El acceso al Deployment se realiza mediante:

```text
practica2-api-service
```

El Service está configurado como `NodePort` y utiliza el puerto:

```text
80:30080/TCP
```

El puerto `80` del Service redirige al puerto `8080` del contenedor.
Para verificar el Service:

```bash
kubectl get svc -n practica2
```

También se pueden comprobar sus endpoints:

```bash
kubectl get endpoints -n practica2
```

### Acceso a la API mediante port-forward

Durante las pruebas se identificó que, debido a la configuración de Kubernetes utilizada en Docker Desktop con `kind`, el `NodePort` no estaba publicado directamente hacia `localhost`.
Para permitir el acceso desde el equipo local se utilizó:

```bash
kubectl port-forward svc/practica2-api-service 8081:80 -n practica2
```

Con el `port-forward` activo, la API puede verificarse mediante:

```text
http://localhost:8081/api/status
```

La respuesta confirma el funcionamiento de la API desplegada en Kubernetes.
También se verificó el acceso a la documentación OpenAPI de la API.

---

## 3. Recursos del contenedor

El Deployment define solicitudes y límites de recursos para el contenedor.

| Recurso | Requests |  Limits |
| ------- | -------: | ------: |
| CPU     |   `100m` |  `250m` |
| Memoria |  `128Mi` | `256Mi` |

Estos valores corresponden a una configuración inicial para una API REST pequeña, con una sola réplica y sin pruebas de carga.
Los `requests` permiten que Kubernetes considere una capacidad mínima para planificar el Pod, mientras que los `limits` establecen el máximo de recursos que puede utilizar el contenedor.
La documentación detallada de esta configuración se encuentra en:

```text
k8s/RECURSOS.md
```

---

## 4. Labels y Selectors

Los recursos utilizan la etiqueta:

```yaml
app: practica2-api
```

El Deployment utiliza esta etiqueta para identificar los Pods que administra:

```yaml
selector:
  matchLabels:
    app: practica2-api
```

El Service utiliza el mismo selector:

```yaml
selector:
  app: practica2-api
```

De esta manera, el Service puede identificar los Pods correspondientes y dirigirles el tráfico.
El uso coherente de labels y selectors permite mantener la relación entre el Deployment, los Pods y el Service.

---

## 5. Comandos principales

### Docker

```bash
docker build -t practica2-api:v1 .
docker images
docker run -d -p 8080:8080 --name practica2-api practica2-api:v1
docker ps
```

### Kubernetes

```bash
kubectl apply -f k8s/namespace.yaml
kubectl apply -f k8s/deployment.yaml
kubectl apply -f k8s/service.yaml
```

Verificación:

```bash
kubectl get namespace
kubectl get deployments -n practica2
kubectl get pods -n practica2
kubectl get svc -n practica2
kubectl get endpoints -n practica2
```

Acceso local mediante `port-forward`:

```bash
kubectl port-forward svc/practica2-api-service 8081:80 -n practica2
```

---

## 6. Evidencias

Las evidencias del proceso se encuentran organizadas en la carpeta:

```text
evidencias/
```

### Docker

Se incluyen evidencias de:

- Construcción de la imagen.
- Validación de la imagen Docker.
- Contenedor ejecutándose en Docker Desktop.
- API funcionando mediante `localhost:8080`.

### Kubernetes

Se incluyen evidencias de:

- Aplicación del Deployment.
- Pods en estado `Running`.
- Deployment y ReplicaSet.
- Descripción del Deployment.
- Manifiesto del Deployment.
- Creación y validación del Namespace.
- Creación y validación del Service.
- Endpoints asociados al Service.
- Descripción del Service.
- API funcionando mediante `port-forward`.
- Acceso a OpenAPI.
- Manifiestos de Namespace y Service.

---

## 7. Video de demostración

Video de demostración de la práctica:

**[Agregar aquí el enlace de YouTube]**

El video presenta el proceso de ejecución de la API, construcción de la imagen Docker, ejecución del contenedor y posterior despliegue y validación en Kubernetes.

---

## 8. Conclusión

La práctica permitió realizar el proceso completo de despliegue de una API REST, comenzando con su containerización mediante Docker y continuando con su ejecución dentro de Kubernetes.
La implementación permitió comprobar la relación entre la imagen Docker, el Deployment, los Pods y el Service. También se verificó la configuración de recursos, labels y selectors necesarios para mantener una comunicación correcta entre los componentes.
Durante la validación se presentó una dificultad con el acceso mediante `NodePort` en el entorno local utilizado. Esta situación se solucionó mediante `kubectl port-forward`, permitiendo comprobar correctamente el funcionamiento de la API desplegada en Kubernetes.
