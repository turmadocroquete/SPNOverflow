using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace te404
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            String[] teste = { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };

            Path p = new Path(teste);

            String[] abc = p.DirReduc();
            for (int i = 0; i < abc.Length; i++)
            {

                Console.WriteLine("Array Element: " + abc[i]);

            }
        }
    }
  class Path
    {

        private String [] p;
        public Path(String []dir) {
          
            p= new String [dir.Length];
           
            for (int i =0; i<dir.Length; i++)
            {
                p[i] = dir[i];

            }

            
        }
        
       



        public String [] DirReduc()
    {
           //Create an empty list of strings
            List<String> list = new List<String>();
              

                for (int i = 0; i < p.Length; i++)
                {
                //Check if input array contains only: NORTH, SOUTH, EAST, WEST values


                //Check for NORTH<->SOUTH or SOUTH<->NORTH or EAST<->WEST or WEST<->EAST

                String opposite = getOpposite(p[i]);

                if ((list.Contains(opposite)))
                {
                    int index = list.IndexOf(opposite);
                    list.RemoveAt(index);
                }
                else
                {
                    list.Add(p[i]);
                }

            }
           

            //Convert Final list to Array of Strings
            String[]arr1= list.ToArray();
       
            return arr1;
    }

        public static String getOpposite(String element)
        {
            if (element == "NORTH")
            {
                return "SOUTH";
            }
            else if (element == "SOUTH")
            {
                return "NORTH";
            }
            else if (element == "EAST")
            {
                return "WEST";
            }
            return "EAST";
        }
    }
}