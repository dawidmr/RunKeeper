using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using DataAccess.RunkeeperDB;

namespace WebCrawler
{
    public class Manager
    {
        private DateTime defaultStartDate = new DateTime(2012, 3, 1);

        public void Update(string login)
        {
            var convertion = new ConvertManager();
            var userData = GetUserDataFromWebsite(login);
            var convertedData = convertion.ConvertFromJson(userData);

            var dbFormatData = convertion.ConvertFromJsonDbToRunkeeperDB(convertedData);

            new ActivitiesRepository().AddData(dbFormatData);
        }

        public List<string> GetUserDataFromWebsite(string login)
        {
            var newestEntry = new ActivitiesRepository().GetLatestEntryDate(login);

            var since = newestEntry.HasValue ? newestEntry.Value : defaultStartDate;
            var data = new RunkeeperWebsite().GetDataFromRunkeeperWebsite(login, since);

            return data;
        }
    }
}
