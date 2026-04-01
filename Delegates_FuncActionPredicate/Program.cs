namespace Delegates_FuncActionPredicate
{
    internal class Program
    {
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg1);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);
        static void Main(string[] args)
        {
            #region Part 1 : Func 
            MathClass math = new MathClass();
            Func<int, int, int> summation = math.Sum;

            //Replace the method above with delegate
            Func<int, int, int> addFuncDelegate = delegate (int a, int b)
            {
                return a + b;
            };

            //Replace the method above with lambda expression
            Func<int, int, int> addFuncLamda = (a, b) => a + b;

            //Replace "Func<int, int, int>" with "Func2<int, int, int>"
            Func2<int, int, int> addFunc = (a, b) => a + b;

            int result = addFunc(5, 3);
            Console.WriteLine($"Sum resut is {result}");

            float var1 = 2.3f;
            float var2 = 4.56f;
            int var3 = 7;

            // Func keyword is used to define a delegate that takes parameters and returns a value.
            // The last type parameter specifies the return type, while the preceding type parameters specify the input types. 
            Func<float, float, int, float> calculateFunc = (x, y, z) => x + y * z;
            float result2 = calculateFunc(var1, var2, var3);
            Console.WriteLine($"Sum resut is {result2}");

            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + annualSalary * bonusPercentage;
            decimal annualSalary = 50000m;
            decimal bonusPercentage = 0.1m;
            decimal totalCompensation = calculateTotalAnnualSalary(annualSalary, bonusPercentage);
            Console.WriteLine($"Total compensation is {totalCompensation}");
            #endregion

            #region Part 2 : Action
            //Action keyword is used to define a delegate that takes parameters but does not return a value.

            // Display employee details using Action delegate
            // Employee details: Id, First Name, Last Name, Annual Salary, Gender, Manager (true/false)
            Action<int, string, string, decimal, char, bool> displayEmployeeDetails
                = (arg1, arg2, arg3, arg4, arg5, arg6) =>
                Console.WriteLine($"Id: {arg1}{Environment.NewLine}" +
                $"First Name: {arg2}{Environment.NewLine}" +
                $"Last Name: {arg3}{Environment.NewLine}" +
                $"Annual Salary: {arg4}{Environment.NewLine}" +
                $"Gender: {arg5}{Environment.NewLine}" +
                $"Manager: {arg6}");

            displayEmployeeDetails(1, "John", "Doe", 60000m, 'M', true);
            #endregion

            #region Part 3 : Predicate
            //Predicate keyword is used to define a delegate that takes a parameter and returns a boolean value.
            // Check if a number is even using Predicate delegate 

            //Basic syntax
            Predicate<int> isEvenPredicate = number => number % 2 == 0;
            int numberToCheck = 10;
            Console.WriteLine($"Is {numberToCheck} even? {isEvenPredicate(numberToCheck)}");


            List<Employee> employees = new List<Employee>();

            employees.Add(new Employee { Id = 1, FirstName = "Sarah", LastName = "Jones", AnnualSalary = calculateTotalAnnualSalary(60000, 2), Gender = 'f', IsManager = true });
            employees.Add(new Employee { Id = 2, FirstName = "Andrew", LastName = "Brown", AnnualSalary = calculateTotalAnnualSalary(40000, 2), Gender = 'm', IsManager = false });
            employees.Add(new Employee { Id = 3, FirstName = "John", LastName = "Henderson", AnnualSalary = calculateTotalAnnualSalary(58000, 2), Gender = 'm', IsManager = true });
            employees.Add(new Employee { Id = 4, FirstName = "Jane", LastName = "May", AnnualSalary = calculateTotalAnnualSalary(30000, 2), Gender = 'f', IsManager = false });

            //Get the list of employees whose annual salary is greater than 50000 and are managers using Predicate delegate
            List<Employee> employeesFiltered = FilterEmployees(employees, employee => employee.AnnualSalary > 50000 && employee.IsManager);

            //Get the list of employees whose gender is 'f' and last name starts with 'J' using Predicate delegate
            List<Employee> employeesFiltered2 = FilterEmployees(employees, employee => employee.Gender == 'f' && employee.LastName.StartsWith("J"));

            //Display the filtered employees
            foreach (Employee employee in employeesFiltered)
            {
                displayEmployeeDetails(employee.Id, employee.FirstName, employee.LastName, employee.AnnualSalary, employee.Gender, employee.IsManager);
                Console.WriteLine();
            }

            foreach (Employee employee in employeesFiltered2)
            {
                displayEmployeeDetails(employee.Id, employee.FirstName, employee.LastName, employee.AnnualSalary, employee.Gender, employee.IsManager);
                Console.WriteLine();
            }
            #endregion

            #region Combine Func, Action, and Predicate
            math = new MathClass();
            math.PrintMessage($"Sum of 5 and 3 is {math.Add(5, 3)}. {Environment.NewLine}" +
                $"Is {math.Add(5, 3)} even? {math.IsEven(math.Add(5, 3))}");
            #endregion
        }
        static List<Employee> FilterEmployees(List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> employeesFiltered = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    employeesFiltered.Add(employee);
                }
            }
            return employeesFiltered;
        }
    }

    public class MathClass
    {
        public int Sum(int a, int b) => a + b;
        public Func<int, int, int> Add = (a, b) => a + b;
        public Action<string> PrintMessage = message => Console.WriteLine(message);
        public Predicate<int> IsEven = number => number % 2 == 0;
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }
}
