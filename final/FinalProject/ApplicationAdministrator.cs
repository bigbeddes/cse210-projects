using System;
public class ApplicationAdministrator : IPosition
{

    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval:");
        Console.WriteLine("2 Has ability to review a user's time status (submitted, approved, paid");
        Console.WriteLine("3 Add new users");
        Console.WriteLine("4 Change existing user Role and or group");
        Console.WriteLine("5 Deactivate user");
        Console.WriteLine("6 Reset password for a call in user");
        Console.WriteLine("7 Update your password.");
        Console.WriteLine("8 Logout");
        userSelection=int.Parse(Console.ReadLine());


        return userSelection;
    }
}