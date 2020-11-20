#region test

using System;
using System.Collections.Generic;
using System.Linq;
using CoreLib_Common;
using CoreLib_Common.Model;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EF_BeaversLife
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SeedDB();

            Console.ForegroundColor = ConsoleColor.Green;
            Test1();

            Console.ForegroundColor = ConsoleColor.White;

            using var context = new AnimalContext();

            context.Database.EnsureDeleted();
        }

        // TODO [for me]: use ef_method template to generate simple ef method
        private static void Test1()
        {
            using var context = new AnimalContext();
            var s = context.Clubs;

            try
            {
                var firstBeaver = context.Beavers
                                         // includes
                                         .Include(x => x.Clubs)
                                         .Include(x => x.Grades)
                                         .Include(x => x.Job)
                                         // other
                                         .OrderBy(x => x.Id)
                                         .First();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(firstBeaver);

                if (firstBeaver.Clubs != null)
                {
                    foreach (var club in firstBeaver.Clubs)
                    {
                        Console.Write("\t");

                        Console.WriteLine(club);

                        foreach (var location in club.Locations)
                        {
                            Console.Write("\t");
                            Console.Write("\t");

                            Console.WriteLine(location);
                        }
                    }
                }

                if (firstBeaver.Grades != null)
                {
                    foreach (var grade in firstBeaver.Grades)
                    {
                        Console.Write("\t");

                        Console.WriteLine(grade);
                    }
                }

                Console.Write("\t");

                Console.WriteLine(firstBeaver.Job);
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

            #endregion

            #region Seed Many-to-many (Club)

            var club1 = new Club
            {
                Title = "TreesWorshipers",
                Animals = new List<Animal> {beaver1, beaver2, beaver3, beaver4, beaver5, crow4},
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "North America"
                    },
                    new Location
                    {
                        Address = "Canada"
                    },
                    new Location
                    {
                        Address = "Russia"
                    }
                }
            };

            var club2 = new Club
            {
                Title = "CornLovers",
                Animals = new List<Animal> {crow1, crow2, crow3, crow4, crow5},
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "Westeros"
                    }
                }
            };

            var club3 = new Club
            {
                Title = "ChristmasTeam",
                Animals = new List<Animal>
                {
                    beaver1, beaver2, beaver3, beaver4, beaver5,
                    crow1, crow2, crow3, crow4, crow5,
                    deer1, deer2, deer3, deer4, deer5, deer6, deer7, deer8
                },
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "North Pole"
                    }
                }
            };

            context.Clubs.Add(club1);
            context.Clubs.Add(club2);
            context.Clubs.Add(club3);

            #endregion

            #region Seed Grades

            var grade1 = new Grade
            {
                TheGrade = 5,
                Club = club1,
                Animal = beaver1
            };
            var grade2 = new Grade
            {
                TheGrade = 4,
                Club = club1,
                Animal = beaver2
            };
            var grade3 = new Grade
            {
                TheGrade = 3,
                Club = club1,
                Animal = beaver3
            };
            var grade4 = new Grade
            {
                TheGrade = 3,
                Club = club1,
                Animal = beaver4
            };
            var grade5 = new Grade
            {
                TheGrade = 2,
                Club = club1,
                Animal = beaver5
            };
            var grade6 = new Grade
            {
                TheGrade = 1,
                Club = club1,
                Animal = crow4
            };
            var grade7 = new Grade
            {
                TheGrade = 5,
                Club = club2,
                Animal = crow1
            };
            var grade8 = new Grade
            {
                TheGrade = 4.5,
                Club = club2,
                Animal = crow2
            };
            var grade9 = new Grade
            {
                TheGrade = 2.1,
                Club = club2,
                Animal = crow3
            };
            var grade10 = new Grade
            {
                TheGrade = 4.3,
                Club = club2,
                Animal = crow4
            };

            var grade27 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = beaver1
            };
            var grade26 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = beaver2
            };
            var grade25 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = beaver3
            };
            var grade24 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = beaver4
            };
            var grade23 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = beaver5
            };
            var grade22 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = crow1
            };
            var grade21 = new Grade
            {
                TheGrade = 3.5,
                Club = club3,
                Animal = crow2
            };
            var grade20 = new Grade
            {
                TheGrade = 2.5,
                Club = club3,
                Animal = crow3
            };
            var grade19 = new Grade
            {
                TheGrade = 1.5,
                Club = club3,
                Animal = crow4
            };
            var grade28 = new Grade
            {
                TheGrade = 4.9,
                Club = club3,
                Animal = crow5
            };
            var grade11 = new Grade
            {
                TheGrade = 4.8,
                Club = club3,
                Animal = deer1
            };
            var grade12 = new Grade
            {
                TheGrade = 4.7,
                Club = club3,
                Animal = deer2
            };
            var grade13 = new Grade
            {
                TheGrade = 4.6,
                Club = club3,
                Animal = deer3
            };
            var grade14 = new Grade
            {
                TheGrade = 4.5,
                Club = club3,
                Animal = deer4
            };
            var grade15 = new Grade
            {
                TheGrade = 4.4,
                Club = club3,
                Animal = deer5
            };
            var grade16 = new Grade
            {
                TheGrade = 4.3,
                Club = club3,
                Animal = deer6
            };
            var grade17 = new Grade
            {
                TheGrade = 4.2,
                Club = club3,
                Animal = deer7
            };
            var grade18 = new Grade
            {
                TheGrade = 4.1,
                Club = club3,
                Animal = deer8
            };

            context.Grades.Add(grade1);
            context.Grades.Add(grade2);
            context.Grades.Add(grade3);
            context.Grades.Add(grade4);
            context.Grades.Add(grade5);
            context.Grades.Add(grade6);
            context.Grades.Add(grade7);
            context.Grades.Add(grade8);
            context.Grades.Add(grade9);
            context.Grades.Add(grade10);
            context.Grades.Add(grade11);
            context.Grades.Add(grade12);
            context.Grades.Add(grade13);
            context.Grades.Add(grade14);
            context.Grades.Add(grade15);
            context.Grades.Add(grade16);
            context.Grades.Add(grade17);
            context.Grades.Add(grade18);
            context.Grades.Add(grade19);
            context.Grades.Add(grade20);
            context.Grades.Add(grade21);
            context.Grades.Add(grade22);
            context.Grades.Add(grade23);
            context.Grades.Add(grade24);
            context.Grades.Add(grade25);
            context.Grades.Add(grade26);
            context.Grades.Add(grade27);
            context.Grades.Add(grade28);

            #endregion

            #region Seed Jobs

            var job1 = new Job
            {
                Title = "Builder",
                Salary = 1,
                Animals = new List<Animal>
                {
                    beaver1, beaver2, beaver3, beaver4, beaver5
                }
            };
            var job2 = new Job
            {
                Title = "Messenger",
                Salary = 10,
                Animals = new List<Animal>
                {
                    crow1, crow2, crow3, crow4
                }
            };
            var job3 = new Job
            {
                Title = "Delivery",
                Salary = 100,
                Animals = new List<Animal>
                {
                    deer1, deer2, deer3, deer4, deer5, deer6, deer7, deer8
                }
            };

            context.Jobs.Add(job1);
            context.Jobs.Add(job2);
            context.Jobs.Add(job3);

            #endregion

            context.SaveChanges();
        }
    }
}