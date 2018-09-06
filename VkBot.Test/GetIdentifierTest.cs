using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VkBot.Test
{
    [TestClass]
    [TestCategory("Parser")]
    public class GetIdentifierTest
    {
        /// <summary>
        /// Создаем корректный идентификатор пользователя.
        /// Пытаемся получить из него численный Id.
        /// Убеждаемся в правильности полученных данных.
        /// </summary>
        [TestMethod]
        public void TryGetIdFromCorrectUserIdentifier()
        {
            const string USER_ID = "id1234";

            var parsed = Helpers.Parser.TryGetId(USER_ID, out long id);

            Assert.IsTrue(parsed);
            Assert.AreEqual(1234, id);
        }

        /// <summary>
        /// Создаем некорректные идентиифкаторы пользователя.
        /// Пытаемся получить из них численные Id.
        /// Убеждаемся в том, что распарсить не удалось.
        /// </summary>
        [TestMethod]
        public void TryGetIdFromWrongUserIdentifier()
        {
            const string CASE_1 = "id";
            const string CASE_2 = "id123sdf";
            const string CASE_3 = "aaa123";
            const string CASE_4 = "123id123";

            var case1 = Helpers.Parser.TryGetId(CASE_1, out long id);
            var case2 = Helpers.Parser.TryGetId(CASE_2, out id);
            var case3 = Helpers.Parser.TryGetId(CASE_3, out id);
            var case4 = Helpers.Parser.TryGetId(CASE_4, out id);

            Assert.IsFalse(case1);
            Assert.IsFalse(case2);
            Assert.IsFalse(case3);
            Assert.IsFalse(case4);
        }

        /// <summary>
        /// Создаем корректный идентификатор группы.
        /// Пытаемся получить из него численный Id.
        /// Убеждаемся в правильности полученных данных.
        /// </summary>
        [TestMethod]
        public void TryGetIdFromCorrectGroupIdentifier()
        {
            const string GROUP_ID = "club1234";
            const string PUBLIC_ID = "public1254";

            var parsed = Helpers.Parser.TryGetId(GROUP_ID, out long id);
            var pubParsed = Helpers.Parser.TryGetId(PUBLIC_ID, out long pubId);

            Assert.IsTrue(parsed);
            Assert.AreEqual(-1234, id);
            Assert.IsTrue(pubParsed);
            Assert.AreEqual(-1254, pubId);
        }

        /// <summary>
        /// Создаем некорректные идентиифкаторы групп.
        /// Пытаемся получить из них численные Id.
        /// Убеждаемся в том, что распарсить не удалось.
        /// </summary>
        [TestMethod]
        public void TryGetIdFromWrongGroupIdentifier()
        {
            const string CASE_1 = "group";
            const string CASE_2 = "group123id";
            const string CASE_3 = "aaagroup123";
            const string CASE_4 = "123group123";
            const string CASE_5 = "123public123";

            var case1 = Helpers.Parser.TryGetId(CASE_1, out long id);
            var case2 = Helpers.Parser.TryGetId(CASE_2, out id);
            var case3 = Helpers.Parser.TryGetId(CASE_3, out id);
            var case4 = Helpers.Parser.TryGetId(CASE_4, out id);
            var case5 = Helpers.Parser.TryGetId(CASE_5, out id);

            Assert.IsFalse(case1);
            Assert.IsFalse(case2);
            Assert.IsFalse(case3);
            Assert.IsFalse(case4);
            Assert.IsFalse(case5);
        }
    }
}
