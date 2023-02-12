using System;
using System.Collections.Generic;

class Scripture
{
    private string _reference;
    private List <string> _scriptureWords;
    //private List<bool> _scriptureWordValues;
    //private List <Word> _words;
    public Scripture(string reference, string scriptureText)
    {
        //Set the variables, incluiding break up the text into parts and  for each one,
        //create a new word object and add it to the list.
        //Don't forget to create a new list (eg., =new List<Word>...)
        _reference=reference;       
        _scriptureWords=scriptureText.Split(' ').ToList();
    }
    public void HideWords(int number)
    {
        //Hides "number" words at random
        int count=0;
        do
        {
            Random randomGenerator = new Random();
            string[]arrayOfStrings=_scriptureWords.ToArray();
            int hidePossition = randomGenerator.Next(0,arrayOfStrings.Count());
            string passThrough=arrayOfStrings[hidePossition];
            Word newWord=new Word(passThrough);
            arrayOfStrings[hidePossition]=newWord.GetDisplayText(); 
            _scriptureWords=arrayOfStrings.ToList();
            count+=1;
        }
        while(count!=number);
    }
    public string GetDisplayText()
    {
        //Go through each word, call its "GetDisplayText" method and append it to a string
        string scriptureString=String.Join(" ", _scriptureWords);
        return $"{_reference}\n{scriptureString}";
    }
    public bool IsCompletelyHidden()
    {
        //figure out if all the words are hidden, if so, return true if not return false.

        return false;
    }
}



