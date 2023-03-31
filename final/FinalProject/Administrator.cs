using System;
public class Administrator : Employee
{
    bool selectionCheck = true;
    Database db = new Database();
    public Administrator() : base()
    {}
    public Administrator(string userRole, string groupID, int userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive) : base(userRole, groupID, userID, userPassword, firstName, lastName, rate, hoursWorked, payType, timeSubmitted, timeApproved, timePaid, monthEarnedAmount, userActive)
    {}

    public override bool RunMenu()
    {
        MainMenuHeader();
        Console.WriteLine("1 Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 Add new users.");
        Console.WriteLine("3 Change existing user Role and or group.");
        Console.WriteLine("4 Deactivate user.");
        Console.WriteLine("5 Reset password for a call in user.");
        Console.WriteLine("6 Update your password.");
        Console.WriteLine("7 Save changes and logout.");
        SetSelection(int.Parse(Console.ReadLine()));

        switch (GetSelection())
        {
            case 1:
                EnterTime();
                break;
            case 2:
                AddNewUser();
                break;
            case 3:
                ChangeUserGroupOrRole();
                break;
            case 4:
                DeactivateUser();
                break;
            case 5:
                ResetUserPassword();
                break;
            case 6:
                ChangePassword(_userID);
                break;
            case 7:
                SetRepeat(false);
                break;
            default:
                Console.WriteLine("User Selection was outside of the range of the Menu options. Please select a number from the menu...");
                Thread.Sleep(6000);
                break;
        }
        return GetRepeat();
    }

    public void AddNewUser()
    {
        Console.Clear();
        Console.WriteLine("Create a new user:");
        _userID=db.GetKeyList().Count +1;
        Console.Write("Enter new user First Name: ");
        _firstName=Console.ReadLine();
        Console.Write("Enter new user Last Name: ");
        _lastName=Console.ReadLine();
        _userPassword=$"{_userID}{_firstName}{_lastName}";
        if (_userPassword.Length < 8)
        {
            do
            {
                _userPassword += "0";
            }
            while(_userPassword.Length < 8);
        }
        Console.Write("Enter the pay rate the new user will have: ");
        _rate=$"{float.Parse(Console.ReadLine())}";
        _hoursWorked="0";
        Console.Write("If new user is Salary enter 1, if they are Hourly enter 2");
        do
        {
            SetSelection(int.Parse(Console.ReadLine()));
        }
        while (GetSelection() < 1 || GetSelection() > 2);
        if (GetSelection()==1)
        {
            _payType="Salary";
        }
        else if (GetSelection()==2)
        {
            _payType="Hourly";
        }
        SetUserRole();
        SetGroupID();
        _timeSubmitted="nul";
        _timeApproved="nul";
        _timePaid="nul";
        _monthEarnedAmount="0";
        _userActive="yes";

        db.SaveNewUser(_userRole, _groupID, $"{_userID}", _userPassword, _firstName, _lastName, _rate, _hoursWorked, _payType, _timeSubmitted, _timeApproved, _timePaid, _monthEarnedAmount, _userActive);
    }

    public void ChangeUserGroupOrRole()
    {
        Console.Clear();
        NameOrID("Change Role or Permission");
        _userRole=db.GetDictValue(_userID, USERROLE);
        _groupID=db.GetDictValue(_userID, GROUPID);

        Console.WriteLine($"Current Role: {_userRole}. Current Group ID: {_groupID}");
        Console.WriteLine($"Choose a number from the following:\n1 Change Role\n2 Chage Group ID.\n3 Change Both.");
        do
        {
            SetSelection(int.Parse(Console.ReadLine()));
        }
        while (GetSelection() < 1 || GetSelection() > 3);
        switch(GetSelection())
        {
            case 1:
                SetUserRole();
                db.ChangeDictValue(_userID, USERROLE, _userRole);
                break;
            case 2:
                SetGroupID();
                db.ChangeDictValue(_userID, GROUPID, _groupID);
                break;
            case 3:
                SetUserRole();
                db.ChangeDictValue(_userID, USERROLE, _userRole);
                SetGroupID();
                db.ChangeDictValue(_userID, GROUPID, _groupID);
                break;
        }
    }

    public void DeactivateUser()
    {
        Console.Clear();
        NameOrID("Deactivate User");
        Console.WriteLine("Enter 1 if you want to deactivate the user. Just hit enter to leave them active.");
        SetSelection(int.Parse(Console.ReadLine()));
        if (GetSelection() == 1)
        {
            db.ChangeDictValue(_userID, USERID, "no");
            Console.WriteLine("User has been deactivated. Please log out to save changes.");
            Thread.Sleep(5000);
        }
        
    }

    public void ResetUserPassword()
    {
        Console.Clear();
        NameOrID("Change Selected User Password");
        ChangePassword(_userID);
    }

    private void NameOrID(string selectionString)
    {
        Console.Clear();
        Console.WriteLine($"{selectionString}\n");
        Console.Write("Please enter 1 if you want to search by user ID or 2 if you want to search by user name: ");

        do
        {
            SetSelection(int.Parse(Console.ReadLine()));
        }
        while (GetSelection() < 1 || GetSelection() > 2);

        if (GetSelection() == 2)
        {
            _userID = db.DisplayKeysWithNames();
        }
    }

    private void SetGroupID()
    {
        Console.WriteLine("10 - Human Resources");
        Console.WriteLine("110 - Information Technology");
        Console.WriteLine("210 - Records");
        Console.WriteLine("310 - Public Relations");
        Console.WriteLine("Select the number of the Group ID you want to apply to the user:");

        do
        {
            SetSelection(int.Parse(Console.ReadLine()));
            if (GetSelection() == 10 || GetSelection() == 110 || GetSelection() == 210 || GetSelection() == 310)
            {
                selectionCheck=false;
                _groupID=$"{GetSelection()}";
            }
            else
            {
                Console.WriteLine("Selection was not an option from the list, please try again:");
                Thread.Sleep(4000);
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
            SetSelection(int.Parse(Console.ReadLine()));
        }
        while (GetSelection() < 1 || GetSelection() > 4);
        switch (GetSelection())
        {
            case 1:
                _userRole="HR";
                break;
            case 2:
                _userRole="Administrator";
                break;
            case 3:
                _userRole="Manager";
                break;
            case 4:
                _userRole="Employee";
                break;
        }


    }

}