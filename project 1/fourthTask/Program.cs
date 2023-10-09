namespace fourthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности");
            int lenth = int.Parse(Console.ReadLine());
            int min = int.MaxValue;
            for (int i = 1; i <= lenth; i++)
            {
                Console.WriteLine("Введите число");
                int number = int.Parse(Console.ReadLine());
                if (number<min)
                {
                    min = number;
                }
            }
            Console.WriteLine($"Минимальное значение вашей последовательности {min}");
        }
    }
}