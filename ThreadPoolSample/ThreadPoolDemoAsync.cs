namespace ThreadPoolSample;

public static class ThreadPoolDemoAsync
{
    public static void Demo(List<ThreadPoolWorker> workers)
    {
        workers.ForEach(w => ThreadPool.QueueUserWorkItem(async x =>
        {
            await ThreadPoolWorkerAction(w);
        }));
    }
    
    private static async Task ThreadPoolWorkerAction(ThreadPoolWorker threadPoolWorker)
    {
        string result = await threadPoolWorker.DoWorkAsync();
        Console.WriteLine(result);
    }
}