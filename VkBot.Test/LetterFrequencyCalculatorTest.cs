using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkBot.Infrastructure;

namespace VkBot.Test
{
    [TestClass]
    public class LetterFrequencyCalculatorTest
    {
        /// <summary>
        /// Создаем последовательность текстов.
        /// Считаем частотность букв в тексте.
        /// Проверяем правильность подсчета.
        /// </summary>
        [TestMethod]
        public void GetLetterFrequencyTest()
        {
            var texts = new List<string> { "aaaa", "bbb", "abc", "cc" };

            ILetterFrequencyCalculator calculator = new LetterFrequencyCalculator();
            var output = calculator.GetLetterFrequency(texts);

            Assert.AreEqual(3, output.Count);
            Assert.AreEqual(output['a'], (double) 5 / 12);
            Assert.AreEqual(output['b'], (double) 4 / 12);
            Assert.AreEqual(output['c'], (double) 3 / 12);
        }
    }
}
