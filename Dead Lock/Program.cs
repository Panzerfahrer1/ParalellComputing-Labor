// Deadlock Simulation
object lockA = new object();
object lockB = new object();

Thread thread1 = new Thread(() =>
{
    //Thread 1 Locks A
    lock (lockA)
    {
        Thread.Sleep(1000);
        // While T1 does some work, Thread 2 starts.
        // Since T2 locks B, T1 Cant continute
        // And since T1 looks A, T2 cant continute => deadlock
        // To solve this we always should have the same order of locks (A, B, C ,....)
        lock (lockB)
        {
            Console.WriteLine("Thread 1 finished ...");
        }
    }
});

Thread thread2 = new Thread(() =>
{
    lock (lockB)
    {
        Thread.Sleep(1000);
        lock (lockA)
        {
            Console.WriteLine("Thread 2 finished ...");
        }
    }
});

thread1.Start();
thread2.Start();

thread2.Join();
thread1.Join();