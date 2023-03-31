using System;
public class ApplicationAdministrator : IPosition
{
    private int _ID;
    private string _password;
    private string _firstName;
    private string _lastName;
    private float _rate;
    private int _hoursWorked;
    private string _payType;
    private string _userRole;
    private int _groupID;
    private string _timeSubmitted;
    private string _timeApproved;
    private string _timePaid;
    private float _monthEarnedAmount;
    private string _userActive;
    private int _userSelection;
    Load adminLoad = new Load();
    Save adminSave = new Save();

    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 Has ability to review a user's time status (submitted, approved, paid).");
        Console.WriteLine("3 Add new users.");
        Console.WriteLine("4 Change existing user Role and or group.");
        Console.WriteLine("5 Deactivate user.");
        Console.WriteLine("6 Reset password for a call in user.");
        Console.WriteLine("7 Update your password.");
        Console.WriteLine("8 Save changes and logout.");
        userSelection=int.Parse(Console.ReadLine());


        return userSelection;
    }

    public void ReviewUserTimeStatus()
    {
        NameOrID("Retrieve User Reported Time Status");
        _timeSubmitted = adminLoad.GetValue(_ID, 9);
        _timeApproved = adminLoad.GetValue(_ID, 10);
        _timePaid = adminLoad.GetValue(_ID, 11);
        Console.WriteLine($"Last month time submitted: {_timeSubmitted}");
        Console.WriteLine($"Last month time approved: {_timeApproved}");
        Console.WriteLine($"Last month time paid: {_timePaid}");
        Console.Write("Press enter when you are done review the Time Status Report... ");
        Console.ReadLine();
    }

    public void AddNewUser()
    {
        Console.Clear();
        Console.WriteLine("Create a new user:");
        _ID=adminLoad.RelayKeyList().Count +1;
        Console.Write("Enter new user First Name: ");
        _firstName=Console.ReadLine();
        Console.Write("Enter new user Last Name: ");
        _lastName=Console.ReadLine();
        _password=$"{_ID}{_firstName}{_lastName}";
        Console.Write("Enter the pay rate the new user will have: ");
        _rate=float.Parse(Console.ReadLine());
        _hoursWorked=0;
        Console.Write("If new user is Salary enter 1, if they are Hourly enter 2");
        do
        {
            _userSelection=int.Parse(Console.ReadLine());
        }
        while (_userSelection < 1 || _userSelection > 2);
        if (_userSelection==1)
        {
            _payType="Salary";
        }
        else if (_userSelection==2)
        {
            _payType="Hourly";
        }
        SetUserRole();
        SetGroupID();
        _timeSubmitted="nul";
        _timeApproved="nul";
        _timePaid="nul";
        _monthEarnedAmount=0;
        _userActive="yes";

        adminSave.SaveNewUser($"{_ID}", _password, _firstName, _lastName, $"{_rate}", $"{_hoursWorked}", _payType, _userRole, $"{_groupID}", _timeSubmitted, _timeApproved, _timePaid, $"{_monthEarnedAmount}", _userActive);
    }

    public void ChangeUserGroupOrRole()
    {
         
        NameOrID("Change Role or Permission");
        _userRole=adminLoad.GetValue(_ID, 7);
        _groupID=int.Parse(adminLoad.GetValue(_ID, 8));

        Console.WriteLine($"Current Role: {_userRole}. Current Group ID: {_groupID}");
        Console.WriteLine($"Choose a number from the following:\n1 Change Role\n2 Chage Group ID.\n3 Change Both.");
        do
        {
            _userSelection=int.Parse(Console.ReadLine());
        }
        while (_userSelection < 1 || _userSelection > 3);

        if (_userSelection == 1)
        {
            SetUserRole();
        }
        else if (_userSelection == 2)
        {
            SetGroupID();
        }
        else if (_userSelection == 3)
        {
            SetUserRole();
            SetGroupID();
        }
    }

    public void DeactivateUser()
    {
        NameOrID("Deactivate User");
        Console.WriteLine("Enter 1 if you want to deactivate the user. Just hit enter to leave them active.");
        _userSelection = int.Parse(Console.ReadLine());
        if (_userSelection == 1)
        {
            adminSave.RelayChangeDictValue(_ID, 13, "no");
            Console.WriteLine("User has been deactivated. Please log out to save changes.");
            Thread.Sleep(5000);
        }
        
    }

    public void ResetUserPassword()
    {
        NameOrID("Change Selected User Password");
        do
        {
            Console.WriteLine("Enter what the new password will be (must be at least 8 characters): ");
            _password=Console.ReadLine();
        }
        while (_password.Length < 8);
        
        adminSave.RelayChangeDictValue(_ID, 1, _password);
        Console.WriteLine("Password updated. Logout to save changes.");
        Thread.Sleep(5000);
    }


    private void NameOrID(string selectionString)
    {
        Console.Clear();
        Console.WriteLine($"{selectionString}\n");

        do
        {
            Console.Write("Please enter 1 if you want to search by user ID or 2 if you want to search by user name: ");
            _userSelection = int.Parse(Console.ReadLine());
        }
        while (_userSelection < 1 || _userSelection > 2);

        if (_userSelection == 2)
        {
            adminLoad.DisplayKeysWithName();
        }

        Console.WriteLine($"\nPlease enter the User ID you need to look up");
        _ID = int.Parse(Console.ReadLine());
    }

    private void SetGroupID()
    {
        bool selectionCheck = true;
        Console.WriteLine("Select the number of the Group ID you want to apply to the user:");
        Console.WriteLine("10 - Human Resources");
        Console.WriteLine("110 - Information Technology");
        Console.WriteLine("210 - Records");
        Console.WriteLine("310 - Public Relations");

        do
        {
            _userSelection=int.Parse(Console.ReadLine());
            if (_userSelection == 10 || _userSelection == 110 || _userSelection == 210 || _userSelection == 310)
            {
                selectionCheck=false;
            }
        }
        while (selectionCheck == true);
    }

    private void SetUserRole()
    {
        Console.WriteLine("Select the number of the Role you want to apply to the user:");
        Console.WriteLine("1 HR");
        Console.WriteLine("2 Application Administrator");
        Console.WriteLine("3 Manager");
        Console.WriteLine("4 Employee");
        do
        {
            _userSelection=int.Parse(Console.ReadLine());
        }
        while (_userSelection < 1 || _userSelection > 4);

    }
}