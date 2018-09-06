namespace VkBot.Infrastructure
{
    public interface IConsoleManager
    {
        /// <summary>
        /// Получения пароль пользователя.
        /// На ввод накладывается маска.
        /// </summary>
        /// <returns></returns>
        string GetPassword();

        /// <summary>
        /// Получение идентификатора пользователя/группы, у которого(ой) будут просматриваться посты.
        /// </summary>
        /// <returns></returns>
        string GetTargetIdentifier();

        /// <summary>
        /// Вывод на консоль.
        /// </summary>
        /// <param name="text"></param>
        void Output(string text);

    }
}