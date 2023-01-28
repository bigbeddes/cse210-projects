using System;
using System.IO;

 
 public class Questions
 { 
    public  List <string> _questions= new List<string>
    {
        "Who was the most interesting person I interacted with today?","What was the best part of my day?","What was the best food I ate today?","What was the strongest emotion I felt today?","If I had one thing I could do over today, what would it be?","What kind of exercise did I do today?"
    };
    public void DisplayQuestions(List<string> question)
    {
        try
        {
            Console.WriteLine($"\n1 {question[0]}\n2 {question[1]}\n3 {question[2]}\n4 {question[3]}\n5 {question[4]}\n6 {question[5]}\n");
        }
        catch
        {
            Console.WriteLine("An Error Occured while attempting to display the Journal Questions");
        }
    }
    public string RandomQuestion(List<string> questions)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(0,6);
        string randomQuestion=questions[number];
        return randomQuestion;  
    }
 }
    