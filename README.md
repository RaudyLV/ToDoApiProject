# ToDoApi - Una Simple API de Lista de Tareas (Práctica)

Este proyecto es una API RESTful sencilla para gestionar una lista de tareas pendientes (To-Do List). Fue creado principalmente como un ejercicio práctico para afianzar mis habilidades con Git y explorar algunos conceptos específicos del desarrollo .NET.

## Propósito Principal

El objetivo principal de este proyecto no fue seguir una arquitectura de software compleja, sino más bien:

* **Practicar el flujo de trabajo de Git:** Desde la creación del repositorio, la gestión de commits, la creación y fusión de ramas, hasta la resolución de conflictos.
* **Experimentar con la autenticación y autorización en .NET:** Se implementó la autenticación de usuarios utilizando **ASP.NET Core Identity** para el registro y login de usuarios.
* **Integrar la autenticación con JWT (JSON Web Tokens):** Para asegurar las rutas de la API, se generan y validan tokens JWT después del inicio de sesión.
* **Familiarizarme con conceptos básicos de APIs RESTful:** Creación de endpoints para las operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre las tareas.
* **Utilizar Entity Framework Core (EF Core):** Para interactuar con una base de datos (la configuración específica de la base de datos se encuentra en la configuración).
* **Manejar modelos y controladores en ASP.NET Core.**
* **Configuración básica de la API (appsettings.json).**

## Funcionalidades Implementadas

La API `ToDoApi` permite realizar las siguientes acciones sobre las tareas:

* **Obtener todas las tareas:** `GET /api/tasks` (requiere autenticación con JWT).
* **Obtener una tarea por su ID:** `GET /api/tasks/{id}` (requiere autenticación con JWT).
* **Crear una nueva tarea:** `POST /api/tasks` (requiere autenticación con JWT).
* **Actualizar una tarea existente:** `PUT /api/tasks/{id}` (requiere autenticación con JWT).
* **Eliminar una tarea:** `DELETE /api/tasks/{id}` (requiere autenticación con JWT).
* **Registro de usuarios:** `POST /api/auth/register`.
* **Inicio de sesión de usuarios:** `POST /api/auth/login` (devuelve un token JWT).

## Conceptos Clave Practicados

Durante el desarrollo de este proyecto, se hizo énfasis en la práctica de los siguientes conceptos:

* **Git:**
    * Creación y gestión de un repositorio local y remoto (GitHub).
    * Realización de commits significativos y descriptivos.
    * Creación y fusión de ramas para el desarrollo de funcionalidades.
    * Resolución de conflictos de merge (si ocurrieron).
    * Uso de `.gitignore` para excluir archivos innecesarios.
* **ASP.NET Core Identity:**
    * Configuración de Identity para la gestión de usuarios (registro, login).
    * Uso de `UserManager` y `SignInManager`.
    * Configuración de roles (aunque en esta versión simple no se implementó la autorización basada en roles).
* **JWT (JSON Web Tokens):**
    * Generación de tokens JWT después de un inicio de sesión exitoso.
    * Configuración de la autenticación basada en JWT para proteger los endpoints de la API.
    * Uso del middleware de autenticación de JWT en ASP.NET Core.
    * Configuración de la clave secreta, la duración del token, etc.
* **APIs RESTful:**
    * Uso de los verbos HTTP (GET, POST, PUT, DELETE) de acuerdo a las convenciones REST.
    * Devolución de códigos de estado HTTP apropiados.
    * Serialización de datos en formato JSON para las solicitudes y respuestas.
* **Entity Framework Core (EF Core):**
    * Definición de modelos de datos (entidades).
    * Configuración del `DbContext` para interactuar con la base de datos.
    * Realización de operaciones CRUD utilizando EF Core.
    * (Posiblemente) Uso de migraciones de EF Core para gestionar el esquema de la base de datos.
* **Inyección de Dependencias:**
    * Utilización del sistema de inyección de dependencias integrado en ASP.NET Core para registrar y consumir servicios.
* **Configuración:**
    * Uso del archivo `appsettings.json` para configurar la cadena de conexión a la base de datos, la configuración de JWT, etc.

## Instrucciones para Ejecutar (si alguien quisiera probarlo localmente)

1.  **Clonar el repositorio:** `git clone https://github.com/sindresorhus/del`
2.  **Navegar al directorio del proyecto:** `cd ToDoApi`
3.  **Aplicar las migraciones de la base de datos (si aplica):** `dotnet ef database update`
4.  **Ejecutar la API:** `dotnet run`

La API estará disponible en `http://localhost:5014` (el puerto puede variar, revisa la salida de la consola al ejecutar).

## Notas Adicionales

Este proyecto fue creado con fines de aprendizaje y práctica. No sigue una arquitectura de software compleja ni implementa todas las consideraciones de una aplicación de producción (como validación exhaustiva, manejo de errores avanzado, pruebas unitarias completas, etc.). El enfoque principal fue la experimentación con Git y los conceptos mencionados.

¡Gracias por revisar este proyecto!
