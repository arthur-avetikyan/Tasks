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
        static Random rand = new Random();
        public int _count;
        private int _counter;
        private int _state;

        public IEnumerator<int> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        object IEnumerator.Current => Current;

        public int Current { get; private set; }

        public bool MoveNext()
        {
            switch (_state)
            {
                case 0:
                    Console.WriteLine("Inside MoveNext() case 0: in GetRadnomNumbersGenerated() class");
                    _counter = 0;
                    goto case 1;
                case 1:
                    Console.WriteLine("Inside MoveNext() case 1: in GetRadnomNumbersGenerated() class");
                    _state = 1;
                    if (_counter >= _count)
                        return false;
                    Current = rand.Next();
                    _state = 2;
                    return true;
                case 2:
                    Console.WriteLine("Inside MoveNext() case 2: in GetRadnomNumbersGenerated() class");
                    _counter++;
                    goto case 1;
            }
            return false;
        }

        public void Dispose() { }

        public void Reset() { }
    }
}
