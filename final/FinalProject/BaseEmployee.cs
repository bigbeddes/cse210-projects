using System;
public class BaseEmployee : IPosition
{

    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 Update your password.");
        Console.WriteLine("3 Save changes and logout.");
        userSelection=int.Parse(Console.ReadLine());

        return userSelection;
    }

}