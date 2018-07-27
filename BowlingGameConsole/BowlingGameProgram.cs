using BowlingGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameConsole
{
    public class BowlingGameProgram
    {
        //Entry Point Method

        static void Main(string[] args)
        {
            // Initialize Variables
            int sessionCt = 1;
            int isRunning = 1;
            string usrInput = "";

            List<int> SessionScores = new List<int>();

            // Application Start
            Console.WriteLine("Bowling Game Console Application v1.0:");
            Console.WriteLine("Author: Scott Peabody | scottpeabodyis@gmail.com");
            Console.WriteLine("-------------------------------------------------");

            // Game Session Loop
            do
            {
                Console.WriteLine("\r\nPlay New Game? Please input [y/n] then press Enter");
                usrInput = Console.ReadLine();
                if (usrInput == "y")
                {
                    // Start New Game
                    var game = new BowlingGame();
                    int frameTotal = 11;
                    int frameRollCt = 1;
                    int frameScore = 0;
                    int fromSpare = 0;
                    Console.WriteLine("\r\n--------------------\nBowling Session " + sessionCt++ + "\r\n--------------------" );
                    for (var frameCt = 1; frameCt < frameTotal; frameCt++)
                    {
                        // Refactor Code needed in this section
                        // Need to redo the validation method.
                        
                        // Reminder for next time: 
                        // Use the TDD methods more thoroughly to write simplified functions for console in the library.


                        Console.WriteLine("========================================================");
                        bool notValid = true;

                        while (notValid)
                        {
                            try
                            {
                                if(frameRollCt == 1)
                                {
                                    Console.WriteLine("\n(Enter Frame " + frameCt + " - Roll " + frameRollCt + " Score):   [0-9]   [x = Strike]");
                                    usrInput = Console.ReadLine();
                                    if(usrInput=="x")
                                    {
                                        usrInput = "10";
                                    }

                                    int usrInputInt = Convert.ToInt16(usrInput);

                                    while (!BetweenRanges(0, 10, usrInputInt))
                                    {
                                        Console.WriteLine("Not a valid score, Type a number between [0-9] or [x = Strike");
                                        usrInputInt = Convert.ToInt16(Console.ReadLine());
                                    }
                                    frameScore = usrInputInt;
                                    game.Roll(usrInputInt);

                                    if(usrInputInt != 10)
                                    {
                                        frameRollCt = 2; // roll again
                                    }
                                    else
                                    {
                                        if (frameCt == 10)
                                        {
                                            frameRollCt = 3; // extra roll
                                        }
                                        else
                                        {
                                            notValid = false; // next frame due to strike
                                        }
                                        
                                    }
                                }
                                else if(frameRollCt == 2) // next roll on current frame
                                {
                                    Console.WriteLine("\n(Enter Frame " + frameCt + " - Roll " + frameRollCt + " Score):   [0-" + (9 - frameScore) + "]  [/ = Spare]");
                                    usrInput = Console.ReadLine();
                                    if (usrInput == "/")
                                    {
                                        usrInput = "" + (10 - frameScore);
                                    }
                                    int usrInputInt = Convert.ToInt16(usrInput);

                                    while (!BetweenRanges(0, (10 - frameScore), usrInputInt))
                                    {
                                        Console.WriteLine("Not a valid score, Type a number between [0-" + (9 - frameScore) + "]  or [/ = Spare");
                                        usrInputInt = Convert.ToInt16(Console.ReadLine());
                                    }
                                    game.Roll(usrInputInt);
                                    frameRollCt = 1;

                                    if(frameCt != 10)
                                    {
                                        notValid = false; //next frame
                                        
                                    }
                                    else
                                    {
                                        if(usrInputInt+frameScore==10)
                                        {
                                            fromSpare = 1;
                                            frameRollCt = 3;
                                        }
                                        else
                                        {
                                            notValid = false; //sesson concludes
                                        } 
                                    }
                                }
                                else
                                {
                                    //From Strike
                                    if (fromSpare == 0)
                                    {
                                        Console.WriteLine("\n(Enter Frame " + frameCt + " - Roll " + (frameRollCt - 1) + " Score):   [0-9]   [x = Strike]");
                                        usrInput = Console.ReadLine();
                                        if (usrInput == "x")
                                        {
                                            usrInput = "10";
                                        }

                                        int usrInputInt = Convert.ToInt16(usrInput);

                                        while (!BetweenRanges(0, 10, usrInputInt))
                                        {
                                            Console.WriteLine("Not a valid score, Type a number between [0-9] or [x = Strike");
                                            usrInputInt = Convert.ToInt16(Console.ReadLine());
                                        }
                                        frameScore = usrInputInt;
                                        game.Roll(usrInputInt);

                                        //290 - Game
                                        Console.WriteLine("\n(Enter Frame " + frameCt + " - Roll " + frameRollCt + " Score):   [0-9]   [x = Strike]");
                                        usrInput = Console.ReadLine();
                                        if (usrInput == "x")
                                        {
                                            usrInput = "10";
                                        }

                                        usrInputInt = Convert.ToInt16(usrInput);

                                        while (!BetweenRanges(0, 10, usrInputInt))
                                        {
                                            Console.WriteLine("Not a valid score, Type a number between [0-9] or [x = Strike");
                                            usrInputInt = Convert.ToInt16(Console.ReadLine());
                                        }
                                        frameScore = usrInputInt;
                                        game.Roll(usrInputInt);
                                    }
                                    else
                                    {
                                        //From Spare
                                        Console.WriteLine("\n(Enter Frame " + frameCt + " - Roll " + frameRollCt + " Score):   [0-9]   [x = Strike]");
                                        usrInput = Console.ReadLine();
                                        if (usrInput == "x")
                                        {
                                            usrInput = "10";
                                        }

                                        int usrInputInt = Convert.ToInt16(usrInput);

                                        while (!BetweenRanges(0, 10, usrInputInt))
                                        {
                                            Console.WriteLine("Not a valid score, Type a number between [0-9] or [x = Strike");
                                            usrInputInt = Convert.ToInt16(Console.ReadLine());
                                        }
                                        frameScore = usrInputInt;
                                        game.Roll(usrInputInt);
                                        
                                    }
                                    notValid = false;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("This is not valid Score entry, try again.\n");
                            }
                        } 
                    }
                    SessionScores.Add(game.Score);
                    Console.WriteLine("\n--------------------\nFinal Score: " + game.Score + "\n--------------------");
                }
                else if (usrInput ==  "n")
                {
                    Console.WriteLine("---------------------------------");
                    int i = 1;
                    foreach(var score in SessionScores) //Display all session scores
                    {
                        Console.WriteLine("Session " + i + " Score: " + score); 
                        i++;
                    }
                    Console.WriteLine("---------------------------------\nPress any key to exit");
                    Console.ReadLine();
                    isRunning = 0;
                }
                else
                {
                    Console.WriteLine("Invalid input: Please press either y or n on your keyboard then press enter.\r\n");
                }

            } while (isRunning == 1);
            Environment.Exit(0);
        }
        public static bool BetweenRanges(int a, int b, int number) 
        {
            return (a <= number && number <= b);
        }
    }
}


