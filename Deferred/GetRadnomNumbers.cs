using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deferred
{
    class GetRadnomNumbersGenerated : IEnumerable<int>, IEnumerator<int>
    {
        public int count;
        private int lCounter;
        private int lState;

        public IEnumerator<int> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        object IEnumerator.Current => Current;

        public int Current { get; private set; }

        public bool MoveNext()
        {
            switch (lState)
            {
                case 0:
                    Console.WriteLine("Inside MoveNext() case 0: in GetRadnomNumbersGenerated() class");
                    lCounter = 0;
                    goto case 1;
                case 1:
                    Console.WriteLine("Inside MoveNext() case 1: in GetRadnomNumbersGenerated() class");

                    lState = 1;
                    if (lCounter >= count)
                        return false;
                    Current = Program.rand.Next();
                    lState = 2;
                    return true;
                case 2:
                    Console.WriteLine("Inside MoveNext() case 2: in GetRadnomNumbersGenerated() class");
                    lCounter++;
                    goto case 1;
            }
            return false;
        }

        public void Dispose() { }

        public void Reset() { }
    }
}
