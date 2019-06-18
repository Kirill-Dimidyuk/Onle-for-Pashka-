using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStack
{
    public class Stack<T>:IEnumerable,IEnumerable<T>
    {
        private T[] items; // элементы стека

        private int capacity;

        private const int defaultCapacity = 4;
        public int Count { get; private set; }

        public Stack() : this(defaultCapacity)
        {
            this.capacity = 0;
            this.items = new T[defaultCapacity];
        }


        public Stack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException(nameof(capacity));
            }

            this.capacity = capacity;
            items = new T[capacity];
        }
        
        
        // пуст ли стек
        public bool IsEmpty
        {
            get { return Count == 0; }
        }


        // добвление элемента
        public void Push(T item)
        {
            if (capacity == Count)
            {
                capacity *= 2;

                T[] tempArray = items;

                Array.Resize(ref items, capacity);
                Array.Copy(tempArray, items, Count);
            }

            items[Count++] = item;

            if (capacity > Count)
            {
                capacity = Count;
                T[] tempArray = items;
                Array.Resize(ref items, capacity);
                Array.Copy(tempArray, items, Count);
            }
        }
        // извлечение элемента

        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            T item = items[--Count];
            items[Count] = default(T); // сбрасываем ссылку
            return item;
        }

        // возвращаем элемент из верхушки стека
        public T Peek()
        {
            return items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            yield return items[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
