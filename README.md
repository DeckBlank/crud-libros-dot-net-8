
# CRUD Libros en .NET 8 con Docker

Este proyecto es un **API ejemplo** construido con **.NET 8** que utiliza **Dapper** para la interacción con la base de datos SQL Server. A continuación, se presentan los pasos para ejecutar este backend y su base de datos en tu entorno local utilizando **Docker**.

## Requisitos previos

Asegúrate de tener instalados los siguientes programas:

- [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0) (para compilar y ejecutar el proyecto)
- [Docker](https://www.docker.com/get-started) (para ejecutar el contenedor de SQL Server)
- [Git](https://git-scm.com/) (para clonar el repositorio)

## Pasos para levantar el backend

### 1. Clona el repositorio

Primero, clona el repositorio del proyecto:

```bash
git clone https://github.com/DeckBlank/crud-libros-dot-net-8.git
cd crud-libros-dot-net-8
```

### 2. Levantar el contenedor de SQL Server

Este proyecto usa **SQL Server** como base de datos. Para evitar tener que instalarlo manualmente, puedes ejecutar un contenedor de Docker con la siguiente instrucción:

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123!" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

Este comando hará lo siguiente:

- Aceptará el EULA de SQL Server (`ACCEPT_EULA=Y`).
- Configurará la contraseña del administrador del sistema (`SA_PASSWORD=YourPassword123!`).
- Mapeará el puerto **1433** del contenedor al puerto **1433** de tu máquina local (puedes cambiarlo si es necesario).
- Usará la imagen de SQL Server 2022 más reciente.

> **Nota:** Cambia `YourPassword123!` por una contraseña más segura si es necesario.

### 3. Configurar la cadena de conexión

En el archivo `appsettings.json`, asegúrate de que la cadena de conexión a la base de datos esté configurada correctamente para conectar con el contenedor de SQL Server.

Ejemplo de la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=MyDatabase;User Id=sa;Password=YourPassword123!"
  }
}
```

### 4. Restaurar las dependencias

Desde el directorio del proyecto, ejecuta el siguiente comando para restaurar las dependencias del proyecto:

```bash
dotnet restore
```

### 5. Ejecutar el el servicio

Ahora puedes ejecutar el backend con el siguiente comando:

```bash
dotnet run
```

Esto levantará el servidor y podrás acceder a la API en `https://localhost:5001` o `http://localhost:5000`, dependiendo de la configuración del proyecto.

### 6. Acceder a Swagger

Si tienes **Swagger** configurado en tu proyecto, podrás acceder a la documentación de la API en:

```
https://localhost:5001/swagger
```

### 7. Detener el contenedor de SQL Server

Cuando hayas terminado, puedes detener el contenedor de SQL Server con el siguiente comando:

```bash
docker stop sqlserver
```

Si quieres eliminar el contenedor después de detenerlo:

```bash
docker rm sqlserver
```

## Problemas comunes

- **Error de conexión a SQL Server**: Asegúrate de que el contenedor de Docker está en ejecución y que la cadena de conexión en el archivo `appsettings.json` es correcta.
- **Error de autenticación en SQL Server**: Verifica que la contraseña configurada para el usuario `sa` sea la correcta.

## Contribuciones

Si deseas contribuir a este proyecto, por favor sigue los siguientes pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -am 'Añadir nueva funcionalidad'`).
4. Haz push a tu rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un pull request en GitHub.

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.
