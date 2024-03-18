using System.Collections;

namespace Billboard.Models
{
	public class WeekCalculator
	{

		//Method that returns the dates of the current week
		public ArrayList GetThisWeeksDates()
		{
			string dayOfTheWeek = DateTime.Today.DayOfWeek.ToString();
			DateTime todaysDate = DateTime.Today.Date;
			ArrayList week = new ArrayList();

			if (dayOfTheWeek == "Monday")
			{
				string tuesday = todaysDate.AddDays(1).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(2).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(3).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(4).ToString("yyyy-MM-dd");
				week.Add(todaysDate.ToString("yyyy-MM-dd"));
				week.Add(tuesday);
				week.Add(wednesday);
				week.Add(thursday);
				week.Add(friday);

			}
			else if (dayOfTheWeek == "Tuesday")
			{
				string monday = todaysDate.AddDays(-1).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(1).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(2).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(3).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(todaysDate.ToString("yyyy-MM-dd"));
				week.Add(wednesday);
				week.Add(thursday);
				week.Add(friday);
			}
			else if (dayOfTheWeek == "Wednesday")
			{
				string monday = todaysDate.AddDays(-2).ToString("yyyy-MM-dd");
				string tuesday = todaysDate.AddDays(-1).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(1).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(2).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(tuesday);
				week.Add(todaysDate.ToString("yyyy-MM-dd"));
				week.Add(thursday);
				week.Add(friday);
			}
			else if (dayOfTheWeek == "Thursday")
			{
				string monday = todaysDate.AddDays(-3).ToString("yyyy-MM-dd");
				string tuesday = todaysDate.AddDays(-2).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(-1).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(1).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(tuesday);
				week.Add(wednesday);
				week.Add(todaysDate.ToString("yyyy-MM-dd"));
				week.Add(friday);
			}
			else if (dayOfTheWeek == "Friday")
			{
				string monday = todaysDate.AddDays(-4).ToString("yyyy-MM-dd");
				string tuesday = todaysDate.AddDays(-3).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(-2).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(-1).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(tuesday);
				week.Add(wednesday);
				week.Add(thursday);
				week.Add(todaysDate.ToString("yyyy-MM-dd"));
			}
			else if (dayOfTheWeek == "Saturday")
			{
				string monday = todaysDate.AddDays(-5).ToString("yyyy-MM-dd");
				string tuesday = todaysDate.AddDays(-4).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(-3).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(-2).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(-1).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(tuesday);
				week.Add(wednesday);
				week.Add(thursday);
				week.Add(friday);
			}
			else if (dayOfTheWeek == "Sunday")
			{
				string monday = todaysDate.AddDays(-6).ToString("yyyy-MM-dd");
				string tuesday = todaysDate.AddDays(-5).ToString("yyyy-MM-dd");
				string wednesday = todaysDate.AddDays(-4).ToString("yyyy-MM-dd");
				string thursday = todaysDate.AddDays(-3).ToString("yyyy-MM-dd");
				string friday = todaysDate.AddDays(-2).ToString("yyyy-MM-dd");
				week.Add(monday);
				week.Add(tuesday);
				week.Add(wednesday);
				week.Add(thursday);
				week.Add(friday);
			}

			return week;

		}
	}
}
