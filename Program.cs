using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///***********************************************************************
/// *   Program: mergesort.exe
/// *   Author: Mat Teubert
/// *   https://github.com/MatTeubert 
/// *   http://pixelbreakfast.com.au
/// *   Date: 2016 06 30
/// * 
/// *   Comments
/// *   Basic implementation of MergeSort. 
/// *   Accepts an array of numeric arguments and sorts them
/// *   
/// **********************************************************************


namespace mergesort
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a numeric argument.");
                return;
            }

            //Convert array of string arguments into array of floats
            List<float> values = new List<float>();
            for(int i = 0; i<args.Length;i++)
            {
                float num;
                bool test = float.TryParse(args[i], out num);
                
                //Stop if parsing fails
                if (test == false)
                {
                    System.Console.WriteLine("Please enter numeric arguments to sort");
                    return;
                }

                values.Add(num);
            }

            //Call mergesort on array
            values = MergeSort(values);

            //Output results
            for(int i = 0; i<values.Count;i++) {
                
                Console.Write(values[i]);
                if(i < values.Count - 1)
                {
                    Console.Write(",");
                }
            }
            Console.ReadKey();

        }

        static List<float> MergeSort(List<float> A)
        { 
            List<float> B = new List<float>();
            List<float> C = new List<float>();

            if (A.Count > 1)
            {
                //So long as the array can be split, split array into two new arrays
                for (int i = 0; i < A.Count; i++)
                {
                    if (i < A.Count / 2)
                    {
                        B.Add(A[i]);
                    }
                    else
                    {
                        C.Add(A[i]);
                    }
                }

                //Keep recursively splitting
                B = MergeSort(B);
                C = MergeSort(C);
                
                //Merge then pass sorted list to parent
                A = Merge(B, C);

            }
            return A;
        }

        static List<float> Merge(List<float> B, List<float> C)
        {
            List<float> mergedList = new List<float>();
            int i = 0;
            int j = 0;
             
            while (i < B.Count && j < C.Count)
            {
                //Get the lowest value of B or C and add it to mergedList
                if (B[i] < C[j])
                {
                    mergedList.Add(B[i]);
                    i++;
                }
                else
                {
                    mergedList.Add(C[j]);
                    j++;
                }

            }

            //if we've already added all of B, dump C in, or vice-versa
            if (i == B.Count)
            {
                for (int k = j; k < C.Count; k++)
                {
                    mergedList.Add(C[k]);

                }
            }
            else
            {
                for (int k = i; k < B.Count; k++)
                {
                    mergedList.Add(B[k]);

                }
            }

            return mergedList;
        }
    }
}
