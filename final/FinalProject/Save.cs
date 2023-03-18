using System;
public class Save : BaseFileManagement
{
    //creats unclaimed user ID
    public int UserIDGenerator()
    {
        int counter=0;
        foreach (int ID in GetKeyList())
        {
            if (ID > counter)
            {
                counter = ID;
            }
        }
        return counter;
    }

    public void SaveNewUser(string userID, string userPassword, string firstName, string lastName, string rate, string hoursWorked, string payType, string userRole, string groupID, string timeSubmitted, string timeApproved, string timePaid, string monthEarnedAmount, string userActive)
    {
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(GetFilename(), true))
        {
            file.WriteLine(userID + "," + userPassword + "," + firstName + "," + lastName + "," + rate + "," + hoursWorked + "," + payType + "," + userRole + "," + groupID + "," + timeSubmitted + "," + timeApproved + "," + timePaid + "," + monthEarnedAmount + "," + userActive);
        }
        SetUserDict(int.Parse(userID), userPassword, firstName, lastName, rate, hoursWorked, payType, userRole, groupID, timeSubmitted, timeApproved, timePaid, monthEarnedAmount, userActive);
    }

    public void RelayChangeDictValue(int key, int possition, string newValue)
    {
        ChangeDictValue(key, possition, newValue);
    }

    public void RelaySaveUserListCSV()
    {
        SaveUserListCSV();
    }

}