using System.ComponentModel;

int counter = 0;
object lockObj = new object();

Thread thread1 = new Thread(DoWork);
Thread thread2 = new Thread(DoWork);

thread1.Start();
thread2.Start();

thread1.Join();
thread2.Join();

Console.WriteLine("Erwartet: 2.000.000");
Console.WriteLine("Real:");
Console.WriteLine(counter.ToString("N0"));

void DoWork()
{
    for(int i = 0; i < 1_000_000; i++)
    {
        //Interlocked.Increment(ref counter);
        lock(lockObj)
        {
            counter++;
        }
    }
}