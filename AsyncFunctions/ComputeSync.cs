namespace AsyncFunctions
{
    public class ComputeSync
    {
        public ulong GetFactorial(ulong number)
        {
            return number == 1 ? 1 : number * GetFactorial(number - 1);
        }

        public ulong GetFibonacci(ulong number)
        {
            return (number == 0) || (number == 1) ? number : GetFibonacci(number - 1) + GetFibonacci(number - 2);
        }
    }
}
