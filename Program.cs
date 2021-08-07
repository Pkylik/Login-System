using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Login_System
{
    class Program
    {
        private static void LogIn()
        {
            //Parses username database
            string[] usernameDatabase = File.ReadAllLines("ExistingUsernames.txt");

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Please enter your username. \n");

            while (true)
            {
                //User inputs username to string
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                string usernameInput = Console.ReadLine();
                Console.WriteLine("");

                //Checks if username exists or not, if so, give option to input password
                if (usernameDatabase.Any(s => usernameDatabase.Contains(usernameInput)))
                {
                    //Parses the inputted username's password file (THIS IS BY NO MEANS SECURE)
                    string[] passwordDatabase = File.ReadAllLines("Passwords/" + usernameInput + ".txt");
                    
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please enter your password. \n");

                    //User inputs password to string
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    string passwordInput = Console.ReadLine();
                    Console.WriteLine("");

                    //Checks if inputted password matches the corrosponding password file
                    if (passwordDatabase.Any(s => passwordDatabase.Contains(passwordInput)))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Log in success. Welcome back.");
                        Console.WriteLine("");

                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Incorrect password used. \n");
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("That username does not exist, please retry. \n");
                }
            }
        }

        private static void SignUp()
        {
            //Parses the username database
            string[] usernameDatabase = File.ReadAllLines("ExistingUsernames.txt");

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Please enter a username you would like to use: \n");

            while (true)
            {
                //User input to string
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                string usernameInput = Console.ReadLine();
                Console.WriteLine("");

                //Checks if username has been taken
                if (usernameDatabase.Any(s => usernameDatabase.Contains(usernameInput)))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("That username has been taken, please choose another one. \n");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Please enter a password you would like to use: \n");

                    //User input to string
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    string passwordInput = Console.ReadLine();
                    Console.WriteLine("");

                    //Creates file with the inputted password
                    using (StreamWriter writer = File.CreateText($"Passwords/{usernameInput}.txt"))
                    {
                        writer.WriteLine(passwordInput);
                    }

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Account created.");
                    Console.WriteLine("");

                    break;
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("Welcome, please type one of the options below.");
            Console.WriteLine("(Log in || Sign up) \n");

            while (true)
            {
                //User input to string
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();
                Console.WriteLine("");

                //User can choose two options, sign up or log in
                switch (userInput)
                {
                    case "Log in":
                        LogIn();
                        break;

                    case "Sign up":
                        SignUp();
                        break;

                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Please use a valid input. \n");
                        break;
                }
            }
        }
    }
}
