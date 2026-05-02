using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yakubchak_IP55_Lab7.DataStructures;

namespace DataStructures.Tests
{
    [TestClass]
    public class FloatSinglyLinkedListTests
    {
        [TestMethod]
        public void Add_WhenLessThanTwoElements_AddsToEnd()
        {
            // Arrange (Підготовка: створюємо порожній список)
            var list = new FloatSinglyLinkedList();

            // Act (Дія: додаємо два елементи)
            list.Add(1.5f);
            list.Add(2.5f);

            // Assert (Перевірка: чи правильно вони додалися)
            Assert.AreEqual(2, list.Count, "Кількість елементів має бути 2.");
            Assert.AreEqual(1.5f, list[0], "Перший елемент має бути 1.5.");
            Assert.AreEqual(2.5f, list[1], "Другий елемент має бути 2.5.");
        }

        [TestMethod]
        public void Add_WhenMoreThanTwoElements_InsertsStrictlyAfterSecond()
        {
            // Arrange (Підготовка)
            var list = new FloatSinglyLinkedList();
            list.Add(10f); // Індекс 0
            list.Add(20f); // Індекс 1

            // Act (Дія: додаємо третій та четвертий елементи)
            list.Add(30f); // Має вставитися ПІСЛЯ другого (стане індексом 2)
            list.Add(40f); // Має знову вставитися ПІСЛЯ другого (стане новим індексом 2, а 30f посунеться на індекс 3)

            // Assert (Перевірка)
            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(10f, list[0]);
            Assert.AreEqual(20f, list[1]);
            Assert.AreEqual(40f, list[2], "40f має бути вставлено відразу після другого елемента.");
            Assert.AreEqual(30f, list[3], "30f має бути посунуто на кінець.");
        }

        [TestMethod]
        public void RemoveAt_ValidIndex_RemovesCorrectElement()
        {
            // Arrange
            var list = new FloatSinglyLinkedList();
            list.Add(1f);
            list.Add(2f);
            list.Add(3f); // Вставиться після 2f

            // Act
            list.RemoveAt(1); // Видаляємо елемент '2f' (індекс 1)

            // Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(1f, list[0]);
            Assert.AreEqual(3f, list[1]);
        }

        [TestMethod]
        public void FindFirstLessThan_ElementExists_ReturnsCorrectValue()
        {
            // Arrange
            var list = new FloatSinglyLinkedList();
            list.Add(5f);
            list.Add(10f);
            list.Add(-3f);
            list.Add(8f);

            // Act
            float? result = list.FindFirstLessThan(0f); // Шукаємо перший від'ємний

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(-3f, result.Value);
        }
    }
}
