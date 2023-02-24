using System;
public class Listing : BaseActivity
{

    private List<string> _listPrompts= new List<string>
    {
        {"Who are people that you appreciate?"},
        {"What are personal strengths of yours?"},
        {"Who are people that you have helped this week?"},
        {"When have you felt the Holy Ghost this month?"},
        {"Who are some of your personal heroes?"}
    };
    
    private List<int> _listIndex= new List<int>();


    private int _counter=0;


    public Listing(string activityName, string activityDescription) : base(activityName, activityDescription)
    {
        SetIndex(_listIndex, _listPrompts);
    }

    public void ListingIntro()
    {
        GetIntroduction();
    }

    public void ListingActivity()
    {
        if(_listIndex.Count == 0)
        {
            SetIndex(_listIndex, _listPrompts);
        }
        //Randomly select a prompt selection
        Console.WriteLine("Please list as many responses as you can to the following question.");
        RandomListSelector(_listIndex, _listPrompts);
        Console.Write("You may begin in...");
        CountDownAnimation(5);
        Console.WriteLine("");
        
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        DateTime currentTime = DateTime.Now;
        
        do
        { 
            //counts the amount of responses made. time is checked after each entry is made
            Console.ReadLine();
            _counter+=1;
            currentTime = DateTime.Now;
        }
        while(currentTime < futureTime);
        Console.Clear();
    }

    public void ListingConclusion()
    {
        Console.WriteLine($"You made {_counter} entries.");
        Animation(3);
        GetConclusion();
    }
}