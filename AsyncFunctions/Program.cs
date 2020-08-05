using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            for (ulong i = 0; i < (ulong)lNumbers.Length; i++)
                lNumbers[i] = i + 1;

            
            SyncOperations(lComputeSync, lNumbers, lStopwatch);
            AsyncOperationWhenAny(lComputeAsync, lNumbers, lStopwatch, lWaitTime);
            ParallelOperations(lComputeSync, lNumbers, lStopwatch);
            AsyncOperations(lComputeAsync, lNumbers, lStopwatch, lWaitTime);
        }

        private static void SyncOperations(ComputeSync lComputeSync, ulong[] lNumbers, Stopwatch lStopwatch)
        {
            lStopwatch.Start();
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
            Task lSecond = Task.Run(
                async () =>
                {
                    IEnumerable<Task<ulong>> lFibonacci = from num in lNumbers
                                                          select lComputeAsync.GetFibonacciAsync(num);
                    List<Task<ulong>> lFibonaccies = lFibonacci.ToList();

                    while (lFibonaccies.Count > 0)
                    {
                        if (tokenSource.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("Cancellation requested");
                            tokenSource.Token.ThrowIfCancellationRequested();
                        }
                        Task<ulong> lCompleted = await Task.WhenAny(lFibonaccies);
                        lFibonaccies.Remove(lCompleted);

                        Task<ulong> lResult = await lCompleted
                          .ContinueWith(x => lComputeAsync.GetFactorialAsync(x.Result));
                        Console.WriteLine(lResult.Result);
                    }
                }, tokenSource.Token);
            try
            {
                lSecond.Wait(tokenSource.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine($"Async when any ops: {lStopwatch.ElapsedMilliseconds}");
            }
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
