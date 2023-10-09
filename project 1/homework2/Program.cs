namespace secondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Привет, игрок. Сколько у тебя карт?");
            int amount = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = 0;
            while (num < amount)
            {
                Console.WriteLine($"Введи значение {num+1} карты. J - валет, Q - дама, K - король, T - туз.");
                string card = (Console.ReadLine());
                switch (card)
                {
                    case "1":
                        sum += 1;
                        break;
                    case "2":
                        sum += 2;
                        break;
                    case "3":
                        sum += 3;
                        break;
                    case "4":
                        sum += 4;
                        break;
                    case "5":
                        sum += 5;
                        break;
                    case "6":
                        sum += 6;
                        break;
                    case "7":
                        sum += 7;
                        break;
                    case "8":
                        sum += 8;
                        break;
                    case "9":
                        sum += 9;
                        break;
                    case "10":
                    case "J":
                    case "j":
                    case "q":
                    case "Q":
                    case "k":
                    case "K":
                    case "t":
                    case "T":
                        sum += 10;
                        break;
                    default:
                        Console.WriteLine("Я не знаю такой карты, Друг. J - валет, Q - дама, K - король, T - туз.");
                        continue;
                }
                num++;
            }
            Console.WriteLine($"Поздравляю, ты набрал {sum} очков.");
        }

    }
}
