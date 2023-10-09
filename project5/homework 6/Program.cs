
using System;
using System.IO;
using homework_6.Model;
using homework_6.Repository;

namespace homework_6
{
    class Programm
    {
        private static Repository.Repository ?_repository;
        private static string _path = @"data.csv";


        public static void Main(string[] args)
        {
            _repository = new Repository.Repository(_path);
            MessageForUser();

        }

        static void MessageForUser()
        {
            while (true)
            {
                Console.WriteLine("Введите действие:\n" +
                    "1.Добавить запись\n" +
                    "2.Удалить запись об указанном сотруднике\n" +
                    "3.Вывести данные об указанном сотруднике\n" +
                    "4.Вывести все данные\n" +
                    "5.Вывести записи, созданные в пределах указанных дат\n" +
                    "6.Отсортировать данные по параметру\n" +
                    "0.Выход из программы");

                int taskNumber = 0;
                taskNumber = Convert.ToInt32(Console.ReadLine());

                SelectTask(taskNumber);


                if (taskNumber == 0)
                {
                    break;
                }
            }
        }
        static void SelectTask(int taskNumber)
        {
            switch (taskNumber)
            {
                case 1:
                    {
                        WriteFile();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                        _repository?.DeleteWorker(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }

                case 3:
                    {
                        Console.WriteLine("Введите ID сотрудника");
                        _repository?.GetWorkerById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine(_repository?.GetAllWorkers());
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Введите первую дату в формате dd/mm/yyyy");
                        DateTime firstDate = (Convert.ToDateTime(Console.ReadLine()));

                        Console.WriteLine("Введите вторую дату в формате dd/mm/yyyy");
                        DateTime secondDate = (Convert.ToDateTime(Console.ReadLine()));

                        Console.WriteLine(_repository?.GetWorkersBetweenTwoDates(firstDate, secondDate));
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Введите номер параметра:\n" +
                                           "1.ID (по-умолчанию)\n" +
                                           "2.Дата создания записи\n" +
                                           "3.ФИО\n" +
                                           "4.Рост\n" +
                                           "5.Дата рождения\n" +
                                           "6.Место рождения\n");

                        _repository?.SortWorkersBy(Convert.ToInt32(Console.ReadLine()));
                        break;
                    }

                default: break;
            }
        }

        private static void WriteFile()
        {
            DateTime time = DateTime.Now;
            string oldText;
            string newText;
            string[] textLine;

            string name;
            int age;
            int height;
            string birthday;
            string birthplace;

            if (!File.Exists(_path))
                oldText = "";
            else
                oldText = File.ReadAllText(_path) + "\n";

            newText = oldText;
            textLine = newText.Split('\n');

            newText += textLine.Length + "#";

            newText += time + "#";

            Console.WriteLine("Введите Ф.И.О.");
            name = $"{Console.ReadLine()}#";
            newText += name;

            Console.WriteLine("Введите возраст");
            age = Convert.ToInt32(Console.ReadLine());
            newText += Convert.ToString(age) + "#";

            Console.WriteLine("Введите рост");
            height = Convert.ToInt32(Console.ReadLine());
            newText += Convert.ToString(height) + "#";

            Console.WriteLine("Введите дату рождения dd/mm/yyyy");
            birthday = $"{Console.ReadLine()}";
            newText += birthday + "#";

            Console.WriteLine("Введите место рождения");
            birthplace = $"{Console.ReadLine()}";
            newText += birthplace;

            Worker person = new Worker(textLine.Length, time, name, age, height, Convert.ToDateTime(birthday), birthplace);
            _repository?.AddWorker(person);

            File.WriteAllText(_path, newText);
        }
    }

}


