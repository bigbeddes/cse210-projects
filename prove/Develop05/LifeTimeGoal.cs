using System;
public class LifeTimeGoal : IGoal
{
    public LifeTimeGoal()
    {}

    public void GoalPrinter(string completionPoints, string repeatsCompleted, string repeatsNeeded, string goalPoints, int count, string discription, string goalType, string minorPoints)
    {
        Console.WriteLine($"{count}. Goal: {discription}.  Type: {goalType}. Points earned per update: {minorPoints}. Total Points Earned {goalPoints}.");
    }
}