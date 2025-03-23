namespace Formula1StatsApp.Tests
{
    public class DriverTests
    {

        [Test]
        public void WhenStatisticsCalled_CorrectMaxReturned()
        {
            //arrange

            var driverInFile = new DriverInFile("Sergio", "Perez");

            driverInFile.AddResult("1");
            driverInFile.AddResult("3");
            driverInFile.AddResult("-4");
            driverInFile.AddResult("dnf");

            //act

            var statistics = driverInFile.GetStatistics();

            //assert

            Assert.AreEqual(25, statistics.Max);

            //cleanup

            driverInFile.DeleteFile();
        }

        [Test]
        public void WhenStatisticsCalled_CorrectMinReturned()
        {
            //arrange

            var driverInFile = new DriverInFile("Sergio", "Perez");

            driverInFile.AddResult("1");
            driverInFile.AddResult("3");
            driverInFile.AddResult("-4");
            driverInFile.AddResult("dnf");

            //act

            var statistics = driverInFile.GetStatistics();

            //assert

            Assert.AreEqual(15, statistics.Min);

            //cleanup

            driverInFile.DeleteFile();
        }

        [Test]
        public void WhenStatisticsCalled_CorrectRatingReturned()
        {
            //arrange
  
            var driversRating = new DriverInMemory("Sergio", "Perez");

            driversRating.AddResult("A");
            driversRating.AddResult("B");
            driversRating.AddResult("B");
            
            //act

            var statistics = driversRating.GetStatistics();

            //assert
            
            Assert.AreEqual(Math.Round(86.67,2), Math.Round(statistics.Average,2));

        }


    }
}
