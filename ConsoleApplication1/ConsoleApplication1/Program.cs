using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //создание директорий
                string root = @"E:\Temp\K1";

                DirectoryInfo directory = new DirectoryInfo(root);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                root = @"E:\Temp\K2";
                directory = new DirectoryInfo(root);
                if (!directory.Exists)
                {
                    directory.Create();
                }


                //создание файлов
                StreamWriter sw = new StreamWriter(@"E:\Temp\K1\t2.txt");
                sw.WriteLine("Плужникова Анна Андреевна, 2004 года рождения, место жительства г. Владимир");
                sw.Close();
                sw = new StreamWriter(@"E:\Temp\K1\t1.txt");
                sw.WriteLine("Шокина Анастасия Николаевна, 2004 года рождения, место жительства г.Владимир");
                sw.Close();

                //чтение из 1 и 2 файла и запись в 3
                sw = new StreamWriter(@"E:\Temp\K2\t3.txt");
                StreamReader sr = new StreamReader(@"E:\\Temp\K1\t1.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                sr = new StreamReader(@"E:\Temp\K1\t2.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();

                var fi1 = new FileInfo(@"E:\Temp\K1\t1.txt");
                Console.WriteLine(String.Format("Информация о файле: {0}:", fi1.Name));
                Console.WriteLine("Размер: " + fi1.Length + " байт");
                Console.WriteLine("Время создания: " + fi1.CreationTimeUtc);
                Console.WriteLine("Последнее изменение - " + fi1.LastWriteTime);
                Console.WriteLine("Полный путь: " + fi1.FullName);
                Console.WriteLine("-----------------------------------------------------");
                var fi2 = new FileInfo(@"E:\Temp\K1\t2.txt");
                Console.WriteLine(String.Format("Информация о файле: {0}:", fi2.Name));
                Console.WriteLine("Размер: " + fi2.Length + " байт");
                Console.WriteLine("Время создания: " + fi2.CreationTimeUtc);
                Console.WriteLine("Последнее изменение - " + fi2.LastWriteTime);
                Console.WriteLine("Полный путь: " + fi2.FullName);
                Console.WriteLine("-----------------------------------------------------");
                var fi3 = new FileInfo(@"E:\Temp\K2\t3.txt");
                Console.WriteLine(String.Format("Информация о файле: {0}:", fi3.Name));
                Console.WriteLine("Размер: " + fi3.Length + " байт");
                Console.WriteLine("Время создания: " + fi3.CreationTimeUtc);
                Console.WriteLine("Последнее изменение - " + fi3.LastWriteTime);
                Console.WriteLine("Полный путь: " + fi3.FullName);
                Console.WriteLine("-----------------------------------------------------");

                fi2.MoveTo(@"E:\Temp\K2\t2.txt");
                File.Copy(@"E:\Temp\K1\t1.txt", @"E:\Temp\K2\t1.txt", true);
                Directory.Move(@"E:\Temp\K2", @"E:\Temp\ALL");
                Directory.Delete(@"E:\Temp\K1", true);
                Console.WriteLine("Полная информация о файлах папки All: ");
                var fi = new FileInfo(@"E:\Temp\ALL\t1.txt");
                Console.WriteLine(String.Format("Информация о файле: {0}:", fi.Name));
                Console.WriteLine("Размер: " + fi.Length + " байт");
                Console.WriteLine("Время создания: " + fi.CreationTimeUtc);
                Console.WriteLine("Последнее изменение - " + fi.LastWriteTime);
                Console.WriteLine("Полный путь: " + fi.FullName);
            }
            catch { Console.WriteLine("Файлы уже созданы"); }
            Console.ReadKey();


        }
    }
}
