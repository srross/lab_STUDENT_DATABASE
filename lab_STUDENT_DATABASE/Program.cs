/* Lab Name: STUDENT_DATABASE
 * Date: 02/17/2022
 * Author: Sonia Ross
 * 
 * Description: Grand Circus Student Lookup Directory is searchable by Student Number or Student Name.
 * */

string[] name = new string[3] { "MORPHEUS", "NEO", "SMITH" };
string[] hometown = new string[3] { "Matrix", "Zion", "Mega City" };
string[] favoriteFood = new string[3] { "Tacos", "Chili Dogs", "Pizza" };
string[] search = new string[2] { "number", "name" };


var viewStudentData = "y";

var searchType = string.Empty;
var student = -1;
var category = String.Empty;

Console.WriteLine("The Grand Circus Directory of Students is searchable by Student Number or Name");

while (viewStudentData == "y")
{
    // student name and number options
    for (int i = 0; i <= name.Length - 1; i++)
    {
        var number = i + 1;
        Console.WriteLine(number.ToString() + " - " + name[i]);
    }
    Console.WriteLine();


    Console.Write("Which search type would you like to use(number/name)? ");
    var searchChoice = Console.ReadLine().ToLower();

    if (!search.Contains(searchChoice))
    {
        Console.WriteLine($"{searchType} is not a valid option.  Would you like to try again (y/n)? ");
    }
    else
    {
        var searchIndex = Array.IndexOf(search, searchChoice); //var searchIndex = Array.FindIndex(search, s => s == searchChoice);
        student = GetStudent(searchIndex);
    }

    category = GetCategory(student);

    switch (category)
    {
        case "hometown":
            Console.WriteLine();
            Console.WriteLine($"The {category} of {name[student]} is {hometown[student]}");
            Console.WriteLine();
            break;
        case "favorite food":
            Console.WriteLine();
            Console.WriteLine($"The {category} of {name[student]} is {favoriteFood[student]}");
            Console.WriteLine();
            break;
    }

    student = -1;
    category = String.Empty;

    Console.Write("Would you like to search the directory for another student (y/n)? ");
    viewStudentData = Console.ReadLine().ToLower();

    Console.WriteLine();
}


int GetStudent(int searchIndex)
{
    var tryAgain = "y";

    while (student == -1 || tryAgain == "y")
    {
        switch (searchIndex)
        {
            case 0:
                var numberInput = 0;
                Console.Write("Please enter the number of the Student you want to learn about: ");
                var isInteger = int.TryParse(Console.ReadLine(), out numberInput);

                if (!isInteger || numberInput <= 0 || numberInput > name.Length)
                {
                    Console.Write($"Sorry, that is not a valid student number.  Would you like to try again (y/n)? ");
                    tryAgain = Console.ReadLine().ToLower();
                    Console.WriteLine();
                }
                else
                {
                    student = numberInput - 1;

                    Console.WriteLine();
                    Console.WriteLine($"Okay, I've found {name[student]} in our student directory.");
                    tryAgain = "n";
                }
                break;

            case 1:
                var nameInput = string.Empty;
                Console.Write("Please enter the name of the Student you want to learn about: ");
                nameInput = Console.ReadLine().ToUpper();

                if (!name.Contains(nameInput))
                {
                    Console.Write($"Sorry, {nameInput} is not an available option. Would you like to try again (y/n): ");
                    tryAgain = Console.ReadLine().ToLower();
                    Console.WriteLine();
                }
                else
                {
                    student = Array.IndexOf(name, nameInput);

                    Console.WriteLine();
                    Console.WriteLine($"Okay, I've found {name[student]} in our student directory.");
                    tryAgain = "n";
                }
                break;
        }
    }
    return student;
}

string GetCategory(int student)
{
    var tryAgain = "y";

    while (category == string.Empty || tryAgain == "y")
    {
        var userInput = string.Empty;

        Console.Write($"For {name[student]}, would you like to know their Hometown or Favorite Food? ");
        userInput = Console.ReadLine().ToLower();

        if (userInput == string.Empty || (userInput != "hometown" && userInput != "favorite food"))
        {
            Console.Write($"Sorry, {userInput} is not an available option. Would you like to try again (y/n): ");
            tryAgain = Console.ReadLine().ToLower();
            Console.WriteLine();
        }
        else
        {
            category = userInput;
            tryAgain = "n";
        }
    }

    return category;
}