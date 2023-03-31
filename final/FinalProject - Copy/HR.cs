using System;
public class HR : IPosition
{
    private string userGroupID;
    private string userFirstName;
    private string userLastName;
    private string payType;
    private string hoursWorked;
    private string rate;
    private string timeSubmitted;
    private string monthEarnedAmount;
    private string timeApproved;
    private string timePaid;
    private int userEntry;
    Load hrLoad = new Load();
    Save hrSave = new Save();
    public int MainMenu()
    {
        int userSelection=0;
        Console.WriteLine("1. Enter time worked for the month and submit for approval.");
        Console.WriteLine("2 Submit approved timesheets to be paid.");
        Console.WriteLine("3 Update your password.");
        Console.WriteLine("4 Save changes and logout.");
        userSelection=int.Parse(Console.ReadLine()); 

        return userSelection;
    }

    public void PayTimesheets()
    {
        List<int> userList= hrLoad.RelayKeyList();
        
        foreach (int user in userList)
        {
            Console.Clear();
            userFirstName = hrLoad.GetValue(user, 2);
            userLastName = hrLoad.GetValue(user, 3);
            userGroupID = hrLoad.GetValue(user, 8);
            payType = hrLoad.GetValue(user, 6);
            hoursWorked = hrLoad.GetValue(user, 5);
            rate = hrLoad.GetValue(user, 4);
            timeSubmitted = hrLoad.GetValue(user, 9);
            monthEarnedAmount = hrLoad.GetValue(user, 12);
            timeApproved = hrLoad.GetValue(user, 10);
            timePaid=hrLoad.GetValue(user, 11);

            Console.WriteLine($"User ID: {user}.");
            Console.WriteLine($"User Name: {userFirstName} {userLastName}.");
            Console.WriteLine($"User Department ID: {userGroupID}.");
            Console.WriteLine($"Pay Type: {payType}.");
            Console.WriteLine($"Hours Worked: {hoursWorked}.");
            Console.WriteLine($"Pay Rate: ${rate}.");
            Console.WriteLine($"Money Earned for the Month: ${monthEarnedAmount}.");
            Console.WriteLine($"Month Submitted for: {timeSubmitted}.");
            Console.WriteLine($"Last approved Month: {timeApproved}.");
            Console.WriteLine($"Last paid Month: {timePaid}.");
            Console.WriteLine($"If you want pay for the approved time sheet enter 1 otherwise enter 0");
            userEntry=int.Parse(Console.ReadLine());
            if (userEntry == 1)
            {
                hrSave.RelayChangeDictValue(user, 11, timeApproved);
            }
        }
    }

}