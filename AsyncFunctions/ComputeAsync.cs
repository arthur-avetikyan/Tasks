using System.Threading.Tasks;

namespace AsyncFunctions
{
    public class ComputeAsync
    {
        public async Task<ulong> GetFactorialAsync(ulong number)
        {
            //await Task.Delay(100);
            return number == 1 ? 1 : number * await GetFactorialAsync(number - 1);
        }

        public async Task<ulong> GetFibonacciAsync(ulong number)
        {
           // await Task.Delay(100);
            return (number == 0) || (number == 1) ? number : await GetFibonacciAsync(number - 1) + await GetFibonacciAsync(number - 2);
        }
    }
}
