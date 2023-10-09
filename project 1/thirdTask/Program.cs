namespace thirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число");
            int number = int.Parse(Console.ReadLine());
            bool flag = false;
            int i = 2;
            while (number>i)
            {
                if (number % i == 0)
                {
                    flag = true;
                }
                i++;
            }
            if (flag == false)
            {
                Console.WriteLine("Это число простое");
            }
            else
            {
                Console.WriteLine("Это число не является простым");
            }
        }
    }
}