using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"The default fraction is: {fraction1.GetFractionString()}");
        Console.WriteLine($"The decimal value of the default fraction is: {fraction1.GetDecimalValue()}");

        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"\nThe fraction with whole number 5 is: {fraction2.GetFractionString()}");
        Console.WriteLine($"The decimal value of this fraction is: {fraction2.GetDecimalValue()}");

        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"\nThe fraction with top 3 and bottom 4 is: {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value of this fraction is: {fraction3.GetDecimalValue()}");

        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine($"The fraction with top 1 and bottom 3 is: {fraction4.GetFractionString()}");
        Console.WriteLine($"The decimal value of this fraction is: {fraction4.GetDecimalValue()}");

        // Testing setters
        fraction3.SetTop(1);
        fraction3.SetBottom(2);
        Console.WriteLine($"\nAfter setting top to 1 and bottom to 2, the fraction is: {fraction3.GetFractionString()}");
        Console.WriteLine($"The decimal value of this updated fraction is: {fraction3.GetDecimalValue()}");
    }
}