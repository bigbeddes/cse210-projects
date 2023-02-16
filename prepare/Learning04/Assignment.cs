using System;
public class Assignment
{
    private string _studentName;
    private string _topic;
    public Assignment(string studentName, string hwTopic)
    {
        _studentName=studentName;
        _topic= hwTopic;
    }
    public string GetSummary()
    {
        return$"{_studentName} - {_topic}";
    }
    public string GetStudentName()
    {
        return _studentName;
    }
    public string GetTopic()
    {
        return _topic;
    }
}   
