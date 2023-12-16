class Program
{
	static Mutex mutex = new Mutex();
	static Semaphore semaphore = new Semaphore(2, 4);

	public static void SomeFunction()
	{
		semaphore.WaitOne();
		Console.WriteLine("Entering function");
		Thread.Sleep(1000);
		//mutex.WaitOne(2000);

		Console.WriteLine("Making some exclusive job");
		Thread.Sleep(1000);

		//mutex.ReleaseMutex();

		Console.WriteLine("Leaving function");
		semaphore.Release();
	}

	static void Main(string[] args)
	{
		for (int i = 0; i < 5; i++)
		{
			Thread thread = new Thread(SomeFunction);
			thread.Start();
		}
	}
}