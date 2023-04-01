using System;
public class Administrator : Employee
{
    bool selectionCheck = true; 
    private string _newUserRole;
    private string _newGroupID;
    private int _newUserID;
    private string _newUserPassword;
    private string _newFirstName;
    private string _newLastName;
    private string _newRate;
    private string _newPayType;
    private string _newHoursWorked;
    private string _newTimeSubmitted;
    private string _newTimeApproved;
    private string _newTimePaid;
    private string _newMonthEarnedAmount;
    private string _newUserActive;
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
        _newUserID=db.GetKeyList().Count +1;
        Console.Write("Enter new user First Name: ");
        _newFirstName=Console.ReadLine();
        Console.Write("Enter new user Last Name: ");
        _newLastName=Console.ReadLine();
        _newUserPassword=$"{_newUserID}{_newFirstName}{_newLastName}";
        if (_newUserPassword.Length < 8)
        {
            do
            {
                _newUserPassword += "0";
            }
            while(_newUserPassword.Length < 8);
        }
        Console.Write("Enter the pay rate the new user will have: ");
        _newRate=$"{float.Parse(Console.ReadLine())}";
        _newHoursWorked="0";
        Console.Write("If new user is Salary enter 1, if they are Hourly enter 2: ");
        do
        {
            SetSelection(int.Parse(Console.ReadLine()));
        }
        while (GetSelection() < 1 || GetSelection() > 2);
        if (GetSelection()==1)
        {
            _newPayType="Salary";
        }
        else if (GetSelection()==2)
        {
            _newPayType="Hourly";
        }
        SetUserRole();
        SetGroupID();
        _newTimeSubmitted="no";
        _newTimeApproved="no";
        _newTimePaid="no";
        _newMonthEarnedAmount="0";
        _newUserActive="yes";

        db.SaveNewUser(_newUserRole, _newGroupID, $"{_newUserID}", _newUserPassword, _newFirstName, _newLastName, _newRate, _newHoursWorked, _newPayType, _newTimeSubmitted, _newTimeApproved, _newTimePaid, _newMonthEarnedAmount, _newUserActive);
    }

    public void ChangeUserGroupOrRole()
    {
        Console.Clear();
        NameOrID("Change Role or Permission");
        _newUserRole=db.GetDictValue(_newUserID, USERROLE);
        _newGroupID=db.GetDictValue(_newUserID, GROUPID);

        Console.WriteLine($"Current Role: {_newUserID}. Current Group ID: {_newGroupID}");
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
                db.ChangeDictValue(_newUserID, USERROLE, _newUserRole);
                break;
            case 2:
                SetGroupID();
                db.ChangeDictValue(_newUserID, GROUPID, _newGroupID);
                break;
            case 3:
                SetUserRole();
                db.ChangeDictValue(_newUserID, USERROLE, _newUserRole);
                SetGroupID();
                db.ChangeDictValue(_newUserID, GROUPID, _newGroupID);
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
            db.ChangeDictValue(_newUserID, USERID, "no");
            Console.WriteLine("User has been deactivated. Please log out to save changes.");
            Thread.Sleep(5000);
        }
        
    }

    public void ResetUserPassword()
    {
        Console.Clear();
        NameOrID("Change Selected User Password");
        ChangePassword(_newUserID);
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

        switch (GetSelection())
        {
            case 1:
                Console.Write("Enter the ID: ");
                _newUserID=int.Parse(Console.ReadLine());
                break;
            case 2:
                _newUserID = db.DisplayKeysWithNames();
                break;
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
                _newGroupID=$"{GetSelection()}";
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
                _newUserRole="HR";
                break;
            case 2:
                _newUserRole="Administrator";
                break;
            case 3:
                _newUserRole="Manager";
                break;
            case 4:
                _newUserRole="Employee";
                break;
        }
    }

}