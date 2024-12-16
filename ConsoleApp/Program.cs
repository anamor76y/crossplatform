using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;
using Library;

[Command(Name = "Lab4", Description = "Консольний застосунок для запуску лабораторних робіт")]
[Subcommand(typeof(VersionCommand))]
[Subcommand(typeof(RunCommand))]
[Subcommand(typeof(SetPathCommand))]
class Program
{
    static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);
}

[Command(Name = "version", Description = "Виводить інформацію про програму")]
class VersionCommand
{
    public void OnExecute()
    {
        // Виведення інформації про програму
        Console.WriteLine("Автор: Anna Moroz");
        Console.WriteLine("Версія: 1.0");
    }
}

[Command(Name = "run", Description = "Запускає лабораторну роботу")]
class RunCommand
{
    [Argument(0, Description = "Назва лабораторної роботи (lab1, lab2, lab3)")]
    public string? Lab { get; set; }

    [Option("-i|--input <INPUT>", "Шлях до вхідного файлу", CommandOptionType.SingleValue)]
    public string? InputFilePath { get; set; }

    [Option("-o|--output <OUTPUT>", "Шлях до вихідного файлу", CommandOptionType.SingleValue)]
    public string? OutputFilePath { get; set; }

    private void OnExecute()
    {
        // Отримуємо значення змінної середовища LAB_PATH
        string labPath = Environment.GetEnvironmentVariable("LAB_PATH");

        // Визначаємо базовий шлях для файлів
        string basePath = string.IsNullOrEmpty(labPath)
            ? Directory.GetCurrentDirectory()
            : labPath;

        Console.WriteLine($"Базовий шлях для файлів: {basePath}");

        // Формуємо шлях до вхідного файлу
        string inputFilePath = string.IsNullOrEmpty(InputFilePath)
            ? Path.Combine(basePath, "input.txt")
            : Path.GetFullPath(InputFilePath);

        // Перевірка існування вхідного файлу
        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"Файл введення не знайдено: {inputFilePath}");
            return;
        }

        // Формуємо шлях до вихідного файлу
        string outputFilePath = string.IsNullOrEmpty(OutputFilePath)
            ? Path.Combine(basePath, "output.txt")
            : Path.GetFullPath(OutputFilePath);

        Console.WriteLine($"Файл введення: {inputFilePath}");
        Console.WriteLine($"Файл виведення: {outputFilePath}");

        // Виконання обраної лабораторної роботи
        string result;
        switch (Lab?.ToLower())
        {
            case "lab1":
                result = Prog.Lab1(inputFilePath, outputFilePath);
                break;
            case "lab2":
                result = Prog.Lab2(inputFilePath, outputFilePath);
                break;
            case "lab3":
                result = Prog.Lab3(inputFilePath, outputFilePath);
                break;
            default:
                Console.WriteLine("Невідома лабораторна робота.");
                return;
        }

        // Запис результату до файлу
        File.WriteAllText(outputFilePath, result);
        Console.WriteLine($"Лабораторна '{Lab}' виконана. Результат збережено у файл: {outputFilePath}");
    }

    // вихідний файл в поточній директорії
}

[Command(Name = "set-path", Description = "Встановлює шлях до папки лабораторій")]
class SetPathCommand
{
    [Option("-p|--path <PATH>", "Шлях до папки з файлами (обов'язковий)", CommandOptionType.SingleValue)]
    public string? Path { get; set; }

    public void OnExecute()
    {
        if (string.IsNullOrEmpty(Path))
        {
            Console.WriteLine("Помилка: Вкажіть шлях до папки за допомогою параметра -p або --path.");
            return;
        }

        if (!Directory.Exists(Path))
        {
            Console.WriteLine($"Помилка: Шлях '{Path}' не існує. Вкажіть дійсний шлях.");
            return;
        }

        // Встановлення змінної середовища
        Environment.SetEnvironmentVariable("LAB_PATH", Path, EnvironmentVariableTarget.User);
        Console.WriteLine($"Шлях до лабораторних файлів встановлено в змінну середовища 'LAB_PATH': {Path}");
    }
}
