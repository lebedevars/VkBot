using System;
using System.Collections.Generic;
using System.Linq;
using VkBot.Helpers;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkBot.Infrastructure
{
    public class VkManager : IVkManager
    {
        private readonly IVkApi _vkApi;

        public VkManager(IVkApi vkApi)
        {
            _vkApi = vkApi ?? throw new ArgumentNullException(nameof(vkApi));
        }
        
        /// <summary>
        /// Авторизация ВКонтакте.
        /// </summary>
        public void Authorize(string password)
        {
            _vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = Configuration.AppId,
                Login = Configuration.Login,
                Password = password,
                Settings = Settings.All
            });
            if (!_vkApi.IsAuthorized)
                throw new Exception("Ошибка авторизации");
        }

        /// <summary>
        /// Получение последних postsCount постов со страницы пользователя/группы.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="postsCount"></param>
        /// <returns></returns>
        public IEnumerable<string> GetLastPosts(string identifier)
        {
            var searchParams = new WallGetParams();

            if (Parser.TryGetId(identifier, out long longId))
                searchParams.OwnerId = longId;
            else
                searchParams.Domain = identifier;

            var wall = _vkApi.Wall.Get(searchParams);
            return wall.WallPosts.OrderByDescending(post => post.Date).Take(Configuration.PostCount).Select(p => p.Text).ToList();
        }

        /// <summary>
        /// Отправляет пост на стену.
        /// Пользователь/группа определяется настройкой PostTo.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public long Post(string text)
        {
            if (Parser.TryGetId(Configuration.PostTo, out long id))
                return _vkApi.Wall.Post(new WallPostParams { OwnerId = id, Message = text });

            throw new Exception("Не удалось распознать id группы для отправки сообщения на стену");
        }
    }
}
