# GameBacklog

A C# console application for managing a personal video game backlog.

The project is being developed incrementally with a focus on clean structure, validation, automated testing and persistent storage.

## Features

- Add, search and remove games
- Display stored games
- Update platform, game state, rating and playtime
- Case-insensitive title lookup
- Duplicate title prevention
- Input and domain validation
- Automated tests with xUnit
- SQLite persistence in development

## Game Data

Each game contains:

- Title
- Platform
- Game state
- Rating
- Playtime

Supported platforms:

- PC
- PlayStation
- Xbox
- Switch

Supported states:

- Backlog
- Playing
- Completed
- Dropped

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
│
├── GameBacklog.Tests/
│   ├── GameTests.cs
│   ├── GameLibraryTests.cs
│   └── GameBacklog.Tests.csproj
│
├── GameBacklog.sln
└── README.md
```

## Architecture

The application separates its main responsibilities:

- `Game` represents a game and protects its state through validation.
- `GameLibrary` manages the current collection of games.
- `ConsoleMenu` handles user input and application flow.
- `ConsoleHelper` provides reusable console output functionality.
- `GameBacklog.Tests` contains automated unit tests.

## Database

SQLite is being integrated to replace the current in-memory storage.

The database uses a `Games` table containing:

- Id
- Title
- Platform
- State
- Rating
- PlayTimeHours

`Microsoft.Data.Sqlite` is used for direct SQLite access from C#.

## Tests

The project uses xUnit for automated testing.

Run all tests with:

```bash
dotnet test
```

## Run

Build the solution:

```bash
dotnet build
```

Run the console application:

```bash
dotnet run --project GameBacklog.Cli
```

## Planned Development

- Complete SQLite persistence
- Load games from the database on startup
- Persist add, update and remove operations
- Remove hardcoded startup data
- Entity Framework Core
- Database migrations
- ASP.NET Core REST API
- Separate client application

## Technologies

- C#
- .NET 9
- SQLite
- Microsoft.Data.Sqlite
- xUnit
- Git
- GitHub