﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace knapsack
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] weight = { 5, 4, 6, 3 };//berat
            int[] value = { 10, 40, 30, 50 };//nilai barang
            int W = 13;//berat maksimum
            int n = weight.Length;//banyak barang
            Console.WriteLine("\ndengan total nilai "+knapsack2(n, W, weight, value));
        }

        static int knapsack1(int n, int W, int[] weight, int[] value)
        {
            //inisiasi variabel
            int[,] V=new int[n+1, W+1];//matriks V berukuran n+1 X W+1, ini karena ada baris dan kolom dengan indeks 0

            //inisiasi array
            for (int w = 0; w <= W; w++)
                V [0, w] = 0;

            //inti dari knapsack
            for (int i=1; i<=n; i++)
            {
                for (int w=0; w<=W; w++)
                {
                    if (weight[i-1] <= w)
                        V[i, w] = Math.Max(V[i - 1, w], value[i-1] + V[i - 1, w - weight[i-1]]);
                    else
                        V[i, w] = V[i - 1, w];
                }
            }

            return V[n, W];
                
        }

        static int knapsack2(int n, int W, int[] weight, int[] value)
        {
            //inisiasi variabel
            int[,] V = new int[n + 1, W + 1];//matriks V berukuran n+1 X W+1, ini karena ada baris dan kolom dengan indeks 0
            int[,] keep = new int[n + 1, W + 1];

            //inisiasi array
            for (int w = 0; w <= W; w++)
                V[0, w] = 0;

            //inti dari knapsack
            for (int i = 1; i <= n; i++)
            {
                for (int w = 0; w <= W; w++)
                {
                    if ((weight[i - 1] <= w) && (value[i - 1] + V[i - 1, w - weight[i - 1]] > V[i - 1, w]))
                    {
                        V[i, w] = value[i - 1] + V[i - 1, w - weight[i - 1]];
                        keep[i, w] = 1;
                    }
                    else
                    {
                        V[i, w] = V[i - 1, w];
                        keep[i, w] = 0;
                    }
                }
            }
            Console.Write("Ambil ");
            int K = W;
            for (int i = n; i >= 1; i--)
            {
                if (keep[i, K] == 1)
                {
                    Console.Write("item ke-"+i+", ");
                    K = K - weight[i - 1];
                }
            }
            return V[n, W];
        }

    }
}
