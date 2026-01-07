Thread counter1 = new Thread(() => Countdown());
Thread counter2 = new Thread(() => Countdown());
Thread counter3 = new Thread(() => Countdown());

counter1.Name = "Counter 1";
counter2.Name = "Counter 2";
counter3.Name = "Counter 3";

counter1.Start();
counter2.Start();
counter3.Start();

counter1.Join();
counter2.Join();
counter3.Join();

Console.WriteLine("Race finished (You're winner)");

void Countdown(int start = 50)
{
    for(int i = start; i >= 1; i--)
    {
        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
    }
}