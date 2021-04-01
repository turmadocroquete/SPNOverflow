/* ADDED NAMESPACES */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/* TE404 */
namespace te404
{
    /* WildWest class */
    class WildWest
    {
        /* MAIN METHOD */
        static void Main(string[] args)
        {
            // Test input
            String[] test =
            { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };

            if (ValidateValues(test)){

                // Creation of the path
                List<Direction> directions = new List<Direction>();
                for (int i = 0; i < teste.Length; i++)
                {
                    Direction d = new Direction(teste[i]);
                    directions.Add(d);
                }
                Path path = new Path(directions);

                // Optimize path
                p.DirReduc();

                Console.WriteLine("***MENU***");
                Console.WriteLine("0 - Caps");
                Console.WriteLine("1 - Caps");
                Console.WriteLine("How do you wish to print the values?");

                int option;
                do {
                    option = Console.ReadLine();
                } while( option < 0 || option > 3 );

                // Print the final path
                p.PrintPath(option);
            }
            else
            {
                Console.WriteLine("The values are not valid!");
            }
        }

        /* VALIDATE VALUES METHOD */
        private bool validateValues (String[] v)
        {
            String[] valid = {"NORTH","North","SOUTH","South","EAST","East","WEST","West"};
            for (int i = 0; i < v.Length; i++)
            {
                if(Array.IndexOf(valid, v[i]) < 0)
                {                    
                    return false
                }
            }

            return true;
        }
    }

    /* DIRECTION CLASSES */
    class Direction
    {
        /* FIELDS */
        private String name;
        private int x;
        private int y;

        /* CONSTRUCTOR */
        public Direction(String n)
        {
            // Check which direction to create
            switch (n)
            {
                "North":
                "NORTH":
                    x = 0;
                    y = 1;
                    name = "north";
                    break;

                "South":
                "SOUTH":
                    x = 0;
                    y = -1;
                    name = "south";
                    break;

                "East":
                "EAST":
                    x = -1;
                    y = 0;
                    name = "east";
                    break;

                "West":
                "WEST":
                    x = 1;
                    y = 0;
                    name = "west";
                    break;

                default:
                    x = 0;
                    y = 0;
                    name = "none";
                    break;
            }
        }

        /* GET AND SET METHODS */
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String X
        {
            get { return x; }
            set { x = value; }
        }

        public String Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    /* PATH CLASS */
    class Path
    {
        /* FIELDS */
        private List<Direction> directions;

        /* CONSTRUCTOR */
        public Path(List<Direction> d)
        {
            directions = new List<Direction>(d);
        }

        /* GET AND SET METHODS */
        public String Directions
        {
            get { return directions; }
            set { directions = value.ToList(); }
        }

        /* METHOD TO OPTIMIZE PATH */
        public List<Direction> DirReduc()
        {
            // Variables
            List<Direction> bestPath = new List<Direction>();
            String opposite;
            int index;

            // Loop to iterate through directions
            foreach (Direction d in directions)
            {
                opposite = getOpposite(d.Name]);

                if ((bestPath.Contains(opposite)))
                {
                    index = bestPath.IndexOf(opposite);
                    bestPath.RemoveAt(index);
                }
                else
                {
                    bestPath.Add(d.Name);
                }
            }

            directions = new List<Direction>(bestPath);
        }

        /* METHOD TO OPTIMIZE PATH */
        public List<Direction> DirReducXY()
        {
            List<String> bestPath = new List<String>();
            int directionX;
            int directionY;

            foreach (Direction d in directions)
            {
                directionX += d.X;
                directionY += d.Y;
            }

            if(directionY > 0)
            {
                bestPath.AddRange(Enumerable.Repeat("north", directionY));
            }
            else if(directionY <0)
            {
                bestPath.AddRange(Enumerable.Repeat("south", System.Math.Abs(directionY)));
            }

            if(directionX > 0)
            {
                bestPath.AddRange(Enumerable.Repeat("west", directionX));
            }
            else if(directionX <0)
            {
                bestPath.AddRange(Enumerable.Repeat("east", System.Math.Abs(directionX)));
            }

            return bestPath;
        }

        /* METHOD TO GET OPPOSITE DIRECTION */
        public static String GetOpposite(String element)
        {
            if (element == "north")
            {
                return "south";
            }
            else if (element == "south")
            {
                return "north";
            }
            else if (element == "east")
            {
                return "west";
            }
            return "east";
        }

        /* METHOD TO DISPLAY PATH */
        public void PrintPath(int case)
        {
            Console.WriteLine("The optimized path is the following:");
            foreach (Direction d in directions)
            {
                Console.WriteLine(i + " - " + GetRightCase(d.Name, case));
            }
        }

        /* METHOD TO GET LETTERS IN THE RIGHT CASE */
        private static String GetRightCase(String s, int c)
        {
            if(c == 0)
            {
                return s.ToUpper();
            }
            else if (c == 1)
            {
                char[] letters = s.ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                return new String(letters);
            }
            return "";
        }
    }
}
