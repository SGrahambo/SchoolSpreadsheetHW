using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string userInput = GetUserInput();
                BST bst = new BST();

                Console.WriteLine("The user input is: " + userInput);

                if (userInput == "q") // exits the program
                {
                    break;
                } else
                {
                    int[] intArray = ConvertToIntArray(userInput);
                    foreach (int i in intArray)
                    {
                        bst.Insert(i);
                    }
                    Console.WriteLine("BST size: " + bst.GetSize());
                    bst.ListBST();
                }
                Console.WriteLine("\n-------------------------------------------------------------------------");
            }            
        }

        /// <summary>
        /// Prompts for and returns a string input from user
        /// </summary>
        /// <returns> string userInput </returns>
        static string GetUserInput()
        {
            Console.WriteLine("Please enter a series of number in a single line seperated by spaces.");
            string userInput = Console.ReadLine();
            return userInput;
        }

        /// <summary>
        /// Takes a string variable and returns all distinct parsable ints as an array.
        /// </summary>
        /// <returns> int[] intArray </returns>
        static int[] ConvertToIntArray(string input)
        {
            List<int> intList = new List<int>();
            string[] stringArray = input.Split(' ');
           
            foreach (string s in stringArray)
            {
                try
                {
                    intList.Add(Int32.Parse(s));
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{s}'");
                }
            }

            int[] intArray = intList.Distinct().ToArray();

            return intArray;
        }
    }
}
