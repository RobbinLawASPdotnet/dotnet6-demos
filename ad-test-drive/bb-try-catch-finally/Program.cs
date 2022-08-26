//https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/exception-handling
using System;

namespace try_catch_finally
{
    class Person
    {
        public string Name;

        public Person(string name)
        {
            if(name == "robbin")
                throw new ArgumentNullException($"Bad Name: {name}");
            if(name == "robbinl")
                throw new FormatException($"Bad Name: {name}");
            if(name == "robbinlaw")
                throw new FieldAccessException($"Bad Name: {name}");

            Name = name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main method started");
            var app = new Program();
            var temp = app.Ex01();
            Console.WriteLine($"Ex01() returned string: {temp}");
            Console.WriteLine("Main method ended");
        }

        private string Ex01()
        {
            try
            {
                Console.WriteLine("Ex01 try started");
                Person personreference = new Person("rob");
                Console.WriteLine($"My name is: {personreference.Name}");
                Console.WriteLine("Ex01 try ended");
                //return "try";
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"ArgumentNullException in Ex01: {ex.Message}");
                return "ArgumentNullException";
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"FormatException in Ex01: {ex.Message}");
                return "FormatException";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CatchAllException in Ex01: {ex.Message}");
                //throw;
                //return "CatchAllException";
            }
            finally
            {
                Console.WriteLine("The finally runs exception or not");
                //can only have one finally per try
                //cannot have a return in finally
                //return "finally";
            }
            Console.WriteLine("This code will run if the catch does not have a return");
            Console.WriteLine("This code will also run if the try is successful");
            return "funny thing";  
        }
    }
}
