//моя
using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace homework_6.Model
{
	public struct Worker
	{

        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public string? FIO { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public DateTime DoB { get; set; }
        public string? PoB { get; set; }

        public Worker(int id, DateTime datecreate, string? fio, int age, int height, DateTime dob, string? pob)
        {
            Id = id;
            datecreate = DateCreate;
            fio = FIO;
            age = Age;
            height = Height;
            dob = DoB;
            pob = PoB;
        }
    }
}

