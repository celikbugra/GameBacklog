# GameBacklog

A C# console application for managing a personal video game backlog.

The project is being developed step by step as a learning project focused on
object-oriented programming, input validation, separation of responsibilities
and clean application structure.

## Current Features

- Interactive console menu
- Add games through user input
- Search games by title
- Case-insensitive game lookup
- Duplicate title prevention
- Display stored game information
- Update a game's platform
- Track game platform, state, rating and playtime
- Validate game data through encapsulated properties
- Validate console input using `TryParse`
- Validate enum selections using `Enum.IsDefined`
- Configurable console typewriter output

## Game Data

Each game currently stores:

- Title
- Platform
- Game state
- Rating from 0 to 10
- Played hours

Supported game states:

- Backlog
- Playing
- Completed
- Dropped

Supported platforms:

- PC
- PlayStation
- Xbox
- Switch

## Project Structure

```text
GameBacklog/
├── GameBacklog.Cli/
│   ├── Core/
│   │   └── Config.cs
│   ├── Enums/
│   │   ├── GameState.cs
│   │   └── Platform.cs
│   ├── Helpers/
│   │   └── ConsoleHelper.cs
│   ├── ConsoleMenu.cs
│   ├── Game.cs
│   ├── GameLibrary.cs
│   ├── Program.cs
│   └── GameBacklog.Cli.csproj
├── GameBacklog.sln
└── README.md
```

## Architecture

The application currently separates its responsibilities into several components:

- `Game` represents a single game and protects its internal state through
  validated properties and controlled update methods.
- `GameLibrary` manages the collection of games and provides operations such as
  adding, removing and searching for games.
- `ConsoleMenu` handles user interaction, input parsing and application flow.
- `ConsoleHelper` provides reusable console output functionality.
- `Config` contains shared console configuration values.
- `Platform` and `GameState` provide strongly typed values instead of relying on
  strings or arbitrary numbers.

### Validation

The project uses multiple validation layers.

`ConsoleMenu` validates whether user input can be converted into the required
data type.

For example:

```csharp
int.TryParse(...)
double.TryParse(...)
Enum.IsDefined(...)
```

The `Game` class additionally validates its own state so that invalid values
cannot be stored even when a `Game` is created outside the console menu.

Examples include:

- Rating must be between `0` and `10`
- Playtime cannot be negative, `NaN` or infinite
- Platform and game state must contain defined enum values
- Game titles cannot be empty

## Running the Project

The project currently targets **.NET 9**.

Build the solution:

```bash
dotnet build
```

Run the console application:

```bash
dotnet run --project GameBacklog.Cli
```

## Current Development

The console application currently supports:

```text
1: Show all games
2: Add game
3: Find game
4: Update game
6: Exit
```

The update system currently supports changing a game's platform.

Additional update operations and game removal are still being implemented.

## Planned Development

Planned next steps include:

- Update game state
- Update rating
- Add playtime through the update menu
- Remove games through the console menu
- Further separation of console output from game library logic
- Automated tests
- Database persistence with SQLite
- Entity Framework Core
- ASP.NET Core REST API
- Separate client application

## Technologies

- C#
- .NET 9
- Object-oriented programming
- Nullable reference types
- Git
