using System;
public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string hwTopic, string title) 
        : base(studentName, hwTopic)
    {
        _title=title;
    }
    public string GetWritingInformation()
    {
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}