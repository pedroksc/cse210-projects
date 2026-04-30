using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();
        string name = GetName();
        int favoriteNumber = GetFavoriteNumber();
        int birthYear = GetBirthYear();
        int square = SquareNumber(favoriteNumber);
        DisplayResult(name, square, birthYear);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string GetName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int GetFavoriteNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int favoriteNumber = int.Parse(Console.ReadLine());
        return favoriteNumber;
    }

    static int GetBirthYear()
    {
    Console.Write("Please enter the year you were born: ");
        int birthYear = int.Parse(Console.ReadLine());
        return birthYear;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {square}.");
        Console.WriteLine($"{name}, you will turn {2026 - birthYear} years old this year.");
    }

}