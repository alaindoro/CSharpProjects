namespace firstTask
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создадим матрицу с указанным количеством срок и столбцов наполненную случайными целыми числами");
            Console.WriteLine("Введите количество строк:");
            int line = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов:");
            int column = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[,] matrix = new int[line, column];
            Random r = new Random();
            int sum = 0;
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = r.Next(10);
                    sum += matrix[i, j];
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма всех элементов матрицы = {sum}");
            Console.WriteLine();
            Console.WriteLine("Вторая задача. Создадим вторую матрицу по заданным параметрам");

            int[,] matrix2 = new int[line, column];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix2[i, j] = r.Next(10);
                    Console.Write($"{matrix2[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Сложим полученным матрицы между собой");
            int[,] matrix3 = new int[line, column];
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix3[i, j] = matrix[i, j] + matrix2[i, j];
                    Console.Write($"{matrix3[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}