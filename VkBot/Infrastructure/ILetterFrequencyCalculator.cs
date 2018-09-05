using System.Collections.Generic;

namespace VkBot.Infrastructure
{
    public interface ILetterFrequencyCalculator
    {
        IDictionary<char, double> GetLetterFrequency(IEnumerable<string> texts);
    }
}