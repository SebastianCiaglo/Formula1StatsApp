namespace Formula1StatsApp
{
    public abstract class DriverBase : IDriver
    {
        public DriverBase(string name, string surname)
        {
            Name = name;
            Surname = surname;

        }

        public string Name { get; private set; }
        public string Surname { get; private set;}

        public abstract event ResultAddedDelegate ResultAdded;

        public delegate void ResultAddedDelegate(object sender, EventArgs args);

        public abstract void AddPoints(int points);
        public abstract void AddPenalty(int penalty);
        public abstract void AddResult(string result);
        public abstract Statistics GetStatistics();
    }
}
