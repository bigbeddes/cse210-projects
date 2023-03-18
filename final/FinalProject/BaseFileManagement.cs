using System;
public class BaseFileManagement
{
    private string _userListFilename = "UserList.csv";
    private int _userID;
    private string _userPassword;
    private string _firstName;
    private string _lastName;
    private string _rate;
    private string _payType;
    private string _hoursWorked;
    private string _userRole;
    private string _groupID;
    private string _timeSubmitted;
    private string _timeApproved;
    private string _timePaid;
    private string _monthEarnedAmount;
    private string _userActive;
    private Dictionary<int, BaseFileManagement> _userDict = new Dictionary<int, BaseFileManagement>();
    public BaseFileManagement()
    {}
    //constructor to set up user dictionary
    public BaseFileManagement(int userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string userRole, string groupID, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive)
    {
        _userID=userID;
        _userPassword=userPassword;
        _firstName=firstName;
        _lastName=lastName;
        _rate=rate;
        _payType=payType;
        _hoursWorked=hoursWorked;
        _userRole=userRole;
        _groupID=groupID;
        _timeSubmitted=timeSubmitted;
        _timeApproved=timeApproved;
        _timePaid=timePaid;
        _monthEarnedAmount=monthEarnedAmount;
        _userActive=userActive;
    }
    //method to build user dictionary
    public void SetUserDict(int userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string userRole, string groupID, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive)
    {
        BaseFileManagement g = new BaseFileManagement(userID, userPassword, firstName, lastName, rate, hoursWorked, payType, userRole, groupID, timeSubmitted, timeApproved, timePaid, monthEarnedAmount, userActive);
        _userDict[userID]=g;
    }
    //Filename getter
    public string GetFilename()
    {
        return _userListFilename;
    }
    //Look up exact values from User Dictionary with UserID and returns specified value string
    public string GetValues(int key, int possition)
    {
        int selected = possition;
        string value="";
        if (selected == 1)
        {
            value=_userDict[key]._userPassword;
        }
        else if (selected == 2)
        {
            value=_userDict[key]._firstName;
        }
        else if (selected == 3)
        {
            value= _userDict[key]._lastName;
        }
        else if (selected == 4)
        {
            value= _userDict[key]._rate;
        }
        else if (selected == 5)
        {
            value= _userDict[key]._hoursWorked;
        }
        else if (selected == 6)
        {
            value= _userDict[key]._payType;
        }
        else if (selected == 7)
        {
            value= _userDict[key]._userRole;
        }
        else if (selected == 8)
        {
            value= _userDict[key]._groupID;
        }
        else if (selected == 9)
        {
            value= _userDict[key]._timeSubmitted;
        }
        else if (selected == 10)
        {
            value= _userDict[key]._timeApproved;
        }
        else if (selected == 11)
        {
            value= _userDict[key]._timePaid;
        }
        else if (selected == 12)
        {
            value= _userDict[key]._monthEarnedAmount;
        }
        else if (selected == 13)
        {
            value= _userDict[key]._userActive;
        }
        return value;
    }
    //Checks if User ID is in the User Dictionary and returns a bool value
    public bool IDCheck(int key)
    {
        return _userDict.ContainsKey(key);
    }
    //returns list of all User ID's in system
    public List<int> GetKeyList()
    {
        List<int> keys = new List<int>();
        Dictionary<int, BaseFileManagement>.KeyCollection keyColl = _userDict.Keys;
        foreach( int s in keyColl )
            {
                keys.Add(s);
            }
        return keys;
    }

    public void ChangeDictValue(int key, int possition, string newValue)
    {
        int selected = possition;
        if (selected == 1)
        {
            _userDict[key]._userPassword=newValue;
        }
        else if (selected == 2)
        {
            _userDict[key]._firstName=newValue;
        }
        else if (selected == 3)
        {
            _userDict[key]._lastName=newValue;
        }
        else if (selected == 4)
        {
            _userDict[key]._rate=newValue;
        }
        else if (selected == 5)
        {
            _userDict[key]._hoursWorked=newValue;
        }
        else if (selected == 6)
        {
            _userDict[key]._payType=newValue;
        }
        else if (selected == 7)
        {
            _userDict[key]._userRole=newValue;
        }
        else if (selected == 8)
        {
            _userDict[key]._groupID=newValue;
        }
        else if (selected == 9)
        {
            _userDict[key]._timeSubmitted=newValue;
        }
        else if (selected == 10)
        {
            _userDict[key]._timeApproved=newValue;
        }
        else if (selected == 11)
        {
            _userDict[key]._timePaid=newValue;
        }
        else if (selected == 12)
        {
            _userDict[key]._monthEarnedAmount=newValue;
        }
        else if (selected == 13)
        {
            _userDict[key]._userActive=newValue;
        }
    }

    public void SaveUserListCSV()
    {
        
    }
}