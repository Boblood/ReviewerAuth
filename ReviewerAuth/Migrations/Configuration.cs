namespace ReviewerAuth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ReviewerAuth.Models;
    using System.Diagnostics;
    using System.Collections.Generic;
    internal sealed class Configuration : DbMigrationsConfiguration<ReviewerAuth.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Reviewer.GRDB";
        }

        protected override void Seed(ReviewerAuth.Models.ApplicationDbContext context)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Debugger.Launch();
            }
            context.Games.AddOrUpdate(x => x.GameID,
                new Game
                {
                    GameID = 1,
                    Name = "Super Mario Brothers",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(1985, 9, 13),
                    //GameConsoles = new List<GameSystem>() { GameSystem.NES },
                    Description = "The first Console Mario",
                    ReasonForGreatness = "OG status"
                },
                new Game
                {
                    GameID = 2,
                    Name = "The Legend of Zelda",
                    Publisher = "Nintendo",
                    ReleaseDate = new DateTime(1986, 2, 21),
                    //GameConsoles = new List<GameSystem>() { GameSystem.NES },
                    Description = "The first Console Zelda",
                    ReasonForGreatness = "OG status"
                },
                new Game
                {
                    GameID = 3,
                    Name = "Halo: Combat Evolved",
                    Publisher = "Microsoft Game Studios",
                    ReleaseDate = new DateTime(2001, 11, 15),
                    //GameConsoles = new List<GameSystem>() { GameSystem.Xbox, GameSystem.Xbox360 }
                    Description = "The first Console Halo",
                    ReasonForGreatness = "OG status and impact on Game community"
                });

            context.GameConsoles.AddOrUpdate(x => x.ID,
                new GameConsoles
                {
                    ID = 1,
                    RefID = 1,
                    GameID = context.Games.FirstOrDefault(x => x.GameID == 1),
                    //GameID = 1,
                    CurrentGameSystem = GameSystem.NES
                },
                new GameConsoles
                {
                    ID = 2,
                    RefID = 2,
                    GameID = context.Games.FirstOrDefault(x => x.GameID == 2),
                    //GameID = 2,
                    CurrentGameSystem = GameSystem.NES
                },
                new GameConsoles
                {
                    ID = 3,
                    RefID = 3,
                    GameID = context.Games.FirstOrDefault(x => x.GameID == 3),
                    //GameID = 3,
                    CurrentGameSystem = GameSystem.Xbox
                },
                new GameConsoles
                {
                    ID = 4,
                    RefID = 3,
                    GameID = context.Games.FirstOrDefault(x => x.GameID == 3),
                    //GameID = 3,
                    CurrentGameSystem = GameSystem.Xbox360
                });
        }
    }
}
