 using System;
public class Manager : IPosition
{
    Load manLoad = new Load();
    Save manSave = new Save();

    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 approve time of employees in group.");
        Console.WriteLine("3 Update your password.");
        Console.WriteLine("4 Save changes and logout.");
        userSelection=int.Parse(Console.ReadLine());

        return userSelection;
    }

    public void ApproveTime(int groupID)
    {
        
        //iterate through all user keys and print their time info if their group ID matches the managers.
        List<int> userList= manLoad.RelayKeyList();
        int userGroupID;
        string userFirstName;
        string userLastName;
        string payType;
        string hoursWorked;
        string rate;
        string timeSubmitted;
        string monthEarnedAmount;
        string timeApproved;
        string userEntry;
        foreach (int user in userList)
        {
            userGroupID = int.Parse(manLoad.GetValue(user, 8));
            if (userGroupID==groupID)
            {
                Console.Clear();
                userFirstName = manLoad.GetValue(user, 2);
                userLastName = manLoad.GetValue(user, 3);
                payType = manLoad.GetValue(user, 6);
                hoursWorked = manLoad.GetValue(user, 5);
                rate = manLoad.GetValue(user, 4);
                timeSubmitted = manLoad.GetValue(user, 9);
                monthEarnedAmount = manLoad.GetValue(user, 12);
                timeApproved = manLoad.GetValue(user, 10);
                Console.WriteLine($"User ID: {user}.");
                Console.WriteLine($"User Name: {userFirstName} {userLastName}.");
                Console.WriteLine($"Pay Type: {payType}.");
                Console.WriteLine($"Hours Worked: {hoursWorked}.");
                Console.WriteLine($"Pay Rate: ${rate}.");
                Console.WriteLine($"Money Earned for the Month: ${monthEarnedAmount}.");
                Console.WriteLine($"Month Submitted for: {timeSubmitted}.");
                Console.WriteLine($"Last approved Month: {timeApproved}.");
                Console.WriteLine($"If you want to approve the subbmited timesheet enter 1 otherwise just hit enter");
                userEntry=Console.ReadLine();
                if (userEntry == "1")
                {
                    manSave.RelayChangeDictValue(user, 10, timeSubmitted);
                }
            }
        }
    }

}