using System;

/// <summary>
/// Класс представляет машинку
/// </summary>
struct Car
{
    private readonly ConsoleColor Color;
    private readonly string Model;
    private readonly int Row;
    /// <summary>
    /// Скорость, за сколько секунд будет сдвиг на символ
    /// </summary>
    private readonly double Speed;
    /// <summary>
    /// Когда в последний раз было перемещение
    /// </summary>
    private DateTime LastCall;
    /// <summary>
    /// Пощзиция курсора
    /// </summary>
    private int CursorPosition;

    /// <summary>
    /// Сдвинуться на символ
    /// </summary>
    private void StepSymbol()
    {
        Console.SetCursorPosition(CursorPosition, Row);
        if ((Console.WindowWidth - CursorPosition - Model.Length) < 1)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(new string(default, Model.Length));
            CursorPosition = 0;
            Console.SetCursorPosition(CursorPosition, Row);
            Console.Write(Model);
            return;
        }
        Console.ForegroundColor = Color;
        Console.Write($" {Model}");
        Console.ForegroundColor = ConsoleColor.Gray;
        ++CursorPosition;
    }

    /// <summary>
    /// Сдвинуться по времени
    /// </summary>
    public void Update()
    {
        var seconds = (DateTime.Now - LastCall).TotalSeconds;
        for (var i = Speed; i <= seconds; i += Speed)
        {
            StepSymbol();
        }
        LastCall = DateTime.Now;
    }

    /// <summary>
    /// Начать отсчёт времени
    /// </summary>
    public void InitTime()
    {
        LastCall = DateTime.Now;
    }

    /// <param name="color">Цвет</param>
    /// <param name="model">Модель машинки (строка)</param>
    /// <param name="speed">Скорость символов за одну секунду</param>
    /// <param name="row">Ряд в консоли</param>
    public Car(
        in ConsoleColor color,
        in string model,
        in uint speed,
        in uint row)
    {
        Color = color;
        Model = model;
        Row = (int)row;
        Speed = 1d / speed;
        CursorPosition = 0;
        LastCall = DateTime.Now;
    }
}

