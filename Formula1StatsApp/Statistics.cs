namespace Formula1StatsApp
{
    public class Statistics
    {
        public int Min { get; private set; }

        public int Max { get; private set; }

        public int Sum { get; private set; }

        public int Count { get; private set; }

        public float Average
        {
            get
            {
                return Convert.ToSingle(this.Sum) / Convert.ToSingle(this.Count);
            }

        }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = int.MinValue;
            this.Min = int.MaxValue;
        }

        public void AddPoints(int points)
        {
            this.Count++;
            this.Sum += points;
            this.Max = Math.Max(points, this.Max);
            if (points > 0)
            {
                this.Min = Math.Min(points, this.Min);
            }
        }
    }
}
