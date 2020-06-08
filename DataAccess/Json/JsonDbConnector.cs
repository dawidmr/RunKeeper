using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess
{
    public class JsonDbConnector
    {
        public void AddToDB(List<string> entries)
        {
            using (var db = new JsonContext())
            {
                foreach(var entry in entries)
                {
                    db.Json.Add(new Json() { Value = entry });
                }

                db.SaveChanges();
            }
        }

        public List<string> GetFromJsonDb()
        {
            using (var db = new JsonContext())
            {
                return db.Json.Select(x => x.Value).ToList();
            }
        }
    }
}
