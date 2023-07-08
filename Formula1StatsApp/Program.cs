using Formula1StatsApp;

Console.WriteLine("Welcome to the program to gather Formula 1 season progress");
Console.WriteLine("==========================================================");
Console.WriteLine();

Console.WriteLine("Enter Name of the driver");
string name = Console.ReadLine();


Console.WriteLine("Enter Surname of the driver");
string surname = Console.ReadLine();

var driverInFile = new DriverInFile(name, surname);
var driversRating = new DriversRating(name, surname);

driverInFile.ResultAdded += DriverResultAdded;
driversRating.ResultAdded += DriverRatingAdded;

void DriverResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Result added");
}

void DriverRatingAdded(object sender, EventArgs args)
{
    Console.WriteLine("Rating added");
}


while (true)
{
    Console.WriteLine("");
    Console.WriteLine("Enter result of driver, to quit enter q");
    Console.WriteLine("Add position, penalty up to 4 negative points, to indicate disqualification write dnf. To add point for fastest lap enter +.");
    Console.WriteLine("Enter press rating, pick letter from A-E");

    var input = Console.ReadLine();

    if (input == "q")
    {
        break;
    }
    
    if (input == "A" || input == "B" || input == "C" || input == "D" || input == "E")
    {
        driversRating.AddResult(input);

        void ResultAdded(object sender, EventArgs args)
        {
        }
    
    }
    else if(input =="+") 
    {
        driverInFile.AddFastLapPoint(true);

        void ResultAdded(object sender, EventArgs args)
        {
        }
    }
    else
    {
        try
        {
            driverInFile.AddResult(input);

            if (true)
            {
                void ResultAdded(object sender, EventArgs args)
                {
                    Console.WriteLine("Result added");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }

}

var statistics = driverInFile.GetStatistics();


Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"SeasonResult: {statistics.Sum}");

var statistics2 = driversRating.GetStatistics();



Console.WriteLine($"AverageRating: {driversRating.ConvertNumberGradeToLetter(statistics2.Average)}");