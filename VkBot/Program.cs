using VkBot.Infrastructure;
using VkNet;

namespace VkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CalcLetterFrequency();
        }

        private void CalcLetterFrequency()
        {
            IVkManager vkManager = new VkManager(new VkApi());
            vkManager.Authorize();
        }
    }
}
