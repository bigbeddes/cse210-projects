 using System;
public class Manager : IPosition
{

    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval:");
        Console.WriteLine("2 approve time of employees in group");
        Console.WriteLine("3 submit report of users to be paid.");
        Console.WriteLine("4 Update your password");
        Console.WriteLine("5 Logout");
        userSelection=int.Parse(Console.ReadLine());

        return userSelection;
    }
}