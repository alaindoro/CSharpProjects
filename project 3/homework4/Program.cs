using System;

namespace homework4
{
class Program
    {
    static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение:");
            string sentence = Console.ReadLine();
            string[] res = DoSplite(sentence);
            Console.WriteLine("Результат первого задания");
            ShowMeArray(res);
            Console.WriteLine("Результат второго задания");
            ReverseWords(sentence);

        }
        /// <summary>
        /// Метод разделяющий строку по пробелам и записывающий слова в массив
        /// </summary>
        /// <returns></returns>
        static string[] DoSplite(string str)
        {
            string[] subs = str.Split(' ');
            return subs;
        }
        /// <summary>
        /// Метод принимает массив строк и выводит из каждую в отдельной строке в  консоль
        /// </summary>
        /// <param name="args"></param>
        static void ShowMeArray(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }
        /// <summary>
        /// Метод переписывающий строку от последнего слова к первому
        /// </summary>
        /// <param name="str"></param>
        static void ReverseWords(string str)
        {
            string[] res = DoSplite(str);
            Reverse(res);
            static string[] DoSplite(string str)
            {
                string[] subs = str.Split(' ');
                return subs;
            }
            static void Reverse(string[] args)
            {
                string resultString = "";
                for (int i = args.Length -1; i >= 0; i--)
                {
                    string newString = args[i];
                    resultString += newString + " ";
                }
                Console.WriteLine(resultString);
            }
        }
    }
}    