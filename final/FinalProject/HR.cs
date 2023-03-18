using System;
public class HR : IPosition
{
    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval:");
        Console.WriteLine("2 Has ability to review reports from each department head");
        Console.WriteLine("3 Submit approved timesheets to be paid.");
        Console.WriteLine("4 Update your password");
        Console.WriteLine("5 Logout");
        userSelection=int.Parse(Console.ReadLine());

        return userSelection;
    }
}