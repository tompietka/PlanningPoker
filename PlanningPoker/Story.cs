using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;

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
            if (storyName.Length <= 2) throw new ArgumentException("Nazwa historyjki musi by� d�u�sza ni� 3 znaki.");
        }

        public void EstimateAllEqualMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue == -2))
            {
                Estimation = -2;
                return;
            }
            else
                if (Estimations.Any(estimation => estimation.EstimationValue == -1))
                {
                    Estimation = -1;
                    return;
                }
                else

                    if (Estimations.Any(estimation => estimation.EstimationValue != Estimations.First().EstimationValue))
                    {
                        throw new ArgumentException("Wszystkie warto�ci musz� by� r�wne");
                    }
            Estimation = Estimations.First().EstimationValue;
        }


        public void EstimateAverageMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue == -2))
            {
                Estimation = -2;
                return;
            }
                else if (Estimations.Any(estimation => estimation.EstimationValue == -1))
                {
                    Estimation = -1;
                    return;
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
            else if (Estimations.Any(estimation => estimation.EstimationValue == -1))
            {
                Estimation = -1;
                return;
            }
            else
            {
                var min = Estimations.Min(estimation => estimation.EstimationValue);
                var max = Estimations.Max(estimation => estimation.EstimationValue);
                var indexmin = Estimations.IndexOf(Estimations.First(estimation => estimation.EstimationValue == min));
                var indexmax = Estimations.IndexOf(Estimations.First(estimation => estimation.EstimationValue == max));
                Estimations.RemoveAt(indexmin);
                Estimations.RemoveAt(indexmax);
            }
           
                Estimation = (int)Estimations.Average(estimation => estimation.EstimationValue);
        }
    }
}   