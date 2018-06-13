using System;
using System.Collections.Generic;

/// <summary>
/// Класс игры
/// </summary>
static class Program
{
    /// <summary>
    /// Создать машинки
    /// </summary>
    /// <returns>Набор машинок</returns>
    static IEnumerable<Car> CreateCars()
    {
        Console.OutputEncoding =
        Console.InputEncoding =
            System.Text.Encoding.Unicode;
        Console.Title = "Машинки";
        Console.CursorVisible = false;
        var count = Utils.ReadCarsCount();
        var cars = new List<Car>();
        for (uint i = 1; i <= count; ++i)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Создаём машинку {i}...");
            Console.ForegroundColor = ConsoleColor.Gray;
            cars.Add(new Car(
                Utils.ReadColor(),
                Utils.ReadModel(),
                Utils.ReadSpeed(),
                Utils.ReadRow()));
        }
        return cars;
    }

    /// <summary>
    /// Запуск игры
    /// </summary>
    static void Main()
    {
        var cars = CreateCars();
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.Clear();
        foreach (var i in cars)
        {
            i.InitTime();
            i.Update();
        }
        while (true)
        {
            foreach (var i in cars)
            {
                i.Update();
            }
        }
    }
}

