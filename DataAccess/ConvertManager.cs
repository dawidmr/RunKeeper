using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading;
using DataAccess.RunkeeperDB;

namespace DataAccess
{
    public class ConvertManager
    {
        public List<Data> ConvertFromJsonDbToRunkeeperDB(List<JsonMonthData> monthDatas)
        {
            var runkeeperData = new List<Data>();

            foreach (var mData in monthDatas)
            {
                runkeeperData.Add(
                    new Data()
                    {
                        ActivityDateTime = new DateTime().FromStrings(mData.Year, mData.MonthNum, mData.DayOfMonth),
                        ActivityId = mData.ActivityId.ToString(),
                        Distance = float.Parse(mData.Distance, CultureInfo.InvariantCulture.NumberFormat),
                        ElapsedTime = GetTimeFromString(mData.ElapsedTime),
                        Title = mData.MainText,
                        Type = mData.MainText,
                        Username = mData.Username
                    });
            }

            return runkeeperData;
        }

        private TimeSpan GetTimeFromString(string t)
        {
            if (t.Count(c => c == ':') == 1)
            {
                t = $"0:{t}";
            }

            return TimeSpan.Parse(t);

        }


        public List<JsonMonthData> ConvertFromJson(List<string> strings)
        {
            var data = new List<JsonMonthData>();

            foreach (var entry in strings)
            {
                try
                {
                    var doc = JsonDocument.Parse(entry);

                    var obj = doc.RootElement.EnumerateObject();

                    if (obj.First().Value.EnumerateObject().Any())
                    {
                        var jsonElements = obj.First().Value.EnumerateObject().First().Value.EnumerateObject().First().Value.EnumerateArray().ToList();

                        jsonElements.ForEach(e => data.Add((JsonMonthData)JsonSerializer.Deserialize(e.ToString(), typeof(JsonMonthData))));
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            return data;
        }
    }
}
