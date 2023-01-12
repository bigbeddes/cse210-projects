using System;

class Program
{
    static void Main(string[] args)
    {
        int selection=0;
        List<int>numbers= new List<int>();

        do
        {
            Console.Write("Enter number: ");
            string choice = Console.ReadLine();
            selection = int.Parse(choice);
            if (selection!=0)
            {
                numbers.Add(selection);
            }
        } while (selection!= 0);

        int sum=0;
        int largest=-999999999;
        int smallest=999999999;
        foreach (int num in numbers)
        {
            sum+=num;
            if (num>largest)
            {
                largest=num;
            }
            if (num>0)
            {
                if (num<smallest)
                {
                    smallest=num;
                }
            }
        }
        Console.WriteLine($"The sum is: {sum}");

        int totalEntries= numbers.Count;
        float average=sum/totalEntries;
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");

    }
}