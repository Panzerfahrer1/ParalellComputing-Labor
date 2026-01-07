Thread ping = new Thread(() => WritePingPong("Ping", 100));
Thread pong = new Thread(() => WritePingPong("Pong", 150));

ping.Name = "Ping Thread";
pong.Name = "Pong Thread";

ping.IsBackground = false;
pong.IsBackground = false;

Console.WriteLine(ping.ThreadState);
Console.WriteLine(pong.ThreadState);

ping.Start();
pong.Start();

Console.WriteLine(ping.ThreadState);
Console.WriteLine(pong.ThreadState);

ping.Join();
pong.Join();

Console.WriteLine(ping.ThreadState);
Console.WriteLine(pong.ThreadState);

Console.WriteLine("All threads Finished");
void WritePingPong(string word, int sleepTime = 0)
{
    for (int i = 0; i < 50; i++)
    {
        Console.WriteLine(word);
        Thread.Sleep(sleepTime);
    }
}