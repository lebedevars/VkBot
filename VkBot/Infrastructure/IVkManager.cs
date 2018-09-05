using System.Collections.Generic;

namespace VkBot.Infrastructure
{
    public interface IVkManager
    {
        void Authorize();

        IEnumerable<string> GetLastPosts(string identifier, int postsCount);
    }
}