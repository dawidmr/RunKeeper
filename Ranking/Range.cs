namespace Ranking
{
    public class Range : IRange
    {
        public Range(int min, int max, string unit)
        {
            Min = min;
            Max = max;
            Description = $"{min} - {max} {unit}";
        }

        public int Min { get; private set; }
        public int Max { get; private set; }
        public string Description { get; private set; }
    }
}
