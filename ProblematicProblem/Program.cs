using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Linq;

namespace ProblematicProblem
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rng = new Random();
            var cont = false;
            int userAge;
            
            List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };


           
            
            #region Application

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? " +
                "Type \"yes\" or type \"quit\" to exit: ");
            var userInputApp = Console.ReadLine().ToLower();
            while (userInputApp != "quit")
            {

                

                #region Get User Info

                    Console.WriteLine();

                    Console.Write("We are going to need your information first! What is your name? ");
                    string userName = Console.ReadLine();

                    Console.WriteLine();

                do
                {
                    Console.Write("What is your age? ");
                    if (int.TryParse(Console.ReadLine(), out userAge))
                    {
                        cont = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input. Try Again\n");
                        cont = false;
                    }
                } while (!cont);

                Console.WriteLine();

                Console.Write("Would you like to see the current list of activities before we generate a random activity? Sure/No thanks: ");

                bool seeList = false;
                var userInput = Console.ReadLine().ToLower();
                switch (userInput[0])
                {
                    case 'y':
                    case 's':
                        seeList = true;
                        break;
                    default:
                        seeList = false;
                        break;
                }

                #endregion


                #region User Sees List, Appends activities


                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    #region Add Activity

                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");


                    var addToList = false;
                    if (Console.ReadLine().ToLower()[0] == 'y')
                        addToList = true;

                    Console.WriteLine();

                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        userAddition = char.ToUpper(userAddition[0]) + userAddition.Substring(1);

                        activities.Add(userAddition);

                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }

                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        if (Console.ReadLine().ToLower().StartsWith('y'))
                        {
                            addToList = true;
                        }
                        else
                        {
                            addToList = false;
                        }

                    }
                    #endregion


                }
                #endregion



                #region Connect to Database, return Activity

                
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                bool redo = false;
                Console.WriteLine();
                do
                {
                    redo = false;
                    int randomNumber = rng.Next(activities.Count);

                    string randomActivity = activities[randomNumber];

                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Pick something else!");

                        activities.Remove(randomActivity);

                        randomNumber = rng.Next(activities.Count);

                        randomActivity = activities[randomNumber];
                    }

                    Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    var userRedo = Console.ReadLine().ToLower();
                    if (userRedo.StartsWith('r'))
                    {
                        redo = true;
                    }
                    else
                    {
                        userInputApp = "quit";
                    }
                    
                    //userInputApp = "quit";
                    
                } while (redo);
                #endregion
                
               


            }
            
            

            #endregion





        }
    }
}
