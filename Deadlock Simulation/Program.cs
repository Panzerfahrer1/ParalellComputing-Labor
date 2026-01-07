List<int> from = new(10000);
List<int> to = new(10000);

for(int i = 0; i < 10000; i++)
{
    from.Add(i);
}

object lockA = new object();
object lockB = new object();

Thread thread1 = new(() => CopyReverse(from, to));
Thread thread2 = new(() => Copy(from, to));

thread1.Start();
thread2.Start();
thread1.Join();
thread2.Join();

void CopyReverse(List<int> from, List<int> to)
{
    lock (lockA)
    {
        lock (lockB)
        {
            to.Clear();
            for(int i = 0; i < from.Count; i++)
            {
                to.Add(from[from.Count - 1 - i]);
            }

            Console.WriteLine("Fertig");

            Thread.Sleep(1000);
        }
    }

    CopyReverse(from, to);
}

void Copy(List<int> from, List<int> to)
{
    lock (lockA)
    {
        lock (lockB)
        {
            to.Clear();
            for (int i = 0; i < from.Count; i++)
            {
                to.Add(from[i]);
            }

            Console.WriteLine("Fertig");

            Thread.Sleep(1000);
        }
    }

    CopyReverse(from, to);
}