using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1,100);
        int guess = 0;
        int counter = 0;
        do
        {
            Console.Write("What is the magic number? 1-100) ");
            string choice = Console.ReadLine();
            guess = int.Parse(choice);
            if (guess > 100)
            {
                Console.WriteLine("The number you guessed is not in the range of 1-100.");
            }
            else if (guess < 1)
            {
                Console.WriteLine("The number you guessed is not in the range of 1-100.");
            }
            else if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You Guessed it!");
            }
            counter += 1;
        } while (guess!= number);
        Console.WriteLine($"You guessed {counter} times.");
    }
}