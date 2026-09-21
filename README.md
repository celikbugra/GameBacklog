# GameBacklog

A C# console application for managing a personal video game backlog.

The project provides basic game management features such as storing game data,
tracking play state, ratings and playtime, and searching games by title.

## Features

- Game model with title, platform, state, rating and playtime
- Controlled game state changes
- Rating validation
- Playtime tracking
- Game library for storing multiple games
- Add and remove games
- Search games by title
- Display game details
- Platform and game state enums
- Configurable console typewriter output

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
│   ├── Game.cs
│   ├── GameLibrary.cs
│   ├── Program.cs
│   └── GameBacklog.Cli.csproj
├── GameBacklog.sln
└── README.md
```

## Architecture

The current application is structured around a small set of responsibilities:

- `Game` represents a single game and controls changes to its state, rating and playtime
- `GameLibrary` manages a collection of games and provides lookup and display functionality
- `Enums` contains strongly typed values for platforms and game states
- `ConsoleHelper` provides reusable console output behavior
- `Config` stores shared configuration values

The project uses encapsulation to prevent unrestricted changes to game properties
and exposes dedicated methods for updating game state, rating and playtime.

## Running the Project

Requires the .NET SDK.

Build the project:

```bash
dotnet build
```

Run the console application:

```bash
dotnet run --project GameBacklog.Cli
```

## Planned Development

The project is intended to be expanded step by step with:

- Database persistence
- Entity Framework Core
- ASP.NET Core REST API
- Separate client application

## Technologies

- C#
- .NET
- Object-oriented programming
- Git