using DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace WebCrawler
{
    public class RunkeeperWebsite
    {
        public List<string> GetDataFromRunkeeperWebsite(string login, DateTime since)
        {
            //string url = "https://runkeeper.com/activitiesByDateRange?userName=mroczekdawid&startDate=April-01-2020";

            string urlPrefix = $"https://runkeeper.com/activitiesByDateRange?userName={login}&startDate=";
            if (since == DateTime.MinValue)
                throw new Exception("Too long");

            var urls = GenerateMonthUrls(urlPrefix, since);
            var data = new List<string>();

            foreach (var url in urls)
            {
                data.Add(GetJsonDataFromWebsite(url));
                Console.WriteLine(url);
                Thread.Sleep(new Random().Next(5, 30));
            }

            return data;

        }

        private List<string> GenerateMonthUrls(string prefix, DateTime startDate)
        {
            List<string> urls = new List<string>();

            DateTime date = new DateTime(startDate.Year, startDate.Month, 1);

            while (date < DateTime.Now)
            {
                urls.Add($"{prefix}{DateTimeFormatInfo.InvariantInfo.MonthNames[date.Month - 1]}-01-{date.Year}");
                date = date.AddMonths(1);
            }

            return urls;
        }

        private string GetJsonDataFromWebsite(string requestUrl)
        {
            var request = HttpWebRequest.Create(requestUrl);

            request.Method = "GET";

            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            var streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }
    }
}
