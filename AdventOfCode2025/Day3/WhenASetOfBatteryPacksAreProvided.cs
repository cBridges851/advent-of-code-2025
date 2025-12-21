namespace Day3 {
    public class WhenASetOfBatteryPacksAreProvided {
        private int expectedLargestPossibleJoltage;

        [SetUp]
        public void Setup() {
            var puzzleInput = """
                987654321111111
                811111111111119
                234234234234278
                818181911112111
                """;
            var batteryPacks = PuzzleInputParser.ParseBatteryPacks(puzzleInput);
            this.expectedLargestPossibleJoltage = JoltageCalculator.CalculateAllPacks(batteryPacks);
        }

        [Test]
        public void ThenTheCorrectTotalJoltageIsReturned() {
            Assert.That(this.expectedLargestPossibleJoltage, Is.EqualTo(357));
        }
    }
}
