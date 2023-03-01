using System;

class Program
{
    static void Main(string[] args)
    {
        int userSelection=0;
        Breathing breathing = new Breathing("Box-Breathing", "relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing");
        Reflecting reflecting = new Reflecting("Reflecting", "reflect on times in your life when you have shown strength and resilience");
        Listing listing = new Listing("Listing", "reflect on the good things in your life by having you list as many things as you can in a certain area");

        do
        {
            //User Menue
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Please select the number of the Activity you would like to select: ");
            userSelection = int.Parse(Console.ReadLine());
            Console.Clear();

            //Breathing Activity Selected
            if(userSelection == 1)
            {
                breathing.BreathingIntro();
                breathing.BreathingActivity();
                breathing.BreathingConclusion();
            }

            //Reflecting Activity Selected
            else if(userSelection == 2)
            {                
                reflecting.ReflectingIntro();
                reflecting.ReflectingActivity();
                reflecting.ReflectingConclusion();
            }

            //Listing Activity Selected
            else if (userSelection == 3)
            {
                listing.ListingIntro();
                listing.ListingActivity();
                listing.ListingConclusion();
            }

            //Catch if number entered is out of Range
            else if (userSelection < 1 || userSelection > 4)
            {
                Console.WriteLine("The number you entered is not a selectable option, please try again.");
                breathing.CountDownAnimation(5);
            }
            Console.Clear();
        }

        //Quit option Selected ends program.
        while(userSelection!=4);
    }
}