# Recursos y convenciones de labels

## Requests y limits del contenedor

El `deployment.yaml` actual declara:

| Recurso | `requests` | `limits` | Lectura práctica |
|---|---:|---:|---|
| CPU | `100m` (0,1 CPU) | `250m` (0,25 CPU) | Kubernetes reserva capacidad de planificación para 0,1 CPU; el contenedor puede usar más cuando haya capacidad, hasta el límite de 0,25 CPU. Al alcanzar el límite, Kubernetes limita (throttle) su CPU. |
| Memoria | `128Mi` | `256Mi` | El scheduler considera 128 MiB al ubicar el Pod; el contenedor puede crecer hasta 256 MiB. Si supera el límite, puede terminar con `OOMKilled`. |

La API del proyecto es una API REST pequeña en ASP.NET Core y el Deployment tiene una réplica. No se cuenta con una prueba de carga y no se ha medido el consumo bajo carga. Por eso usamos como valores iniciales de laboratorio los mismos que la guía del profesor presenta como ejemplo orientativo, no como una capacidad que podría usar un consumo en producción. La diferencia entre request y limit deja margen para picos moderados y mantiene controlado el consumo del contenedor.

## Revisión de labels y selector

Una label es un par clave-valor que permite identificar recursos de Kubernetes. En este proyecto usamos `app: practica2-api` para identificar los Pods que ejecutan nuestra API. El valor describe la aplicación y se mantiene estable aunque Kubernetes reemplace un Pod y le asigne otro nombre generado. Así, los selectores pueden seguir encontrando las réplicas de la API sin depender del nombre individual de cada Pod.

La relación se establece en dos pasos:

- En `deployment.yaml`, `spec.selector.matchLabels.app` debe coincidir con `spec.template.metadata.labels.app`. El Deployment usa ese selector para reconocer y mantener los Pods que crea.
- En `service.yaml`, `spec.selector.app` debe coincidir con la label de los Pods. El Service usa ese selector para encontrar a qué Pods enviar las solicitudes y actualizar sus endpoints.

En los manifiestos revisados, la configuración queda así:

| Recurso | Campo que se revisa | Valor | Propósito |
|---|---|---|---|
| Deployment | `metadata.namespace` | `practica2` | Ubica el Deployment en el namespace de la práctica. |
| Deployment | `metadata.labels.app` | `practica2-api` | Identifica el objeto Deployment para consultas y organización; no selecciona sus Pods. |
| Deployment | `spec.selector.matchLabels.app` | `practica2-api` | Indica qué Pods administra el Deployment. |
| Plantilla de Pod | `spec.template.metadata.labels.app` | `practica2-api` | Asigna a cada Pod la label que el Deployment espera. |
| Service | `metadata.namespace` | `practica2` | Coloca el Service junto con los Pods que debe encontrar. |
| Service | `metadata.labels.app` | `practica2-api` | Identifica el objeto Service para consultas y organización; no dirige el tráfico a los Pods. |
| Service | `spec.selector.app` | `practica2-api` | Hace que el Service seleccione los Pods de la API. |

El namespace también debe coincidir: un Service busca Pods dentro de su propio namespace, por lo que tener la misma label en otro namespace no basta. Si el selector del Service tiene un valor distinto, el objeto Service puede existir, pero su lista de endpoints queda vacía y no tiene Pods a los cuales enviar tráfico. Si un Pod existe pero aún no está listo, su endpoint no se considera listo para recibir el tráfico normal del Service. Las labels de `metadata` identifican los objetos Deployment y Service; los campos que enlazan recursos son `spec.selector.matchLabels` del Deployment, las labels de la plantilla del Pod y `spec.selector` del Service.