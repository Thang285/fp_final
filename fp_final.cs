using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Threading;


namespace TypingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tao mang chua danh sach cac tu vung
            string[] words = File.ReadAllLines("D:\\Final_CSLT_Code\\words_alpha.txt");
            Random random = new Random();

            //Hien thi dau chuong trinh
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 4);
            Console.WriteLine("Welcome to Typing Game!");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Type the words as quickly as possible!! Press Enter to start.");
            Console.ReadLine();

            //Tao bien dem tu nhap dung
            int correctWords = 0;
            //So tu nhap dung
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //Vong lap hien thi cho choi
            while (true)
            {
                //Hien thi tu duoc chon ngau nhien
                Console.Clear();
                string word = words[random.Next(words.Length)];
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2 - 4);
                Console.Write($"Type: {word}");

                //Tao bien kiem tra ky tu nhap 
                bool correctWord = true;

                for (int i = 0; i < word.Length; i++)
                {
                    ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                    if (char.ToLower(key.KeyChar) == char.ToLower(word[i]))
                    {
                        //Tao bien chua substring 
                        string halfLetter = word.Substring(i + 1);

                        //Doi mau ky tu nhap sang do
                        Console.SetCursorPosition(Console.WindowWidth / 2 + i + 1, Console.WindowHeight / 2 - 4);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(key.KeyChar);
                        Thread.Sleep(200); //Thoi gian 200ms

                        //Doi mau ky tu nhap tro lai trang
                        //Do tung ky tu trong tu
                        //Hien thi ky tu + substring
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(word[i]);
                        Console.Write($"{halfLetter}");
                        Console.SetCursorPosition(Console.CursorLeft - word.Length + i + 1, Console.CursorTop);
                    }
                    else
                    {
                        correctWord = false;
                        break;
                    }
                }

                //Hien thi khi nhap dung
                if (correctWord)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2);
                    Console.WriteLine("Correct! Press Enter for the next word.");
                    Console.ReadLine();
                    correctWords++;
                }

                //Hien thi khi nhap sai
                else
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2);
                    Console.WriteLine("Incorrect letter. Press Enter to continue.");
                    Console.ReadLine();
                    break;
                }
            }

            //Hien thi khi ket thuc chuong trinh
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 2);
            //So tu nhap dung
            Console.WriteLine($"Words typed correctly: {correctWords}");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 3);
            //Tong thoi gian
            Console.WriteLine($"Time taken: {Math.Round(elapsedTime.TotalSeconds, 2, MidpointRounding.ToEven)} seconds");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 4);
            //Thoi gian trung binh moi tu
            Console.WriteLine($"Time taken per word: {Math.Round(Math.Round(elapsedTime.TotalSeconds, 2, MidpointRounding.ToEven) / correctWords, 2, MidpointRounding.ToEven)}");
            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 + 5);
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
        }
    }
}

