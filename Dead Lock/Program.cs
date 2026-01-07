// Deadlock Simulation
object lockA = new object();
object lockB = new object();

Thread thread1 = new Thread(() =>
{
    lock (lockA)
    {
        Thread.Sleep(1000);
        lock (lockB)
        {
            Console.WriteLine("Thread 1 acquired both locks.");
        }
    }
});