using System.Collections.Generic;

namespace VkBot.Infrastructure
{
    public interface ILetterFrequencyCalculator
    {
        /// <summary>
        /// Получение частотности букв из списка постов.
        /// </summary>
        /// <param name="texts"></param>
        /// <returns></returns>
        IDictionary<char, double> GetLetterFrequency(IEnumerable<string> texts);
    }
}