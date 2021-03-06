﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkBot.Infrastructure
{
    public class LetterFrequencyCalculator : ILetterFrequencyCalculator
    {
        public IDictionary<char, double> GetLetterFrequency(IEnumerable<string> texts)
        {
            var output = new Dictionary<char, double>();
            var sb = new StringBuilder();
            foreach (var text in texts)
            {
                sb.Append(new string(text.Where(char.IsLetter).Select(char.ToLower).ToArray()));
            }

            double charCount = sb.Length;
            var frequencies = sb.ToString().GroupBy(l => l).Select(g => new { Character = g.Key, Count = g.Count()}).OrderBy(freq => freq.Character);
            foreach (var freq in frequencies)
            {
                var key = freq.Character;
                if (output.ContainsKey(key))
                    output[key] += Math.Round(freq.Count / charCount, 5);
                else
                    output.Add(freq.Character, Math.Round(freq.Count / charCount, 5));
            }
            return output;
        }
    }
}