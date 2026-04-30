using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        

        List<int> numbersList = new List<int>();
        Console.Write("Enter number: ");
        int number = int.Parse(Console.ReadLine());
        while (number != 0)
        {
            numbersList.Add(number);
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("The sum is: " + numbersList.Sum());
        Console.WriteLine("The average is: " + numbersList.Average());
        Console.WriteLine("The largest number is: " + numbersList.Max());
    }
}