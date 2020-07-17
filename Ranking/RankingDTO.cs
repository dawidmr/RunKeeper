using System;
using System.Collections.Generic;

namespace Ranking
{
    public class RankingDTO
    {
        public IRange range { get; set; }
        public int position { get; set; }
        public TimeSpan bestDifference { get; set; }
        public List<string> activitiesInRangeIds { get; set; }
    }
}
