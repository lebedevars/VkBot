using System.Text.RegularExpressions;

namespace VkBot.Helpers
{
    public static class Parser
    {
        /// <summary>
        /// Проверяет идентификатор на совпадение паттерну (id/club) + численный Id.
        /// Если идентификатор цифровой, то возвращает Id.
        /// Для идентификатора группы возвращается отрицательный Id.
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="longId"></param>
        /// <returns></returns>
        public static bool TryGetId(string identifier, out long longId)
        {
            longId = 0;

            var match = Regex.Match(identifier, @"^(id|club)([\d]{1,})$");
            if (!match.Success)
                return false;

            // 3 группы: группа 0 - все вместе, 1 - слово, 2 - цифра
            longId = long.Parse(match.Groups[2].Value);
            var idType = match.Groups[1].Value;
            if (idType == "club")
                longId = -longId;

            return true;
        }
    }
}