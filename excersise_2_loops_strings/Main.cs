using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace excersise_2_loops_strings
{

    public class MenuHelpers
    {
        public const string Val1 = "1";
        public const string Val2 = "2";
        public const string Quit = "0";
    }


    public class ConsoleUI
    {

        public void Print(string message)//, string? nl = null)
        {
            //if (nl == null)
            //{
                Console.Write(message);
            //}
            //else
            //{
            //    Console.WriteLine(message);
            //}

        }

        public string GetInput()
        {
            return Console.ReadLine() ?? string.Empty;
        }

        public void PressAnyKeyToContinue()
        {
            Console.WriteLine("");
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }

    internal class Main
    {
        private ConsoleUI ui;
        public Main()
        {
            ui = new ConsoleUI();
        }
        public void Run()
        {
            bool exit = false;

            do
            {
                Console.Clear();
                ShowMainMenu();
                string menuSelection = ui.GetInput();
                ui.Print(Environment.NewLine);

                switch (menuSelection)
                {
                    case MenuHelpers.Val1:
                        MovieVisitor val1 = new MovieVisitor(ui);
                        val1.RunIt();
                        ui.PressAnyKeyToContinue();
                        break;

                    case MenuHelpers.Val2:
                        MovieVisitors val2 = new MovieVisitors(ui);
                        val2.RunIt();
                        ui.PressAnyKeyToContinue();
                        break;

                    case MenuHelpers.Quit:
                        exit = true;
                        break;

                    default:
                        ui.Print($"Invalid selection \"{menuSelection}\" please try again. {Environment.NewLine}");
                        ui.PressAnyKeyToContinue();
                        break;

                }
            }
            while (!exit);
        }

        private void ShowMainMenu()
        {
            ui.Print($"This is the main menu of console application \"{Process.GetCurrentProcess().ProcessName}\".{Environment.NewLine}");
            ui.Print($"Select a menu item in the menu by entering the corresponding number to the left. {Environment.NewLine}");
            ui.Print(
                $"{MenuHelpers.Val1}. Calculate movie ticket price for one person {Environment.NewLine}" +
                $"{MenuHelpers.Val2}. Calculate total price for a group of movie visitors {Environment.NewLine}" +
                $"{MenuHelpers.Quit}. Quit {Environment.NewLine}{Environment.NewLine}");

            ui.Print($"Enter choice 0 to {MenuHelpers.Val2}: ");
        }

    }

    class MovieVisitor
    {
        //To do this, you will use a nested if-statement.It should proceed
        //as follows:
        //
        //    1. The user inputs an age in numbers.
        //    2. The program converts this from a string to an integer.
        //    3. The program checks if the person is a youth (under 20 years old).
        //    4. If the above is true, the program should print: Youth price: 80 SEK.
        //    5. Otherwise, the program checks if the person is a pensioner (over 64 years old).
        //    6. If the above is true, the program should print: Pensioner price: 90 SEK.
        //    7. Otherwise, the program should print: Standard price: 120 SEK.

        public int Age { get; set; }
        public int TicketPrice { get; set; }
        //TODO 2511102316: Should use enum or class or similar instead of a string for age category.
        public string AgeCategory { get; set; }

        private ConsoleUI ui;
        public void GetAge()
        {
            ui.Print("Enter the age of the cinema visitor: ");
            string str = ui.GetInput();
            //TODO 2511102154: Need to add verification of input here.
            Age = int.Parse(str);
            CalculateTicketPrice();
        }

        public void PrintTicketPrice()
        {
            ui.Print($"{AgeCategory} price: {TicketPrice} kr {Environment.NewLine}");
        }

        public void CalculateTicketPrice()
        {
            if (Age < 20)
            {
                TicketPrice = 80;
                AgeCategory = "Youth";
            }
            else if (Age > 64)
            {
                TicketPrice = 90;
                AgeCategory = "Senior";
            }
            else
            {
                TicketPrice = 120;
                AgeCategory = "Standard";
            }
        }

        public void RunIt()
        {
            GetAge();
            PrintTicketPrice();
        }

        public MovieVisitor(ConsoleUI pUi)
        {
            ui = pUi;
            TicketPrice = 0;
            AgeCategory = string.Empty;
        }

    }

    class MovieVisitors
    {
        private List<MovieVisitor> movieVisitors;

        public int NrVisitors { get; set; }
        public int TotalCost { get; set; }
        
        private ConsoleUI ui;

        public void GetNumberOfVisitors()
        {
            ui.Print("Enter number of movie visitors: ");
            string str = ui.GetInput();
            //TODO 2511102154: Need to add verification of input here.
            NrVisitors = int.Parse(str);
        }
        public void CalculateTotalPriceForMovieVisitors()
        {
            foreach (MovieVisitor movieVisitor in movieVisitors)
            {
                TotalCost += movieVisitor.TicketPrice;
            }
        }

        public void RunIt()
        {
            GetNumberOfVisitors();
            AddMovieVisitors();
            CalculateTotalPriceForMovieVisitors();
            ui.Print($"The number of movie visitors are: {movieVisitors.Count} {Environment.NewLine}");
            ui.Print($"The total cost for the movie visitors: {TotalCost} kr {Environment.NewLine}");
        }

        public void AddMovieVisitors()
        {
            for (int nr = 0; nr < NrVisitors; nr++)
            {
                MovieVisitor movieVisitor = new MovieVisitor(ui);
                movieVisitor.GetAge();
                movieVisitors.Add(movieVisitor);
            }
        }

        public MovieVisitors(ConsoleUI pUi)
        {
            ui = pUi;
            movieVisitors = new List<MovieVisitor>();
            TotalCost = 0;
        }
    }
}
