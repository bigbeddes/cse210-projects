using System;

public class Reflecting : BaseActivity
{

    private List<string> _prompts = new List<string>
    {
        {"Think of a time when you stood up for someone else."},
        {"Think of a time when you did something really difficult."},
        {"Think of a time when you helped someone in need."},
        {"Think of a time when you did something truly selfless."}
    };

    private List<string> _questions = new List<string>
    {
        {"Why was this experience meaningful to you?"},
        {"Have you ever done anything like this before?"},
        {"How did you get started?"},
        {"How did you feel when it was complete?"},
        {"What made this time different than other times when you were not as successful?"},
        {"What is your favorite thing about this experience?"},
        {"What could you learn from this experience that applies to other situations?"},
        {"What did you learn about yourself through this experience?"},
        {"How can you keep this experience in mind in the future?"}
    };

    private List<int> _promptsIndexes = new List<int>();

    private List<int> _questionsIndexes = new List<int>();

    public Reflecting(string activityName, string activityDescription) : base(activityName, activityDescription)
    {
        //establish indexes that prevent list selection duplication
        SetIndex(_promptsIndexes, _prompts);
        SetIndex(_questionsIndexes, _questions);
    }

    public void ReflectingIntro()
    {
        GetIntroduction();
    }

    public void ReflectingActivity()
    {
        //Picks a prompt that hasn't been used and refresh's the list if you've gone through them all.
        if(_promptsIndexes.Count == 0)
        {
            SetIndex(_promptsIndexes, _prompts);
        }

        RandomListSelector(_promptsIndexes, _prompts);

        //Does activity for designated duration and
        //Picks a random question that hasn't been used and refresh's the list if you've gone through them all. 
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(GetDuration());
        DateTime currentTime = DateTime.Now;
        
        do
        {
            if(_questionsIndexes.Count == 0)
            {
                SetIndex(_questionsIndexes, _questions);
            }
            RandomListSelector(_questionsIndexes, _questions);
            Animation(10);
            
            currentTime = DateTime.Now;
        }
        while(currentTime < futureTime);
        Console.Clear();
    }

    public void ReflectingConclusion()
    {
        GetConclusion();
    }
}