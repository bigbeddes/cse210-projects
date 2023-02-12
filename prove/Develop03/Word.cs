using System;

class Word
{
    private string _content;
    public Word(string wordInString)
    {
        _content = wordInString;
    }
    
    public string GetDisplayText()
    {
        //returns the text of the word or else returns ___//
        int repeat=_content.Length;
        string underscore=new string ('_', repeat);
        return underscore;
    }
}