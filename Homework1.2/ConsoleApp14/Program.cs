using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            var a = ReadPos("a");
            var b = ReadPos("b");
            var c = ReadPos("c");
            var k = ran.Next(a,b);
            Console.WriteLine($"k is {k}");
            do
            {
                if (k > c)
                {
                    Console.WriteLine(k);
                    Console.WriteLine("k > c");
                    b = k;
                    k = ran.Next(a, b);

                    Console.WriteLine($"now k is {k}");
                }
                else if (k<c)
                {
                    Console.WriteLine(k);
                    Console.WriteLine("k < c");
                    a = k;
                    k = ran.Next(a, b);
                    Console.WriteLine($"now k is {k}");
                }
            } while (k != c);
            Console.WriteLine($"You are write, it is {c}");
            Console.WriteLine(k);

            Console.Read();
        }
        static int ReadPos(string posname)
        {
            do
            {
                try
                {
                    Console.WriteLine($"Enter {posname}");
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                    {
                        throw new OperationCanceledException();
                    }
                    var line = Console.ReadLine();
                    var key_line = $"{key.KeyChar}{line}";
                    return Convert.ToInt32($"{key_line}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Bad inpruv {ex} try again or click escape");
                }
            } while (true);
        }
    }
}
