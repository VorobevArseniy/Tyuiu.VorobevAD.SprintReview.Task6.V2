namespace Tyuiu.VorobevAD.SprintReview.Task6.V2.Lib
{
    public class DataService
    {

        public int[,] RandMatrix(int[,] array, int n1, int n2)
        {
            if (n1 >= n2)
                throw new ArgumentException("n1 должно быть меньше n2.");

            Random random = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = random.Next(n1, n2 + 1); // Заполнение случайными числами
                }
                // Сортировка строки по убыванию
                SortRowDescending(array, i);
            }

            return array;
        }

        static void SortRowDescending(int[,] array, int row)
        {
            int cols = array.GetLength(1);
            int[] tempRow = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                tempRow[j] = array[row, j];
            }

            Array.Sort(tempRow);
            Array.Reverse(tempRow);

            for (int j = 0; j < cols; j++)
            {
                array[row, j] = tempRow[j];
            }
        }

        public double GetMatrix(int[,] array, int K, int L, int C)
        {
            if (K < 0 || L >= array.GetLength(0) || K > L)
                throw new ArgumentException("Неверные значения K и L.");

            if (C < 0 || C >= array.GetLength(1))
                throw new ArgumentException("Неверное значение C.");

            double sum = 0;
            int count = 0;

            for (int i = K; i <= L; i++)
            {
                sum += array[i, C];
                count++;
            }

            return Math.Round(sum / count, 3);
        }
    }

}

