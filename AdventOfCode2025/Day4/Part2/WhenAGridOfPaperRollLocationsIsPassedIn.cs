namespace Day4.Part2 {
    public class WhenAGridOfPaperRollLocationsIsPassedIn {
        private int result;

        /// <summary>
        /// Initialises the test fixture by computing the number of paper roll locations for a sample grid using a calculator configured with an exclusive adjacent-roll limit of 4.
        /// </summary>
        /// <remarks>
        /// The computed value is stored in the private field <c>result</c>.
        /// </remarks>
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