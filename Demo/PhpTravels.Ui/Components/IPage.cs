﻿namespace PhpTravels.Ui.Components
{
	public interface IPage
	{
		string Url { get; }

		bool IsOpened { get; }

		void WaitToBeOpened();

		void Open();
	}
}
