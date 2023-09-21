using System.Diagnostics;
using ThreadPoolSample;

const int workerCount = 50;
const int sleepTimer = 10000;

List<ThreadPoolWorker> workers = new List<ThreadPoolWorker>(workerCount);

for (int i = 0; i < workerCount; i++)
{
    workers.Add(new ThreadPoolWorker(i));
}

Stopwatch stopwatch = new Stopwatch();
RunDemo(ThreadPoolDemoAsync.Demo, workers, stopwatch, "Async", workerCount);

Console.WriteLine($"Waiting for {sleepTimer} ms before starting next batch.");

RunDemo(ThreadPoolDemoNotAsync.Demo, workers, stopwatch, "Non-Async", workerCount * 2);

Console.WriteLine($"Sleeping for {sleepTimer} ms before closing.");
Thread.Sleep(sleepTimer);


static void RunDemo(Action<List<ThreadPoolWorker>> demoAction,
    List<ThreadPoolWorker> workers,
    Stopwatch stopwatch,
    string batchType,
    int completedCount)
{
    stopwatch.Start();
    demoAction.Invoke(workers);
    while (ThreadPool.CompletedWorkItemCount < completedCount)
    {
        // Intentionally left empty.
    }
    stopwatch.Stop();
    Console.WriteLine($"Time lapsed for {batchType} Batch is: {stopwatch.ElapsedMilliseconds} ms");

    stopwatch.Reset();
}