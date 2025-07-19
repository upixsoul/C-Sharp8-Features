using C_Sharp8.Utils;
using System.IO;
using System.Net;

namespace C_Sharp8
{
    //8.- Init-Only Properties
    public class Configuration
    {
        public string ConnectionString { get; init; }
        public int MaxRetries { get; init; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG C# 8 Catalog");
            Console.WriteLine("This catalog contains examples of C# 8.0 features");
            Console.WriteLine("These features are available in .NET Core 3.0+");

            #region NullableReferenceTypes
            Console.WriteLine("1.- Testing nullable reference types");
            Console.WriteLine("Enables better null safety by distinguishing nullable from non-nullable reference types.");
            ProcessUser(new User());
            #endregion

            #region DefaultInterfaceMethods
            Console.WriteLine();
            Console.WriteLine("2.- Testing Default Interface Methods");
            Console.WriteLine("Allows interfaces to have default implementations, enabling API evolution without breaking existing code.");

            ILogger logger = new ConsoleLogger();
            logger.Log("Info message");
            logger.LogError("Something went wrong");
            #endregion

            #region SwitchExpressions
            Console.WriteLine();
            Console.WriteLine("3.- Testing Switch Expressions");
            Console.WriteLine("Simplifies switch statements with concise, expression-based syntax.");
            HttpStatusCode status = HttpStatusCode.OK;
            var result = status switch
            {
                HttpStatusCode.OK => "Success",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.BadRequest => "Invalid request",
                _ => "Unknown status"
            };
            Console.WriteLine($"HTTP Status: {status}, Result: {result}");
            Console.WriteLine($"Using method: {GetStatusDescription(status)}");
            #endregion

            #region PatternMatchingAndRecords
            Console.WriteLine();
            Console.WriteLine("4.- Testing Pattern Matching Enhancements");
            Console.WriteLine("Includes recursive patterns, property patterns, and tuple patterns for more expressive code.");
            Console.WriteLine("7.- Testing Records");
            Console.WriteLine("Immutable data types for concise data modeling with value-based equality.");


            var product = new Product("Laptop", 1200.00m, true);
            var productResult = EvaluateProduct(product);
            var product2 = product with { Name = "iPad", IsInStock = false, Price = 800 }; // Non-destructive mutation
            var product2Result = EvaluateProduct(product2);
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, In Stock: {product.IsInStock}");
            Console.WriteLine($"Evaluation Result: {productResult}");

            Console.WriteLine($"Product2: {product2.Name}, Price: {product2.Price}, In Stock: {product2.IsInStock}");
            Console.WriteLine($"Evaluation Result: {product2Result}");
            #endregion

            #region UsingDeclarations
            Console.WriteLine();
            Console.WriteLine("5.- Using Declarations");
            Console.WriteLine("Automatically disposes resources when they go out of scope, reducing nesting.");
            //ReadFile("file.txt");
            Console.WriteLine("Reader disposed automatically");
            #endregion

            #region AsyncStreams
            Console.WriteLine();
            Console.WriteLine("6.- Async Streams (IAsyncEnumerable)");
            Console.WriteLine("Enables asynchronous iteration over collections, ideal for streaming data.");
            PrintSequence().Wait();
            #endregion

            #region InitOnlyProperties
            Console.WriteLine();
            Console.WriteLine("8.- Init-Only Properties");
            Console.WriteLine("Allows properties to be set only during object initialization");
            var config = new Configuration { ConnectionString = "Server=...", MaxRetries = 3 };
            Console.WriteLine($"config.ConnectionString = {config.ConnectionString} config.MaxRetries = {config.MaxRetries}");
            Console.WriteLine("config.ConnectionString = \"new value\"; //will trigger a Compile-time error");
            #endregion

            #region RangesAndIndices
            Console.WriteLine();
            Console.WriteLine("9.- Ranges and Indices");
            Console.WriteLine("Simplifies slicing and indexing of arrays or collections.");
            // Creating and initializing an array 
            int[] arr = new int[] { 1, 2, 3, 4, 5 };

            // Simple getting the index value 
            Console.WriteLine("Values of the specified indexes:");
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr[2]);
            Console.WriteLine(arr[3]);
            Console.WriteLine(arr[4]);

            // Using index from end(^) operator
            // Getting the index value from the end
            Console.WriteLine("Values from the end:");
            Console.WriteLine(arr[^1]);
            Console.WriteLine(arr[^2]);
            Console.WriteLine(arr[^3]);
            Console.WriteLine(arr[^4]);
            Console.WriteLine(arr[^5]);

            // Throw an exception if we try to access
            Console.WriteLine("arr[^0] as it is not valid");
            //Console.WriteLine(arr[^0]);

            // Creating and initializing an array 
            string[] emp = new string[] {"Anu", "Priya", "Rohit",
                "Amit", "Shreya", "Rinu", "Sumit", "Zoya"};

            Console.Write(" Employees in project A: ");
            var P_A = emp[0..3];
            foreach (var emp1 in P_A)
                Console.Write($" [{emp1}]");

            Console.Write("\n Employees in project B: ");
            var P_B = emp[3..5];
            foreach (var emp2 in P_B)
                Console.Write($" [{emp2}]");

            Console.Write("\n Employees in project C: ");
            var P_C = emp[1..^2];
            foreach (var emp3 in P_C)
                Console.Write($" [{emp3}]");

            Console.Write("\n Employees in project D: ");
            var P_D = emp[..];
            foreach (var emp4 in P_D)
                Console.Write($" [{emp4}]");

            Console.Write("\n Employees in project E: ");
            var P_E = emp[..2];
            foreach (var emp5 in P_E)
                Console.Write($" [{emp5}]");

            Console.Write("\n Employees in project F: ");
            var P_F = emp[6..];
            foreach (var emp6 in P_F)
                Console.Write($" [{emp6}]");

            Console.Write("\n Employees in project G: ");
            var P_G = emp[^3..^1];
            foreach (var emp7 in P_G)
                Console.Write($" [{emp7}]");
            
            Console.WriteLine();
            Console.WriteLine("Declaring a range as a variable");
            Range num = 1..3;
            int[] val = arr[num];

            // Displaying arr 
            foreach (var n in val)
                Console.Write($" [{n}]");
            #endregion

            #region StaticLocalFunctions
            Console.WriteLine();
            Console.WriteLine("10.- Static Local Functions");
            Console.WriteLine("Local functions can be marked static to prevent capturing local variables, improving performance.");
            static int Sum(int[] numbers) => numbers.Sum();
            Console.WriteLine($"Sum Result = {Sum([10,20,30])}");
            #endregion
        }

        //1.- NullableReferenceTypes
        static void ProcessUser(User user)
        {
            Console.WriteLine($"user.Name: {user.Name} Safe, no warning");
            Console.WriteLine($"user.Email?.ToUpper()  {user.Email?.ToUpper()} Null check");
        }

        //3.- SwitchExpressions
        public static string GetStatusDescription(HttpStatusCode status) =>
            status switch
            {
                HttpStatusCode.OK => "Success",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.BadRequest => "Invalid request",
                _ => "Unknown status"
            };

        //4.- PatternMatching
        //7.- Records
        public record Product(string Name, decimal Price, bool IsInStock);
        public static string EvaluateProduct(Product product) =>
            product switch
            {
                { Price: < 0 } => "Invalid price",
                { IsInStock: false } => "Out of stock",
                { Price: > 100 } => "Premium product",
                _ => "Standard product"
            };

        //5.- UsingDeclarations
        public static void ReadFile(string path)
        {
            using var reader = new StreamReader(path);
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        } // reader disposed automatically

        //6.- Async Streams (IAsyncEnumerable)
        public static async IAsyncEnumerable<int> GenerateSequence()
        {
            for (int i = 0; i < 15; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
        public static async Task PrintSequence()
        {
            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }
        }
    }
}
