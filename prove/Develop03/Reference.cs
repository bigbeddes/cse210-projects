using System;
using System.IO;

class Reference
{
    private string _referenceFileName="scriptMasteryReference.csv";
    private string _scriptureFileName="scriptMasteryScripture.csv";
    private string _scriptureText;
    private string _referenceText;
    public void DisplayScriptureOptions()
    {
        string[] lines=System.IO.File.ReadAllLines(@_referenceFileName);
        for (int i = 0; i<lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            Console.WriteLine($"{fields[0]} {fields[1]}");
        }
        Console.Write("Please enter the number of the list that has the Scripture you would like to memorize: ");

        int userSelection=(int.Parse(Console.ReadLine()));
        for (int i = 0; i<lines.Length; i++)
        {
            string[] fields = lines[i].Split(',');
            if (int.Parse(fields[0]) == userSelection)
            {
                _referenceText=fields[1];
            }
        }
        string[] scriptureLines=System.IO.File.ReadAllLines(@_scriptureFileName);
        int count=1;
        for (int i = 0; i<scriptureLines.Length; i++)
        {
            if (count == userSelection)
            {
                _scriptureText=scriptureLines[i];
            }
            count+=1;
        }
    }
    public string GetScriptureText()
    {
        return _scriptureText;
    }
    public string GetReferenceText()
    {
        return _referenceText;
    }
}
