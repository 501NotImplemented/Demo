using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Core;
using OpenQA.Selenium;
using PhpTravels.Ui.Entities;

namespace PhpTravels.Ui.Components.Home
{
	public class FeaturedHotelsSection
	{
		internal FeaturedHotelsSection()
		{
		}

		public Hotel Cheapest => GetHotels().OrderByDescending(h => h.Price).Last();

		private List<IWebElement> GetHotelWebElements()
		{
			var hotels = Browser.Instance.FindElements(By.XPath("//div[@class='mb-40']//div[@id='MenuHorizon28_01']//div[@class='product-grid-item']"));
			return hotels.ToList();
		}

		private List<Hotel> GetHotels()
		{
			var hotelWebElements = GetHotelWebElements();
			var hotels = new List<Hotel>();

			Parallel.ForEach(hotelWebElements, webElement =>
												{
													var hotel = GetHotel(webElement);
													hotels.Add(hotel);
												});

			return hotels;
		}

		private static Hotel GetHotel(IWebElement webElement)
		{
			var receivedText = webElement.Text.Split('\r', '\n').Where(x => !string.IsNullOrEmpty(x)).ToList();
			var currencyChar = "$";
			var priceIndex = receivedText.Count - 2;
			var titleIndex = 1;

			var trimmedPrice = receivedText[priceIndex].Replace(currencyChar, string.Empty);

			var hotel = new Hotel
			{
				Price = Convert.ToDouble(trimmedPrice),
				Title = receivedText[titleIndex]
			};

			return hotel;
		}
	}
}
