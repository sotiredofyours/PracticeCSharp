using System;
using System.Threading;

namespace krest
{
    class Program
    {
        private static int Count = 0;
        static void PrintField(int[,] field)
        {
            Console.Clear();
            Console.SetCursorPosition(0,0);
            Console.WriteLine("ПОЛЕ");
            Console.WriteLine("-------------");
            for (int i = 0; i < field.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 0)
                    {
                        Console.Write("   ");
                    }
                    else if (field[i, j] == 1)
                    {
                        Console.Write(" X ");
                    }
                    else
                    {
                        Console.Write(" O ");
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        public static void DoMove(int[,] field)
        {
            int firstcord = 0;
            int secondcord = 0;
            if (Count % 2 == 0)
            {
                Console.WriteLine("Ход крестиков. Введите координаты через пробел");
            }
            else
            {
                Console.WriteLine("Ход ноликов. Введите координаты через пробел");
            }

            var coordinates = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (int.TryParse(coordinates[0], out firstcord) && int.TryParse(coordinates[1], out secondcord))
            {
                if (firstcord > 3 || firstcord < 1 || secondcord > 3 || firstcord < 1)
                {
                    Console.WriteLine("Неверный ввод");
                    DoMove(field);
                }
                else
                {
                    if (field[firstcord-1, secondcord-1] == 0)
                    {
                        if (Count % 2 == 0)
                        {
                            field[firstcord - 1, secondcord - 1] = 1;
                        }
                        else
                        {
                            field[firstcord - 1, secondcord - 1] = 2;
                        }
                        Count++;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Поле занято");
                        DoMove(field);
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect input");
                DoMove(field);
            }
        }

        public static bool FieldIsFull(int[,] field)
        {
            foreach (var e in field)
            {
                if (e == 0) return false;
            }

            return true;
        }

        public static int WinP(int[,] field)
        {
            if (field[0, 0] == field[0, 1] && field[0, 1] == field[0, 2] && field[0, 0] != 0) return field[0,0];
            if (field[1, 0] == field[0, 1] && field[0, 1] == field[1, 2] && field[0, 0] != 0) return field[1,0];
            if (field[2, 0] == field[2, 1] && field[2, 1] == field[2, 2] && field[0, 0] != 0) return field[2,0];
            if (field[0, 0] == field[1, 0] && field[1, 0] == field[2, 0] && field[0, 0] != 0) return field[0,0];
            if (field[0, 1] == field[1, 1] && field[1, 1] == field[2, 1] && field[0, 0] != 0) return field[1,1];
            if (field[0, 2] == field[1, 2] && field[1, 2] == field[2, 2] && field[0, 0] != 0) return field[1,2];
            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[0, 0] != 0) return field[0,0];
            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0] && field[0, 0] != 0) return field[0,2];
            return 0;
        }

        public static bool GameIsOver(int[,] field)
        {
            if (WinP(field) == 1)
            {
                PrintField(field);
                Console.WriteLine("Победа крестов");
                return true;
            }
            else if (WinP(field) == 2)
            {
                PrintField(field);
                Console.WriteLine("Победа нулей");
                return true;
            }
            else
            {
                if (FieldIsFull(field))
                {
                    PrintField(field);
                    Console.WriteLine("Ничья");
                    return true;
                }
            }
            return false;
        }

        public static void StartGame()
        {
            int[,] field = new int[3, 3];
            while (!GameIsOver(field))
            { 
                PrintField(field);
                DoMove(field); 
            }
        }
        static void Main(string[] args)
        {
            StartGame();
        }
    }
}
 