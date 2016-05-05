using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp.Module4.Task1
{
    class DynamicArray<E>
    {
        private int size = 0;
        private int modCount = 0;
        private int capacity;

        private const int MAX_ARRAY_SIZE = Int32.MaxValue - 10;

        private Object[] elementData;
        private static readonly Object[] EMPTY_ELEMENTDATA = new Object[]{};


        public DynamicArray(int initialCapacity)
        {
            if (initialCapacity > 0)
            {
                this.elementData = new Object[initialCapacity];
                this.capacity = initialCapacity;
            }
            else if (initialCapacity == 0)
            {
                this.elementData = EMPTY_ELEMENTDATA;
            }
            else
            {
                throw new ArgumentException("Illegal argument");
            }
        }

        public DynamicArray() : this(10)
        {
            
        }

        public Object[] getElementData()
        {
            return elementData;
        }

        public bool add(E e)
        {
            modCount++;
            checkCapacityForCopying(modCount);
            elementData[size++] = e;
            return true;
        }

        public E get(int index)
        {
            rangeCheck(index);
            return (E)elementData[index];
        }


        public Boolean remove(int index)
        {

            if (index >= 0 && index < elementData.Length)
            {
                Object[] copy = new Object[elementData.Length - 1];
                Array.Copy(elementData, 0, copy, 0, index);
                Array.Copy(elementData, index + 1, copy, index, elementData.Length - index - 1);
                elementData = copy;
                capacity--;
                modCount--;
                return true;
            }

            return false;
        }

        private void rangeCheck(int index)
        {
            if (index >= size | index < 0)
                throw new IndexOutOfRangeException();
        }

        private void checkCapacityForCopying(int modCount)
        {
            if (modCount > capacity && modCount != MAX_ARRAY_SIZE) grow(capacity);
        }

        private void grow(int capacity)
        {
            var elementData = new Object[capacity + 10];
            this.elementData.CopyTo(elementData, 0);
            this.elementData = elementData;
            this.capacity = capacity + 10;
        }

        public override String ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < modCount; i++)
            {
                if (elementData[i] == null)
                {
                    sb.Append("null,");
                    continue;
                }
                if (i + 1 == modCount) { sb.AppendFormat("{0}]", elementData[i].ToString()); }
                else { sb.AppendFormat("{0}, ", elementData[i].ToString()); }
                
            }

            if (modCount == 0) { sb.Append("]"); }
            return sb.ToString();

        }

    }
}
