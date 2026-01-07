Dictionary<int, int> dict = new Dictionary<int, int>(10000);

int count = 0;
object obj = new object();

Random random = new Random();

Thread thread = new Thread(AppendDict);
Thread thread1 = new Thread(AppendDict);

thread.Start();
thread1.Start();

thread.Join();
thread1.Join();

Console.WriteLine(count);

void AppendDict()
{
    for (int i = 0; i < 1000; i++)
    {
        int randomNumber = Random.Shared.Next(0, 9999);

        lock (obj)
        {
            try
            {
                if (dict.ContainsKey(randomNumber))
                {
                    dict.Remove(randomNumber);
                }
                else
                {
                    dict.Add(randomNumber, randomNumber);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref count);
            }
        }
    }
}