using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Algorithms
{
    public class TaskFun
    {
        public static async Task MainAsync()
        {
            var input = Enumerable.Range(0, 10).ToArray();
            var manualResetEventSlim = new ManualResetEventSlim(false);

            var task1 = new Task((obj) =>
            {
                if (obj is int[] numbers)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.WriteLine($"Task 1: {numbers[i]}");
                        if (i == 2) manualResetEventSlim.Wait();
                    }
                }
            }, input, TaskCreationOptions.LongRunning);

            var task2 = new Task((obj) =>
            {
                if (obj is int[] numbers)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.WriteLine($"Task 2: {numbers[i]}");
                        if (i == 2)
                        {
                            manualResetEventSlim.Wait();
                        }
                    }
                }
            }, input, TaskCreationOptions.LongRunning);

            var task3 = new Task((obj) =>
            {
                if (obj is int[] numbers)
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        Console.WriteLine($"Task 3: {numbers[i]}");
                        if (i == 5)
                        {
                            Console.WriteLine("Task 3: Set event");
                            manualResetEventSlim.Set();
                        }
                    }
                }
            }, input, TaskCreationOptions.LongRunning);

            task1.Start();
            task2.Start();
            task3.Start();

            await Task.WhenAll(task1, task2, task3);
        }
    }
}
