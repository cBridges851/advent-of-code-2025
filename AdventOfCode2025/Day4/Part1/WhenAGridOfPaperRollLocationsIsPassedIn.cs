using SharedUtilities;

namespace Day4.Part1 {
    public class WhenAGridOfPaperRollLocationsIsPassedIn {
        private int result;

        /// <summary>
        /// Initializes the test fixture by computing the number of paper-roll locations for a predefined grid.
        /// </summary>
        /// <remarks>
        /// Converts a hard-coded multi-line grid to a 2D array and stores the calculated count (using an exclusive adjacent limit of 4) in the private `result` field for use by the tests.
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
            this.result = new NumberOfPaperRollLocationsPart1Calculator(maxAdjacentPaperRollsExclusive).Calculate(puzzleInputAs2DArray);
        }

        [Test]
        public void ThenItShouldCorrectlyIdentifyHowManyRollsHaveLessThanAGivenAmountAroundIt() {
            Assert.That(this.result, Is.EqualTo(13));
        }
    }
}