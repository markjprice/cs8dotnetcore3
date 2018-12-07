using System;
using static System.Console;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            object height = 1.88; // storing a double value in an object
            object name = "Amir"; // storing a string value in an object 
            WriteLine($"{name} is {height} metres tall.");
            //int length1 = name.Length; // gives compile error!
            int length2 = ((string)name).Length; // tell compiler it is a string
            WriteLine($"{name} has {length2} characters.");

            var population = 66_000_000; // 66 million in UK 
            var weight = 1.88; // in kilograms
            var price = 4.99M; // in pounds sterling
            var fruit = "Apples"; // strings use double-quotes 
            var letter = 'Z'; // chars use single-quotes
            var happy = true; // Booleans have value of true or false

            WriteLine($"{default(int)}"); // 0 
            WriteLine($"{default(bool)}"); // False 
            WriteLine($"{default(DateTime)}"); // 1/01/0001 00:00:00

            int thisCannotBeNull = 4;
            //thisCannotBeNull = null; // compile error!
            int? thisCouldBeNull = null;
            WriteLine(thisCouldBeNull); // null
            WriteLine(thisCouldBeNull.GetValueOrDefault()); // 0
            thisCouldBeNull = 7;
            WriteLine(thisCouldBeNull); // 7
            WriteLine(thisCouldBeNull.GetValueOrDefault()); // 7

            // declaring the size of the array
            string[] names = new string[4];

            // storing items at index positions
            names[0] = "Kate";
            names[1] = "Jack";
            names[2] = "Rebecca";
            names[3] = "Tom";

            // looping through the names
            for (int i = 0; i < names.Length; i++)
            {
                WriteLine(names[i]); // read the item at this index
            }

            WriteLine($"The UK population is {population}.");
            Write($"The UK population is {population:N0}. ");
            WriteLine($"{weight}kg of {fruit} costs {price:C}.");

            Write("Type your first name and press ENTER: ");
            string firstName = ReadLine();
            Write("Type your age and press ENTER: ");
            string age = ReadLine();
            WriteLine($"Hello, {firstName}, you look good for {age}.");


        }
    }
}
