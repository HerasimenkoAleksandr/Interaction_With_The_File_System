using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace dz12
{
    public class CreateNumbers
    {
        private List<int> Numbers;
        public CreateNumbers()
        {
            Numbers = new List<int>(100);
            Random newNumber = new Random();
            Console.Write(@"Все числа:");
            for (int i = 0; i < 100; i++)
            {

                Numbers.Add(newNumber.Next(100));
                if (i % 20 == 0)
                {
                    Console.WriteLine();
                }
                Console.Write($" {Numbers[i]}");
            }
            Console.WriteLine();
        }
        public List<ulong> FindFibNumbers()
        {
            int k = 0;
            List<ulong> FibNumbers = new List<ulong>();
            Console.WriteLine("Числа Фибоначчи: ");
            foreach (var i in Numbers)
            {
                k++;
                ulong numbertemp;
                ulong number = 0;
                ulong fibnumber = 1;
                for (int j = 1; j < i.GetHashCode(); j++)
                {
                    numbertemp = fibnumber;
                    fibnumber += number;
                    number = numbertemp;
                }
                Console.WriteLine(i.GetHashCode() + " :-> " + fibnumber);
                FibNumbers.Add(fibnumber);
            }
            return FibNumbers;
        }
        public List<int> FindPrimeNumbers()
        {
            int n = 0;
            Console.WriteLine($"простые числа: ");
            List<int> PrimeNumbers = new List<int>();
            foreach (var i in Numbers)
            {
                for (int j = 2; j < i.GetHashCode(); j++)
                {
                    if (i.GetHashCode() % j == 0)
                    {
                        break;
                    }
                    if (i.GetHashCode() - 1 == j)
                    {
                        PrimeNumbers.Add(i.GetHashCode());
                        if (n > 15)
                        {
                            Console.WriteLine();
                            n = 0;
                        }
                        Console.Write($" {i.GetHashCode()}");
                    }
                }
            }
            Console.WriteLine();
            return PrimeNumbers;
        }

        public void WriteNumber<T>(List<T> obj)
        {
            int c = 0;
            if (obj.Count == 100)
            {
                using (FileStream fs = new FileStream("Fibonacci_number1.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                        for (int i = 0; i < obj.Count; i++)
                        {
                            c++;
                            if (c > 15)
                            {
                                sw.Write("\n");
                                c = 0;
                            }
                            sw.Write(" " + obj[i]);
                        }
                }

            }
            else
            {
                using (FileStream fs = new FileStream("Prime_number.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                        foreach (var t in obj)
                        {
                            c++;
                            if (c > 15)
                            {
                                sw.Write("\n");
                                c = 0;
                            }
                            sw.Write(" " + t.GetHashCode());
                        }

                }
            }

        }

        public void ReadNumbers(string obj)
        {
            using (FileStream fs = new FileStream(obj, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                int r = 0;
                using (StreamReader sw = new StreamReader(fs, Encoding.Unicode))
                {
                    //  Console.WriteLine("Читаем =" + sw.ReadToEnd());
                    char[] oper = { ' ', '\n' };
                    var Temp = sw.ReadToEnd().Split(oper, StringSplitOptions.None);
                    Console.WriteLine($"Читаем файл {obj} ");
                    foreach (var p in Temp)
                    {
                        if (r > 10)
                        {
                            Console.WriteLine();
                            r = 0;
                        }
                        Console.Write(" " + p);
                    }
                }
            }
            Console.WriteLine();
        }
    }


    public class ChangeText
    {
        public string String { get; set; }
        public ChangeText()
        {
            Console.WriteLine("Ведиет текст");
            String = Console.ReadLine();
            using (FileStream fs = new FileStream("Text.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(String);
                }

            }
        }

        public void ChangeWord(string obj1, string obj2)
        {
            string temp;
            using (FileStream fs = new FileStream("Text.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                //string newText = null;
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    String word1;
                    String word2;
                    Console.WriteLine("Ведиет слово которое хотите в тексте поменять: ");
                    word1 = Console.ReadLine();
                    Console.WriteLine("Ведиет слово для замены: ");
                    word2 = Console.ReadLine();
                    char[] oper = { ' ', '\n' };
                    temp = sr.ReadToEnd().Replace(word1, word2);
                    Console.WriteLine($"Читаем файл: {temp} ");
                }

            }
            using (FileStream fs = new FileStream("Text.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                   // Console.WriteLine($"Читаем файл: {temp} ");
                    sw.Write(temp);
                }

            }
        }
    }


    public class Moderator
    {
        public string Text { get; set; }
        public string WordsForModerator { get; set; }
        public Moderator()
        {

            // Console.WriteLine("Ведиет текст");
            Text = "test best res car \nman telephone";
            WordsForModerator = "car telephone";
            using (FileStream fs = new FileStream("WordsForModerator.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(WordsForModerator);
                }

            }
            using (FileStream fs = new FileStream("TextForModerator.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(Text);
                }

            }
        }
        public void ChangeWord()
        {
            string[] temp;
            char[] oper = { ' ', '\n' };
            using (FileStream fs = new FileStream("WordsForModerator.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {

                    temp = sr.ReadToEnd().Split(oper);
                }

            }
            Console.WriteLine("Читаем файл WordsForModerator.txt:");
            foreach (var f in temp)
            {
                Console.Write(f.ToString() + " ");
            }
            Console.WriteLine();
            using (FileStream fs = new FileStream("TextForModerator.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {

                string newText = null;

                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    String word;
                    newText = sr.ReadToEnd();
                    Console.WriteLine("Читаем файл TextForModerator.txt:");
                    Console.WriteLine(newText);
                    for (int i = 0; i < temp.Length; i++)
                    {
                        word = null;
                        foreach (var j in temp[i])
                        {
                            word += " ";
                            word += "*";
                        }
                        newText = newText.Replace(temp[i], word);
                    }

                    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                    {
                        // fs.Seek(0, SeekOrigin.Begin);
                        fs.Position = 0;
                        sw.Write(newText);



                    }

                }
            }
            using (FileStream fs = new FileStream("TextForModerator.txt", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                string newText2 = null;
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    newText2 = sr.ReadToEnd();
                    Console.WriteLine($"Читаем файл TextForModerator.txt после изменений: {newText2} ");
                }
            }
        }
    }
    public class PathToFile
    {
        public PathToFile()
        {
            Console.WriteLine("Для выполнения этого задание создан файл TextForExampler.txt ");
            Console.WriteLine("В файле записан следующая строка: ");
            string Text = "test best res car man telephone";
            Console.WriteLine(Text);
            using (FileStream fs = new FileStream("TextForExampler.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.Write(Text);
                }

            }
            Console.WriteLine();
        }
        public void OpenFile()
        {
            Console.WriteLine("Если вы хотите открыть свой файл для проверки выполнения задания - нажмите 1");
            Console.WriteLine("для открытия созданого файла - нажмите 2");
            int a;
            a = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            switch (a)
            {
                case 1:
                    {
                        string Path;
                        Console.Write("введите путь к файлу: ");
                        Path = Console.ReadLine();
                        string newText = null;
                        using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {

                            using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                            {
                                newText = sr.ReadToEnd();
                                Console.WriteLine($"Читаем файл {Path} : {newText} ");
                            }
                        }
                        using (FileStream fs = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                            {
                                string[] sReverse = newText.Split();
                                Array.Reverse(sReverse);
                                newText = null;
                                for (int i = 0; i < sReverse.Length; i++)
                                {
                                    newText += sReverse[i] + " ";
                                }
                                Console.WriteLine($"Читаем файл {"TextForExampler.txt"} : {newText} ");
                                sw.Write(newText);
                            }

                        }
                        break;
                    }
                case 2:
                    {

                        string newText = null;
                        using (FileStream fs = new FileStream("TextForExampler.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
                        {

                            using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                            {
                                newText = sr.ReadToEnd();
                                Console.WriteLine($"Читаем файл {"TextForExampler.txt"} : {newText} ");
                            }
                        }
                        using (FileStream fs = new FileStream("TextForExampler.txt", FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                            {
                                string[] sReverse = newText.Split();
                                Array.Reverse(sReverse);
                                newText = null;
                                for (int i = 0; i < sReverse.Length; i++)
                                {
                                    newText += sReverse[i] + " ";
                                }
                                Console.WriteLine($"Читаем файл {"TextForExampler.txt"} : {newText} ");
                                sw.Write(newText);
                            }

                        }
                        break;
                    }
                default:
                    break;
            }
        }

    }

    public class FileWithNumber
    {

        long[] Numbers;
        public FileWithNumber()
        {
            int d;
            Random number = new Random();
            using (FileStream fs = new FileStream("NumberForExampler.txt", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    for (int i = 0; i < 100000; i++)
                    {
                        d = number.Next(-100000, 100000);
                   
                        sw.Write(d + " ");
                    }
                   
                }

            }
        }

        public void ReadFile()
        {
            using (FileStream fs = new FileStream("NumberForExampler.txt", FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    try
                    {
                        string[] p = sr.ReadToEnd().Split(' ', '\n', (char)StringSplitOptions.RemoveEmptyEntries);
                        Numbers = new long[p.Length - 1];
                        for (int i = 0; i < p.Length; i++)
                        {

                            Numbers[i] = long.Parse(p[i]);
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine($" Numbers in array { Numbers.Length}");
                    }
                }
            }
        }
        public void DoNumbers()
        {
            Array.Sort(Numbers);
            IEnumerable<long> minus = from i in Numbers where i < 0 select i;
            IEnumerable<long> plus = from i in Numbers where i >= 0 select i;
            IEnumerable<long> two_digit = from i in Numbers where i <= 99&&i>=(-99) select i;
            IEnumerable<long> five_digit = from i in Numbers where i >= 10000 || i <= (-10000) select i;
            Console.WriteLine("Количество отрицательных чисел:"+minus.Count());
            Console.WriteLine("Количество отрицательных чисел:" + plus.Count());
            long s = minus.Count() + plus.Count();
            Console.WriteLine($"Проверка: сумма отрицательных и положительных чисел = {s}");
            Console.WriteLine("Количество двузначны чисел:" + two_digit.Count());
            Console.WriteLine("Количество пятизначных чисел:" + five_digit.Count());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ 1");
            CreateNumbers Test = new CreateNumbers();
            Console.WriteLine();
            Test.WriteNumber(Test.FindPrimeNumbers());
            Console.WriteLine();
            Test.WriteNumber(Test.FindFibNumbers());
            Console.WriteLine();
            Test.ReadNumbers("Fibonacci_number1.txt");
            Console.WriteLine();
            Test.ReadNumbers("Prime_number.txt");
            Console.WriteLine("\nНажмите ENTER для перехода к заданию 2");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗАДАНИЕ 2");
            Console.WriteLine();
            ChangeText Text = new ChangeText();
            Text.ChangeWord("Hello", "Hi");
        
            Console.WriteLine("\nНажмите ENTER для перехода к заданию 3");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗАДАНИЕ 3");
            Moderator moderator = new Moderator();
            moderator.ChangeWord();
     
            Console.WriteLine("\nНажмите ENTER для перехода к заданию 4");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗАДАНИЕ 4");
            PathToFile Test4 = new PathToFile();
            Test4.OpenFile();
            Console.WriteLine("\nНажмите ENTER для перехода к заданию 5");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nЗАДАНИЕ 5");
            FileWithNumber Test5 = new FileWithNumber();
            Test5.ReadFile();
            Test5.DoNumbers();

        }
       
    }
}
