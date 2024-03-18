using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft;

namespace Billboard.Models
{
	public class DAL : IDisposable
	{

		void IDisposable.Dispose()
		{

		}
		
		String user = "a7abb391415eb95037953aa831bc39be";
		String pass = "8637e9cfc4d11d26755cd7f7ee39f2f4";

		public async Task<NotificationModel.NotificationContainer> GetJson()
		{
			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Authorization =
			new AuthenticationHeaderValue(
			"Basic", Convert.ToBase64String(
			System.Text.Encoding.ASCII.GetBytes(
			$"{user}:{pass}")));
			var result = await client.GetAsync("https://api.sympahr.net/api/HiQSympaNotificationsStudentGroup");
			var content = result.Content.ReadAsStringAsync().Result;

			var Notifications = Newtonsoft.Json.JsonConvert.DeserializeObject<Billboard.Models.NotificationModel.NotificationContainer>(content);

			return Notifications;


		}

		public async Task<UserModel.Root> GetWeather()
        {
			HttpClient client = new HttpClient();
			var result = await client.GetAsync("https://api.openweathermap.org/data/2.5/onecall?lat=55.60638&lon=12.99395&exclude=minutely,hourly,alerts&units=metric&appid=e1ced796fa56ca948b91f0d7916b921f");
			var content = result.Content.ReadAsStringAsync().Result;

			var Notifications = Newtonsoft.Json.JsonConvert.DeserializeObject<UserModel.Root>(content);

			return Notifications;

		}



	}
   

}



