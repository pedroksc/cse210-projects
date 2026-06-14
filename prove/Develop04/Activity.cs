using System;
using System.Threading;

public class Activity
{
    // Private member variables
    private string _name;
    private string _description;
    private int _duration;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Getters
    public string GetName() => _name;
    public int GetDuration() => _duration;

    // Common starting message shown at the beginning of every activity
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"=== {_name} ===\n");
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How many seconds would you like to do this activity? ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    // Common ending message shown at the end of every activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    // Spinner animation — cycles through characters to show activity
    public void ShowSpinner(int seconds)
    {
        string[] spinChars = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinChars[i % spinChars.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase last character
            i++;
        }
    }

    // Countdown timer — shows ticking numbers down from a value
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the digit
            if (i > 9) Console.Write("\b \b"); // Handle two-digit numbers
        }
    }
}