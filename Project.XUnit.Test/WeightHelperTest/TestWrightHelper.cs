namespace Project.XUnit.Test.WeightHelperTest
{
    public class TestWrightHelper
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

        private readonly WeightHelper _weightHelper;

        private const double MinHeight = 0;
        private const double MaxHeight = 300;
        private const double MinWeight = 0;
        private const double MaxWeight = 200;

        public TestWrightHelper()
        {
            _weightHelper = new WeightHelper();
        }

        [Theory]
        [InlineData(-1, 70)]
        [InlineData(1, 70)]
        [InlineData(160, -1)]
        [InlineData(160, 1)]

        [InlineData(50, 199)]
        [InlineData(50, 201)]
        [InlineData(299, 50)]
        [InlineData(301, 50)]

        [InlineData(-1, -1)]
        [InlineData(301, 201)]

        [InlineData(150, 100)]
        public void Height_Or_Weight_Less_Than_Zero_Throws_Exception(double height, double weight)
        {
            var exception = Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            Assert.Equal($"Height must be greater than {MinHeight} and weight cannot be less than {MinWeight}.", exception.Message);
        }


        [Theory]
        [InlineData(-1, 70)]
        [InlineData(1, 70)]
        [InlineData(160, -1)]
        [InlineData(160, 1)]

        [InlineData(50, 199)]
        [InlineData(50, 201)]
        [InlineData(299, 50)]
        [InlineData(301, 50)]

        [InlineData(-1, -1)]
        [InlineData(301, 201)]

        [InlineData(150, 100)]
        public void Height_Or_Weight_Greater_Than_Max_Throws_Exception(double height, double weight)
        {
            var exception = Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            Assert.Equal($"Height must be less than {MaxHeight} and weight cannot be more than {MaxWeight}", exception.Message);
        }

    }
}
