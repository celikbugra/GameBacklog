using GameBacklog.Cli;
using GameBacklog.Cli.Enums;

Game witcher3           = new Game("The Witcher 3",           Platform.PC,          GameState.Playing,    rating: 10, playTimeHours: 1000.8);
Game breathOfTheWild    = new Game("Breath Of The Wild",      Platform.Switch,      GameState.Playing,    rating:  9, playTimeHours:  100.4);
Game theLastOfUs        = new Game("The Last Of Us Part I",   Platform.Playstation, GameState.Playing ,   rating: 10, playTimeHours:     23);
Game redDeadRedemption2 = new Game("Red Dead Redemption II",  Platform.Playstation, GameState.Completed,  rating: 10, playTimeHours:    500);

GameLibrary library = new GameLibrary();

library.AddGame(witcher3);
library.AddGame(breathOfTheWild);
library.AddGame(theLastOfUs);
library.AddGame(redDeadRedemption2);

//library.ShowAllGameDetails();

library.FindGameByTitle("The Witcher 3");
library.FindGameByTitle("Halo 4");

Console.ReadLine();