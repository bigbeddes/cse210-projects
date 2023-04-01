using System;
public class Database 
{
    public Database()
    {}
    private string _userListFilename = "UserList.csv";
    private int GROUPID = 1;
    private int FIRSTNAME = 4;
    private int LASTNAME = 5;

    private Dictionary<int, Employee> _userDict = new Dictionary<int, Employee>();
 
    public void ConvertCsvFileToDict()
    {
        string [] lines = System.IO.File.ReadAllLines(_userListFilename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            AddToUserDict(parts);
        }
    }

     public void AddToUserDict(string [] parts)
    {
        int key=int.Parse(parts[2]);
        switch (parts[0])
        {
            case "Employee":
                Employee e = new Employee(parts[0], parts[1], key, parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
                _userDict[key]=e;
                break;
            case "Manager":
                Manager m = new Manager(parts[0], parts[1], key, parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
                _userDict[key]=m;
                break;
            case "Administrator":
                Administrator a = new Administrator(parts[0], parts[1], key, parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
                _userDict[key]=a;
                break;
            case "HR":
                HR hr = new HR(parts[0], parts[1], key, parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
                _userDict[key]=hr;
                break;
        }
    }

    public bool IDCheck(int key)
    {
        return _userDict.ContainsKey(key);
    }

    public List<int> GetKeyList()
    {
        List<int> keys = new List<int>();
        Dictionary<int, Employee>.KeyCollection keyColl = _userDict.Keys;
        foreach( int s in keyColl )
            {
                keys.Add(s);
            }
        return keys;
    }

    public void FinalSave()
    {
        List<int> keys = GetKeyList();
        int counter=1;
        foreach (int key in keys)
        {
            switch (counter)
            {
                case 1:
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(_userListFilename, false))
                    {
                        file.WriteLine(_userDict[key]._userRole + "," + _userDict[key]._groupID + "," + _userDict[key]._userID + "," + _userDict[key]._userPassword + "," + _userDict[key]._firstName + "," + _userDict[key]._lastName + "," + _userDict[key]._rate + "," +  _userDict[key]._payType + "," + _userDict[key]._hoursWorked + "," + _userDict[key]._timeSubmitted + "," + _userDict[key]._timeApproved + "," + _userDict[key]._timePaid + "," + _userDict[key]._monthEarnedAmount + "," + _userDict[key]._userActive);
                    }
                    break;
                case > 1:
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(_userListFilename, true))
                    {
                        file.WriteLine(_userDict[key]._userRole + "," + _userDict[key]._groupID + "," + _userDict[key]._userID + "," + _userDict[key]._userPassword + "," + _userDict[key]._firstName + "," + _userDict[key]._lastName + "," + _userDict[key]._rate + "," + _userDict[key]._payType + "," + _userDict[key]._hoursWorked + "," + _userDict[key]._timeSubmitted + "," + _userDict[key]._timeApproved + "," + _userDict[key]._timePaid + "," + _userDict[key]._monthEarnedAmount + "," + _userDict[key]._userActive);
                    }
                    break;
            }
            counter+=1;
        }
    }

    public Employee UserLogin()
    {
        int loginAttempt=0;
        string enteredPassword="";
        int lookupID=0;
        bool checkID = false;
        bool repeatLoop = true;
        Employee g= null;
        ConvertCsvFileToDict();
        // asks for and stores user ID
        Console.Clear();
        Console.WriteLine("Welcome to the Paperless Payroll Application: Please login.");
        do
        {
            
            Console.Write("Please enter your User ID: ");
            lookupID=int.Parse(Console.ReadLine());
            loginAttempt+=1;

            // Checks if entered ID exists in the User List
            checkID=IDCheck(lookupID);
            if (checkID)
            {
                Console.Write("Please endter your password: ");
                enteredPassword = Console.ReadLine();
                //checks if passwords match and if the user is active


                    if (enteredPassword  == _userDict[lookupID]._userPassword && _userDict[lookupID]._userActive == "yes")
                    {
                        //triggers the repeat loop while logic to change so we can get out of the do While loop
                        repeatLoop = false;
                        g= _userDict[lookupID];
                    }
                    //if user is disabled then they will get this displayed
                    else if (_userDict[lookupID]._userActive == "no")
                    {
                        Console.WriteLine("Entered User Account has been disabled, please contact your IT Administrator.");
                                Thread.Sleep(5000);
                    }
                    
                    else if (_userDict[lookupID]._userPassword != enteredPassword)
                    {
                        Console.WriteLine("Entered Password does not match saved password.");
                        Thread.Sleep(5000);
                    }
            }
            else
            {
                Console.WriteLine($"Entered ID - {lookupID} does not exist.");
                Thread.Sleep(5000);
            }
            
            //If you fail to login on the 3rd attempt you will get this error.
            if (loginAttempt >= 3)
            {
                //triggers the repeat loop while logic to change so we can get out of the do While loop
                if ( !checkID || enteredPassword != _userDict[lookupID]._userPassword || _userDict[lookupID]._userActive == "no")
                {
                    repeatLoop=false;
                    Console.Write("3 failed login attempts, please contact your IT Administrator");
                    Thread.Sleep(5000);
                }
            }
        }
        while (repeatLoop);
        
        return g;
    }

    public void ChangeDictValue(int key, int position, string newValue)
    {
        switch (position)
        {
            case 0:
                _userDict[key]._userRole=newValue;
                break;
            case 1:
                _userDict[key]._groupID=newValue;
                break;
            case 3:
                 _userDict[key]._userPassword=newValue;
                break;
            case 4:
                _userDict[key]._firstName=newValue;
                break;
            case 5:
                _userDict[key]._lastName=newValue;
                break;
            case 6:
                _userDict[key]._rate=newValue;
                break;
            case 7:
                _userDict[key]._payType=newValue;
                break;
            case 8:
                _userDict[key]._hoursWorked=newValue;
                break;
            case 9:
                _userDict[key]._timeSubmitted=newValue;
                break;
            case 10:
                _userDict[key]._timeApproved=newValue;
                break;
            case 11:
                _userDict[key]._timePaid=newValue;
                break;
            case 12:
                _userDict[key]._monthEarnedAmount=newValue;
                break;
            case 13:
                _userDict[key]._userActive=newValue;
                break;
            default:
                Console.WriteLine("Selection outside of dictionary range.");
                Thread.Sleep(3000);
                break;
        }
    }

    public string GetDictValue(int key, int position)
    {
        string value="";
        switch (position)
        {
            case 0:
                value = _userDict[key]._userRole;
                break;
            case 1:
                value = _userDict[key]._groupID;
                break;
            case 3:
                value = _userDict[key]._userPassword;
                break;
            case 4:
                value = _userDict[key]._firstName;
                break;
            case 5:
                value = _userDict[key]._lastName;
                break;
            case 6:
                value = _userDict[key]._rate;
                break;
            case 7:
                value = _userDict[key]._payType;
                break;
            case 8:
                value = _userDict[key]._hoursWorked;
                break;
            case 9:
                value = _userDict[key]._timeSubmitted;
                break;
            case 10:
                value = _userDict[key]._timeApproved;
                break;
            case 11:
                value = _userDict[key]._timePaid;
                break;
            case 12:
                value = _userDict[key]._monthEarnedAmount;
                break;
            case 13:
                value = _userDict[key]._userActive;
                break;
            default:
                Console.WriteLine("Selection outside of dictionary range.");
                Thread.Sleep(3000);
                break;
        }
        return value;
    }

    public int DisplayKeysWithNames()
    {
        int value;
        Console.Write("Enter the users First Name: ");
        string firstName=Console.ReadLine();
        Console.Write("Enter the users Last Name: ");
        string lastName=Console.ReadLine();
        List<int>usersMatch = new List<int>();
        List<int>keys=GetKeyList();
        foreach (int key in keys)
        {
            if (firstName ==GetDictValue(key, FIRSTNAME) && lastName==GetDictValue(key, LASTNAME))
            {
                usersMatch.Add(key);
            }
        }
        Console.WriteLine("Users that match:");
        foreach (int user in usersMatch)
        {
            Console.WriteLine($"User ID: {user}. User Name: {GetDictValue(user, FIRSTNAME)} {GetDictValue(user, LASTNAME)}. Group ID: {GetDictValue(user, GROUPID)}");
        }
        Console.WriteLine($"\nPlease enter the User ID you need to look up");
        value = int.Parse(Console.ReadLine());
        return value;
    }

    public void SaveNewUser(string userRole, string groupID, string userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(_userListFilename, true))
        {
            file.WriteLine(userRole + "," + groupID + "," + userID + "," + userPassword + "," + firstName + "," + lastName + "," + rate + "," + payType + "," + hoursWorked + "," + timeSubmitted + "," + timeApproved + "," + timePaid + "," + monthEarnedAmount + "," + userActive);
        }
        string[] g = new string[]{userRole, groupID, userID, userPassword, firstName, lastName, rate, payType, hoursWorked, timeSubmitted, timeApproved, timePaid, monthEarnedAmount, userActive};
        AddToUserDict(g);
    }
    
}