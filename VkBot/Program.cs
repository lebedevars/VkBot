using System;
using System.Collections.Generic;
using VkBot.Helpers;
using VkBot.Infrastructure;
using VkNet;

namespace VkBot
{
    class Program
    {
        private IConsoleManager _console;
        private IVkManager _vkManager;
        private ILetterFrequencyCalculator _calculator;

        static void Main(string[] args)
        {
            new Program().CalcLetterFrequency();
        }

        private void CalcLetterFrequency()
        {
            try
            {
                _console = new ConsoleManager();
                _vkManager = new VkManager(new VkApi());
                _calculator = new LetterFrequencyCalculator();

                Authorize();

                var identifier = _console.GetTargetIdentifier();
                while (identifier != string.Empty)
                {
                    var posts = _vkManager.GetLastPosts(identifier);
                    var freqAsText = GetFrequency(posts);

                    _console.Output(freqAsText);
                    MakePost(identifier, freqAsText);

                    identifier = _console.GetTargetIdentifier();
                } 

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Отправка поста на стену.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="freqAsText"></param>
        private void MakePost(string identifier, string freqAsText)
        {
            var postId = _vkManager.Post($"{identifier}, статистика для последних {Configuration.PostCount} постов:\r\n{freqAsText}");
            if (postId != 0)
                _console.Output($"Сообщение со статистикой отправлено на стену (id = {Configuration.PostTo}).");
            else
                _console.Output($"Ошибка отправки сообщения на стену (id = {Configuration.PostTo}).");
        }

        /// <summary>
        /// Получение частотности букв.
        /// </summary>
        /// <param name="posts"></param>
        /// <returns></returns>
        private string GetFrequency(IEnumerable<string> posts)
        {
            var letterFrequency = _calculator.GetLetterFrequency(posts);
            var freqAsText = JsonHelper.SerializeDictionary(letterFrequency);
            return freqAsText;
        }

        /// <summary>
        /// Авторизация. При неудачной попытке авторизоваться предлагается сделать новую попытку.
        /// </summary>
        private void Authorize()
        {
            try
            {
                var password = _console.GetPassword();
                _vkManager.Authorize(password);
            }
            catch (Exception e)
            {
                _console.Output(e.Message);
                _console.Output("Не удалось авторизоваться: проверьте учетные данные и попробуйте снова");
                Authorize();
            }
        }
    }
}