// See https://aka.ms/new-console-template for more information
using Project;

Console.WriteLine("Starting Test Project for BTH Coures PA2579 Assignment - 2");

WeightHelper obj2 = new WeightHelper();
double height = -1; // in cm
double weight = -1;   // in kg
double bmi = obj2.CalculateBMI(height, weight);
string category = obj2.GetBMICategory(height, weight);

Console.WriteLine($"BMI: {bmi}, Category: {category}");
KataCalculator obj = new KataCalculator();
obj.add("3,4");

