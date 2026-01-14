SemaphoreSlim _sem = new SemaphoreSlim(3); // Capacity of 3

for(int i = 0; i < 5; i++)
{
    new Thread(Enter).Start(i);
}

void Enter(object id)
{
    Console.WriteLine(id + " wants to enter");
    _sem.Wait();
    //critical area
    Console.WriteLine(id + " is in!");
    Thread.Sleep(1000 + (int)id);
    Console.WriteLine(id + " is leaving...");
    _sem.Release();
}