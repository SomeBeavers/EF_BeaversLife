﻿namespace EF_BeaversLife_Framework;

// NOTE [for me]: use ef_method template to generate simple ef method
// NOTE [for me]: use format_print to paste Console.Write("\t");
internal class Program
{
    private static async Task Main()
    {
        SeedDb();

        Console.ForegroundColor = ConsoleColor.Green;
        // ReSharper disable once MethodHasAsyncOverload
        ExecuteQueries();
        //await ExecuteQueriesAsync();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("!! finish");
        Console.ReadLine();
    }

    private static void ExecuteQueries()
    {
        //new UseReferenceLoad().UseReferenceLoad1();
        //new UseNotMapped().UseNotMapped1();
        //new Mix().UseCustomIdName();
        //new UseComplexType().UseComplexType1();
        //new Mix().UseInverseProperties();
        //new UseIncludeWithSelect().UseIncludeWithSelect1();
        //new UseInclude().UseDbQueryIncludeWithStringPath();
        //new UseInclude().UseExtensionInclude1();

        //new UseEnumeration().DbCallDueToToArray();
        //new UseEnumeration().DbCallDueToToDictionary();
        //new UseEnumeration().DbCallDueToToList();
        //new UseEnumeration().DbCallDueToToList2();
        //new UseEnumeration().DbCallDueToToList3();
        //new UseEnumeration().DbCallDueToFirst();
        //new UseEnumeration().DbCallDueToAny();
        //new UseEnumeration().DbCallDueToLoad();
        //new UseEnumeration().DbCallDueToReload();
        //new UseLocalData().UseLocalData1();
        //new UseLocalData().UseLocalData2();
        //new Mix().UseFind3();

        //new UseLocalData().UseLocalData3();
        //new UseEnumeration().DbCallDueToLoad2();
        //new UseNoTracking().UseNoTracking1();

        //new UseIncludeWithSelect().UseIncludeMultilevel();
        new Mix().UseFind1();
    }

    private static async Task ExecuteQueriesAsync()
    {
        //var useAsync = new UseAsync();
        //await useAsync.UseAsync1();
        //await useAsync.UseAsync2();
        //await useAsync.UseAsync3();

        //await new UseInclude().UseStringIncludeWithWhere1();
    }

    private static void SeedDb()
    {
        using var context = new AnimalContext();

        context.Database.Delete();
        context.Database.Create();

        #region Seed TPT (Animal)

        var beaver1 = new Beaver
        {
            Name = "SomeBeavers1",
            Age = 27,
            Fluffiness = FluffinessEnum.VeryFluffy,
            Size = 15,
            IpAddress = "127.0.0.1"
        };
        var beaver2 = new Beaver
        {
            Name = "SomeBeavers2",
            Age = 26,
            Fluffiness = FluffinessEnum.Fluffy,
            Size = 14,
            IpAddress = "127.0.0.1"
        };
        var beaver3 = new Beaver
        {
            Name = "SomeBeavers3",
            Age = 25,
            Fluffiness = FluffinessEnum.NotFluffy,
            Size = 13,
            IpAddress = "127.0.0.1"
        };
        var beaver4 = new Beaver
        {
            Name = "SomeBeavers4",
            Age = 24,
            Fluffiness = FluffinessEnum.Fluffy,
            Size = 12,
            IpAddress = "127.0.0.1"
        };
        var beaver5 = new Beaver
        {
            Name = "SomeBeavers5",
            Age = 23,
            Fluffiness = FluffinessEnum.VeryFluffy,
            Size = 11,
            IpAddress = "127.0.0.1"
        };

        var crow1 = new Crow
        {
            Name = "Crowly",
            Age = 5,
            Color = "black",
            Size = 1,
            IpAddress = "127.0.0.1"
        };
        var crow2 = new Crow
        {
            Name = "Crowly1",
            Age = 5,
            Color = "black",
            Size = 1,
            IpAddress = "127.0.0.1"
        };
        var crow3 = new Crow
        {
            Name = "Crowly2",
            Age = 22,
            Color = "black",
            Size = 4,
            IpAddress = "127.0.0.1"
        };
        var crow4 = new Crow
        {
            Name = "Crowly3",
            Age = 50,
            Color = "white",
            Size = 10,
            IpAddress = "127.0.0.1"
        };
        var crow5 = new Crow
        {
            Name = "Crowly4",
            Age = 5,
            Color = "pink",
            Size = 1,
            IpAddress = "127.0.0.1"
        };

        var deer1 = new Deer
        {
            Name = "Dasher",
            Age = 1,
            Horns = true,
            IpAddress = "127.0.0.1"
        };
        var deer2 = new Deer
        {
            Name = "Dancer",
            Age = 2,
            Horns = true,
            IpAddress = "127.0.0.1"
        };
        var deer3 = new Deer
        {
            Name = "Prancer",
            Age = 1,
            Horns = false,
            IpAddress = "127.0.0.1"
        };
        var deer4 = new Deer
        {
            Name = "Vixen",
            Age = 1,
            Horns = true,
            IpAddress = "127.0.0.1"
        };
        var deer5 = new Deer
        {
            Name = "Comet",
            Age = 1,
            Horns = true,
            IpAddress = "127.0.0.1"
        };
        var deer6 = new Deer
        {
            Name = "Cupid",
            Age = 1,
            Horns = false,
            IpAddress = "127.0.0.1"
        };
        var deer7 = new Deer
        {
            Name = "Donder ",
            Age = 1,
            Horns = true,
            IpAddress = "127.0.0.1"
        };
        var deer8 = new Deer
        {
            Name = "Blitzen",
            Age = 1,
            Horns = true,
            IpAddress = "127.0.0.1"
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
            Animals = [beaver1, beaver2, beaver3, beaver4, beaver5, crow4],
            Locations =
            [
                new()
                {
                    Address            = "North America",
                    GeographicLocation = DbGeography.FromText("POINT(-122 47)")
                },
                new()
                {
                    Address            = "Canada",
                    GeographicLocation = DbGeography.FromText("POINT(122 40)")
                },
                new()
                {
                    Address            = "Russia",
                    GeographicLocation = DbGeography.FromText("POINT(1 1)")
                }
            ]
        };

        var club2 = new Club
        {
            Title = "CornLovers",
            Animals = [crow1, crow2, crow3, crow4, crow5],
            Locations =
            [
                new()
                {
                    Address            = "Westeros",
                    GeographicLocation = DbGeography.FromText("POINT(00 00)")
                }
            ]
        };

        var club3 = new Club
        {
            Title = "ChristmasTeam",
            Animals =
            [
                beaver1, beaver2, beaver3, beaver4, beaver5,
                crow1, crow2, crow3, crow4, crow5,
                deer1, deer2, deer3, deer4, deer5, deer6, deer7, deer8
            ],
            Locations =
            [
                new()
                {
                    Address            = "North Pole",
                    GeographicLocation = DbGeography.FromText("POINT(9 9)")
                }
            ]
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
            Animals =
            [
                beaver1, beaver2, beaver3, beaver4, beaver5
            ]
        };
        var job2 = new Job
        {
            Title = "Messenger",
            Salary = 10,
            Animals =
            [
                crow1, crow2, crow3, crow4
            ]
        };
        var job3 = new Job
        {
            Title = "Delivery",
            Salary = 100,
            Animals =
            [
                deer1, deer2, deer3, deer4, deer5, deer6, deer7, deer8
            ]
        };

        context.Jobs.Add(job1);
        context.Jobs.Add(job2);
        context.Jobs.Add(job3);

        #endregion

        #region Seed TPH (Food)

        var food1 = new NormalFood
        {
            Title = "Elm",
            Animal = beaver1,
            Taste = Taste.Normal
        };
        var food2 = new VeganFood
        {
            Title = "Daphne laureola",
            Animal = beaver2,
            Calories = 100
        };
        var food3 = new VeganFood
        {
            Title = "Carpinus betulus",
            Animal = beaver3,
            Calories = 1001
        };
        var food4 = new VeganFood
        {
            Title = "Hornbeam",
            Animal = beaver4,
            Calories = 101
        };
        var food5 = new NormalFood
        {
            Title = "Pizza",
            Animal = beaver5,
            Taste = Taste.Excellent
        };
        var food6 = new NormalFood
        {
            Title = "Steak",
            Animal = crow1,
            Taste = Taste.Excellent
        };
        var food7 = new NormalFood
        {
            Title = "Meat",
            Animal = crow2,
            Taste = Taste.Good
        };
        var food8 = new NormalFood
        {
            Title = "Pizza",
            Animal = crow3,
            Taste = Taste.VeryGood
        };
        var food9 = new VeganFood
        {
            Title = "Corn",
            Animal = crow4,
            Calories = 1
        };
        var food10 = new NormalFood
        {
            Title = "Pizza",
            Animal = crow5,
            Taste = Taste.Normal
        };
        var food11 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer1,
            Calories = 10
        };
        var food12 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer2,
            Calories = 10
        };
        var food13 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer3,
            Calories = 10
        };
        var food14 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer4,
            Calories = 10
        };
        var food15 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer5,
            Calories = 10
        };
        var food16 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer6,
            Calories = 10
        };
        var food17 = new NormalFood
        {
            Title = "Elves",
            Animal = deer7,
            Taste = Taste.Excellent
        };
        var food18 = new VeganFood
        {
            Title = "Pizza",
            Animal = deer8,
            Calories = 10
        };

        context.Food.Add(food1);
        context.Food.Add(food2);
        context.Food.Add(food3);
        context.Food.Add(food4);
        context.Food.Add(food5);
        context.Food.Add(food6);
        context.Food.Add(food7);
        context.Food.Add(food8);
        context.Food.Add(food9);
        context.Food.Add(food10);
        context.Food.Add(food11);
        context.Food.Add(food12);
        context.Food.Add(food13);
        context.Food.Add(food14);
        context.Food.Add(food15);
        context.Food.Add(food16);
        context.Food.Add(food17);
        context.Food.Add(food18);

        #endregion

        #region Seed Many-to-many old style (Drawback)

        var drawback1 = new Drawback
        {
            Title = "Crowdy",
            Foods =
            [
                food1, food2, food3, food4, /*food5,*/ food6, food7, food8, food9, food10, food11, food12, food13,
                food14, food15, food16, food17, food18
            ],
            Clubs =
            [
                club1, club2, club3
            ],
            Consequence = new Consequence
            {
                Name = "Nervousness"
            },
            DrawbackDetail = new DrawbackDetails
            {
                DateCreated = DateTime.Now,
                Description = "the quality or state of being nervous"
            }
        };
        var drawback2 = new Drawback
        {
            Title = "Windy",
            Foods =
            [
                food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11, food12, food13,
                food14, food15, food16, food17, food18
            ],
            Clubs =
            [
                club1, club2, club3
            ],
            Consequence = new Consequence
            {
                Name = "Teleportation to Land of Oz"
            },
            DrawbackDetail = new DrawbackDetails
            {
                DateCreated = DateTime.Now,
                Description = "hallucination"
            }
        };
        var drawback3 = new Drawback
        {
            Title = "Soggy",
            Foods =
            [
                food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11, food12, food13,
                food14, food15, food16, food17, food18
            ],
            Clubs =
            [
                club1, club2, club3
            ],
            Consequence = new Consequence
            {
                Name = "Wet clothes"
            },
            DrawbackDetail = new DrawbackDetails
            {
                DateCreated = DateTime.Now,
                Description = "cold"
            }
        };
        var drawback4 = new Drawback
        {
            Title = "Hardy",
            Foods =
            [
                food1, food2, food3, food4, food5, food6, food7, food8, food9, food10, food11, food12, food13,
                food14, food15, food16, food17, food18
            ],
            Clubs =
            [
                club1, club2, club3
            ],
            Consequence = new Consequence
            {
                Name = "Sadness"
            },
            DrawbackDetail = new DrawbackDetails
            {
                DateCreated = DateTime.Now,
                Description = "the condition or quality of being sad"
            }
        };

        context.Drawbacks.Add(drawback1);
        context.Drawbacks.Add(drawback2);
        context.Drawbacks.Add(drawback3);
        context.Drawbacks.Add(drawback4);

        var jobDrawback1 = new JobDrawback
        {
            Job = job1,
            Drawback = drawback1
        };
        var jobDrawback2 = new JobDrawback
        {
            Job = job1,
            Drawback = drawback2
        };
        var jobDrawback3 = new JobDrawback
        {
            Job = job1,
            Drawback = drawback3
        };
        var jobDrawback4 = new JobDrawback
        {
            Job = job1,
            Drawback = drawback4
        };
        var jobDrawback5 = new JobDrawback
        {
            Job = job2,
            Drawback = drawback1
        };
        var jobDrawback6 = new JobDrawback
        {
            Job = job2,
            Drawback = drawback2
        };
        var jobDrawback7 = new JobDrawback
        {
            Job = job3,
            Drawback = drawback1
        };
        var jobDrawback8 = new JobDrawback
        {
            Job = job3,
            Drawback = drawback2
        };

        context.JobDrawbacks.Add(jobDrawback1);
        context.JobDrawbacks.Add(jobDrawback2);
        context.JobDrawbacks.Add(jobDrawback3);
        context.JobDrawbacks.Add(jobDrawback4);
        context.JobDrawbacks.Add(jobDrawback5);
        context.JobDrawbacks.Add(jobDrawback6);
        context.JobDrawbacks.Add(jobDrawback7);
        context.JobDrawbacks.Add(jobDrawback8);

        #endregion

        #region Seed Persons

        var person1 = new Person
        {
            Name = "BeaverPerson",
            AnimalsLoved = [beaver1, beaver2, beaver3, beaver4, beaver5],
            AnimalsHated = [deer1, deer2, deer3, deer4, deer5, deer6, deer7, deer8]
        };

        context.Persons.Add(person1);

        #endregion

        context.SaveChanges();
    }
}
