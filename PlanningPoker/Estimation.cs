using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;

namespace PlanningPoker
{
    public class Estimation
    {

        public Estimation(string playerName, string storyName, int estimationValue)
        {
            PlayerName = playerName;
            StoryName = storyName;
            EstimationValue = estimationValue;
            Validate(estimationValue);
        }

        public string PlayerName { get; set; }
        public string StoryName { get; set; }
        public int EstimationValue { get; set; }

        public enum EstimationCard
        {
            Break = -3,
            TooBig = -2,
            Unknown = -1,
            Zero = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Five = 5,
            Eight = 8,
            Thirteen = 13,
            TwentyOne = 21
        }

        private static void Validate(int estimationValue)
        {
            var validationFlag = Enum.IsDefined(typeof (EstimationCard), estimationValue);
            if(validationFlag == false) throw new ArgumentException("Wrong Estimation Value");
        }

        public void Edit(Estimation estimation, int estimationValue)
        {
            Validate(estimationValue); //if estimation value is incorrect then exception is thrown and program is terminated
            estimation.EstimationValue = estimationValue;
        }
    }
}