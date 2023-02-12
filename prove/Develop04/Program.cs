using System;

class Program
{
    static void Main(string[] args)
    {
        string testString=$"Now the Lord had shown unto me, Abraham, the intelligences that were organized before the world was; and among all these there were many of the noble and great ones;And God saw these souls that they were good, and he stood in the midst of them, and he said: These I will make my rulers; for he stood among those that were spirits, and he saw that they were good; and he said unto me: Abraham, thou art one of them; thou wast chosen before thou wast born.";
        Console.WriteLine(testString);
        List<string> list = new List<string>();
        string[] splittedStringArray = testString.Split(' ');
        foreach (string stringInArray in splittedStringArray)
        {
            list.Add(stringInArray);
        }
        Console.WriteLine(list);
    }
}