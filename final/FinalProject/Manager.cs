using System;
public class Manager : Employee
{
    
    private List <int> _subordinates = new List<int>();
    public Manager() : base()
    {}
    public Manager(string userRole, string groupID, int userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive) : base(userRole, groupID, userID, userPassword, firstName, lastName, rate, hoursWorked, payType, timeSubmitted, timeApproved, timePaid, monthEarnedAmount, userActive)
    {}

    public override bool RunMenu()
    {
        MainMenuHeader();
        Console.WriteLine("1 Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 approve time of employees in group.");
        Console.WriteLine("3 Update your password.");
        Console.WriteLine("4 Save changes and logout.");
        SetSelection(int.Parse(Console.ReadLine()));
            
        switch (GetSelection())
        {
            case 1:
                EnterTime();
                break;
            case 2:
                ApproveTime();
                break;
            case 3:
                ChangePassword(_userID);
                break;
            case 4:
                SetRepeat(false);
                break;
            default:
                Console.WriteLine("User Selection was outside of the range of the Menu options. Please select a number from the menu...");
                Thread.Sleep(6000);
                break;
        }
        return GetRepeat();
    }

    private void ApproveTime()
    {
        
        //iterate through all user keys and print their time info if their group ID matches the managers.
        List<int> userList= db.GetKeyList();
        
        foreach (int user in userList)
        {
            if (db.GetDictValue(user,USERACTIVE) == "yes")
            {
                if (_groupID == db.GetDictValue(user, GROUPID))
                {
                    Console.Clear();
                    Console.WriteLine($"User ID: {user}.");
                    Console.WriteLine($"User Name: {db.GetDictValue(user, FIRSTNAME)} {db.GetDictValue(user, LASTNAME)}.");
                    Console.WriteLine($"Pay Type: {db.GetDictValue(user, PAYTYPE)}.");
                    Console.WriteLine($"Hours Worked: {db.GetDictValue(user, HOURSWORKED)}.");
                    Console.WriteLine($"Pay Rate: ${db.GetDictValue(user, RATE)}.");
                    Console.WriteLine($"Money Earned for the Month: ${db.GetDictValue(user, MONTHEARNEDAMOUNT)}.");
                    Console.WriteLine($"Month Submitted for: {db.GetDictValue(user, TIMESUBMITTED)}.");
                    Console.WriteLine($"Last approved Month: {db.GetDictValue(user, TIMEAPPROVED)}.");
                    Console.Write($"If you want to approve the subbmited timesheet enter 1 otherwise enter 2: ");
                    SetSelection(int.Parse(Console.ReadLine()));
                    if (GetSelection() == 1)
                    {
                        db.ChangeDictValue(user, TIMEAPPROVED, SelectMonth("Enter the number of the Month you want to Approve the time for"));
                    }
                }
            }
        }
    }

}