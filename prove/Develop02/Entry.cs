using System;
using System.IO;
 
 public class Entry
 {
    public string _journalFilename=@"myJournal\myJournal.csv";
    public string _journalEntry;
    public string _journalDate;
    public string _selectedJournalQuestion;
    
    
    
    public void AppendEntries(string journalQuestion, string journalEntry, string journalDate, string filename)
    {
        try
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filename, true))
            {
                file.WriteLine(journalDate + "," + journalQuestion + "," + journalEntry);
            }
        }
        catch
        {
            Console.WriteLine("Unable to write entry to selected Journal File");
        }
    }

    public void DisplayEntries(string filename)
    {
        try
        {
            string[] lines =System.IO.File.ReadAllLines(@filename);
            foreach (string i in lines)
            {
                Console.WriteLine(i);
            }
        }
        catch
        {
            Console.WriteLine("An Error Occured while attempting to display the selected journal");
        }
    }
 }
