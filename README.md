# Programacion-NoSQL

Aplicación en ejecución de un sitio web desarrollado con ASP.NET consumiendo 2 bases de datos NoSql distintas. Se deberá ejemplificar como conectarse a una base de datos a través del driver para cada base de datos. 

# Configuración del Entorno de Desarrollo

Este proyecto utiliza MongoDB y Redis. A continuación, se detallan los pasos para instalar MongoDB Compass y Redis en tu máquina local y cómo agregar los paquetes NuGet necesarios para el proyecto.

## MongoDB Compass

1. Ve al [sitio web de MongoDB](https://www.mongodb.com/try/download/compass) y descarga MongoDB Compass.
2. Ejecuta el instalador y sigue las instrucciones para instalar MongoDB Compass en tu máquina.

## Configuración de Conexión

Para configurar la conexión con MongoDB:

1. Abre el archivo `appsettings.json` o un archivo de configuración similar en tu proyecto.
2. Agrega la cadena de conexión de MongoDB:

   ```json
   {
     "ConnectionStrings": {
       "MongoDB": "mongodb://localhost:27017/NombreBaseDeDatos"
     }
   }

## Redis

Para instalar Redis:

1. Descarga e instala Redis desde [aquí](https://redis.io/download).
2. Sigue las instrucciones proporcionadas en el sitio web para instalar Redis en tu sistema operativo.

Para configurar la conexión con Redis:

Abre el archivo appsettings.json o un archivo de configuración similar en tu proyecto.

Agrega la cadena de conexión de Redis:

{
  "ConnectionStrings": {
    "Redis": "localhost:6379,ssl=false,abortConnect=False"
  }
}

Esta cadena de conexión es un ejemplo genérico. Asegúrate de reemplazar los valores con la dirección y los detalles de configuración de tu servidor Redis.

Paquetes NuGet
Asegúrate de agregar los siguientes paquetes NuGet a tu proyecto:

MongoDB.Driver: Este paquete proporciona un cliente .NET para MongoDB.
StackExchange.Redis: Ofrece un cliente .NET para Redis.
Puedes instalar estos paquetes desde la consola del Administrador de Paquetes en Visual Studio usando los siguientes comandos:

```shell
Install-Package MongoDB.Driver
Install-Package StackExchange.Redis
Con estos pasos, tendrás las configuraciones de conexión para MongoDB y Redis en tu proyecto.
```

Estos detalles ayudarán a los colaboradores a establecer y configurar correctamente las conexiones a MongoDB y Redis en el proyecto. Puedes agregar estos pasos al README de tu repositorio para proporcionar información adicional sobre cómo configurar estas conexiones en el proyecto.

## Paquetes NuGet

Asegúrate de agregar los siguientes paquetes NuGet a tu proyecto:

- MongoDB.Driver: Este paquete proporciona un cliente .NET para MongoDB.
- StackExchange.Redis: Ofrece un cliente .NET para Redis.

Puedes instalar estos paquetes desde la consola del Administrador de Paquetes en Visual Studio usando los siguientes comandos:

```shell
Install-Package MongoDB.Driver
Install-Package StackExchange.Redis
```
