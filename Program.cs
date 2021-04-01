/* ADDED NAMESPACES */
using System;
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
            Console.WriteLine("Welcome to the wild west!");

            // Test input
            String[] test =
            { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };

            // Print input
            PrintInput(test);

            // Validates the input
            if (ValidateValues(test))
            {
                // Creation of the path
                List<Direc> directions = new List<Direc>();
                for (int i = 0; i < test.Length; i++)
                {
                    Direc d = GetDirection(test[i].ToLower());
                    directions.Add(d);
                }
                Path path = new Path(directions);

                // Optimize path
                path.DirReduc();

                // Read option from console
                int option = ReadOption();

                // Print the final path
                path.PrintPath(option);
            }
            else
            {
                Console.WriteLine("The values are not valid!");
            }
        }

        /* VALIDATE VALUES METHOD */
        private static bool ValidateValues(String[] v)
        {
            // Valid values
            String[] valid = { "north", "south", "east", "west" };

            // Loop through input values
            for (int i = 0; i < v.Length; i++)
            {
                if (Array.IndexOf(valid, v[i].ToLower()) < 0)
                {
                    return false;
                }
            }

            return true;
        }

        /* PRINT INPUT METHOD */
        private static void PrintInput(String[] input)
        {
            Console.WriteLine("The current input is:");
            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine(input[i]);
            }
            Console.WriteLine("\n");
        }

        /* READ OPTIONS METHOD */
        private static int ReadOption()
        {
            int option;

            // Print menu
            Console.WriteLine("***MENU***");
            Console.WriteLine("0 - Caps");
            Console.WriteLine("1 - Camel Case");
            Console.WriteLine("How do you wish to print the values?");

            // Read input
            do
            {
                option = int.Parse(Console.ReadLine());
                if (option < 0 || option > 1)
                {
                    Console.WriteLine("Invalid option!\nPlease type a valid option:");
                }
            } while (option < 0 || option > 1);

            return option;
        }

        /* GET RIGHT DIRECTION OBJECT */
        private static Direc GetDirection(String dir)
        {
            // Check direction
            if (dir == "north")
            {
                return new North();
            }
            else if (dir == "south")
            {
                return new South();
            }
            else if (dir == "west")
            {
                return new West();
            }
            return new East();
        }
    }

    /* DIRECTION CLASSES */
    class Direc
    {
        /* FIELDS */
        protected String name;
        protected int x;
        protected int y;

        /* CONSTRUCTOR */
        public Direc()
        {
            name = "";
            x = 0;
            x = 0;
        }

        /* GET AND SET METHODS */
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
    }

    /* NORTH CLASS */
    class North : Direc
    {
        public North()
        {
            this.name = "north";
            this.x = 0;
            this.y = 1;
        }
    }

    /* SOUTH CLASS */
    class South : Direc
    {
        public South()
        {
            this.name = "south";
            this.x = 0;
            this.y = -1;
        }
    }

    /* EAST CLASS */
    class East : Direc
    {
        public East()
        {
            this.name = "east";
            this.x = -1;
            this.y = 0;
        }
    }

    /* WEST CLASS */
    class West : Direc
    {
        public West()
        {
            this.name = "west";
            this.x = 1;
            this.y = 0;
        }
    }

    /* PATH CLASS */
    class Path
    {
        /* FIELDS */
        private List<Direc> directions;

        /* CONSTRUCTOR */
        public Path(List<Direc> d)
        {
            directions = new List<Direc>(d);
        }

        /* GET AND SET METHODS */
        public List<Direc> Directions
        {
            get { return directions; }
            set { directions = value.ToList(); }
        }

        /* METHOD TO OPTIMIZE PATH */
        public void DirReduc()
        {
            List<Direc> bestPath = new List<Direc>();
            int directionX = 0;
            int directionY = 0;
            Direc dir;

            // Add directions
            foreach (Direc d in directions)
            {
                directionX += d.X;
                directionY += d.Y;
            }

            // Check what directions to add to the best path
            if (directionY > 0)
            {
                dir = new North();
                bestPath.AddRange(Enumerable.Repeat(dir, directionY));
            }
            else if (directionY < 0)
            {
                dir = new South();
                bestPath.AddRange(Enumerable.Repeat(dir, System.Math.Abs(directionY)));
            }

            if (directionX > 0)
            {
                dir = new West();
                bestPath.AddRange(Enumerable.Repeat(dir, directionX));
            }
            else if (directionX < 0)
            {
                dir = new East();
                bestPath.AddRange(Enumerable.Repeat(dir, System.Math.Abs(directionX)));
            }

            directions = bestPath.ToList();
        }

        /* METHOD TO DISPLAY PATH */
        public void PrintPath(int cas)
        {
            // Prints path
            Console.WriteLine("\nThe optimized path is the following:");
            for (int i = 0; i < directions.Count; i++)
            {
                Console.WriteLine(GetRightCase(directions[i].Name, cas));
            }
        }

        /* METHOD TO GET LETTERS IN THE RIGHT CASE */
        private static String GetRightCase(String s, int c)
        {
            char[] letters;

            // Changes case according to input
            if (c == 0)
            {
                return s.ToUpper();
            }
            else if (c == 1)
            {
                letters = s.ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                return new String(letters);
            }
            return "";
        }
    }
}
