
using System;
using System.Collections.Generic;

namespace TodoConsoleApp
{
    // Define the interface
    public interface IGreet
    {
        void SayHello(string name);
    }

    // Implement the interface in a class
    public class FriendlyGreeter : IGreet
    {
        public void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}! Welcome to learning interfaces.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Todo Console App!");

            // Tuple example
            var person = (Name: "Alice", Age: 30);
            Console.WriteLine($"Tuple Example: Name = {person.Name}, Age = {person.Age}");

            var capital = new Dictionary<string, string>
            {
                { "USA", "Washington, D.C." },
                { "France", "Paris" },
                { "Japan", "Tokyo" }
            };

            // List example
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine("List Example: Numbers = " + string.Join(", ", numbers));

            // Adding to the list
            numbers.Add(6);
            Console.WriteLine("After adding 6: " + string.Join(", ", numbers));

            // Iterating over the list
            Console.WriteLine("Iterating over the list:");
            foreach (var num in numbers)
            {
                Console.WriteLine($"Number: {num}");
            }

            // Interface example
            IGreet greeter = new FriendlyGreeter();
            greeter.SayHello("Alice");

            // Try out your C# syntax and logic here
            Console.WriteLine("Type something and press Enter:");
            var input = Console.ReadLine();
            Console.WriteLine($"You typed: {input}");
        }
    }
}
