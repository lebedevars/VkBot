using System.Collections.Generic;

namespace VkBot.Infrastructure
{
    public interface IVkManager
    {
        /// <summary>
        /// Авторизация ВКонтакте.
        /// Требуется указать нужные параметры в App.config.
        /// </summary>
        /// <param name="password"></param>
        void Authorize(string password);

        /// <summary>
        /// Получение последних postsCount постов по идентификатору.
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        IEnumerable<string> GetLastPosts(string identifier);

        /// <summary>
        /// Отправка сообщения на стену.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        long Post(string text);
    }
}