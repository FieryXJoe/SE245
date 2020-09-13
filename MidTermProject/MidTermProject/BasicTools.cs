using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;

namespace MidTermProject
{
    class BasicTools
    {
        public static void pause()
        {
            Console.WriteLine("\nPress Any Key to Continue\n");
            Console.ReadKey();
        }
        
        //Used Week4_Sample2_Class2.pdf from Canvas as reference point for this function
        public static bool isValidEmail(String s)
        {
            bool rtrn = true;
            int atLocation = s.IndexOf("@"), nextAtLocation = s.IndexOf("@", atLocation + 1), periodLocation = s.LastIndexOf(".");
            if (s.Length < 8)
                rtrn = false;
            else if (atLocation < 2)
                rtrn = false;
            else if (periodLocation == -1 || atLocation == -1)
                rtrn = false;
            else if (periodLocation + 2 > s.Length)
                rtrn = false;
            return rtrn;

        }
    }
}
