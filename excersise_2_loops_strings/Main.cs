using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace excersise_2_loops_strings
{

    public class MenuHelpers
    {
        public const string Val1 = "1";
        public const string Val2 = "2";
        public const string Val3 = "3";
        public const string Val4 = "4";
        public const string Quit = "0";
    }


    public class ConsoleUI
    {
        public int LeftPos { get; set; }
        public int TopPos { get; set; }

        public ConsoleUI()
        {
            TopPos = Console.CursorTop;
            LeftPos = Console.CursorLeft;
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

        public void Print(string message)
        {
            Console.Write(message);
        }

        public void RestoreCursorPos()
        {
            Console.CursorTop = TopPos;
            Console.CursorLeft = LeftPos;
        }

        public void SaveCursorPos()
        {
            TopPos = Console.CursorTop;
            LeftPos = Console.CursorLeft;
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

                    case MenuHelpers.Val4:
                        TheThirdWord val4 = new TheThirdWord(ui);
                        val4.RunIt();
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
                $"{MenuHelpers.Val4}. The third word {Environment.NewLine}" +
                $"{MenuHelpers.Quit}. Quit {Environment.NewLine}{Environment.NewLine}");

            ui.Print($"Enter choice 0 to {MenuHelpers.Val2}: ");
        }
    }


    class TheThirdWord
    {
        private ConsoleUI ui;

        public string? Sentence { get; set; }
        public string[] WordArray { get; set; }

        public TheThirdWord(ConsoleUI ui)
        {
            this.ui = ui;
            Sentence = null;
            WordArray = Array.Empty<string>();
        }

        public bool GetSentence()
        {
            WordArray = Array.Empty<string>();
            Sentence = String.Empty;
            ui.Print("Enter a sentence that contains at least three words: ");
            Sentence = Regex.Replace(ui.GetInput(), @"\s+", " ");
            WordArray = Sentence.Split(' ');

            if (WordArray.Length < 3)
            {
                ui.Print($"You only entered {WordArray.Length} words! {Environment.NewLine}");
                return false;
            }
            return true;
        }

        public void RunIt()
        {
            if (!GetSentence())
                return;
            ui.Print($"The third word in the sentence is: {WordArray[2]} {Environment.NewLine}");
        }
    }


    class RepeatTenTimes
    {
        private ConsoleUI ui;

        public string? Text { get; set; }

        public RepeatTenTimes(ConsoleUI ui)
        {
            this.ui = ui;
            Text = null;
        }

        public void GetText()
        {
            ui.Print("Enter an arbitrary piece of text: ");
            Text = ui.GetInput();
        }

        public void PrintText(int repeatXTimes = 10)
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
            PrintText();
        }
    }


    class MovieVisitor
    {
        private ConsoleUI ui;

        public int Age { get; set; }
        //TODO 2511102316: Should use enum or class or similar instead of a string for age category.
        public string AgeCategory { get; set; }
        public int TicketPrice { get; set; }

        public MovieVisitor(ConsoleUI ui)
        {
            this.ui = ui;
            TicketPrice = 0;
            AgeCategory = string.Empty;
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

        public void RunIt()
        {
            GetAge();
            PrintTicketPrice();
        }
    }


    class MovieVisitors
    {
        private List<MovieVisitor> movieVisitors;
        private ConsoleUI ui;

        public int NrVisitors { get; set; }
        public int TotalCost { get; set; }

        public MovieVisitors(ConsoleUI ui)
        {
            this.ui = ui;
            movieVisitors = new List<MovieVisitor>();
            TotalCost = 0;
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

        public void CalculateTotalPriceForMovieVisitors()
        {
            foreach (MovieVisitor movieVisitor in movieVisitors)
            {
                TotalCost += movieVisitor.TicketPrice;
            }
        }

        public void GetNumberOfVisitors()
        {
            ui.Print("Enter number of movie visitors: ");
            string str = ui.GetInput();
            //TODO 2511102154: Need to add verification of input here.
            NrVisitors = int.Parse(str);
        }

        public void RunIt()
        {
            GetNumberOfVisitors();
            AddMovieVisitors();
            CalculateTotalPriceForMovieVisitors();
            ui.Print($"The number of movie visitors are: {movieVisitors.Count} {Environment.NewLine}");
            ui.Print($"The total cost for the movie visitors: {TotalCost} kr {Environment.NewLine}");
        }
    }
}
