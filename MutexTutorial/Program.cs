int _count = 0;
Mutex lockMutex = new Mutex(); // lokal, prozessintern (wenn ich keinen Namen mitgebe) => also wie Lock

#region MutexAlsLock
lockMutex.WaitOne(); // betritt kritischen Abschnitt
// Immer mit try, dort passiert der Zugriff
try
{
    _count++;
}
finally
{
    lockMutex.ReleaseMutex(); // Wieder Freigeben
}

#endregion

#region propper Mutex
// Wenn true, setzt er den Mutex SOFORT
// Wenn name, wird der Mutex Gesetzt => Es bedeutet es ist nur für meinen User gelocked
// Wenn man "Global\\" Schreibt gilt der Lock für jeden User.
// Mit out Created new kann man sicherstellen dass es nur einmal läuft. 
//  Wenn es einen neuen Mutex erstellt ist es true, wenn ein anderer Prozess auch einen erstellen will, ist es false
bool createdNew = false;
using (Mutex mutex = new Mutex(false, "Global\\MyMutex", out createdNew))
{
    Console.WriteLine("Warte auf einen mutex...");
    if (mutex.WaitOne(TimeSpan.FromSeconds(5.0))) //Hier wird der Mutex gesetzt und wenn er gesetzt wird => True; wenn schon gesperrt => false?
    //Wenn er innerhalb der 5s den Mutex nicht bekommt wird es false => Er springt ins else
    {
        try
        {
            // Kritischer Bereich
            Console.WriteLine("Wrote new file...");
            Thread.Sleep(10000);
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }
    else
    {
        Console.WriteLine("Konnte Mutex nicht erlangen...");
        Thread.Sleep(3000);
    }
}

#endregion