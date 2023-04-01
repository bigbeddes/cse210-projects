using System;
public class Employee
{
    //dictionary attributes
    public string _userRole;
    public string _groupID;
    public int _userID;
    public string _userPassword;
    public string _firstName;
    public string _lastName;
    public string _rate;
    public string _payType;
    public string _hoursWorked;
    public string _timeSubmitted;
    public string _timeApproved;
    public string _timePaid;
    public string _monthEarnedAmount;
    public string _userActive;

    //attribute indexes
    protected int USERROLE = 0;
    protected int GROUPID = 1;
    protected int USERPASSWORD = 3;
    protected int FIRSTNAME = 4;
    protected int LASTNAME = 5;
    protected int RATE = 6;
    protected int PAYTYPE = 7;
    protected int HOURSWORKED = 8;
    protected int TIMESUBMITTED = 9;
    protected int TIMEAPPROVED = 10;
    protected int TIMEPAID = 11;
    protected int MONTHEARNEDAMOUNT = 12;
    protected int USERACTIVE = 13;
    //navigate menu
    private int _userSelection = 0;
    private bool _repeat = true;
    //dictionary database
    public Database db = new  Database();
    public Employee()
    {}
    //constructor to set up user dictionary
    public Employee(string userRole, string groupID, int userID, string userPassword, string firstName, string lastName, string rate, string payType, string hoursWorked, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive)
    {
        _userRole=userRole;
        _groupID=groupID;
        _userID=userID;
        _userPassword=userPassword;
        _firstName=firstName;
        _lastName=lastName;
        _rate=rate;
        _payType=payType;
        _hoursWorked=hoursWorked;
        _timeSubmitted=timeSubmitted;
        _timeApproved=timeApproved;
        _timePaid=timePaid;
        _monthEarnedAmount=monthEarnedAmount;
        _userActive=userActive;
    }

     public virtual bool RunMenu()
    {
        MainMenuHeader();
        Console.WriteLine("1 Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 Update your password.");
        Console.WriteLine("3 Save changes and logout.");
        _userSelection=int.Parse(Console.ReadLine());

        if (_userSelection == 1 )
        {
            EnterTime();
        }
        else if (_userSelection == 2)
        {
            ChangePassword(_userID);
        }
        else if (_userSelection <1 || _userSelection > 3)
        {
            Console.WriteLine("User Selection was outside of the range of the Menu options. Please select a number from the menu...");
            Thread.Sleep(6000);
        }
        else 
        {
            _repeat=false;
        }
        return _repeat;
    }
    
    public void MainMenuHeader()
    {
        Console.Clear();
        Console.WriteLine($"name:{_firstName} {_lastName}");
        Console.WriteLine($"Role: {_userRole}");
        Console.WriteLine($"Department ID: {_groupID}");
        Console.WriteLine("Main Menu");
    }
    //Updates user input for time worked and pay earned for the month and saaves to UserList csv file
    public void EnterTime()
    {
        Console.Clear();
        Console.WriteLine($"name: {_firstName} {_lastName}");
        Console.WriteLine($"Last Reported Month: {_timeSubmitted}");
        Console.WriteLine($"Last Reported Hours Worked: {_hoursWorked}");
        Console.WriteLine($"Last Reported Total earned: ${_monthEarnedAmount}");
        Console.WriteLine($"Last Approved Month: {_timeApproved}");
        Console.WriteLine($"Last Paid Month: {_timePaid}");
        Console.Write($"\nEnter 1 if you would like to update your time, enter 2 to return to the Main Menu: ");
        _userSelection = int.Parse(Console.ReadLine());
        if (_userSelection == 1)
        {
            Console.Clear();
            db.ChangeDictValue(_userID, TIMESUBMITTED, SelectMonth("Enter the number of the Month you want to update your time for"));
            Console.Write("Enter how many hours you worked durring the Month you are updating: ");
            db.ChangeDictValue(_userID, HOURSWORKED, $"{int.Parse(Console.ReadLine())}");
            switch (_payType)
            {
                case "Hourly":
                    db.ChangeDictValue(_userID, MONTHEARNEDAMOUNT, $"{Math.Round((float.Parse(_rate))*(float.Parse(_hoursWorked)), 2)}");
                    break;
                case "Salary":
                    db.ChangeDictValue(_userID, MONTHEARNEDAMOUNT, $"{Math.Round(float.Parse(_rate), 2)}");
                    break;
            }
        }

    }
    //Updates user password
    public void ChangePassword(int key)
    {
        string password1;
        string password2;
        //Create new password
        do
        {
            Console.Clear();
            Console.Write("Please enter your new password (must contain at least 8 characters): ");
            password1=Console.ReadLine();
            Console.Write("Please re-enter your new password: ");
            password2=Console.ReadLine();
            if (password1.Length < 8)
            {
                Console.Write("Your entered password must be atleast 8 characters long.");
                Thread.Sleep(5000);
            }
            else if (password1==password2)
            {
                Console.Write("Your password has been reset");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Passwords do not match");
                Thread.Sleep(3000);
            }
        }
        while (password1 != password2 || password1.Length < 8);
        //save new password to user list
        db.ChangeDictValue(key, USERPASSWORD, password1);

    }
    
    public void SetSelection(int selection)
    {
        _userSelection = selection;
    }

    public int GetSelection()
    {
        return _userSelection;
    }

    public void SetRepeat(bool repeat)
    {
        _repeat=repeat;
    }

    public bool GetRepeat()
    {
        return _repeat;
    }
    // Convert month number to month Name
    public string SelectMonth(string question)
    {
        Console.Write($"{question} (ex. enter 1 for January): ");
        _userSelection=int.Parse(Console.ReadLine());
        string month="";
        switch (_userSelection)
        {
            case 1:
                month="January";
                break;
            case 2:
                month="February";
                break;
            case 3:
                month="March";
                break;
            case 4:
                month="April";
                break;
            case 5:
                month="May";
                break;
            case 6:
                month="June";
                break;
            case 7:
                month="July";
                break;
            case 8:
                month="August";
                break;
            case 9:
                month="September";
                break;
            case 10:
                month="October";
                break;
            case 11:
                month="November";
                break;
            case 12:
                month="December";
                break;
            default:
                Console.WriteLine("Selection outside of Month range.");
                Thread.Sleep(3000);
                break;
        }
        return month;
    }

}
