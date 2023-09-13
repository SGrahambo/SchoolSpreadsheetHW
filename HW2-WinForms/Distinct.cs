using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_WinForms
{
    /// <summary>
    /// Different methods to return the number of distinct integers in a list.
    /// </summary>
    public class Distinct
    {
        /// <summary>
        /// uses hash list to find distinct number of integers in list.
        /// </summary>
        /// <param name="list">input list</param>
        /// <returns> int hashList.Count </returns>
        public static int HashDistinct(List<int> list)
        {
            var hashList = new HashSet<int>();

            // adds each item from list to hashset.
            foreach (int num in list)
            {
                hashList.Add(num);
            }

            return hashList.Count;
        }

        /// <summary>
        /// Iterates through the min and max range of a list and counts each unique value it finds in list.
        /// </summary>
        /// <param name="min">min possible value of list.</param>
        /// <param name="max">max possible value of list.</param>
        /// <param name="list">input list</param>
        /// <returns> int number of distinct values. </returns>
        public static int O1Distinct(int min, int max, List<int> list)
        {
            int count = 0; // number of unique values.
            for (int i = min; i <= max; i++)
            {
                foreach (int num in list)
                {
                    if (num == i)
                    {
                        count++;
                        break;
                    }
                }
            }

            return count;

        }

        /// <summary>
        /// Sorts then iterates through list, counting how often the value changes.
        /// </summary>
        /// <param name="list">input list</param>
        /// <returns> int of number of distinct values in list</returns>
        public static int SortDistinct(List<int> list)
        {
            int count = 0; // number of unique values.
            list.Sort();
            int check = int.MinValue; // current value to check if current index value in list is different.

            // iterates through sorted list and counts each time the value changes.
            foreach (int num in list)
            {
                if (num != check)
                {
                    check = num;
                    count++;
                }
            }

            return count;
        }
    }
}
