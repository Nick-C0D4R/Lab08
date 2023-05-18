using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab08
{
    public class Program
    {

        public delegate void Task1();
        public delegate void Task2();
        public delegate void Task3();
        public delegate void Task4();

        static void Main(string[] args)
        {
            Task1 task1 = new Task1(() =>
            {
                string path = "task1.txt";
                byte[] bytes;
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using (FileStream fs = File.OpenRead(path))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    List<byte> list = new List<byte>();
                    foreach(byte item in bytes)
                    {
                        if(item < 50)
                        {
                           list.Add(item);
                        }
                    }
                    bytes = list.ToArray();
                }
                foreach (var item in bytes)
                {
                    Console.Write($"{(int)item,-10}");
                }
            });

            Task2 task2 = new Task2(() =>
            {
                string path = "task1.txt";
                byte[] bytes;
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
                using (FileStream fs = File.OpenRead(path))
                {
                    bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    Array.Sort(bytes);
                }
                foreach (var item in bytes)
                {
                    Console.Write($"{(int)item,-10}");
                }
            });





            task1.Invoke();
            task2.Invoke();
        }
    }
}
