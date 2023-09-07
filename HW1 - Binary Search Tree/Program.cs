using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1___Binary_Search_Tree
{
    class Program
    {
        /// <summary>
        /// Prompts user for input of integers and inserts each distinct int to a binary search tree and prints it back in order along with other stats.
        /// </summary>
        /// <param name="args"></param>
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
                    Console.WriteLine("BST inorder traversal:");
                    bst.ListBST();
                    Console.WriteLine("\nBST size: " + bst.GetSize());
                    Console.WriteLine("Height of BST: " + bst.GetHeight());
                    Console.WriteLine("Minimum height of bst: " + bst.GetMinHeight());
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
