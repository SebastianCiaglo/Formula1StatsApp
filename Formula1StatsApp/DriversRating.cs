﻿using System.Drawing;

namespace Formula1StatsApp
{
    public class DriversRating : DriverBase
    {
        public override event ResultAddedDelegate ResultAdded;

        private List<int> points = new List<int>();

        public DriversRating(string name, string surname) : base(name, surname) 
        {
        
        }

        public override void AddPoints(int points)
        {
            this.points.Add(points);

            if (ResultAdded != null)
            {
                ResultAdded(this, new EventArgs());
            }
        }


        public override void AddResult(string result)
        {
            switch (result)
            {
                case "A":
                    AddPoints(100);
                    break;

                case "B":
                    AddPoints(80);
                    break;

                case "C":
                    AddPoints(60);
                    break;

                case "D":
                    AddPoints(40);
                    break;

                case "E":
                    AddPoints(20);
                    break;
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (this.points.Count > 0)
            {


                foreach (var point in this.points)
                {
                    statistics.AddPoints(point);
                }
            }
            else
            {
                statistics.AddPoints(0);
            }

            return statistics;
        }

        public char ConvertNumberGradeToLetter(float grade)
        {
            switch (grade)
            {
                case >99:
                    return 'A';
                case > 79:
                    return 'B';
                case > 59:
                    return 'C';
                case > 39:
                    return 'D';
                default:
                    return 'E';
            }
        }
    }
}
