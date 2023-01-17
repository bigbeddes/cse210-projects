using System;


class Program
{
    static void Main(string[] args)
    {
       Job job1 = new Job();
       job1._company="City of Sacramento";
       job1._jobTitle="Information Technology Support Specialist";
       job1._startYear=2014;
       job1._endYear=2019;

       Job job2 = new Job();
       job2._company="California Highway Patrol";
       job2._jobTitle="Information Technology  Specialist";
       job2._startYear=2019;
       job2._endYear=2023;

       Resume myResume= new Resume();
       myResume._name="Ryan Beddes";

       myResume._jobs.Add(job1);
       myResume._jobs.Add(job2);

       myResume.Display();
    }
}