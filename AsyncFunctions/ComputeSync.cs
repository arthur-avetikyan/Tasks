using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncFunctions
{
    public class ComputeSync
    {
        public ulong GetFactorial(ulong number)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Restart();
            //while (stopwatch.ElapsedMilliseconds == 100) { }

            return number == 1 ? 1 : number * GetFactorial(number - 1);
        }

        public ulong GetFibonacci(ulong number)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Restart();
            //while (stopwatch.ElapsedMilliseconds == 100) { }

            return (number == 0) || (number == 1) ? number : GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
