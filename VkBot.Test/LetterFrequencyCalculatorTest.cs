using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VkBot.Infrastructure;

namespace VkBot.Test
{
    [TestClass]
    [TestCategory("Letter frequency")]
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
            var texts = new List<string> { "AAaa", "bBb", "abc", "cc" };

            ILetterFrequencyCalculator calculator = new LetterFrequencyCalculator();
            var output = calculator.GetLetterFrequency(texts);

            Assert.AreEqual(3, output.Count);
            Assert.AreEqual(output['a'], Math.Round((double) 5 / 12, 5));
            Assert.AreEqual(output['b'], Math.Round((double) 4 / 12, 5));
            Assert.AreEqual(output['c'], Math.Round((double) 3 / 12, 5));
        }
    }
}
