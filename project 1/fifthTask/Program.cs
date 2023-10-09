namespace fifthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Играем в Угадай число. Введите максимальное значение диапазона чисел");
            int max = int.Parse(Console.ReadLine());
            Random rend = new Random();
            int guessMe = rend.Next(0, max);
            while (true)
            {
                Console.WriteLine("Введите число");
                string attempt = Console.ReadLine();
                if (attempt.Length == 0)
                {
                    Console.WriteLine($"Игра окончена. Загаданное число {guessMe}");
                    break;
                }
                int guess = int.Parse(attempt);
                if (guessMe < guess)
                {
                    Console.WriteLine("Загаданное число меньше");
                }
                else if (guessMe > guess)
                {
                    Console.WriteLine("Загаданное число больше");
                }
                else if (guessMe == guess)
                {
                    Console.WriteLine($"Вы победили. Загаданное число {guessMe}");
                    break;
                }
            }
        }
    }
}