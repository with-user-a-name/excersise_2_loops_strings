C# Exercise - Flow Control Using Loops and String Manipulation

Note: The result of the exercise must be shown to the teacher and approved before it can be considered completed.

The exercise can be written entirely in the program class with the menu in the Main method.
Main Menu

Create a main menu for the program that keeps it alive and informs the user. To create the program's main menu, you should do the following:

    Inform the user that they have reached the main menu and that they will navigate by entering numbers to test different functions.
    Create the structure for a switch statement that initially includes two cases: one for "0" to shut down the program and a default case that indicates invalid input.
    Create an infinite iteration, meaning it does not end until we command it to stop. Solve this by creating your own boolean with a corresponding while loop.
    Expand the menu with options to execute the other exercises.

Menu Option 1: Youth or Senior

To exemplify the use of if-statements, implement a program that checks if a person is a senior or youth at a specified age for a hypothetical local cinema. To access this function, create a case in the main menu for "1," which should also be stated in the text explaining the menu.

You will use a nested if-statement. The process should be as follows:

    The user enters an age in numbers.
    The program converts this from a string to an int.
    The program checks if the person is a youth (under 20 years).
    If true, the program outputs: Youth price: 80 SEK.
    Otherwise, the program checks if the person is a senior (over 64 years).
    If true, the program outputs: Senior price: 90 SEK.
    Otherwise, the program outputs: Standard price: 120 SEK.

We also want the option to calculate the price for a whole group. Add this option to the main menu (case "2"). It is also acceptable to have this option in a submenu. First, we indicate how many people will go to the cinema, then ask for each person's age, and finally print a summary in the console that should include:

    The number of people
    The total cost for the entire group

Menu Option 2: Repeat Ten Times

To use another type of iteration, implement a for-loop here to repeat something that a user inputs ten times. It should not be written using ten separate "Console.Write(Input);" statements but rather via a loop that does this ten times. To access this function, add a case for "3" in your main menu and provide an explanatory text.

The process is as follows:

    The user enters an arbitrary text.
    The program stores the text as a variable.
    The program writes this text out ten times in a row using a for-loop, meaning WITHOUT line breaks. Example of output: 1. Input, 2. Input, 3. Input, etc.

Menu Option 3: The Third Word

You have previously learned how to convert strings to integers (e.g., int.Parse, int.TryParse) but now we will split a string. The user should enter a sentence, which the program will split into words using the string's .Split(char) method. You should split the string at each space. To store this easily, input should be saved as a var since you will get back more than one string.

To test this, create case "4" in your main menu and write an explanation in the text.

The process is explained below:

    The user enters a sentence with at least 3 words.
    The program splits the string using the split method at each space.
    The program extracts the third string (word) from the input.
    The program outputs the third string (word).

Documentation

Don’t forget to comment your code thoroughly so that you or others can easily understand it in the future.
Extra Tasks for Those with Extra Time:

    Validate all user inputs. Ensure that the program doesn’t crash with incorrect input.
    Children under five and seniors over 100 enter for free.
    Handle multiple spaces in a row in part 3.
    Anything else you find interesting to include or want to practice!

Good luck!
