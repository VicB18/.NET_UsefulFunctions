using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Linq;
using System.Collections.Generic;

public class UsefulFunctions
{
    public static void MedianFilter(int[] A, int WindowSize, int N, out int[] Afiltered)
    {
        Afiltered = new int[N];
        List<int> SortedWindow = new List<int>();
        List<int> OriginalOrder = new List<int>();
        int i;

        for (i = 0; i < WindowSize + 1; i++)
        {
            SortedWindow.Add(A[i]);
            OriginalOrder.Add(A[i]);
        }

        for (i = 0; i < WindowSize; i++)
        {
            SortedWindow = OriginalOrder.ToList();
            SortedWindow.Sort();
            Afiltered[i] = SortedWindow[(i + WindowSize) / 2];
            OriginalOrder.Add(A[i + WindowSize + 1]);
        }

        for (i = WindowSize; i < N - WindowSize - 1; i++)
        {
            SortedWindow = OriginalOrder.ToList();
            SortedWindow.Sort();
            Afiltered[i] = SortedWindow[WindowSize];
            OriginalOrder.Add(A[i + WindowSize + 1]);
            OriginalOrder.RemoveAt(0);
        }

        for (i = N - WindowSize - 1; i < N; i++)
        {
            SortedWindow = OriginalOrder.ToList();
            SortedWindow.Sort();
            Afiltered[i] = SortedWindow[(N - i + WindowSize) / 2];
            OriginalOrder.RemoveAt(0);
        }
    }
}
