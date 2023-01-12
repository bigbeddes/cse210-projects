using System;

class Program
{
    static void Main(string[] args)
    {
        static void Body()
        {
            DisplayWelcome();
            string name=PromptUserName();
            int number=PromptUserNumber();
            int squaredNumber=SquareNumber(number);
            DisplayResult(name, squaredNumber);
        }
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }
        static string PromptUserName()
        {
            Console.Write("What is your name: ");
            string name=Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.Write("What is your favorite number: ");
            string response=Console.ReadLine();
            int number=int.Parse(response);
            return number;
        }
        static int SquareNumber(int number)
        {
            int calc=number*number;
            return calc;
        }
        static void DisplayResult(string name, int calc)
        {
            Console.WriteLine($"{name}, the square of your number is {calc}");
        }

        Body();
    }
}