using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanningPoker
{
    public class Story
    {

        public Story(string name)
        {
            Name = name;
            Validate(name);
        }

        public string Name { get; set; }

        public IList<Estimation> Estimations { get; set; }

        public int Estimation { get; set; }

        private static void Validate(string storyName)
        {
            if (storyName.Length <= 2) throw new ArgumentException("Nazwa historyjki musi byæ d³u¿sza ni¿ 3 znaki.");
        }

        public void EstimateAllEqualMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue == -2))
            {
                Estimation = -2;
                return;
            }
            if (Estimations.Any(estimation => estimation.EstimationValue == -1))
            {
                Estimation = -1;
                return;
            }
            if (Estimations.Any(estimation => estimation.EstimationValue != Estimations.First().EstimationValue))
            {
                throw new ArgumentException("Wszystkie wartoœci musz¹ byæ równe");
            }
            Estimation = Estimations.First().EstimationValue;
        }


        public void EstimateAverageMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue == -2))
            {
                Estimation = -2;
            }
                else if (Estimations.Any(estimation => estimation.EstimationValue == -1))
                {
                    Estimation = -1;
                }
                else
                    Estimation = (int)Estimations.Average(estimation => estimation.EstimationValue);
        }

        public void EstimateAverageRemoveMinMaxMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue == -2))
            {
                Estimation = -2;
                return;
            }
            if (Estimations.Any(estimation => estimation.EstimationValue == -1))
            {
                Estimation = -1;
                return;
            }
            var min = Estimations.Min(estimation => estimation.EstimationValue);
            var max = Estimations.Max(estimation => estimation.EstimationValue);
            var indexmin = Estimations.IndexOf(Estimations.First(estimation => estimation.EstimationValue == min));
            var indexmax = Estimations.IndexOf(Estimations.First(estimation => estimation.EstimationValue == max));
            Estimations.RemoveAt(indexmin);
            Estimations.RemoveAt(indexmax);

            Estimation = (int)Estimations.Average(estimation => estimation.EstimationValue);
        }
    }
}   