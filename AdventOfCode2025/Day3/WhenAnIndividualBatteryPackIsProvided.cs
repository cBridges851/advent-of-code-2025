namespace Day3 {
    public class WhenAnIndividualBatteryPackIsProvided {
        [TestCase("987654321111111", 98)]
        [TestCase("811111111111119", 89)]
        [TestCase("234234234234278", 78)]
        [TestCase("818181911112111", 92)]
        public void ThenTheLargestPossibleJoltageIsReturned(string batteryPack, int expectedJoltage) {
            var result = JoltageCalculator.CalculateIndividualPack(batteryPack);
            Assert.That(result, Is.EqualTo(expectedJoltage));
        }
    }
}
