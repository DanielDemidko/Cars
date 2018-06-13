using System;

/// <summary>
/// Класс для общих вспомогательных методов
/// </summary>
static class Utils
{
    /// <summary>
    /// Функция считывает число с консоли до тех пор 
    /// пока оно не станет удовлетворять заданным условиям
    /// </summary>
    /// <param name="message">Сообщение при кажом вводе числа</param>
    /// <param name="onFalse">Сообщение если время не удовлетворяет условию</param>
    /// <param name="predicate">Условие</param>
    /// <returns>Число</returns>
    private static uint ReadUInt(
        in string message, 
        in string onFalse = null, 
        in Predicate<uint> predicate = null)
    {
        while (true)
        {
            Console.Write(message);
            if (UInt32.TryParse(Console.ReadLine(), out var res) && 
                (predicate == null || predicate(res)))
            {
                return res;
            }
            if (onFalse != null)
            {
                Console.WriteLine(onFalse);
            }
        }
    }

    /// <summary>
    /// Считывает цвет с консоли
    /// </summary>
    /// <returns>Цвет</returns>
    public static ConsoleColor ReadColor()
    {
        Console.WriteLine("Выберите цвет.");
        for (var i = ConsoleColor.Black; i <= ConsoleColor.White; ++i)
        {
            if(i != ConsoleColor.DarkGray && i != ConsoleColor.Gray)
            {
                Console.WriteLine($"{(uint)i} - {i}");
            }
        }
        return (ConsoleColor)Utils.ReadUInt(
            "Номер цвета: ",
            "Такого цвета у нас нет!",
            i => i <= (uint)ConsoleColor.White);
    }

    /// <summary>
    /// Считывает модель машинки с консоли
    /// </summary>
    /// <returns>Модель машинки (строка)</returns>
    public static string ReadModel()
    {
        Console.WriteLine("Выберите модель машинки.");
        var Models = new[] { "○▀┻○", "○▀━o", "○▀━○", "●▀━●", "○▀┻o" };
        for (uint i = 0; i < Models.Length; ++i)
        {
            Console.WriteLine($"{i} - {Models[i]}");
        }
        return Models[Utils.ReadUInt(
            "Введите номер модели: ",
            "Такой модели у нас нет!",
            i => i < Models.Length)];
    }

    /// <summary>
    /// Считывает скорость
    /// </summary>
    /// <returns>Скорость</returns>
    public static uint ReadSpeed() =>
        Utils.ReadUInt(
            "Введите скорость символов в секунду: ", 
            "Некорректная скорость!");

    /// <summary>
    /// Считывает ряд
    /// </summary>
    /// <returns>Ряд</returns>
    public static uint ReadRow() =>
        Utils.ReadUInt(
            "Введите номер ряда: ", 
            "Некорректный ряд!") - 1;

    /// <summary>
    /// Считывает количество машинок
    /// </summary>
    /// <returns>Количество</returns>
    public static uint ReadCarsCount() =>
        Utils.ReadUInt(
            "Введите количество машинок: ",
            "Некорректное количество!");
}

