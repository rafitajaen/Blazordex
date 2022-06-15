# Blazerdex
 Creando una Pokedex con Blazor WebAssembly. La aplicación obtiene la información haciendo peticiones HTTP a [PokeAPI](https://pokeapi.co/).

## Elementos del Proyecto

 - Peticiones HTTP a PokeAPI
 - Renderización Listas
 - Enrutado simple
 - Formulario para manejar una búsqueda

 **Imagen del proyecto**

 ## Stack
 - .NET 6 y Blazor
 - [.NET CLI](https://docs.microsoft.com/en-us/dotnet/core/tools/)
 - VSCode

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

 ### 6. Creación de Páginas
 - Las páginas residen en [/Pages](/Pages/)

 El proyecto sólo utiliza dos páginas: [Index](/Pages/Index.razor) y [PokemonDetails](/Pages/PokemonDetails.razor)


