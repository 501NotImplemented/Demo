namespace PhpTravels.Ui.Contracts
{
	public interface IPage
	{
		bool IsOpened { get; }

		string Url { get; }

		void Open();

		void WaitToBeOpened();
	}
}
