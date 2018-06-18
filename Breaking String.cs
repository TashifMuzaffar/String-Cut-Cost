using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakAString
{
    class Program
    {
        static void break_string(int n, int[] L)
        {
            int m = L.Length;
            Array.Sort(L);
            foreach (var item in L)
                Console.Write("{0} ", item);
            Console.WriteLine();
            int[,] cost = new int[1+m,1+m];
            int[,] br = new int[1+m,1+m];
            for (int i=0; i<m; i++)
            {
                cost[i,i] = cost[i,i+1] = 0;
            }
            for(int len=2; len<=m; len++)
            {
                for(int i=0; i<m-len+1; i++)
                {
                    int j = i + len - 1;
                    cost[i, j] = int.MaxValue;
                    for(int k=i+1; k<j; k++)
                    {
                        if (cost[i, k] + cost[k, j] < cost[i, j])
                        {
                            cost[i, j] = cost[i, k] + cost[k, j];
                            br[i, j] = k; 
                        }
                    }
                    cost[i, j] = cost[i, j] + L[j] - L[i];
                }
            }
            Console.WriteLine("The minimum cost of breaking the string is ", cost[1,m]);
            print_break(L, br, 1, m);
        }
        static void print_break(int[] L, int[,] br, int i, int j)
        {
            if(j-i >= 2)
            {
                Console.WriteLine("Break at: ");
                foreach (var item in br)
                    Console.WriteLine(br);
            }
        }
        static void Main(string[] args)
        {
            
           int[] a = { 1, 5, 7, 4, 2, 6, 3 };
            break_string(, a);
        }
    }
}
