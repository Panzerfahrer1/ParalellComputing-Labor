using System.Data.SqlTypes;

namespace ProducerAndConsumerSemaphore
{
    internal class Program
    {
        static Queue<int> buffer = new Queue<int>();
        static SemaphoreSlim items = new SemaphoreSlim(0);
        static SemaphoreSlim spaces = new SemaphoreSlim(5);

        static readonly Lock @lock = new Lock();

        static int id = 0;  

        static void Main(string[] args)
        {

            Thread producer = new Thread(Producer);
            Thread consumer = new Thread(Consumer);

            producer.Start();
            consumer.Start();

            producer.Join();
            consumer.Join();
        }

        static void Producer()
        {
            for (int i = 0; i < 20; i++)
            {
                spaces.Wait(); // producer waits until space is free
                lock (@lock)
                {
                    buffer.Enqueue(i);
                    Console.WriteLine($"Produzent erzeugt: {i}");
                }
                items.Release();
                Thread.Sleep(100);
            }
        }

        static void Consumer()
        {
            for (int i = 0; i < 20; i++)
            {
                items.Wait();
                lock (@lock)
                {
                    int item = buffer.Dequeue();
                    Console.WriteLine($"Deqeued {item}");
                }
                spaces.Release();
                Thread.Sleep(1000);
            }
        }
    }
}
