using System;
public class BaseActivity
{
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;
    private Random _randomGenerator = new Random();

    public BaseActivity(string activityName, string activityDescription)
    {
        _activityDescription=$"This activity will help you {activityDescription}.";
        _activityName=activityName;
    }

    public void GetIntroduction()
    {
        //takes care of intro message and sets duration length for each activity
        Console.WriteLine($"Welcome to the {_activityName} activity. {_activityDescription}");
        Console.Write($"Please enter how many seconds you would like to do the {_activityName} activity for? ");
        int duration=int.Parse(Console.ReadLine());
        _activityDuration=duration;
        Animation(3);
        Console.Clear();
    }

    public int GetDuration()
    {
        //Duration getter
        return _activityDuration;
    }

    public void GetConclusion()
    {
        //takes care of concluiding statement
        Console.WriteLine("Great Job!");
        Animation(3);
        Console.WriteLine($"You completed {_activityDuration} seconds of the {_activityName} activity.");
        Animation(9);
    }

    public void CountDownAnimation(int pause)
    {
        //countdown timer if desired
        int count = pause;
        do
        {
            Console.Write(pause);
            Thread.Sleep(1000);
            Console.Write("\b \b");
            pause-=1;
        }
        while(pause > 0);
    }

    public void Animation(int pause)
    {
        //spinner pause animation, 1 cycle per completion
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(pause);
        DateTime currentTime = DateTime.Now;
        do
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            currentTime = DateTime.Now;
        }
        while(currentTime < futureTime);
    }

     public void SetIndex(List<int> index, List<string> list)
    {
        //Prompt index setup
        int counter=0;
        foreach (var i in list)
        {
            index.Add(counter);
            counter+=1;
        }
    }


    public void RandomListSelector(List<int> index, List<string> list)
    {
        //Randomly pick a string list item that hasn't been used
        int promptSelection = _randomGenerator.Next(0,index.Count);
        Console.WriteLine(list[index[promptSelection]]);
        index.RemoveAt(promptSelection);
    }

}