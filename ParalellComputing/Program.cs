Thread thread = new Thread(PrintNumbers);
Thread thread1 = new Thread(PrintNumbers);


// So kann man auch Parameter übergeben
// Thread thread2 = new Thread(() => PrintNumbers("Test Übergabe", 1));

thread1.Name = "Thread 2";
thread.Name = "Thread 1";

thread.IsBackground = false;
thread1.IsBackground = false;

Console.WriteLine(thread.ThreadState);

thread1.Start();
thread.Start();

Console.WriteLine(thread.ThreadState);

thread.Join();
thread1.Join();

Console.WriteLine("Main Thread...");

Console.WriteLine(thread.ThreadState);
static void PrintNumbers()
{
    for(int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Hallo {Thread.CurrentThread.Name} #{i}");

        Thread.Sleep(100);
    }
}