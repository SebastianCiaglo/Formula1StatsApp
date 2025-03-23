using Formula1StatsApp;

Console.WriteLine("Welcome to the program to gather Formula 1 season progress");
Console.WriteLine("==========================================================");
Console.WriteLine();

Console.WriteLine("Enter Name of the driver");
string name = Console.ReadLine();

Console.WriteLine("Enter Surname of the driver");
string surname = Console.ReadLine();

var driversInFile = new DriverInFile(name, surname);
var driversInMemory = new DriverInMemory(name, surname);

driversInFile.ResultAdded += DriverResultAdded;
driversInMemory.ResultAdded += DriverRatingAdded;

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
        driversInMemory.AddResult(input);
        driversInMemory.ResultAdded += DriverResultAdded;
    }
    else if(input =="+") 
    {
        driversInFile.AddFastLapPoint(true);
        driversInFile.ResultAdded += DriverResultAdded;
    }
    else
    {
        try
        {
            driversInFile.AddResult(input);

            if (true)
            {
                driversInFile.ResultAdded += DriverResultAdded;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception catched: {e.Message}");
        }
    }
    driversInFile.ResultAdded -= DriverResultAdded;
    driversInMemory.ResultAdded -= DriverResultAdded;

}

void ResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Result added");
}

var statistics = driversInFile.GetStatistics();

Console.WriteLine($"Min: {statistics.Min}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"SeasonResult: {statistics.Sum}");

var statistics2 = driversInMemory.GetStatistics();

Console.WriteLine($"AverageRating: {driversInMemory.ConvertNumberGradeToLetter(statistics2.Average)}");