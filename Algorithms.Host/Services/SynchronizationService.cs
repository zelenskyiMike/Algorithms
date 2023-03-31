namespace Algorithms.Host.Services
{
	public class SynchronizationService
	{
		static object lockObject = new();

		const string semaphoreName = "SemaphoreDemo";
		static Semaphore semaphore = new Semaphore(2, 3, semaphoreName);

		public void LockPrimitive()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section \n");

			lock (lockObject) 
			{
				WorkMock();
			}

			Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
		}

		public void MonitorPrimitive() 
		{
			Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section \n");

			Monitor.Enter(lockObject);

			WorkMock();

			Monitor.Exit(lockObject);
			Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
		}

		public void MutexPrimitive()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section \n");

			using (Mutex mutex = new(false, "MutexDemo"))
			{
				//Checking if Other External Thread is Running
				if (!mutex.WaitOne(5000, false))
				{
					Console.WriteLine("An Instance of the Application is Already Running");
					Console.ReadKey();
					return;
				}
				Console.WriteLine($"Application Is Running by {Thread.CurrentThread.Name}.......");
				Console.ReadKey();
			}
			Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
		}

		public void SemaphorePrimitive()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section \n");

			try
			{
				//Try to Open the Semaphore if Exists, if not throw an exception
				semaphore = Semaphore.OpenExisting(semaphoreName);
			}
			catch (Exception Ex)
			{
				//If Semaphore not Exists, create a semaphore instance
				//Here Maximum 2 external threads can access the code at the same time
				semaphore = new Semaphore(2, 2, semaphoreName);
			}
			Console.WriteLine($"External Thread {Thread.CurrentThread.Name}  Trying to Acquiring");
			semaphore.WaitOne();
			//This section can be access by maximum two external threads: Start
			Console.WriteLine($"External Thread {Thread.CurrentThread.Name} Acquired");

			Thread.Sleep(500);

			//This section can be access by maximum two external threads: End
			semaphore.Release();
		}

		private void WorkMock()
		{
			Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section\n");

			for (int i = 0; i <= 5; i++)
			{
				Thread.Sleep(500);
				Console.Write(i + " ");
			}

			Console.WriteLine();
		}
	}
}
