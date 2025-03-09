using NUnit.Framework;
using Project;

namespace NUnit
{
        //BVA (Boundary Value Analysis)
        //1 - dentify Input Boundaries: Identify the minimum and maximum values that the software can accept for a given input.
        // MinHeight = 0;
        // MaxHeight = 300;
        // MinWeight = 0;
        // MaxWeight = 200;

        //2 - Select Boundary Values: Choose values that are just inside and just outside the identified boundaries.
        // Just outside boundray is Height = -1;
        // Just inside boundray Height = 1;
        // Just inside boundery Height = 299;
        // Just oustside boundery Height = 301;

        // Just outside boundray Weight = -1;
        // Just inside boundray Weight = 1;
        // Just inside boundery Weight = 199;
        // Just outside boundray Weight = 201;

        //3 -Test the Boundary Values: Use these selected values for testing.

        //Advantages
        //It targets areas where errors are more likely to occur.
        //It provides thorough testing without an exhaustive number of test cases.
        //Example: If a software function accepts values from 1 to 100, you’d focus on testing values like 0, 1, 2, 99, 100 and 101.
    [TestFixture]
    public class TestWeightHelper
    {

        private readonly WeightHelper _weightHelper;

        private const double MinHeight = 0;
        private const double MaxHeight = 300;

        private const double MinWeight = 0;
        private const double MaxWeight = 200;

        public TestWeightHelper()
        {
            _weightHelper = new WeightHelper();
        }

        [TestCase(-1, -1)]
        [TestCase(-1, 70)]
        [TestCase(170, -1)]
        public void Height_Or_Weight_Less_Than_Zero_Throws_Exception(double height, double weight)
        {
            var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            Assert.That(exception.Message, Is.EqualTo($"Height must be greater than {MinHeight} and weight cannot be less than {MinWeight}."));
        }


        [TestCase(301, 201)]
        [TestCase(100, 201)]
        [TestCase(301, 100)]
        public void Height_Or_Weight_Greater_Than_Max_Throws_Exception(double height, double weight)
        {
            var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            Assert.That(exception.Message, Is.EqualTo($"Height must be less than {MaxHeight} and weight cannot be more than {MaxWeight}"));
        }

        [TestCase(170, 50, "Underweight")]
        [TestCase(170, 65, "Normal weight")]
        [TestCase(170, 80, "Overweight")]
        [TestCase(170, 100, "Obese")]
        public void GetBMICategory_Returns_Correct_Category(double height, double weight, string expectedCategory)
        {
            string category = _weightHelper.GetBMICategory(height, weight);
            Assert.That(category, Is.EqualTo(expectedCategory));
        }
    }
}
