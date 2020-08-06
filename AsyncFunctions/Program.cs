using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeAsync lComputeAsync = new ComputeAsync();
            ComputeSync lComputeSync = new ComputeSync();
            ulong[] lNumbers = new ulong[10];
            int lWaitTime = 100000000;
            Stopwatch lStopwatch = new Stopwatch();

            for (int i = lNumbers.Length - 1; i >= 0; i--)
                lNumbers[i] = (ulong)i + 1;

            SyncOperations(lComputeSync, lNumbers, lStopwatch);
            AsyncOperations(lComputeAsync, lNumbers, lStopwatch, lWaitTime);
            AsyncOperationWhenAny(lComputeAsync, lNumbers, lStopwatch, lWaitTime);
            ParallelOperations(lComputeSync, lNumbers, lStopwatch);
        }

        private static void SyncOperations(ComputeSync lComputeSync, ulong[] lNumbers, Stopwatch lStopwatch)
        {
            lStopwatch.Restart();
            foreach (ulong number in lNumbers)
            {
                Console.WriteLine(lComputeSync.GetFactorial(lComputeSync.GetFibonacci(number)));
            }
            Console.WriteLine($"Sync ops: {lStopwatch.ElapsedMilliseconds}");
        }

        private static void ParallelOperations(ComputeSync lComputeSync, ulong[] lNumbers, Stopwatch lStopwatch)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource(200);
            lStopwatch.Restart();

            Parallel.ForEach(lNumbers, number => Console.WriteLine(lComputeSync.GetFactorial(lComputeSync.GetFibonacci(number))));
            Console.WriteLine($"Parallel ops: {lStopwatch.ElapsedMilliseconds}");
        }

        private static void AsyncOperationWhenAny(ComputeAsync lComputeAsync, ulong[] lNumbers, Stopwatch lStopwatch, int waitTime)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource(waitTime);
            lStopwatch.Restart();
            var lAntecedents = new List<Task<Task<ulong>>>();
            foreach (ulong number in lNumbers)
            {
                lAntecedents.Add(Task.Run(() => lComputeAsync.GetFibonacciAsync(number)
                                                                       .ContinueWith(x => lComputeAsync.GetFactorialAsync(x.Result)), tokenSource.Token));
            }
            while (lAntecedents.Count > 0)
            {
                Task<Task<ulong>> lCompleted = Task.WhenAny(lAntecedents).Result;
                lAntecedents.Remove(lCompleted);
                Console.WriteLine(lCompleted.Result.Result);
            }
            Console.WriteLine($"Async when any ops: {lStopwatch.ElapsedMilliseconds}");
        }

        private static void AsyncOperations(ComputeAsync lComputeAsync, ulong[] lNumbers, Stopwatch lStopwatch, int waitTime)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource(waitTime);
            lStopwatch.Restart();

            Task lFirst = Task.Run(
                              async () =>
                              {
                                  foreach (ulong number in lNumbers)
                                  {
                                      if (tokenSource.Token.IsCancellationRequested)
                                      {
                                          Console.WriteLine("Cancellation requested");
                                          tokenSource.Token.ThrowIfCancellationRequested();
                                      }
                                      Task<ulong> lCompleted = await lComputeAsync.GetFibonacciAsync(number)
                                                                                .ContinueWith(x => lComputeAsync.GetFactorialAsync(x.Result));
                                      Console.WriteLine(lCompleted.Result);
                                  }
                              }, tokenSource.Token);
            try
            {
                lFirst.Wait(tokenSource.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine($"Async ops: {lStopwatch.ElapsedMilliseconds}");
            }
        }
    }
}
