using System;
public interface IGoal
{
    // Used in DisplayGoals
    void GoalPrinter(string completionPoints, string repeatsCompleted, string repeatsNeeded, string goalPoints, int count, string discription, string goalType, string minorPoints);
}