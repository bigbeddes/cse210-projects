using System;

class Program
{
    static void Main(string[] args)
    {
        FileManagement file = new FileManagement();
        int userSelection;

        do
        {
            Console.Clear();
            userSelection=file.PrintMenu();
            Console.Clear();

            if (userSelection ==1)
            {
                file.CreateGoal();
            }
            if (userSelection==2)
            {
                file.DisplayGoals();
            }
            if (userSelection==3)
            {
                file.SaveGoals();
            }
            if (userSelection==4)
            {
                file.OpenGoalFile();
            }
            if (userSelection==5)
            {
                file.RecordEvent();
            }
        }
        while (userSelection !=6); 
        Console.WriteLine("Have a good day!");
        Thread.Sleep(3000);
    }
}
