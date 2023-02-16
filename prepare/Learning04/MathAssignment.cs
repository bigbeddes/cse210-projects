using System;
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;
    public MathAssignment(string studentName, string hwTopic, string textbookSection, string problems) : base(studentName, hwTopic)
    {
        _textbookSection=textbookSection;
        _problems=problems;

    }
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}