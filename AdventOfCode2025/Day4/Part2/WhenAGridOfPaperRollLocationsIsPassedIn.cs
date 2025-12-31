namespace Day4.Part2 {
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
            this.result = new NumberOfPaperRollLocationsPart2Calculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
        }

        [Test]
        public void ThenItShouldCorrectlyIdentifyHowManyRollsHaveLessThanAGivenAmountAroundIt() {
            Assert.That(this.result, Is.EqualTo(43));
        }
    }
}
