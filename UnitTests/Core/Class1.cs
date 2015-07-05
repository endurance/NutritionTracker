using Core.Extension.UnitConversion;
using Core.ValueObjects.ServingMeasurements.Imperial;
using Core.ValueObjects.ServingMeasurements.Metric;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            // Conversion test
            //Some fat
            var fatGrams = new Gram(50);
            // convert to milligrams
            MilliGram fatInMilligram = fatGrams.ConvertToMilligrams();

            Assert.That(fatInMilligram.Amount, Is.EqualTo(50000));
        }

        [Test]
        public void Test2()
        {
            var fatGrams = new Gram(50);

            string name = fatGrams.AbbreviatedName;
            string friendlyName = fatGrams.GetFriendlyName();

        }
    }
}