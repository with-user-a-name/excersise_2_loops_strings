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
        public const string Val3 = "3";
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

                    case MenuHelpers.Val3:
                        RepeatTenTimes val3 = new RepeatTenTimes(ui);
                        val3.RunIt();
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
                $"{MenuHelpers.Val3}. Repeat ten times {Environment.NewLine}" +
                $"{MenuHelpers.Quit}. Quit {Environment.NewLine}{Environment.NewLine}");

            ui.Print($"Enter choice 0 to {MenuHelpers.Val2}: ");
        }

    }

    class RepeatTenTimes
    {
        private ConsoleUI ui;
        public string? Text { get; set; }

        public void GetText()
        {
            ui.Print("Enter an arbitrary piece of text: ");
            Text = ui.GetInput();
        }

        public void printText(int repeatXTimes = 10)
        {
            if (Text == null || Text.Length == 0) { return; }
            for (int i = 1; i <= repeatXTimes; i++)
            {
                if (i < repeatXTimes)
                {
                    ui.Print($"{i}. {Text}, ");
                }
                else
                {
                    ui.Print($"{i}. {Text}");
                }
            }
            ui.Print(Environment.NewLine);
        }

        public void RunIt()
        {
            GetText();
            printText();
        }

        public RepeatTenTimes(ConsoleUI ui)
        {
            this.ui = ui;
            Text = null;
        }
    }

    class MovieVisitor
    {

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

        public MovieVisitor(ConsoleUI ui)
        {
            this.ui = ui;
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

        public MovieVisitors(ConsoleUI ui)
        {
            this.ui = ui;
            movieVisitors = new List<MovieVisitor>();
            TotalCost = 0;
        }
    }
}
