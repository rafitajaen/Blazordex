# Blazerdex
 Creando una Pokedex con Blazor WebAssembly. La aplicación obtiene la información haciendo peticiones HTTP a [PokeAPI](https://pokeapi.co/).

 Puedes ver el resultado final en el siguiente enlace: https://blazordex.web.app

## Objetivos del Proyecto

 - Utilizar Blazor
 - Peticiones HTTP a PokeAPI
 - Renderización Listas
 - Enrutado simple
 - Formulario para manejar una búsqueda
 - Continuous Deployment con GitHub Actions


 ## Stack Utilizado
 - .NET 6 + Blazor
 - Bootstrap v5
 - [.NET CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/) + Firebase CLI (vía npm)
 - GitHub Actions + Firebase Hosting
 - VSCode


 ## Screenshots

 ![Imagen del proyecto](/Assets/Blazordex-screenshot.jpg)


 ## Descripción de los pasos efectuados

 ### 1. Instalación
 Creación de nuevo proyecto:
 ```
 dotnet new blazorwasm -o Blazordex
 ```

 Instalación de .NET Webassembly build tools:
 ```
 dotnet workload install wasm-tools
 ```

 Instalación del paquete para añadir peticiones HTTP:
 ```
 dotnet add package Microsoft.Extensions.Http --version 6.0.0
 ```

 ### 2. Creación de los Modelos

 - Reside en la carpeta [/Models](/Models/)
 - Documentación de refencia del [Pokemon Endpoint](https://pokeapi.co/docs/v2#pokemon).
 - Documentación de C# sobre el tipo primitivo `record` (Desde C# 9), que provee funcionalidades para encapsular datos: [Link](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/record)
 - Documentación de C# sobre *Init only setters* para eliminar el boilerplate en los constructores: [Link](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/init)

Serializamos el modelo a través de los siguientes **records**: 
 `NamedModel`, `Sprites`, `PokemonTypes`, `Pokemon`, `GetPokemonListResponse`


 ### 3. Creación del Cliente

 - Reside en la carpeta [/Clients](/Clients/)

Creación de la clase `PokeClient` que utiliza los métodos: 
  - **GetPokemons(int offset)**: Para cargar más Pokemons
  - **GetPokemon(string url)**: 
  - **GetPokemonByNameOrId(string identifier)**:

 Necesitamos que la configuración del cliente apunte a la API de PokeAPI. Para ello configuramos `appsettings.json` en **/wwwroot** y lo registramos en `Program.cs`

 ### 4. Configuración
 - `PokeApiOptions` reside en la carpeta [/Configurations](/Configurations/)
 -  Necesitamos que la configuración apunte a la API de PokeAPI. Para ello configuramos `BaseAddress` en [appsetings.json](/wwwroot/appsettings.json)
 - Debemos también registrar la configuración en [Program.cs](/Program.cs)

 ### 5. Creación de Shared Components
 - Los componentes residen en [/Shared/Components](/Shared/Components/)

 En particular, los componentes `<PokemonCard>`, `<PokemonTypes>` serán consumidos por las páginas.

 #### 5.1 Creación de Backgrounds personalizados
 En función de los tipos de cada Pokemon se añade un background personalizado. El código reside en: [PokemonCard.razor](/Shared/Components/PokemonCard.razor)
 - Utilizamos un [Diccionario](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.-ctor?view=net-6.0) para mapear los colores. `Key` es el Identificador y `Value` es el color rgb.
 - El método `getBackgroundByType()` es el encargado de asignar los backgrounds a cada tarjeta.

 ### 6. Creación de Páginas
 - Las páginas residen en [/Pages](/Pages/)

 El proyecto sólo utiliza dos páginas: [Index](/Pages/Index.razor) y [PokemonDetails](/Pages/PokemonDetails.razor)

 ### 7. Dar un poco de estilo
 Los estilos están distribuídos en:
  - Clases para los elementos en Bootstrap, y
  - En los `.css` asociados a cada archivo `.razor` para los detalles más personalizados.
  - CSS inline para los `backgrounds` en función de los tipos de cada Pokemon.

  

### 8. Continuous Deployment 
 1. Crear un nuevo proyecto en [Firebase](https://console.firebase.google.com/)
 2. Instalar firebase CLI
 ```
npm install -g firebase-tools
 ```
 3. Asegurarse de tener abierto VSCode como administrador (*Lo necesitaras para ejecutar comandos de firebase*)
 4. Cambiar la directiva de ejecución: [Documentación](https://docs.microsoft.com/es-es/powershell/module/microsoft.powershell.core/about/about_execution_policies?view=powershell-7.2) - [Solución](https://github.com/firebase/firebase-tools/issues/1627)
 ```
Set-ExecutionPolicy -ExecutionPolicy Bypass -Scope CurrentUser
 ```
 5. Login en Firebase
 ```
firebase login
 ```
 6. Inicializar el proyecto y seguir los pasos de Firebase CLI
 ```
firebase init
 ```
 7. Publicar en el directorio `release/wwwroot`
 8. Script para ejecutar antes de cada deploy
  ```
dotnet publish -c Release -o release
 ```


**Agradecimiento especial**

A Adre Lopes - [@alopes2](https://github.com/alopes2) por mostrar sus [conocimientos](https://medium.com/geekculture/creating-a-pokedex-with-blazor-webassembly-677b5bcf3593) de una forma divertida y a [@ssmkhrj](https://github.com/ssmkhrj) por la [inspiración](https://ssmkhrj.github.io/Pokemon-Pokedex/).


