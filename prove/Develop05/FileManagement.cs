using System;
public class FileManagement
{
    private string _filename;
    private int _totalPoints;

    //values needed to build goals dictionary
    private string _discription;
    private string _goalType;
    private string _repeatsNeeded;
    private string _repeatsCompleted;
    private string _minorPoints;
    private string _completionPoints;
    private string _goalPoints;
    
    //key generator for goals dictionary
    private int _goalCounter=1;

    //Create 2 dictionaries needed, one is simple and static (levels), the other is complex and gets added on as it gets built (goals)
    private Dictionary<int,string> _levels=new Dictionary<int,string>
    {
        {100000,"Atlas"}, {25000,"Master Chief"}, {10000,"Hero"}, {4000,"Vet"}, {1500,"Journyman"}, {500,"Rookie"}, {0,"Noob"}
    };
    private Dictionary<int, FileManagement> _goals = new Dictionary<int, FileManagement>();
    
    //initiate 3 goal clases to be used in FileManagement
    LifeTimeGoal lifetime = new LifeTimeGoal();
    SimpleGoal simple = new SimpleGoal();
    CheckListGoal checklist = new CheckListGoal();
    
    //Allows GoalBuilder() to pass back unique fields when adding new goals durring CreateGoal()
    public FileManagement(string repeatNeeded, string repeatsCompleted, string minorPoints, string completionPoints)
    {
        _repeatsNeeded=repeatNeeded;
        _repeatsCompleted=repeatsCompleted;
        _minorPoints= minorPoints;
        _completionPoints=completionPoints;
    }

    // Used in CreateGoal() and OpenGoalFile() to append unique fields to the _goals Dictionary
    public FileManagement(string zero, string one, string two, string three, string four, string five, string six)
    {
        _discription=zero;
        _goalType=one;
        _repeatsNeeded=two;
        _repeatsCompleted=three;
        _minorPoints=four;
        _completionPoints=five;
        _goalPoints=six;
    }

    //Used for any other FileMangement Methods
    public FileManagement()
    {
        
    }
    
    //Calculates point total, Rank Level, Displays menue and returns user input
    public int PrintMenu()
    {
        // Calculate and display total points
        _totalPoints=0;
        List<int> tally = GetKeyList();
        foreach (int key in tally)
        {
            _totalPoints += int.Parse(_goals[key]._goalPoints);
        }
        Console.WriteLine($"Your total points is: {_totalPoints}");
        
        //Get list of key in Levels and only save if key is larger than total points
        List<int> highNumber = new List<int>();
        Dictionary<int, string>.KeyCollection keyColl = _levels.Keys;
        foreach( int s in keyColl )
        {
            if (_totalPoints >= s)
            {
                highNumber.Add(s);
            }
        }    
        int result=0; 
        foreach( int r in highNumber )
        {
            if (r >= result)
            {
                result=r;
            }
        }
        Console.WriteLine($"\nYour Goals Rank is: {_levels[result]}\n");

        // Display Menu Options and pass on the User Selection
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1 Create New Goal"); 
        Console.WriteLine("2 List Goals");
        Console.WriteLine("3 Save Goals");
        Console.WriteLine("4 Load Goals");
        Console.WriteLine("5 Record Event");
        Console.WriteLine("6 Quit");
        Console.Write($"\nPlease enter the menu number option you want to work on: ");
        int userSelection = int.Parse(Console.ReadLine());
        return userSelection;
    }

    // Takes in the inputs needed to add goal to the Goals dictionary
    public void CreateGoal()
    {
        _goalType=GetGoalType("What kind of a goal would you like to create?");
        Console.WriteLine("Please enter the goal you would like to make? Be sure not to use commas:");
        _discription= Console.ReadLine();
        _goalPoints="0";
        
        // Build out goal based on Type
        if (_goalType=="Lifetime")
        {
            _repeatsNeeded="1";
            _repeatsCompleted="0";
            Console.Write("Enter how many points (whole number) you would like to award any updates made: ");
            _minorPoints= Console.ReadLine();
            _completionPoints="0";
        }
        else if (_goalType=="Simple")
        {
            _repeatsNeeded="1";
            _repeatsCompleted="1";
            _minorPoints="0";
            Console.Write("Enter how many points (whole number) you would like after completing the goal: ");
            _completionPoints= Console.ReadLine();
        }
        else if (_goalType == "Checklist")
        {
            Console.Write("Enter how many times you will need to complete this task for the goal to be completed: ");
            _repeatsNeeded= Console.ReadLine();
            _repeatsCompleted="0";
            Console.Write("How many points (whole number) will you get each time you complete a task: ");
            _minorPoints=Console.ReadLine();
            Console.Write("How many points (whole number) will you get after completing this goal: ");
            _completionPoints=Console.ReadLine();
        }
        
        //Compile goal info into goal dictionary
        FileManagement g = new FileManagement(_discription, _goalType, _repeatsNeeded, _repeatsCompleted, _minorPoints, _completionPoints, _goalPoints);
        _goals[_goalCounter]= g;
        _goalCounter+=1;
    }

    //Lists each line displayed on a line depending on what Goal Type it is.
    public void DisplayGoals()
    {
        List<int> keys = GetKeyList();
        int count=1;
        Console.WriteLine($"Listed Goals:\n");
        foreach( int s in keys )
        {
            
            if (_goals[s]._goalType == "Lifetime")
            {
                lifetime.GoalPrinter(_goals[s]._completionPoints, _goals[s]._repeatsCompleted, _goals[s]._repeatsNeeded, _goals[s]._goalPoints, count, _goals[s]._discription, _goals[s]._goalType, _goals[s]._minorPoints);
            }

            else if (_goals[s]._goalType == "Simple")
            {
                simple.GoalPrinter(_goals[s]._completionPoints, _goals[s]._repeatsCompleted, _goals[s]._repeatsNeeded, _goals[s]._goalPoints, count, _goals[s]._discription, _goals[s]._goalType, _goals[s]._minorPoints);
            }

            else if (_goals[s]._goalType == "Checklist")
            {
                checklist.GoalPrinter(_goals[s]._completionPoints, _goals[s]._repeatsCompleted, _goals[s]._repeatsNeeded, _goals[s]._goalPoints, count, _goals[s]._discription, _goals[s]._goalType, _goals[s]._minorPoints);
            }
            count +=1;
        }
        Console.Write($"\nPress enter to return to main menue: ");
        Console.ReadLine();
    }
    
    //iterates through the dictionary Keys and Loads them into a designated file
    public void SaveGoals()
    {
        Console.WriteLine("Please enter the new name of the csv file you would like to save this goals list to in the Goals Folder:");
        string name= Console.ReadLine();
        _filename=@$"GoalFiles\{name}.csv" ;

        List<int> keys = GetKeyList();
        foreach (int key in keys)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(_filename, true))
            {
                file.WriteLine(_goals[key]._discription + "," + _goals[key]._goalType + "," + _goals[key]._repeatsNeeded + "," + _goals[key]._repeatsCompleted + "," + _goals[key]._minorPoints + "," + _goals[key]._completionPoints + "," + _goals[key]._goalPoints);
            }
        }
    }

    // Loads user input goals file and adds to the goal dictionary
    public void OpenGoalFile()
    {
        //designate file to open and save location to be pulled so we can save the modified dictionary to it later.
        Console.WriteLine("Please enter the name of the file you would like to open in the GoalFiles folder:");
        string name= Console.ReadLine();
        _filename=@$"GoalFiles\{name}.csv" ;
        //Read through selected file and build dictionary one line at a time
        string [] lines = System.IO.File.ReadAllLines(_filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            FileManagement g = new FileManagement(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
            _goals[_goalCounter] = g;
            _goalCounter+=1;
        }
    }

    //Allows user to Select an existing goal to report progress made and update total points for
    public void RecordEvent()
    {
        //Asks user for what goal type they want to report on and pairs down the dictionary to only incluide those goal tyes
        string type=GetGoalType("What kind of a goal would you like to report an update on?");
        List<int> allKeys = GetKeyList();
        List<int> selectedKeys = new List<int>();
        foreach (int key in allKeys)
        {
            if (type == _goals[key]._goalType)
            {
                selectedKeys.Add(key);
            }
        }

        // Lists key number with goal and asks user to type the key of the goal they want to report on
        Console.WriteLine($"{type} Goal List:");
        foreach (int k in selectedKeys)
        {
            Console.WriteLine($"{k} - {_goals[k]._discription}");
        }
        Console.Write("Please enter the number at the left of the Goal you would like to report on: ");
        int userKey = int.Parse(Console.ReadLine());

        // Allows user to update the goal they selected
        Console.Clear();
         if (_goals[userKey]._goalType=="Lifetime")
        {
            lifetime.GoalPrinter(_goals[userKey]._completionPoints, _goals[userKey]._repeatsCompleted, _goals[userKey]._repeatsNeeded, _goals[userKey]._goalPoints, userKey, _goals[userKey]._discription, _goals[userKey]._goalType, _goals[userKey]._minorPoints);
            Console.WriteLine("Please enter what progress has been made towards this lifetime goal:");
            Console.ReadLine();
            int total= int.Parse(_goals[userKey]._goalPoints);
            total += int.Parse(_goals[userKey]._minorPoints);
            _goals[userKey]._goalPoints = $"{total}";
        }
        else if (_goals[userKey]._goalType== "Simple")
        {
            if (int.Parse(_goals[userKey]._repeatsCompleted) < 1)
            {
                simple.GoalPrinter(_goals[userKey]._completionPoints, _goals[userKey]._repeatsCompleted, _goals[userKey]._repeatsNeeded, _goals[userKey]._goalPoints, userKey, _goals[userKey]._discription, _goals[userKey]._goalType, _goals[userKey]._minorPoints);
                Console.Write("Please enter 1 if you completed this goal, enter any other number if you didn't to return to the main menu. ");
                int report = int.Parse(Console.ReadLine());
                if (report == 1)
                {
                    int total = int.Parse(_goals[userKey]._goalPoints);
                    total += int.Parse(_goals[userKey]._completionPoints);
                    _goals[userKey]._goalPoints = $"{total}";
                    _goals[userKey]._repeatsCompleted=$"{report}";
                }
            }    
            else
            {
                Console.Write("You have already completed this goal. Press enter to return to the main menu");
                Console.ReadLine();
            } 
        }
        else if (_goals[userKey]._goalType == "Checklist")
        {
            int repeats= int.Parse(_goals[userKey]._repeatsCompleted);
            int pointsPer = int.Parse(_goals[userKey]._minorPoints);
            int completionPoints = int.Parse(_goals[userKey]._completionPoints);
            int goalRunningTotalPoints = int.Parse(_goals[userKey]._goalPoints);
            if (repeats < int.Parse(_goals[userKey]._repeatsNeeded))
            {
                checklist.GoalPrinter(_goals[userKey]._completionPoints, _goals[userKey]._repeatsCompleted, _goals[userKey]._repeatsNeeded, _goals[userKey]._goalPoints, userKey, _goals[userKey]._discription, _goals[userKey]._goalType, _goals[userKey]._minorPoints);
                Console.Write("Please enter how many times you completed this goal: ");
                int report = int.Parse(Console.ReadLine());
                repeats += report;
                _goals[userKey]._repeatsCompleted = $"{repeats}";
                if (repeats >= int.Parse(_goals[userKey]._repeatsNeeded))
                {
                    goalRunningTotalPoints += (repeats*pointsPer) + completionPoints;
                    _goals[userKey]._goalPoints=$"{goalRunningTotalPoints}";
                }
                else
                {
                    goalRunningTotalPoints += (repeats*pointsPer);
                    _goals[userKey]._goalPoints=$"{goalRunningTotalPoints}";
                }
                
            }
            else
            {
                Console.Write("You have already completed this goal. Press hit enter to return to the main menu");
                Console.ReadLine();
            }
        }
    }

    // Iterates through Goals dictionary returns a list of all the keys
    //Used in DisplayGoals() SaveGoals(), and RecordEvent
    public List<int> GetKeyList()
    {
        List<int> keys = new List<int>();
        Dictionary<int, FileManagement>.KeyCollection keyColl = _goals.Keys;
        foreach( int s in keyColl )
            {
                keys.Add(s);
            }
        return keys;
    }

    //  Ask user which goal type to work on and returns goal type string user selected.
    // Used in CreateGoals() and RecordEvent()
    public string GetGoalType(string menuHeader)
    {
        Console.Clear();
        int userSelection;
        string passthrough="";
        do
        {
            Console.WriteLine(menuHeader);
            Console.WriteLine("1 Lifetime Goals");
            Console.WriteLine("2 Simple Goals");
            Console.WriteLine("3 Checklist Goals");
            Console.WriteLine($"Select the number of the Goal Type you would like to work on: ");
            userSelection=int.Parse(Console.ReadLine());
            if (userSelection==1)
            {
                passthrough="Lifetime";
            }
            else if (userSelection==2)
            {
                passthrough="Simple";
            }
            else if (userSelection==3)
            {
                passthrough="Checklist";
            }
        }
        while(userSelection > 3 || userSelection < 1);
        return passthrough;
    }
}