using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class WeightHelper
    {
        private const double MinHeight = 0; 
        private const double MaxHeight = 300;

        private const double MinWeight = 0;
        private const double MaxWeight = 200;

        private const string Underweight = "Underweight";
        private const string Normalweight = "Normal weight";
        private const string Overweight = "Overweight";
        private const string Obese = "Obese";

        public double CalculateBMI(double heightCm, double weightKg)
        {
            if (heightCm <= MinHeight || weightKg < MinWeight)
                throw new ArgumentException($"Height must be greater than {MinHeight} and weight cannot be less than {MinWeight}.");

            if (heightCm > MaxHeight || weightKg > MaxWeight)
                throw new ArgumentException($"Height must be less than {MaxHeight} and weight cannot be more than {MaxWeight}");

            double heightM = heightCm / 100; 
            return Math.Round(weightKg / (heightM * heightM), 2);
        }

        public string GetBMICategory(double heightCm, double weightKg)
        {
            double bmi = CalculateBMI(heightCm, weightKg);

            if (bmi < 18.5)
                return Underweight;
            else if (bmi >= 18.5 && bmi < 25)
                return Normalweight;
            else if (bmi >= 25 && bmi < 30)
                return Overweight;
            else
                return Obese;
        }
    }
}
