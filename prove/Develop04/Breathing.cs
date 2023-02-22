using System;
public class Breathing : BaseActivity
{

    private int _breathing;
    public Breathing(string activityName, string activityDescription) : base(activityName, activityDescription)
    {}

    public void BreathingIntro()
    {
        GetIntroduction();
    }

    public void BreathingActivity()
    {
        Console.Write("Please enter how many seconds you would like each interval to last (Suggested between 3-6): ");
        _breathing = int.Parse(Console.ReadLine());
        Console.Write("Begin in...");
        CountDownAnimation(5);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        DateTime currentTime = DateTime.Now;
        do
        {
            //Box Breathing Activity, Will complete 1 cycle before checking if time of activity has been met.//
            Console.Clear();
            Console.Write($"Breath in for {_breathing} seconds - ");
            CountDownAnimation(_breathing);
            Console.WriteLine("");
            Console.Write($"Hold your Breath for {_breathing} seconds - ");
            CountDownAnimation(_breathing);
            Console.WriteLine("");
            Console.Write($"Exhale for {_breathing} seconds - ");
            CountDownAnimation(_breathing);
            Console.WriteLine("");
            Console.Write($"Hold your Breath for {_breathing} seconds - ");
            CountDownAnimation(_breathing);
            currentTime = DateTime.Now;
            Console.Clear();
        }
        while(currentTime < futureTime);
    }

    public void BreathingConclusion()
    {
        GetConclusion();
    }
    
}