namespace ThreadPoolSample;

public sealed class ThreadPoolWorker
{
    private readonly int _id;
    
    public ThreadPoolWorker(int id)
    {
        _id = id;
    }

    public string DoWork()
    {
        Task.Delay(TimeSpan.FromSeconds(2)).GetAwaiter().GetResult();

        return $"Completed {nameof(DoWork)} Processing for Task Id: {_id}";
    }
    
    public async Task<string> DoWorkAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(2));

        return $"Completed {nameof(DoWorkAsync)} Processing for Task Id: {_id}";
    }
}