/*
    Joseph Sherry
    Lab 1
 
    Program gets students name and 4 grades, calculates average and letter grade
    displays grade with % and letter grade and allows user to read data before ending.

    vars
    
    name                Name input by user
    letGrADE            The letter grade determined by program
    grade1-grade4       The unique grades input by user
    avg                 The average grade calculated by program
 */

using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            String name, letGrade;
            Double grade1, grade2, grade3, grade4, avg;

            Console.Write("Enter the student's name:");
            name = Console.ReadLine();
            
            Console.Write("Enter the 1st grade:");
            grade1 = Double.Parse(Console.ReadLine());
            Console.Write("Enter the 2nd grade:");
            grade2 = Double.Parse(Console.ReadLine());
            Console.Write("Enter the 3rd grade:");
            grade3 = Double.Parse(Console.ReadLine());
            Console.Write("Enter the 4th grade:");
            grade4 = Double.Parse(Console.ReadLine());

            avg = grade1 + grade2 + grade3 + grade4;
            avg /= 4;

            //I'm a big fan of ternary operators if you hate them I can stop
            letGrade = (avg >= 90 ? "A" : (avg >= 80 ? "B" : (avg >= 70 ? "C" : (avg >= 65 ? "D" : "F"))));

            Console.WriteLine("\n\n\n\n" + name + "\n" + avg + "%\n" + letGrade);
        }
    }
}
