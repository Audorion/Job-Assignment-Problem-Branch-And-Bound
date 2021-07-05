using System;
using System.Linq;
namespace TaskFirst
{
    class Program
    {
        static int[] smallestInCol(int[,] mat, bool[] acceptIN, bool[] acceptJN, int currentJ)
        {                                       
            int[] minCol = new int[4] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (acceptIN[i] == true )
                {
                    for (int j = 0; j < mat.GetLength(0); j++)
                    {
                        if (acceptJN[j] == true && j != currentJ)
                        {
                            if (mat[i, j] < minCol[i])
                            {
                                minCol[i] = mat[i, j];
                            } 
                        }
                    }
                }            
                }
            return minCol;
        }

        static void Main(string[] args)
        {
            int totalCost = 0;
            int N = 4;
            int[] minCol = new int[4] { int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue };
            int[,] matrix = new int[4, 4] {{ 9, 2, 7, 8}, 
                                           { 6, 4, 3, 7},  
                                           { 5, 8, 1, 8},  
                                           { 7, 6, 9, 4}  };
            //int[,] matrix = new int[4, 4] {{ 10, 16, 12, 11},
            //                               { 22, 11, 25, 4},
            //                               { 3, 7, 9, 11},
            //                               { 22, 63, 26, 12}  };
            int[] updateM = new int[N];
            int[] newM = new int[N];
            bool[] acceptI = new bool[4] { true, true, true, true };
            bool[] acceptJ = new bool[4] { true, true, true, true };

            for (int t = 0; t < matrix.GetLength(0); t++) 
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    minCol = smallestInCol(matrix, acceptI, acceptJ, i);
                    if (acceptJ[i] == true)
                    {
                        updateM[i] = matrix[t, i] + minCol.Skip(1 + t).Sum() + totalCost;    // находим сумму нижестоящих минимумов и стоимости текущей ветви для каждой 
                    }
                    else { updateM[i] = int.MaxValue; }
                }                                                                          
                newM[t] = updateM.Min();
                totalCost += matrix[t,Array.IndexOf(updateM, updateM.Min())];
                acceptJ[Array.IndexOf(updateM, updateM.Min())] = false;
                Console.WriteLine("Рабочий "+ (t+1) + " должен выбрать вариант " + (Array.IndexOf(updateM, updateM.Min())+1));
                acceptI[t] = false;
            }
            Console.WriteLine("Общая стоимость:" + totalCost);
        }
    }
}


