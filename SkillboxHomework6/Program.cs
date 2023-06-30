using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SkillboxHomework6
{
    internal class Program
    {
        /// <summary>
        /// Забирает данные у пользователя и записывает в файл
        /// </summary>
        /// <param name="path"></param>
        static void SaveFile(string path)
        {
            string datas = "";
            Console.Write("Введите ФИО сотрудника :");
            datas += $"#{Console.ReadLine()}";
            Console.Write("Введите возраст сотрудника :");
            datas += $"#{Console.ReadLine()}";
            Console.Write("Введите рост сотрудника :");
            datas += $"#{Console.ReadLine()}";
            Console.Write("Введите дату рождения сотрудника :");
            datas += $"#{Console.ReadLine()}";
            Console.Write("Введите место рождения сотрудника :");
            datas += $"#{Console.ReadLine()}\n";

            int id = 0;
            string fullString="";

            if (File.Exists(path))
            {
                string lastString = File.ReadLines(path).Last();  //Считывает последнюю строку из файла
                id = int.Parse(lastString.Split('#')[0]);   //Находит ID последней записи и записывает в переменную id
                fullString = $"{id + 1}#{DateTime.Now}{datas}";  // Дополняет строку id и датой/временем
                File.AppendAllText(path, fullString);
            }
            else
            {
                fullString = $"{id + 1}#{DateTime.Now}{datas}";  // Дополняет строку id и датой/временем
                File.AppendAllText(path, fullString);
            }
            Console.WriteLine("\nИнформация внесена в базу данных.");
        }
        /// <summary>
        /// Считывает данные из файла и выводит на экран
        /// </summary>
        /// <param name="path"></param>
        static void ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("База не существует, необходимо внесите данные сотрудников!");
            }
            else
            {
                Console.WriteLine("Сотрудники : \n");
                string list = (File.ReadAllText(path));

                string[] splitedList = list.Split('#');

                foreach (var e in splitedList)
                {
                    Console.Write($"{e} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                string path = @"list.txt";
                Console.WriteLine("Введите '1'для просмотра списка сотрудников,\nВведите '2' для внесения нового сотрудника : \nВведите 'q' для выхода");
                string mode = Console.ReadLine();
                Console.WriteLine();
                if (mode == "1") ReadFile(path);
                else if (mode == "2")
                {
                    SaveFile(path);

                    Console.ReadKey();
                }
                else if (mode=="q")
                {
                    exit = true;
                }
                else
                Console.WriteLine("Введите правильный символ!");
            }
        }
    }
}
