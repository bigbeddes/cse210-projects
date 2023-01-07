using System;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";

        Console.Write("What is your grade percentage? (example- 98) ");
        string grade = Console.ReadLine();
        int numberGrade = int.Parse(grade);

        if (numberGrade >= 90)
        {
            letter="A";
        }
        else if (numberGrade >= 80)
        {
            letter="B";
        }
        else if (numberGrade >= 70)
        {
            letter="C";
        }
        else if (numberGrade >= 60)
        {
            letter="D";
        }
        else
        {
            letter="F";
        }

        if (numberGrade>=70)
        {
            Console.WriteLine($"You got a {letter}. Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine($"You got a {letter}. You didn't pass, please try again.");
        }
        
    }
}