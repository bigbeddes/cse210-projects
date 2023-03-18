using System;
public class Load : BaseFileManagement
{
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

}







       