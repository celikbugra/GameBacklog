# GameBacklog

A C# console application for managing a personal video game backlog.

The project is being developed step by step as a learning project focused on object-oriented programming, input validation, separation of responsibilities, automated testing and clean application structure.

## Current Features

* Interactive console menu
* Add games through user input
* Display all stored games
* Search games by title
* Case-insensitive game lookup
* Duplicate title prevention
* Remove games
* Update an existing game's:

  * Platform
  * Game state
  * Rating
  * Playtime
* Track game platform, state, rating and playtime
* Validate game data through encapsulated properties
* Validate console input using `TryParse`
* Validate enum selections using `Enum.IsDefined`
* Configurable console typewriter output
* Automated unit tests using xUnit

## Game Data

Each game currently stores:

* Title
* Platform
* Game state
* Rating from 0 to 10
* Played hours

Supported game states:

* Backlog
* Playing
* Completed
* Dropped

Supported platforms:

* PC
* PlayStation
* Xbox
* Switch

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

The application currently separates its responsibilities into several components:

* `Game` represents a single game and protects its internal state through validated properties and controlled update methods.
* `GameLibrary` manages the collection of games and provides operations for adding, removing, searching and retrieving games.
* `ConsoleMenu` handles user interaction, input parsing and application flow.
* `ConsoleHelper` provides reusable console output functionality.
* `Config` contains shared console configuration values.
* `Platform` and `GameState` provide strongly typed values instead of relying on strings or arbitrary numbers.

## Validation

The project uses multiple validation layers.

`ConsoleMenu` validates user input before passing values to the application.

Examples include:

```csharp
int.TryParse(...)
double.TryParse(...)
Enum.IsDefined(...)
```

The `Game` class additionally protects its own state so that invalid values cannot be stored even when a `Game` is created or modified outside the console menu.

Current validation rules include:

* Game titles cannot be empty or whitespace
* Rating must be between `0` and `10`
* Initial playtime cannot be negative, `NaN` or infinite
* Added playtime must be positive and finite
* Platform values must represent defined enum values
* Game state values must represent defined enum values

Invalid domain values may result in exceptions such as `ArgumentException` or `ArgumentOutOfRangeException`.

## Automated Tests

The project includes a separate xUnit test project.

Current tests cover areas such as:

* Creating games with valid values
* Rejecting invalid ratings
* Rejecting invalid playtime
* Changing ratings with invalid values
* Adding invalid playtime
* Adding games to the library
* Duplicate title prevention
* Case-insensitive duplicate detection
* Finding existing games
* Handling unknown games
* Removing existing games
* Handling attempts to remove unknown games

Run all tests with:

```bash
dotnet test
```

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

Run the automated tests:

```bash
dotnet test
```

## Current Development

The console application currently supports:

```text
1: Show all games
2: Add game
3: Find game
4: Update game
5: Remove game
6: Exit
```

The update system currently supports:

```text
1: Platform
2: State
3: Rating
4: Add playtime
5: Cancel
```

Game data is currently stored in memory using a `List<Game>`.

This means the stored games currently exist only while the application is running.

## Planned Development

Planned next steps include:

* Persistent storage using SQLite
* Database fundamentals and SQL
* Entity Framework Core
* Database migrations
* Further separation between application logic and persistence
* ASP.NET Core REST API
* Separate client application
* Additional automated tests as new features are added

## Technologies

* C#
* .NET 9
* Object-oriented programming
* Nullable reference types
* xUnit
* Git
* GitHub
