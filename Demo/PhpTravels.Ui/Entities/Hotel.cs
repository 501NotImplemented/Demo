﻿namespace PhpTravels.Ui.Entities
{
	public class Hotel
	{
		public double Price { get; set; }

		public string Title { get; set; }

		public override string ToString()
		{
			return $"{nameof(Title)}: '{Title}', {nameof(Price)}: '{Price}'";
		}
	}
}
