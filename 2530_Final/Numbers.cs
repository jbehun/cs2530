using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2530_Final
{
    class Numbers
    {
        private List<int> numbers;

        public Numbers(List<int> numbers)
        {
            this.numbers = numbers;
        }

        // A)  Create an iterator called DoubleElements.
        //     It should return the double of each element in list numbers 
        public IEnumerable<int> DoubleElements()
        {
            foreach(int num in numbers)
            {
                yield return num * 2;
            }
        }
        
        // B)  Create an iterator called ReverseNumbers
        //     It should return all the elements of the list numbers in reverse order
        public IEnumerable<int> ReversNumbers()
        {
            for(int i = (numbers.Count - 1); i >= 0; i--)
            {
                yield return numbers[i];
            }
        }

        // C)  Create an iterator called ThirdElements. 
        //     It should return every third element of list numbers
        public IEnumerable<int> ThirdElemnts()
        {
            for(int i = 0; i < numbers.Count; i++)
            {
                if(i % 3 == 0)
                {
                    yield return numbers[i];
                }
            }
        }

    }
}
