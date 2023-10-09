//моя
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using homework_6.Model;

namespace homework_6.Repository
{
    public class Repository
    {
        private string _path;
        private List<Worker> _workers;

        public Repository(string path)
        {
            _path = path;
            _workers = new List<Worker>();

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "");
            }

            string[] allLines = File.ReadAllLines(path);

            for (int i = 0; i < allLines.Length; i++)
            {
                string[] allParams = allLines[i].Split('#');
                Worker w = new Worker(Convert.ToInt32(allParams[0]), Convert.ToDateTime(allParams[1]),
                    allParams[2], Convert.ToInt32(allParams[3]), Convert.ToInt32(allParams[4]),
                    Convert.ToDateTime(allParams[5]), allParams[6]);
                _workers.Add(w);
            }
        }

        public List<Worker> GetAllWorkers()
        {
            // здесь происходит чтение из файла
            // и возврат массива считанных экземпляров
            return _workers;
        }

        public Worker GetWorkerById(int id)
        {
            // происходит чтение из файла, возвращается Worker
            // с запрашиваемым ID
            return _workers[id];
        }

        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого
            _workers.RemoveAt(id - 1);
            ChangeFile();

        }

        private void ChangeFile()
        {
            string newText = "";

            for (int i = 0; i < _workers.Count; i++)
            {
                newText += _workers[i].Id + "#";
                newText += _workers[i].DateCreate + "#";
                newText += _workers[i].FIO + "#";
                newText += _workers[i].Age + "#";
                newText += _workers[i].Height + "#";
                newText += _workers[i].DoB + "#";
                newText += _workers[i].PoB + "\n";
            }

            File.WriteAllText(_path, newText);
        }

        public void AddWorker(Worker worker)
        {
            // присваиваем worker уникальный ID,
            // дописываем нового worker в файл
            _workers.Add(worker);
            ChangeFile();
        }

        public List<Worker> GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
            List<Worker> result = new List<Worker>();

            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i].DateCreate >= dateFrom && _workers[i].DateCreate <= dateTo)
                {
                    result.Add(_workers[i]);
                }
            }
            return result;
        }

        public void SortWorkersBy(int sortChar)
        {
            switch (sortChar)
            {
                case 1:
                    {
                        _workers = _workers.OrderBy(x => x.Id).ToList();
                        break;
                    }
                case 2:
                    {
                        _workers = _workers.OrderBy(x => x.DateCreate).ToList();
                        break;
                    }
                case 3:
                    {
                        _workers = _workers.OrderBy(x => x.FIO).ToList();
                        break;
                    }
                case 4:
                    {
                        _workers = _workers.OrderBy(x => x.Height).ToList();
                        break;
                    }
                case 5:
                    {
                        _workers = _workers.OrderBy(x => x.DoB).ToList();
                        break;
                    }
                case 6:
                    {
                        _workers = _workers.OrderBy(x => x.PoB).ToList();
                        break;
                    }
            }

        }

    }
}