//Requirements: For each student, enter a name and 5 lab grades.Display each student with each average grade for their 5 labs, and their letter grade.
//Drop down a line or two, and then display the average for each lab #.  (Average grade on Lab #1 for all students)
//Joseph Sherry

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab_2
{
    class Program
    {
        //function calculateLetterGrade
        //Use code from last lab here
        //Return letter grade
        public static String calcLetGrade(double avg)
        {
            return avg >= 90 ? "A" : avg >= 80 ? "B" : avg >= 70 ? "C" : avg >= 65 ? "D" : "F";
        }
        static void Main(string[] args)
        {
            //Create vars
            //lists
            //Name, 5 grades, average
            List<String> names = new List<String>();
            List<double> lab1Grades = new List<double>();
            List<double> lab2Grades = new List<double>();
            List<double> lab3Grades = new List<double>();
            List<double> lab4Grades = new List<double>();
            List<double> lab5Grades = new List<double>();
            List<double> studentAvgs = new List<double>();
            // Boolean var starting true
            bool flag = true;
            //Declare 5 new doubles for class avgs
            double lab1Avg = 0, lab2Avg = 0, lab3Avg = 0, lab4Avg = 0, lab5Avg = 0;
            //Declare counter for class avg math
            int counter = 0;

            //While var true
            while (flag)
            {
                //Prompt user to enter name
                Console.Write("Enter the name of the student: ");
                names.Add(Console.ReadLine());
                //For loop looping 5 times (since there are 5 separate lists a for loop seems less efficient than just writing the code 5 times for 5 lists)
                //Prompt user to enter grades & Store data in list / array
                Console.Write("Enter " + names[counter] + "'s grade on Lab 1: ");
                lab1Grades.Add(double.Parse(Console.ReadLine()));

                Console.Write("Enter " + names[counter] + "'s grade on Lab 2: ");
                lab2Grades.Add(double.Parse(Console.ReadLine()));
                
                Console.Write("Enter " + names[counter] + "'s grade on Lab 3: ");
                lab3Grades.Add(double.Parse(Console.ReadLine()));
                
                Console.Write("Enter " + names[counter] + "'s grade on Lab 4: ");
                lab4Grades.Add(double.Parse(Console.ReadLine()));
                
                Console.Write("Enter " + names[counter] + "'s grade on Lab 5: ");
                lab5Grades.Add(double.Parse(Console.ReadLine()));

                //Calculate average
                studentAvgs.Add(Math.Round((lab1Grades[counter] + lab2Grades[counter] + lab3Grades[counter] + lab4Grades[counter] + lab5Grades[counter]) / 5 , 2));
                
                //var = prompt user if they want to continue (t / f)
                Console.Write("Would you like to enter grades for another student (y/n): ");
                flag = Console.ReadLine().ToLower() == "y" ? true : false;

                //Increment counter
                counter++;

                //Clear screen
                Console.Clear();
            }
            //Output individuals
            //for each student (this was assuming 2d list not separate lists)
            for (int i = 0; i < counter; i++)
            {
                //Name Avg and calculateLetterGrade(avg)
                Console.WriteLine(names[i] + " had an average of " + studentAvgs[i] + " and earned a " + calcLetGrade(studentAvgs[i]) + " in the class.");
                Console.WriteLine("Lab 1: " + lab1Grades[i] + " || Lab 2: " + lab2Grades[i] + " || Lab 3: " + lab3Grades[i] + " || Lab 4: " + lab4Grades[i] + " || Lab 5: " + lab5Grades[i]);
                Console.WriteLine();
            }
            //Output class averages
            //For each student(once again was expecting 2d array will need 5 loops instead)
            foreach(double lab1Grade in lab1Grades)
                //Add grade 1 to 1st var grade 2 to 2nd var etc…
                lab1Avg += lab1Grade;
            foreach (double lab2Grade in lab2Grades)
                lab2Avg += lab2Grade;
            foreach (double lab3Grade in lab3Grades)
                lab3Avg += lab3Grade;
            foreach (double lab4Grade in lab4Grades)
                lab4Avg += lab4Grade;
            foreach (double lab5Grade in lab5Grades)
                lab5Avg += lab5Grade;
            //Divide 1st var by counter and 2nd var by counter etc… (rounded to 2 decimal places)
            lab1Avg = Math.Round(lab1Avg / counter, 2);
            lab2Avg = Math.Round(lab2Avg / counter, 2);
            lab3Avg = Math.Round(lab3Avg / counter, 2);
            lab4Avg = Math.Round(lab4Avg / counter, 2);
            lab5Avg = Math.Round(lab5Avg / counter, 2);
            //Vars now store class average per lab
            //Output averages for each lab
            Console.WriteLine();
            Console.WriteLine("The class average on Lab 1 was " + lab1Avg);
            Console.WriteLine("The class average on Lab 2 was " + lab2Avg);
            Console.WriteLine("The class average on Lab 3 was " + lab3Avg);
            Console.WriteLine("The class average on Lab 4 was " + lab4Avg);
            Console.WriteLine("The class average on Lab 5 was " + lab5Avg);
        }
    }
}
