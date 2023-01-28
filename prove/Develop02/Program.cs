using System;

class Program
{
    static void Main(string[] args)
    {
        int selection = 0;
        Entry newEntry=new Entry();
        Questions question=new Questions();
       
        do
        {
            //display and ask for menue options//
            Console.WriteLine("\nPlease select a number from one of the options:\n1 Make a journal entry.\n2 List journal questions.\n3 Open a different journal file.\n4 Displaay journal entries.\n5 Close journal application");
            string userInput= Console.ReadLine();
            selection=int.Parse(userInput);
            //make a journal entry//
            if (selection == 1)
            {
                //get random question//
                newEntry._selectedJournalQuestion= question.RandomQuestion(question._questions);
                //make journal entry//
                Console.WriteLine(newEntry._selectedJournalQuestion);
                newEntry._journalEntry=Console.ReadLine();
                //get todays date and convert to string//
                var todayDate=DateTime.Today;
                newEntry._journalDate=todayDate.ToString();
                //create a new journal entry//
                newEntry.AppendEntries(newEntry._selectedJournalQuestion, newEntry._journalEntry, newEntry._journalDate, newEntry._journalFilename); 
            }
            //change journal entry question//
            else if (selection == 2)
            {
                question.DisplayQuestions(question._questions);
            }
            //open custom journal file//
            else if (selection == 3)
            {
                Console.WriteLine("please type the full journal file name that you would like to open in the myJournal folder (example: myJournal.csv):");
                string filename=Console.ReadLine();
                newEntry._journalFilename=$"myJournal\\{filename}";
            }
            //display journal entries//
            else if (selection == 4)
            {
                newEntry.DisplayEntries(newEntry._journalFilename);
            }
            //number not in range//
            else if (selection <1 || selection> 5)
            {
                Console.WriteLine("The number you entered is outside the selection range, please try again.");
            }
            //close journal application//
            else
            {
                Console.WriteLine("Thank you for using the My Journal application");
            }
        } 
        while (selection != 5);
        
    }
}