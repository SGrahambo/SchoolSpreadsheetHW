﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_WinForms
{
    public class Distinct
    {
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

        public static int O1Distinct(List<int> list)
        {
            return 0;
        }

        public static int SortDistinct(List<int> list)
        {
            return 0;
        }
    }
}
