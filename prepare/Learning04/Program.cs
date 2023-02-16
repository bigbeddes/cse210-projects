using System;

class Program
{
    static void Main(string[] args)
    {
        //Base Assignment check
        Assignment assignment1=new Assignment("Ryan Beddes", "Addition");
        Console.WriteLine(assignment1.GetSummary());
        //Math check
        MathAssignment math1= new MathAssignment("Ryan Beddes", "Fractions", "7.3", "8-10");
        Console.WriteLine(math1.GetSummary());
        Console.WriteLine(math1.GetHomeworkList());
        //Writing Assignment Check
        WritingAssignment wa1= new WritingAssignment("Ryan Beddes", "European History", "The Causes of World War II");
        Console.WriteLine(wa1.GetSummary());
        Console.WriteLine(wa1.GetWritingInformation());
    }
}