using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BGAWebApp.Data;
using System;
using System.Linq;

namespace BGAWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BGAWebAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BGAWebAppContext>>()))
            {
                // Look for any movies.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }

                context.Game.AddRange(
                    new Game
                    {
                        Title = "Azul",
                        Rating = 7.8M,
                        BestCount = "2",
                        RecommendCount = "34",
                        SupportCount = "1234",
                        Link = "https://boardgamegeek.com/boardgame/230802/azul"

                    },

                    new Game
                    {
                        Title = "Space Base",
                        Rating = 7.6M,
                        BestCount = "34",
                        RecommendCount = "25",
                        SupportCount = "12345",
                        Link = "https://boardgamegeek.com/boardgame/242302/space-base"
                    },

                    new Game
                    {
                        Title = "Blood Rage",
                        Rating = 8.0M,
                        BestCount = "4",
                        RecommendCount = "3",
                        SupportCount = "1234",
                        Link = "https://boardgamegeek.com/boardgame/170216/blood-rage"
                    },

                    new Game
                    {
                        Title = "6 nimmt!",
                        Rating = 6.9M,
                        BestCount = "56",
                        RecommendCount = "4789",
                        SupportCount = "123456789",
                        Link = "https://boardgamegeek.com/boardgame/432/6-nimmt"
                    },

                    new Game
                    {
                        Title = "Carcassonne",
                        Rating = 7.4M,
                        BestCount = "2",
                        RecommendCount = "345",
                        SupportCount = "12345",
                        Link = "https://boardgamegeek.com/boardgame/822/carcassonne"
                    },

                    new Game
                    {
                        Title = "Agricola",
                        Rating = 8.0M,
                        BestCount = "4",
                        RecommendCount = "123",
                        SupportCount = "12345",
                        Link = "https://boardgamegeek.com/boardgame/200680/agricola-revised-edition"
                    },

                    new Game
                    {
                        Title = "7 Wonders Duel",
                        Rating = 8.1M,
                        BestCount = "2",
                        RecommendCount = "2",
                        SupportCount = "2",
                        Link = "https://boardgamegeek.com/boardgame/173346/7-wonders-duel"
                    },

                    new Game
                    {
                        Title = "The Castles of Burgundy",
                        Rating = 8.1M,
                        BestCount = "2",
                        RecommendCount = "34",
                        SupportCount = "234",
                        Link = "https://boardgamegeek.com/boardgame/84876/castles-burgundy"
                    },

                    new Game
                    {
                        Title = "Splendor",
                        Rating = 7.4M,
                        BestCount = "3",
                        RecommendCount = "24",
                        SupportCount = "234",
                        Link = "hhttps://boardgamegeek.com/boardgame/148228/splendor"
                    },

                    new Game
                    {
                        Title = "King of Tokyo",
                        Rating = 7.2M,
                        BestCount = "45",
                        RecommendCount = "36",
                        SupportCount = "23456",
                        Link = "https://boardgamegeek.com/boardgame/70323/king-tokyo"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}