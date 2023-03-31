using System;
public class Load : BaseFileManagement
{
    private string _firstName;
    private string _lastName;
    private string _userGroupID;
    //converts User List Csv file into a User Dictionary
    public void LoadDict()
    {
        string [] lines = System.IO.File.ReadAllLines(GetFilename());
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            int key=int.Parse(parts[0]);
            SetUserDict(key, parts[1], parts[2], parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], parts[12], parts[13]);
        }
    }
    //Passes GetValues() value from BaseFileManagement
    public string GetValue(int key, int possition)
    {
        return GetValues(key, possition);
    }
    //Passes IDcheck() bool from BaseFileManagement
    public bool CheckID(int key)
    {
        return IDCheck(key);
    }

    public List<int> RelayKeyList()
    {
        return GetKeyList();
    }

    public void DisplayKeysWithName()
    {
        Console.Write("Enter the users First Name: ");
        _firstName=Console.ReadLine();
        Console.Write("Enter the users Last Name: ");
        _lastName=Console.ReadLine();
        string compareFirstName;
        string compareLastName;
        List<int>usersMatch = new List<int>();
        List<int>keys=GetKeyList();
        foreach (int key in keys)
        {
            compareFirstName=GetValues(key, 2);
            compareLastName=GetValues(key, 3);
            if (compareFirstName == _firstName && compareLastName == _lastName)
            {
                usersMatch.Add(key);
            }
        }
        Console.WriteLine("Users that match:");
        foreach (int user in usersMatch)
        {
            _userGroupID=GetValues(user, 8);
            Console.WriteLine($"User ID: {user}. User Name: {_firstName} {_lastName}. Group ID: {_userGroupID}");
        }
    }

}







       