using C_Sharp8.Utils;
using System.Net;

namespace C_Sharp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to DAGG C# 8 Catalog");
            Console.WriteLine("This catalog contains examples of C# 8.0 features");

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

            #region PatternMatching
            Console.WriteLine();
            Console.WriteLine("4.- Testing Pattern Matching Enhancements");
            Console.WriteLine("Includes recursive patterns, property patterns, and tuple patterns for more expressive code.");

            var product = new Product("Laptop", 1200.00m, true);
            var productResult = EvaluateProduct(product);
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, In Stock: {product.IsInStock}");
            Console.WriteLine($"Evaluation Result: {productResult}");
            #endregion
        }

        //NullableReferenceTypes
        static void ProcessUser(User user)
        {
            Console.WriteLine($"user.Name: {user.Name} Safe, no warning");
            Console.WriteLine($"user.Email?.ToUpper()  {user.Email?.ToUpper()} Null check");
        }

        //SwitchExpressions
        public static string GetStatusDescription(HttpStatusCode status) =>
            status switch
            {
                HttpStatusCode.OK => "Success",
                HttpStatusCode.NotFound => "Resource not found",
                HttpStatusCode.BadRequest => "Invalid request",
                _ => "Unknown status"
            };

        //PatternMatching
        public record Product(string Name, decimal Price, bool IsInStock);
        public static string EvaluateProduct(Product product) =>
            product switch
            {
                { Price: < 0 } => "Invalid price",
                { IsInStock: false } => "Out of stock",
                { Price: > 100 } => "Premium product",
                _ => "Standard product"
            };
    }
}
