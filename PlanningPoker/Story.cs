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
            if (storyName.Length <= 2) throw new ArgumentException("Story name should have lenght of 3 or more characters");
        }

        public void EstimateAllEqualMode(params Estimation[] estimations)
        {
            Estimations = estimations.ToList();

            if (Estimations.Any(estimation => estimation.EstimationValue != Estimations.First().EstimationValue))
            {
                throw new ArgumentException("All estimations need to be equal");
            }
            Estimation = Estimations.First().EstimationValue;
        }
    }
}   