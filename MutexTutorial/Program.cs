int _count = 0;
Mutex mutex = new Mutex(); // lokal, prozessintern (wenn ich keinen Namen mitgebe) => also wie Lock

mutex.WaitOne(); // betritt kritischen Abschnitt
// Immer mit try, dort passiert der Zugriff
try
{
    _count++;
}
finally
{
    mutex.ReleaseMutex(); // Wieder Freigeben
}