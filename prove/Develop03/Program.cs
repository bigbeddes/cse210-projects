using System;

class Program
{
    static void Main(string[] args)
    {
        //get desired scripture to memerize from user
        Reference newReference=new Reference();
        newReference.DisplayScriptureOptions();

        // designate how many words will be hidden at random
        Scripture theScripture=new Scripture(newReference.GetReferenceText(), newReference.GetScriptureText());
        Console.WriteLine("Please enter the number of words you would like to hide per turn.");
        int hiddenWordPerTurn=int.Parse(Console.ReadLine());
        bool test=false;
        string userInput="";
        do
        {
            Console.WriteLine($"{theScripture.GetDisplayText()}");
            test=theScripture.IsCompletelyHidden();
            theScripture.HideWords(hiddenWordPerTurn);

            Console.Write("Enter quit to end the program or just enter to continue. ");
            userInput=Console.ReadLine();
            if (test==true)
            {
                userInput="quit";
            }
            Console.Clear();
            
        }
        while(userInput!="quit");
    }
}