using System;


class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;


        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;


        // Return to your Program.cs. Add the end of the Main function, create a new instance of the Resume class.
        // Add the two jobs you created earlier, to the list of jobs in the resume object.
        // Verify that you can access and display the first job title using dot notation similar to myResume._jobs[0]._jobTitle .

        Resume myResume = new Resume();
        myResume._name = "Pedro";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}


