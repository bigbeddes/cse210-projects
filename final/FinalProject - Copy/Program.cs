using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Compiler compiler = new Compiler(); 

        // Authenticates and Authorizes user through login process.
        string type = compiler.Login();

        if (type=="HR")
        {
            compiler.HRMenu();
        }

        else if (type=="ApplicationAdministrator")
        {
            compiler.ApplicationAdministratorMenu();
        }

        else if (type=="Manager")
        {
            compiler.ManagerMenu();
        }

        else if (type=="BaseEmployee")
        {
            compiler.BaseEmployeeMenu();
        }
        Console.Write("Thank you for using the Payroll Application.");
        Thread.Sleep(4000);
    }
}