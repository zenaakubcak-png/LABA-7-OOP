using System;
using System.Collections;
using System.Collections.Generic;

namespace Yakubchak_IP55_Lab7.DataStructures
{
    /// <summary>
    /// Вузол односпрямованого зв'язного списку.
    /// </summary>
    internal class Node
    {
        /// <summary>
        /// Дані вузла.
        /// </summary>
        public float Data { get; set; }

        /// <summary>
        /// Посилання на наступний вузол.
        /// </summary>
        public Node Next { get; set; }

        /// <summary>
        /// Ініціалізує новий екземпляр класу Node.
        /// </summary>
        /// <param name="data">Значення типу float.</param>
        public Node(float data)
        {
            Data = data;
            Next = null;
        }
    }

    /// <summary>
    /// Власна структура даних: Односпрямований список для типу float.
    /// Спосіб додавання: Включення після другого елементу списку.
    /// </summary>
    public class FloatSinglyLinkedList : IEnumerable<float>
    {
        private Node _head;

        /// <summary>
        /// Кількість елементів у списку.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Індексатор для доступу до елементів на читання за індексом.
        /// </summary>
        /// <param name="index">Індекс елемента (починається з 0).</param>
        /// <returns>Значення елемента.</returns>
        /// <exception cref="IndexOutOfRangeException">Викидається, якщо індекс виходить за межі списку.</exception>
        public float this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException("Індекс поза межами списку.");

                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.Data;
            }
        }

        /// <summary>
        /// Додає елемент до списку. Згідно з варіантом: включення після другого елементу списку.
        /// Якщо елементів менше двох, елемент додається в кінець.
        /// </summary>
        /// <param name="data">Дані для додавання.</param>
        public void Add(float data)
        {
            Node newNode = new Node(data);

            if (_head == null)
            {
                _head = newNode;
            }
            else if (_head.Next == null)
            {
                _head.Next = newNode;
            }
            else
            {
                // Вставка строго після другого елемента (_head.Next)
                Node secondNode = _head.Next;
                newNode.Next = secondNode.Next;
                secondNode.Next = newNode;
            }
            Count++;
        }

        /// <summary>
        /// Видаляє елемент за вказаним індексом.
        /// </summary>
        /// <param name="index">Індекс елемента для видалення.</param>
        /// <exception cref="IndexOutOfRangeException">Викидається, якщо індекс недійсний.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Індекс поза межами списку.");

            if (index == 0)
            {
                _head = _head.Next;
            }
            else
            {
                Node current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
            }
            Count--;
        }

        /// <summary>
        /// 1. Знаходить перший елемент, який менший за вказане порогове значення.
        /// </summary>
        /// <param name="threshold">Порогове значення (наприклад, 0 для пошуку від'ємних).</param>
        /// <returns>Значення елемента або null, якщо не знайдено.</returns>
        public float? FindFirstLessThan(float threshold)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data < threshold)
                    return current.Data;
                current = current.Next;
            }
            return null;
        }

        /// <summary>
        /// 2. Знаходить суму елементів, більших за середнє значення списку.
        /// </summary>
        /// <returns>Сума елементів.</returns>
        public float SumGreaterThanAverage()
        {
            if (Count == 0) return 0;

            float sum = 0;
            Node current = _head;
            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }

            float average = sum / Count;
            float targetSum = 0;

            current = _head;
            while (current != null)
            {
                if (current.Data > average)
                    targetSum += current.Data;
                current = current.Next;
            }

            return targetSum;
        }

        /// <summary>
        /// 3. Отримує новий список зі значень елементів, більших за вказане значення.
        /// </summary>
        /// <param name="threshold">Порогове значення (наприклад, 0 для пошуку позитивних).</param>
        /// <returns>Новий екземпляр FloatSinglyLinkedList.</returns>
        public FloatSinglyLinkedList GetElementsGreaterThan(float threshold)
        {
            FloatSinglyLinkedList newList = new FloatSinglyLinkedList();
            Node current = _head;
            while (current != null)
            {
                if (current.Data > threshold)
                {
                    // Для нового списку використовуємо стандартне додавання в кінець
                    // щоб зберегти порядок позитивних елементів (обхідний шлях для специфіки Add)
                    newList.AppendToEnd(current.Data);
                }
                current = current.Next;
            }
            return newList;
        }

        /// <summary>
        /// Допоміжний метод для додавання в кінець (використовується при генерації нового списку).
        /// </summary>
        private void AppendToEnd(float data)
        {
            Node newNode = new Node(data);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }

        /// <summary>
        /// 4. Видаляє всі елементи, які менші за вказане значення.
        /// </summary>
        /// <param name="threshold">Порогове значення (наприклад, 0 для видалення від'ємних).</param>
        public void RemoveAllLessThan(float threshold)
        {
            // Видалення з голови, якщо перші елементи підпадають під умову
            while (_head != null && _head.Data < threshold)
            {
                _head = _head.Next;
                Count--;
            }

            if (_head == null) return;

            Node current = _head;
            while (current.Next != null)
            {
                if (current.Next.Data < threshold)
                {
                    current.Next = current.Next.Next; // Пропускаємо вузол, тим самим видаляючи його
                    Count--;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        /// <summary>
        /// Повертає перелічувач, який здійснює ітерацію по колекції.
        /// </summary>
        public IEnumerator<float> GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

