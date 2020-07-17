using System;
using System.Collections.Generic;
using System.Text;

namespace Ranking
{
    public class RangeFabric : IRangeFabric
    {
        private List<int> RangeMaxLimits = new List<int> { 0, 3, 5, 10, 20, 50, 100, 1000, int.MaxValue };
        
        public Range GetRange(double length, string unit)
        {
            int min = 0;
            int max = 0;

            if (length <= 0)
            {
                throw new ArgumentException($"Length must be greater than 0.");
            }

            for (int i = 0; i < RangeMaxLimits.Count; i++)
            {
                if (length <= RangeMaxLimits[i])
                {
                    min = RangeMaxLimits[i - 1];
                    max = RangeMaxLimits[i];

                    break;
                }
            }

            return new Range(min, max, unit);
        }
    }
}
