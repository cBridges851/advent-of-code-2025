namespace Day4 {
    public class WhenAGridOfPaperRollLocationsIsPassedIn {
        private int result;

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            var puzzleInput = """
                ..@@.@@@@.
                @@@.@.@.@@
                @@@@@.@.@@
                @.@@@@..@.
                @@.@@@@.@@
                .@@@@@@@.@
                .@.@.@.@@@
                @.@@@.@@@@
                .@@@@@@@@.
                @.@.@@@.@.
                """;
            var puzzleInputAs2DArray = TwoDArrayConverter.ConvertTo2DArray(puzzleInput);
            var maxAdjacentPaperRollsExclusive = 4;
            this.result = new NumberOfPaperRollLocationsCalculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
        }

        [Test]
        public void ThenItShouldCorrectlyIdentifyHowManyRollsHaveLessThanAGivenAmountAroundIt() {
            Assert.That(this.result, Is.EqualTo(13));
        }
    }
}
