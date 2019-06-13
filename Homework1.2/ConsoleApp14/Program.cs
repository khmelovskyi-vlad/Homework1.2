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
            int startPos, endPos;
            var randomNum = Rand(ran, out startPos, out endPos);
            var myNumber = ReadPos("you Number");
            Console.WriteLine($"now computer number is {randomNum}");
            do
            {
                if (randomNum > myNumber)
                {
                    Console.WriteLine("computer number > my number");
                    endPos = randomNum;
                    randomNum = ran.Next(startPos, endPos);

                    Console.WriteLine($"now computer number is {randomNum}");
                }
                else if (randomNum < myNumber)
                {
                    Console.WriteLine("computer number < my number");
                    startPos = randomNum;
                    randomNum = ran.Next(startPos, endPos);
                    Console.WriteLine($"now computer number is {randomNum}");
                }
            } while (randomNum != myNumber);
            Console.WriteLine($"Computer is write, it is {myNumber}");

            Console.Read();
        }
        static int Rand(Random rand, out int startP, out int endP)
        {
            startP = ReadPos("start position");
            endP = ReadPos("end position");
            int randomNum;
            while (true)
            {
                try
                {
                    randomNum = rand.Next(startP, endP);
                    return randomNum;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again");
                    startP = ReadPos("start position");
                    endP = ReadPos("end position");
                }
            }
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
