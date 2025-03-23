namespace Formula1StatsApp
{
    public interface IDriver
    {
        string Name { get; }
        string Surname { get; }

        void AddPoints(int points);

        void AddResult(string result);

        event DriverBase.ResultAddedDelegate ResultAdded;

        Statistics GetStatistics(); 
        
    }
}
