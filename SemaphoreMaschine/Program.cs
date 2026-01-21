using System.Reflection;
SemaphoreSlim sm = new SemaphoreSlim(2);
Random rnd = new Random();

Thread t1 = new Thread(DoSomething);
Thread t2 = new Thread(DoSomething);
Thread t3 = new Thread(DoSomething);
Thread t4 = new Thread(DoSomething);
Thread t5 = new Thread(DoSomething);
Thread t6 = new Thread(DoSomething);
Thread t7 = new Thread(DoSomething);
Thread t8 = new Thread(DoSomething);

t1.Start();
t2.Start();
t3.Start();
t4.Start();
t5.Start();
t6.Start();
t7.Start();
t8.Start();

while (System.Diagnostics.Process.GetCurrentProcess().Threads.Count > 0)
{
    Console.WriteLine(System.Diagnostics.Process.GetCurrentProcess().Threads.Count);
}

t1.Join();
t2.Join();
t3.Join();
t4.Join();
t5.Join();
t6.Join();
t7.Join();
t8.Join();

void DoSomething()
{
    int[] delay = new int[3] { 1000, 2000, 3000 };
    sm.Wait();
    System.Threading.Thread.Sleep(delay[rnd.Next(3)]);
    sm.Release();
}