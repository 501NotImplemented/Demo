using System;
using System.Threading;

namespace Demo.Core
{
	public class Wait
	{
		private static readonly int DefaultTimeout = 20;

		private static readonly TimeSpan SleepTimeout = TimeSpan.FromMilliseconds(150);

		/// <summary>
		/// Wait using Thread.Sleep
		/// </summary>
		/// <param name="timeout">Timeout in TimeSpan format</param>
		public static void For(TimeSpan timeout)
		{
			Thread.Sleep(timeout);
		}

		/// <summary>
		/// Wait for a condition with given timeout
		/// </summary>
		/// <param name="action">The condition to be met</param>
		/// <param name="timeout">Timeout, in TimeSpan format. Default to 20 seconds.</param>
		public static void Until(Func<bool> action, TimeSpan? timeout = null)
		{
			if (timeout == null)
			{
				timeout = TimeSpan.FromSeconds(DefaultTimeout);
			}

			var timeoutDate = DateTime.Now.Add(timeout.Value);
			bool isActionCompleted;

			do
			{
				isActionCompleted = action();

				if (!isActionCompleted)
				{
					For(SleepTimeout);
				}
			}
			while (!isActionCompleted && DateTime.Now < timeoutDate);

			if (isActionCompleted == false)
			{
				var errorMessage = $"Wait for {action.Method.Name} exited by timeout of {timeout}";

				throw new TimeoutException(errorMessage);
			}
		}
	}
}
