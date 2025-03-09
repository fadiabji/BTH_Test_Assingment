using NUnit.Framework;
using Project;

namespace NUnit
{
    [TestFixture]
    public class TestWeightHelper
    {
        private readonly WeightHelper _weightHelper;

        //private readonly Fixture _fixture = new Fixture(); 


        private const double MinHeight = 0;
        private const double MaxHeight = 300;

        private const double MinWeight = 0;
        private const double MaxWeight = 200;

        public TestWeightHelper()
        {
            _weightHelper = new WeightHelper();
        }

        [TestCase(-1, 70)]
        [TestCase(1, 70)]
        [TestCase(160, -1)]
        [TestCase(160, 1)]
        [TestCase(50, 199)]
        [TestCase(50, 201)]
        [TestCase(299, 50)]
        [TestCase(301, 50)]
        [TestCase(-1, -1)]
        [TestCase(301, 201)]
        [TestCase(150, 100)]
        public void Height_Or_Weight_Less_Than_Zero_Throws_Exception(double height, double weight)
        {
            var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            NUnit.Framework.Assert.That(exception.Message, Is.EqualTo($"Height must be greater than {MinHeight} and weight cannot be less than {MinWeight}."));
        }

        [TestCase(-1, 70)]
        [TestCase(1, 70)]
        [TestCase(160, -1)]
        [TestCase(160, 1)]
        [TestCase(50, 199)]
        [TestCase(50, 201)]
        [TestCase(299, 50)]
        [TestCase(301, 50)]
        [TestCase(-1, -1)]
        [TestCase(301, 201)]
        [TestCase(150, 100)]
        public void Height_Or_Weight_Greater_Than_Max_Throws_Exception(double height, double weight)
        {
            var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
            NUnit.Framework.Assert.That(exception.Message, Is.EqualTo($"Height must be less than {MaxHeight} and weight cannot be more than {MaxWeight}"));
        }


        //[Test]
        //public void CalculateBMI_AutoData()
        //{
        //    double height = _fixture.Create<double>();
        //    double weight = _fixture.Create<double>();

        //    NUnit.Framework.Assert.nul(height);
        //    Assert.Isnull(weight);
        //    Assert.That(height, Is.EqualTo(weight));
        //    var exception = NUnit.Framework.Assert.Throws<ArgumentException>(() => _weightHelper.CalculateBMI(height, weight));
        //    NUnit.Framework.Assert.That(exception.Message, Is.EqualTo($"Height must be less than {MaxHeight} and weight cannot be more than {MaxWeight}"));
        //}
    }
}
