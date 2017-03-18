using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Picking_Numbers
{
    /*    
    /// Problem:
    /// Given an array of integers, 
    /// find and print the maximum number of integers you can select from the array
    /// such that the absolute difference between any two of the chosen integers is <= 1.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 4, 6, 5, 3, 3, 1 };
            Console.WriteLine(PickNumbers(array));
            Console.ReadKey();
        }

        static int PickNumbers(int[] a)
        {            
            //Group numbers by frequency
            var query = from i in a
                        group i by i into g
                        select new { Count = g.Count(), Value = g.Key };

            Dictionary<int, int> frq = new Dictionary<int, int>();//Value & Frequency
            int maxCount = -1;//Count of Number(s) with the most frequency
            
            //Find the count of number(s) that satisfy the condition that any two of the chosen integers is <= 1.
            foreach (var v in query)
            {
                if (v.Count > maxCount)
                    maxCount = v.Count;
                if (frq.ContainsKey(v.Value - 1) && (v.Count + frq[v.Value - 1]) > maxCount)
                    maxCount = v.Count + frq[v.Value - 1];
                if (frq.ContainsKey(v.Value + 1) && (v.Count + frq[v.Value + 1]) > maxCount)
                    maxCount = v.Count + frq[v.Value + 1];
                frq.Add(v.Value, v.Count);                                                                                                 
            }
            return maxCount;
        }


    }
}
