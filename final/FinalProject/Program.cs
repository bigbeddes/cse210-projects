using System;

class Program
{
    static void Main(string[] args)
    {
        bool run;
        Console.Clear();

        // Authenticates and Authorizes user through login process.
        Database db = new Database();

        //repeats logged in user menu until logout and save is selected
        Employee currentUser = db.UserLogin();
        if (currentUser != null)
        {
            do
            {
                run=currentUser.RunMenu();
            }
            while (run);
            db.FinalSave();
        }
        
        
        
        Console.WriteLine("Thank you for using the Payroll Application.");
        Thread.Sleep(4000);
    }
}