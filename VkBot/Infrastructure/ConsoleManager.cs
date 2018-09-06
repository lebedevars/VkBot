using System;

namespace VkBot.Infrastructure
{
    public class ConsoleManager : IConsoleManager
    {
        public string GetPassword()
        {
            Console.Write("Введите пароль: ");
            var password = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, password.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }

        public string GetTargetIdentifier()
        {
            Console.Write("Введите идентификатор пользователя/группы: ");
            return Console.ReadLine();
        }

        public void Output(string text)
        {
            Console.WriteLine(text);
        }
    }
}
