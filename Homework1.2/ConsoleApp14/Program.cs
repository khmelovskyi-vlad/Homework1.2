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
            int randomNum, startPos, endPos;
            (randomNum, startPos, endPos) = Rand(ran);
            var myNumber = ReadPos("you Number");
            while (randomNum != myNumber)
            {
                Console.WriteLine($"now computer number is {randomNum}");
                if (randomNum > myNumber)
                {
                    Console.WriteLine("computer number > my number");
                    endPos = randomNum-1;
                }
                else if (randomNum < myNumber)
                {
                    Console.WriteLine("computer number < my number");
                    startPos = randomNum+1;
                }
                randomNum = ran.Next(startPos, endPos);
            } 
            Console.WriteLine($"Computer is write, it is {myNumber}");

            Console.Read();
        }
        static (int randomNum, int startP, int endP) Rand(Random rand)
        {
            while (true)
            {
                int startP = ReadPos("start position");
                int endP = ReadPos("end position");
                try
                {
                    var randomNum = rand.Next(startP, endP);
                    return (randomNum, startP, endP);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Bed input {ex.Message}, try again");
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
