﻿using System;
using System.Collections.Generic;
namespace tamagotchi
{
    class Program
    {
        static void ShowCommands(tamagotchi.Animal cat)
        {
            Console.WriteLine("Выберите дейтсвие");
            Console.WriteLine("1.Покормить\n 2.Поиграть\n3.Почистить комнату\n4.Напоить");
            var command = Console.ReadKey(true).Key;
            switch (command)
            {
                case ConsoleKey.D1: {
                    cat.Eat();
                    break;
                }
                case ConsoleKey.D2: {
                    cat.Play();
                    break;
                }
                case ConsoleKey.D3:
                {
                    cat.Clean();
                    break;
                }
                case ConsoleKey.D4:
                {
                    cat.Drink();
                    break;
                }
                default:
                {
                    Console.WriteLine("Неверный ввод");
                    ShowCommands(cat);
                    break;
                }
            }
        }
        static void StartGame()
        {
            Console.WriteLine("Начало игры. Выберите животное");
            Console.WriteLine("1.Кошка");
            var value = Console.ReadKey(true).Key;
            if (value == ConsoleKey.D1)
            {
                Console.WriteLine("Вы начали игру. Введите имя питомца ");
                var name = Console.ReadLine();
                tamagotchi.Cat cat = new tamagotchi.Cat(name);
                while (cat.isAlive())
                {
                    ShowCommands(cat);
                }
            }
        }
        static void Main(string[] args)
        {
            StartGame();
        }
    }
}