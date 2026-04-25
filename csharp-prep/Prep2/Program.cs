using System;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string stringGrade = Console.ReadLine();
        int intGrade = int.Parse(stringGrade);

        string letter = "";

        if (intGrade >= 90)
        {
            letter = "A";
        }
        else if (intGrade >= 80)
        {
            letter = "B";
        }
        else if (intGrade >= 70)
        {
            letter = "C";
        }
        else if (intGrade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (intGrade >= 70)
        {
            Console.WriteLine("Congrats! You passed.");
        }
        else
        {
            Console.WriteLine("Sorry, try again next time.");
        }
    }
}