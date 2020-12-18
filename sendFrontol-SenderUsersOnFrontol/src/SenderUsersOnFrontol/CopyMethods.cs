using System;
using System.IO;
using System.Windows.Forms;

class CopyMethods
{
    //копировать файлы с определенной датой последнего изменения
    public static void CopyByDate(string source, string dest, DateTime date)
    {
        string[] path = Directory.GetFiles(source);
        foreach (string file in path)
        {
            FileInfo fi = new FileInfo(file);
            if (fi.LastWriteTime.Year == date.Year && fi.LastWriteTime.Month == date.Month && fi.LastWriteTime.Day == date.Day)
            {
                string name = Path.GetFileName(file);
                string spath = Path.Combine(source, name);
                string dpath = Path.Combine(dest, name);
                Console.WriteLine("Копироване файла {0}", name);
                try
                {
                    if (!File.Exists(dpath))
                    {
                        File.Copy(spath, dpath, false);
                        Console.WriteLine("\t...завершено!");
                    }
                    else Console.WriteLine("File already exists");
                }
                catch (Exception e) { Console.WriteLine("Error: " + e); }

            }
        }
    }

    //копировать файлы по шаблону с определенной датой последнего изменения
    public static void CopyByDate(string source, string dest, string pattern, DateTime date)
    {
        string[] path = Directory.GetFiles(source, pattern);
        foreach (string file in path)
        {
            FileInfo fi = new FileInfo(file);
            if (fi.LastWriteTime.Year == date.Year && fi.LastWriteTime.Month == date.Month && fi.LastWriteTime.Day == date.Day)
            {
                string name = Path.GetFileName(file);
                string spath = Path.Combine(source, name);
                string dpath = Path.Combine(dest, name);
                Console.WriteLine("Копироване файла {0}", name);
                try
                {
                    if (!File.Exists(dpath))
                    {
                        File.Copy(spath, dpath, false);
                        Console.WriteLine("\t...завершено!");
                    }
                    else Console.WriteLine("File already exists");
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message);
                    Console.WriteLine("Error: " + e);
                }


            }
        }
    }

    //копировать файлы по шаблону
    public static void CopyByPattern(string source, string dest, string pattern)
    {
        string[] path = Directory.GetFiles(source, pattern);
        foreach (string file in path)
        {
            FileInfo fi = new FileInfo(file);
            string name = Path.GetFileName(file);
            string spath = Path.Combine(source, name);
            string dpath = Path.Combine(dest, name);
            Console.WriteLine("Копироване файла {0}", name);
            try
            {
                if (!File.Exists(dpath))
                {
                    File.Copy(spath, dpath, false);
                    Console.WriteLine("\t...завершено!");
                }
                else
                {
                    File.Copy(spath, dpath, true);
                    Console.WriteLine("\t...завершено!");
                }
            }
            catch (Exception e) { Console.WriteLine("Error: " + e); }



        }
    }
}