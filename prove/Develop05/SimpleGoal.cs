using System;
public class SimpleGoal : IGoal
{
    public SimpleGoal()
    {}

    public void GoalPrinter(string completionPoints, string repeatsCompleted, string repeatsNeeded, string goalPoints, int count, string discription, string goalType, string minorPoints)
    {
        string completed = "[ ]";
        string end =$"Points to earn after completing goal: {completionPoints}.";
        if (int.Parse(repeatsCompleted) > int.Parse(repeatsNeeded))
        {
            completed = "[x]";
            end = $"Total points Earned: {goalPoints}.";
        }
        Console.WriteLine($"{count}. Goal: {discription}.  Type: {goalType}. Goal completed {completed}. {end}");
    }
}