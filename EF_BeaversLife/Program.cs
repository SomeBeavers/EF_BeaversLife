using System;
using System.Collections.Generic;
using System.Linq;
using CoreLib_Common;
using CoreLib_Common.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_BeaversLife
{
    class Program
    {
        static void Main(string[] args)
        {
            SeedDB();

            Console.ForegroundColor = ConsoleColor.Green;
                Test1();

            Console.ForegroundColor = ConsoleColor.White;
        }

        // TODO [for me]: use ef_method template to generate simple ef method
        private static void Test1()
        {
            using var context = new AnimalContext();
            var s = context.Clubs;

            try
            {
                var firstBeaver = context.Beavers.Include(x => x.Clubs).OrderBy(x => x.Id).First();

                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(firstBeaver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SeedDB()
        {
            using var context = new AnimalContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            #region Seed TPT (Animal)

            var beaver1 = new Beaver
            {
                Name = "SomeBeavers1",
                Age = 27,
                Fluffiness = FluffinessEnum.VeryFluffy,
                Size = 15
            };
            var beaver2 = new Beaver
            {
                Name = "SomeBeavers2",
                Age = 26,
                Fluffiness = FluffinessEnum.Fluffy,
                Size = 14
            };
            var beaver3 = new Beaver
            {
                Name = "SomeBeavers3",
                Age = 25,
                Fluffiness = FluffinessEnum.NotFluffy,
                Size = 13
            };
            var beaver4 = new Beaver
            {
                Name = "SomeBeavers4",
                Age = 24,
                Fluffiness = FluffinessEnum.Fluffy,
                Size = 12
            };
            var beaver5 = new Beaver
            {
                Name = "SomeBeavers5",
                Age = 23,
                Fluffiness = FluffinessEnum.VeryFluffy,
                Size = 11
            };

            var crow1 = new Crow
            {
                Name = "Crowly",
                Age = 5,
                Color = "black",
                Size = 1
            };
            var crow2 = new Crow
            {
                Name = "Crowly1",
                Age = 5,
                Color = "black",
                Size = 1
            };
            var crow3 = new Crow
            {
                Name = "Crowly2",
                Age = 22,
                Color = "black",
                Size = 4
            };
            var crow4 = new Crow
            {
                Name = "Crowly3",
                Age = 50,
                Color = "white",
                Size = 10
            };
            var crow5 = new Crow
            {
                Name = "Crowly4",
                Age = 5,
                Color = "pink",
                Size = 1
            };

            var deer1 = new Deer
            {
                Name = "Dasher",
                Age = 1,
                Horns = true
            };
            var deer2 = new Deer
            {
                Name = "Dancer",
                Age = 2,
                Horns = true
            };
            var deer3 = new Deer
            {
                Name = "Prancer",
                Age = 1,
                Horns = false
            };
            var deer4 = new Deer
            {
                Name = "Vixen",
                Age = 1,
                Horns = true
            };
            var deer5 = new Deer
            {
                Name = "Comet",
                Age = 1,
                Horns = true
            };
            var deer6 = new Deer
            {
                Name = "Cupid",
                Age = 1,
                Horns = false
            };
            var deer7 = new Deer
            {
                Name = "Donder ",
                Age = 1,
                Horns = true
            };
            var deer8 = new Deer
            {
                Name = "Blitzen",
                Age = 1,
                Horns = true
            };



            #endregion

            var club1 = new Club
            {
                Title = "TreesWorshipers",
                Animals = new List<Animal>(){beaver1,beaver2}
            };

            context.Beavers.Add(beaver1);
            context.Beavers.Add(beaver2);
            context.Beavers.Add(beaver3);
            context.Beavers.Add(beaver4);
            context.Beavers.Add(beaver5);

            context.Crows.Add(crow1);
            context.Crows.Add(crow2);
            context.Crows.Add(crow3);
            context.Crows.Add(crow4);
            context.Crows.Add(crow5);

            context.Deers.Add(deer1);
            context.Deers.Add(deer2);
            context.Deers.Add(deer3);
            context.Deers.Add(deer4);
            context.Deers.Add(deer5);
            context.Deers.Add(deer6);
            context.Deers.Add(deer7);
            context.Deers.Add(deer8);
            context.Clubs.Add(club1);

            context.SaveChanges();
        }
    }
}
