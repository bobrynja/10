using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //создание директорий
                string root = @"C:\Temp\K1";

                DirectoryInfo directory = new DirectoryInfo(root);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                root = @"C:\Temp\K2";
                directory = new DirectoryInfo(root);
                if (!directory.Exists)
                {
                    directory.Create();
                }


                //создание файлов
                StreamWriter sw = new StreamWriter(@"C:\Temp\K1\t2.txt");
                sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
                sw.Close();
                sw = new StreamWriter(@"C:\Temp\K1\t1.txt");
                sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
                sw.Close();

                //чтение из 1 и 2 файла и запись в 3
                sw = new StreamWriter(@"C:\Temp\K2\t3.txt");
                StreamReader sr = new StreamReader(@"C:\Temp\K1\t1.txt");
                string line = sr.ReadLine();
                while (line != null)
                {
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                sr = new StreamReader(@"C:\Temp\K1\t2.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();

                var fi1 = new FileInfo(@"C:\Temp\K1\t1.txt");
                textBox1.Text = String.Format("Информация о файле: {0}:", fi1.Name)+Environment.NewLine;
                textBox1.Text += "Размер: " + fi1.Length + " байт" + Environment.NewLine;
                textBox1.Text += ("Время создания: " + fi1.CreationTimeUtc) + Environment.NewLine;
                textBox1.Text += ("Последнее изменение - " + fi1.LastWriteTime) + Environment.NewLine;
                textBox1.Text += ("Полный путь: " + fi1.FullName) + Environment.NewLine;
                textBox1.Text += ("-----------------------------------------------------" + Environment.NewLine);
                var fi2 = new FileInfo(@"C:\Temp\K1\t2.txt");
                textBox1.Text += (String.Format("Информация о файле: {0}:", fi2.Name) + Environment.NewLine);
                textBox1.Text += ("Размер: " + fi2.Length + " байт" + Environment.NewLine);
                textBox1.Text += ("Время создания: " + fi2.CreationTimeUtc) + Environment.NewLine;
                textBox1.Text += ("Последнее изменение - " + fi2.LastWriteTime) + Environment.NewLine;
                textBox1.Text += ("Полный путь: " + fi2.FullName) + Environment.NewLine;
                textBox1.Text += ("-----------------------------------------------------") + Environment.NewLine;
                var fi3 = new FileInfo(@"C:\Temp\K2\t3.txt");
                textBox1.Text += (String.Format("Информация о файле: {0}:", fi3.Name) + Environment.NewLine);
                textBox1.Text += ("Размер: " + fi3.Length + " байт") + Environment.NewLine;
                textBox1.Text += ("Время создания: " + fi3.CreationTimeUtc) + Environment.NewLine;
                textBox1.Text += ("Последнее изменение - " + fi3.LastWriteTime) + Environment.NewLine;
                textBox1.Text += ("Полный путь: " + fi3.FullName) + Environment.NewLine;
                textBox1.Text += ("-----------------------------------------------------") + Environment.NewLine;

                fi2.MoveTo(@"C:\Temp\K2\t2.txt");
                File.Copy(@"C:\Temp\K1\t1.txt", @"C:\Temp\K2\t1.txt", true);
                Directory.Move(@"C:\Temp\K1", @"C:\Temp\ALL");
                Directory.Delete(@"C:\Temp\K2", true);
                textBox1.Text +=("Полная информация о файлах папки All: ") + Environment.NewLine;
                var fi = new FileInfo(@"C:\Temp\ALL\t1.txt");
                textBox1.Text += (String.Format("Информация о файле: {0}:", fi.Name) + Environment.NewLine);
                textBox1.Text += ("Размер: " + fi.Length + " байт" + Environment.NewLine);
                textBox1.Text += ("Время создания: " + fi.CreationTimeUtc) + Environment.NewLine;
                textBox1.Text += ("Последнее изменение - " + fi.LastWriteTime + Environment.NewLine);
                textBox1.Text += ("Полный путь: " + fi.FullName) + Environment.NewLine;
            }
            catch { MessageBox.Show("Файл уже существует"); }
        }
    }
}
