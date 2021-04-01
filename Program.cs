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
            Console.WriteLine("-------------------------");
            Console.WriteLine("Welcome to the wild west!");
            Console.WriteLine("-------------------------\n");

            // Reads user values
            List <String> input = ReadDirections();

            // Print input
            PrintInput(input);

            Path path = CreatePath(input);

            // Optimize path
            path.DirReduc();

            // Read option from console
            String option = ReadOption();

            // Print the final path
            path.PrintPath(option);
        }

        /* READ DIRECTIONS FROM USER */
        private static List<String> ReadDirections()
        {
            List<String> valid = new List<String> { "north", "south", "east", "west", "exit", "n", "s", "w", "e" };
            List<String> input = new List <String>();
            String i = "";

            Console.WriteLine("***INSTRUCTIONS***");
            Console.WriteLine("Type the path you want cowboy! Most probabily you will get the best of it ;)");
            Console.WriteLine("The path choose must contain the following values: (n)orth, (s)outh, (e)ast, (w)est or exit (to stop)!");
            Console.WriteLine("Values can be in any case...");
            Console.WriteLine("Here's a path you can try out: north, south, south, west, north!");
            Console.WriteLine("If you type any other value, you'll be busted!");
            Console.WriteLine("Best of lucks!");
            Console.WriteLine("******************\n");
            do
            {
                Console.WriteLine("Your move:");
                i = Console.ReadLine().ToLower();
                if (valid.Contains(i) && !(i.Equals("exit")))
                {
                    input.Add(GetFullDirection(i));
                }
                else if(!(valid.Contains(i)))
                {
                    Console.WriteLine("Invalid input! The valid values are: north, south, east or west!");
                }

            } while (!(i.Equals("exit")));

            return input;
        }

        /* GET FULL NAME OF DIRECTION METHOD */
        private static String GetFullDirection(String i)
        {
            if (i == "n")
            {
                return "north";
            }
            else if (i == "s")
            {
                return "south";
            }
            else if (i == "e")
            {
                return "east";
            }
            else if (i == "w")
            {
                return "west";
            }
            return i;
        }

        /* PRINT INPUT METHOD */
        private static void PrintInput(List<String> input)
        {
            Console.WriteLine("\nThe current input is:");

            foreach (String i in input)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n");
        }

        /* CREATION OF PATH THROUGH USER INPUT */
        private static Path CreatePath(List <String> input)
        {
            Direc d;
            List<Direc> directions = new List<Direc>();

            // Creation of the path
            foreach (String i in input)
            {
                d = GetDirection(i);
                directions.Add(d);
            }

            return new Path(directions);
        }

        /* READ OPTIONS METHOD */
        private static String ReadOption()
        {
            String option;

            // Print menu
            Console.WriteLine("Now, lets print!\n");
            Console.WriteLine("You can use the values inside square brackets to choose the case!");
            Console.WriteLine("Options:");
            Console.WriteLine("------------");
            Console.WriteLine("Caps - [caps]");
            Console.WriteLine("Camel Case - [camel]\n");
            Console.WriteLine("How do you wish to print the values?");

            // Read input
            do
            {
                option = Console.ReadLine();

                Console.WriteLine(option);

                if (!(option.Equals("caps")) && !(option.Equals("camel")))
                {
                    Console.WriteLine("Invalid option!\nPlease type a valid option:");
                }

            } while (!(option.Equals("caps")) && !(option.Equals("camel")));

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
        public void PrintPath(String cas)
        {
            // Prints path
            Console.WriteLine("\nThe optimized path is the following:");
            for (int i = 0; i < directions.Count; i++)
            {
                Console.WriteLine(GetRightCase(directions[i].Name, cas));
            }
        }

        /* METHOD TO GET LETTERS IN THE RIGHT CASE */
        private static String GetRightCase(String s, String c)
        {
            char[] letters;

            // Changes case according to input
            if (c.Equals("caps"))
            {
                return s.ToUpper();
            }
            else if (c.Equals("camel"))
            {
                letters = s.ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                return new String(letters);
            }
            return "";
        }
    }
}
