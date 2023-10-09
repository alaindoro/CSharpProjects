namespace firstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine($" {number} чётное число");
            }
            else
            {
                Console.WriteLine($" {number} нечётное число");
            }
        }
    }
}