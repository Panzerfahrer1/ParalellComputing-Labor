using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net;

Stopwatch sw = Stopwatch.StartNew();

object lock1 = new object();

int counter = 0;

Thread t1 = new Thread(DoWork);
Thread t2 = new Thread(DoWork);

t1.Start();
t2.Start();

t1.Join();
t2.Join();

void DoWork()
{
    int localCounter = 0;

    for (int i = 0; i < 100_000_000; i++)
    {
        localCounter++;
    }

    lock (lock1)
    {
        counter += localCounter;
    }
}

sw.Stop();

Console.WriteLine(sw.ElapsedMilliseconds);
Console.ReadLine();

// Debug (Release hat ähnliche Werte):
// Lock ganze Funktion: 291ms
// Lock nur counter++ : 4860ms
// Lock nur Zuweisung += 94ms