using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace WebCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            new JsonRunkeeperConverter().ConvertFromJson();
        }

        public static void GetData()
        {
            //string url = "https://runkeeper.com/activitiesByDateRange?userName=mroczekdawid&startDate=April-01-2020";
            string urlPrefix = "https://runkeeper.com/activitiesByDateRange?userName=mroczekdawid&startDate=";
            var startDate = new DateTime(2012, 3, 1);

            var urls = GetUrls(urlPrefix, startDate);
            var data = new List<string>();
            
            foreach(var url in urls)
            {
                data.Add(GetData(url));
                Console.WriteLine(url);
                Thread.Sleep(new Random().Next(20, 300));
            }

            Console.WriteLine("Saving to DB");

            new JsonDbConnector().AddToDB(data);

        }

        public static List<string> GetUrls(string prefix, DateTime startDate)
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

        public static string GetData(string requestUrl)
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
