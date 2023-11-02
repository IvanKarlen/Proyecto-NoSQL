# Programacion-NoSQL

Aplicación en ejecución de un sitio web desarrollado con ASP.NET CORE consumiendo 2 bases de datos NoSql distintas. Se deberá ejemplificar como conectarse a una base de datos a través del driver para cada base de datos. 


# Proyecto Elecciones Presidenciales 2023

Este proyecto muestra una aplicación web desarrollada con ASP.NET que utiliza dos bases de datos NoSQL distintas: MongoDB y Redis. A continuación, se detallan los pasos para instalar MongoDB Compass y Redis en tu entorno local, junto con las configuraciones y la carga de datos en MongoDB Compass.

## MongoDB Compass

1. Descarga [MongoDB Compass](https://www.mongodb.com/try/download/compass) desde el sitio web oficial de MongoDB.

2. Instala MongoDB Compass siguiendo las instrucciones proporcionadas.

3. Abre MongoDB Compass y conecta con tu instancia local o remota de MongoDB.

## Carga de Datos en MongoDB Compass

A continuación, se describe cómo cargar los datos de votantes, presidentes y jefes de gobierno en MongoDB Compass.

### Votantes

Los votantes son personas habilitadas para votar. Aquí se muestra un ejemplo de la estructura de un votante que puedes registrar en MongoDB Compass:

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

Presidentes
Los presidentes son candidatos a la presidencia y pueden tener una lista de jefes de gobierno asociados. Aquí se muestra un ejemplo de la estructura de un presidente que puedes registrar en MongoDB Compass:

```json
{
    "Id": 1,
    "Nombre": "Nombre del Presidente",
    "VicePresidente": "Nombre del Vicepresidente",
    "JefesDeGobierno": [
        {
            "Id": 1,
            "Nombre": "Nombre del Jefe de Gobierno 1"
        },
        {
            "Id": 2,
            "Nombre": "Nombre del Jefe de Gobierno 2"
        }
        // Agrega más jefes de gobierno si es necesario
    ]
}
```

## Redis

Para instalar Redis:

1. Descarga e instala Redis desde [aquí](https://redis.io/download).
2. Sigue las instrucciones proporcionadas en el sitio web para instalar Redis en tu sistema operativo.

Para configurar la conexión con Redis:

Abre el archivo appsettings.json o un archivo de configuración similar en tu proyecto.

Agrega la cadena de conexión de Redis:
```json
{
  "ConnectionStrings": {
    "Redis": "localhost:6379,ssl=false,abortConnect=False"
  }
}
```

Esta cadena de conexión es un ejemplo genérico. Asegúrate de reemplazar los valores con la dirección y los detalles de configuración de tu servidor Redis.

## Paquetes NuGet

Asegúrate de agregar los siguientes paquetes NuGet a tu proyecto:

- MongoDB.Driver: Este paquete proporciona un cliente .NET para MongoDB.
- StackExchange.Redis: Ofrece un cliente .NET para Redis.

Puedes instalar estos paquetes desde la consola del Administrador de Paquetes en Visual Studio usando los siguientes comandos:

```shell
Install-Package MongoDB.Driver
Install-Package StackExchange.Redis
```
