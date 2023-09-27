# Proyecto-NoSQL

# Configuración del Entorno de Desarrollo

Este proyecto utiliza MongoDB y Redis como parte de su infraestructura. A continuación, se detallan los pasos para configurar y cargar datos en MongoDB Compass y Redis en tu máquina local.

## MongoDB Compass

MongoDB Compass es una herramienta gráfica para interactuar con MongoDB. Sigue estos pasos para descargarlo e instalarlo en tu máquina:

1. Ve al sitio web de MongoDB y descarga MongoDB Compass desde [aquí](https://www.mongodb.com/try/download/compass).

2. Ejecuta el archivo de instalación descargado y sigue las instrucciones para instalar MongoDB Compass en tu máquina.

3. Una vez instalado, abre MongoDB Compass y sigue los pasos para conectarte a tu instancia local de MongoDB o a una instancia remota, según corresponda.

## Carga de Datos en MongoDB Compass

A continuación, se describe cómo cargar los datos de votantes, presidentes y diputados en MongoDB Compass. Utilizaremos las clases `Votante`, `Presidente`, y `Diputado` del proyecto como referencia para la estructura de datos.

### Votantes

Los votantes son personas habilitadas para votar. Puedes registrarlos en MongoDB Compass con la siguiente estructura:

```json
{
    "Id": 1,
    "Nombre": "Nombre del Votante",
    "Apellido": "Apellido del Votante",
    "IdTipoDocumento": 1,
    "Documento": "Documento del Votante",
    "Cuil": "CUIL del Votante",
    "padronElectoral": {
        "NroOrden": 1,
        "Distrito": 1,
        "CIRC": 1,
        "Seccion": 1,
        "Mesa": 1
    },
    "Voto": false
}
```

### Presidentes

Los presidentes son candidatos a la presidencia y pueden tener una lista de diputados asociados. Puedes registrarlos en MongoDB Compass con la siguiente estructura:

```json
{
    "Id": 1,
    "Nombre": "Nombre del Presidente",
    "VicePresidente": "Nombre del Vicepresidente",
    "Diputados": [
        {
            "Id": 1,
            "Nombre": "Nombre del Diputado 1"
        },
        {
            "Id": 2,
            "Nombre": "Nombre del Diputado 2"
        }
        // Agrega más diputados si es necesario
    ]
}
```

---
