using System;
public class CheckListGoal : IGoal
{
    public CheckListGoal()
    {}

    public void GoalPrinter(string completionPoints, string repeatsCompleted, string repeatsNeeded, string goalPoints, int count, string discription, string goalType, string minorPoints)
    {
        string completed= $"[ ]. Points earned per repition: {minorPoints}. Points earned when goal is completed: {completionPoints}. Points Earned so far: {goalPoints}.";
        string end=$"Points earned per repitition";
        if (int.Parse(repeatsCompleted) >= int.Parse(repeatsNeeded))
        {
            completed= $"[x]. Total points earned: {goalPoints}.";
        }
        Console.WriteLine($"{count}. Goal: {discription}.  Type: {goalType}. {repeatsCompleted}/{repeatsNeeded} done so far. Goal completed: {completed}");
    }
}