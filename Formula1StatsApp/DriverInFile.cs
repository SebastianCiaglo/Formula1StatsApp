namespace Formula1StatsApp
{
    public class DriverInFile : DriverBase
    {
        private const string filename = "points.txt";

        public override event ResultAddedDelegate ResultAdded;

        public DriverInFile(string name, string surname) : base(name, surname)
        {

        }

        public override void AddPoints(int points)
        {
            if (points >= -5 && points <= 25)
            {
                using (var writer = File.AppendText(filename))
                {
                    writer.WriteLine(points);
                }

                if (ResultAdded != null)
                {
                    ResultAdded(this, new EventArgs());
                }
            }
        }

        public override void AddPenalty(int penalty)
        {
            if (penalty < 0 && penalty >-5)
            {
                AddPoints(penalty);
            }
            else if(penalty>0)
            {
                throw new Exception("Incorrect position");
            }
            else
            {
                throw new Exception("Penalty out of range");
            }
        }

        public void AddFastLapPoint(bool fastLap)
        {
            if (fastLap = true)
            {
                AddPoints(1);
            }
        }

        public void AddResult(int result)
        {
            switch (result)
            {
                case 1:
                    AddPoints(25);
                    break;

                case 2:
                    AddPoints(18);
                    break;

                case 3:
                    AddPoints(15);
                    break;
                case 4:
                    AddPoints(12);
                    break;
                default:
                    AddPenalty(result);
                    break;
            }
        }

        public override void AddResult(string result)
        {
            if (int.TryParse(result, out int value))
            {
                AddResult(value);
            }
            else if (result == "dnf" || result == "DNF")
            {
                AddPoints(0);
            }
            else
            {
                throw new Exception("string is not position");
            }
        }

        public void DeleteFile()
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            int i = 0;

            if (File.Exists(filename))
            {
                using (var reader = File.OpenText(filename))
                {
                    var line = reader.ReadLine();
                    
                    while (line != null)
                    {

                        var point = int.Parse(line);
                        statistics.AddPoints(point);
                        line = reader.ReadLine();
                        
                        i++;
                    }

                }
            }
            return statistics;
        }
    }
}
