using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;

namespace DataAccess
{
    public class JsonRunkeeperConverter
    {
        public List<JsonMonthData> ConvertFromJson()
        {
            var strings = new JsonDbConnector().GetFromJsonDb();

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
