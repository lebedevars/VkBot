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
            _vkApi = vkApi;
        }
        
        /// <summary>
        /// Авторизация ВКонтакте.
        /// </summary>
        public void Authorize()
        {
            _vkApi.Authorize(new ApiAuthParams
            {
                ApplicationId = 6683623,
                Login = "",
                Password = "",
                Settings = Settings.All
            });
        }

        /// <summary>
        /// Получение последних postsCount постов со страницы пользователя / группы.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="postsCount"></param>
        /// <returns></returns>
        public IEnumerable<string> GetLastPosts(string identifier, int postsCount = 5)
        {
            var searchParams = new WallGetParams();

            if (Parser.TryGetId(identifier, out long longId))
                searchParams.OwnerId = longId;
            else
                searchParams.Domain = identifier;

            var wall = _vkApi.Wall.Get(searchParams);
            return wall.WallPosts.OrderByDescending(post => post.Date).Take(5).Select(p => p.Text).ToList();
        }
    }
}
