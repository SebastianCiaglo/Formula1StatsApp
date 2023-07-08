namespace Formula1StatsApp.Tests
{
    public class TypeTests
    {
        [Test]
        public void ReturnFloatAverageFromIntInput() 
        {
            //arrange
            var input1 = 100;

            var input2 = 63;

            var input3 = 18;

            double average = 0.0;

            double result = 60.333333;

            //act

            average=(Convert.ToDouble(input1)+input2+input3)/3;
            

            //assert

            Assert.AreEqual(Math.Round(result,2),Math.Round(average,2));
        }

        [Test]
        public void ReferenceTypeTest()
        {
            //arrange

            var driver1 = GetDriver("Yuki", "Tsunoda");
            var driver2 = GetDriver("Yuki", "Tsunoda");

            //act


            //assert
            Assert.AreEqual(driver1.Name, driver2.Name);

        }

        public void ValueTypeTest()
        {
            //arrange

            var driver1paycheck = 10500.0;
            var driver1expenses = 2145.5;

            //act

            var result = driver1paycheck > driver1expenses;

            //assert
            Assert.AreEqual(true, result);

        }

        private DriversRating GetDriver(string name, string surname)
        {
            return new DriversRating(name, surname);
        }

    }
}
