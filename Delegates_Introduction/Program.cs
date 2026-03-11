namespace Delegates_Introduction
{
    internal class Program
    {
        //Defining a delegate type
        //This delegate can point to any method that takes a string parameter and returns void
        delegate void LogDelegate(string message);
        static void Main(string[] args)
        {
            #region Part 1: Using a delegate to point to a static method
            ////Creating an instance of the delegate and assigning it a method
            //LogDelegate logDelegate = new LogDelegate(LogTextToFile);

            //// Ask the user enter the name
            //Console.Write("Please enter your name:");
            //string name = Console.ReadLine();

            ////Using the delegate to call the method
            //logDelegate($"Hello, {name}! Welcome to the world of delegates in C# Part 1!");
            #endregion

            #region Part 2: Using a delegate to point to an instance method
            //// Create the instance of the Logger class
            //Logger logger = new Logger();

            //// Create another instance of the delegate and assign it an instance method
            //LogDelegate logDelegateInstance = new LogDelegate(logger.LogTextToScreen);

            //// Ask the user enter the name
            //Console.Write("Please enter your name:");
            //string name = Console.ReadLine();

            //// Using the delegate to call the instance method
            //logDelegateInstance($"Hello, {name}! Welcome to the world of delegates in C# Part 2!");
            #endregion

            #region Part 3: Using a delegate to point to multiple methods (Multicast Delegates)
            //// Create the instance of the Logger class
            //Logger logger = new Logger();

            //// Create a multicast delegate that points to both the static and instance methods
            //LogDelegate multicastLogDelegate = LogTextToFile;
            //multicastLogDelegate += logger.LogTextToScreen;

            //// Ask the user enter the name
            //Console.Write("Please enter your name:");
            //string name = Console.ReadLine();

            //// Using the multicast delegate to call both methods
            //multicastLogDelegate($"Hello, {name}! Welcome to the world of delegates in C# Part 3!");
            #endregion

            #region Part 4: Delegates passed as arguments to methods
            //// Create the instance of the Logger class
            //Logger logger = new Logger();

            //// Create a multicast delegate that points to both the static and instance methods
            //LogDelegate multicastLogDelegate = LogTextToFile;
            //multicastLogDelegate += logger.LogTextToScreen;

            //// Ask the user enter the name
            //Console.Write("Please enter your name:");
            //string name = Console.ReadLine();

            ////Passing multicast delegate as an argument to a method that takes a LogDelegate parameter
            //LogMessage(multicastLogDelegate, $"Hello, {name}! Welcome to the world of delegates in C# Part 4!");
            #endregion

            #region Part 5: Using lambda expressions with delegates
            // Create a LogDelegate instance using a lambda expression
            LogDelegate lambdaLogDelegate = message => Console.WriteLine($"{DateTime.Now}: {message}");

            // Ask the user enter the name
            Console.Write("Please enter your name:");
            string name = Console.ReadLine();

            // Using the lambda delegate to log a message
            lambdaLogDelegate($"Hello, {name}! Welcome to the world of delegates in C# Part 5!");
            #endregion

        }

        // A static method that matches the signature of the LogDelegate
        static void LogTextToScreen(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        // Another static method that matches the signature of the LogDelegate
        static void LogTextToFile(string message)
        {
            string fileName = "log.txt";
            using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }

        // A method that takes a LogDelegate as a parameter and uses it to log a message
        static void LogMessage(LogDelegate logMethod, string message)
        {
            logMethod(message);
        }
    }

    public class Logger
    {
        // A instant method that matches the signature of the LogDelegate
        public void LogTextToScreen(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }

        // Another instant method that matches the signature of the LogDelegate
        public void LogTextToFile(string message)
        {
            string fileName = "log.txt";
            using (StreamWriter writer = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName), true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
