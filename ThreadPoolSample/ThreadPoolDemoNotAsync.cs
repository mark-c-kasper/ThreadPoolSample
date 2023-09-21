namespace ThreadPoolSample;

public static class ThreadPoolDemoNotAsync
{
    public static void Demo(List<ThreadPoolWorker> workers)
    {
        workers.ForEach(w => ThreadPool.QueueUserWorkItem(ThreadPoolWorkerAction, w, false));
    }
    
    private static void ThreadPoolWorkerAction(ThreadPoolWorker threadPoolWorker)
    {
        string result = threadPoolWorker.DoWork();
        Console.WriteLine(result);
    }
}