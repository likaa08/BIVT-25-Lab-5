using System.Linq;
using System.Runtime.InteropServices;

namespace Lab5
{
    public class White
    {
        public double Task1(int[,] matrix)
        {
            double average = 0;

            // code here
            double sum = 0;
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                        count++;
                    }
                }
            }
            average = sum / count;
            

            // end

            return average;
        }
        public (int row, int col) Task2(int[,] matrix)
        {
            int row = 0, col = 0;

            // code here
            int min = int.MaxValue;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < min)
                    {
                        min = matrix[i, j];
                        row = i;
                        col = j;
                    }
                }
            }

            // end

            return (row, col);
        }
        public void Task3(int[,] matrix, int k)
        {

            // code here
            
            if (matrix == null || matrix.Length == 0)
                return;
            
            if (k < 0 || k >= matrix.GetLength(1))
                return;
            
            if (matrix.GetLength(0) <= 1)
                return;
            
            int maxRow = 0;
            int maxValue = matrix[0, k];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, k] > maxValue)
                {
                    maxValue = matrix[i, k];
                    maxRow = i;
                }
            }
            
            if (maxRow == 0)
                return;
            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int temp = matrix[0, j];
                matrix[0, j] = matrix[maxRow, j];
                matrix[maxRow, j] = temp;
            }
            
            // end

        }
        public int[,] Task4(int[,] matrix)
        {
            int[,] answer = null;

            // code here

            if (matrix == null || matrix.Length == 0)
                return new int [0, 0];
            if (matrix.GetLength(0) == 1)
                return new int[0, matrix.GetLength(1)];

            int minrow = 0;
            int minval  = matrix[0, 0];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, 0] < minval)
                {
                    minval = matrix[i, 0];
                    minrow = i;
                }
            }

            int[,] newmatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            int newrow = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i == minrow)
                    continue;
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newmatrix[newrow, j] = matrix[i, j];
                }

                newrow++;
            }
            answer = newmatrix;

            // end

            return answer;
        }
        public int Task5(int[,] matrix)
        {
            int sum = 0;

            // code here
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            
            // end

            return sum;
        }
        public void Task6(int[,] matrix)
        {

            // code here

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                
                int firstNegative = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        firstNegative = j;
                        break;
                    }
                }
                
                if (firstNegative == -1 || firstNegative == 0) 
                    continue;
                
                int maxIndex = 0;
                for (int j = 0; j < firstNegative; j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;
                }
                
                int lastNegative = -1;
                for (int j = matrix.GetLength(1) - 1; j >= 0; j--)
                {
                    if (matrix[i, j] < 0)
                    {
                        lastNegative = j;
                        break;
                    }
                }
                
                if (lastNegative != -1 && maxIndex != lastNegative)
                {
                    int temp = matrix[i, maxIndex];
                    matrix[i, maxIndex] = matrix[i, lastNegative];
                    matrix[i, lastNegative] = temp;
                }
            }

            // end

        }
        public int[] Task7(int[,] matrix)
        {
            int[] negatives = null;

            // code here

            int count = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
                return null;
            
            negatives = new int[count];
            int index = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives[index] = matrix[i, j];
                        index++;
                    }
                }
            }
             
            

            // end

            return negatives;
        }
        public void Task8(int[,] matrix)
        {

            // code here
            
            if (matrix == null) 
                return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix.GetLength(1) <= 1) 
                    continue;
                
                int maxIndex = 0;
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > matrix[i, maxIndex])
                        maxIndex = j;
                }
                if (maxIndex == 0) 
                {
                    matrix[i, maxIndex + 1] *= 2;
                }
                else if (maxIndex == matrix.GetLength(1) - 1) 
                {
                    matrix[i, maxIndex - 1] *= 2;
                }
                else
                {
                    int leftNeighbor = matrix[i, maxIndex - 1];
                    int rightNeighbor = matrix[i, maxIndex + 1];

                    if (leftNeighbor <= rightNeighbor)
                    {
                        matrix[i, maxIndex - 1] *= 2;
                    }
                    else
                    {
                        matrix[i, maxIndex + 1] *= 2;
                    }
                }
            }

            // end

        }
        public void Task9(int[,] matrix)
        {

            // code here
            if (matrix == null)
                return;
            if (matrix.GetLength(1) == 0)
                return;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int cols = matrix.GetLength(1);
                
                for (int j = 0; j < matrix.GetLength(1) / 2; j++)
                {
                    int index = matrix.GetLength(1) - 1 - j;
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[i, index];
                    matrix[i, index] = temp;
                }
            }

            // end

        }
        public void Task10(int[,] matrix)
        {

            // code here
            
            if (matrix == null) return;
            
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return;

            int n = matrix.GetLength(0);
            
            int startRow = n / 2;
    
            for (int i = startRow; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j <= i)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }

            // end

        }
        public int[,] Task11(int[,] matrix)
        {
            int[,] answer = null;

            // code here
            
            if (matrix == null || matrix.Length == 0)
                return new int[0, 0];

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            
            int goodRowsCount = 0;
            bool[] hasNoZeros = new bool[rows];

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
        
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        hasZero = true;
                        break;
                    }
                }
        
                if (!hasZero)
                {
                    hasNoZeros[i] = true;
                    goodRowsCount++;
                }
            }
            
            if (goodRowsCount == 0)
                return new int[0, cols];
            
            answer = new int[goodRowsCount, cols];
            int newRow = 0;

            for (int i = 0; i < rows; i++)
            {
                if (hasNoZeros[i])
                {
                    for (int j = 0; j < cols; j++)
                    {
                        answer[newRow, j] = matrix[i, j];
                    }
                    newRow++;
                }
            }

            // end

            return answer;
        }
        public void Task12(int[][] array)
        {

            // code here
            
            if (array == null) return;
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    int sum1 = 0, sum2 = 0;
            
                    if (array[j] != null)
                    {
                        for (int k = 0; k < array[j].Length; k++)
                            sum1 += array[j][k];
                    }
            
                    if (array[j + 1] != null)
                    {
                        for (int k = 0; k < array[j + 1].Length; k++)
                            sum2 += array[j + 1][k];
                    }
                    
                    if (sum1 > sum2)
                    {
                        int[] temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            // end

        }
    }
}

