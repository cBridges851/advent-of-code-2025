namespace Day2.Part2 {
    public class WhenASeriesOfProductIdsArePassedIn {
        private ulong result;

        [SetUp]
        public void Setup() {
            var puzzleInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
            var parsedInput = new PuzzleInputParser().Parse(puzzleInput);
            var invalidIds = new InvalidIdFinder().GetInvalidIdsForRanges(parsedInput);
            this.result = new SumOfInvalidProductIdFinder().Calculate(invalidIds);
        }

        [Test]
        public void ThenItCorrectlyReturnsTheSumOfInvalidIds() {
            var expectedAdventOfCodeAnswer = 4174379265;
            Assert.That(this.result, Is.EqualTo(expectedAdventOfCodeAnswer));
        }
    }

    public class WhenFindingInvalidIds {
        [TestCaseSource(nameof(TestCases))]
        public void ThenItCorrectlyFindsNumbersInTheRangeThatHasARepeatingPatternAtLeastTwice(ulong firstId, ulong secondId, ulong[] expectedIds) {
            var result = new InvalidIdFinder().GetInvalidIds(firstId, secondId);
            Assert.That(result, Is.EqualTo(expectedIds));
        }

        private static readonly object[] TestCases = {
            new object[] {
                11UL, 22UL, new[] { 11UL, 22UL }
            },
            new object[] {
                95UL, 115UL, new[] { 99UL, 111UL }
            },
            new object[] {
                998UL, 1012UL, new[] { 999UL, 1010UL }
            },
            new object[] {
                1188511880UL, 1188511890UL, new[] { 1188511885UL }
            },
            new object[] {
                222220UL, 222224UL, new[] { 222222UL }
            },
            new object[] {
                1698522UL, 1698528UL, Array.Empty<ulong>()
            },
            new object[] {
                446443UL, 446449UL, new[] { 446446UL }
            },
            new object[] {
                38593856UL, 38593862UL, new[] { 38593859UL }
            },
            new object[] {
                565653UL, 565659UL, new[] { 565656UL }
            },
            new object[] {
                824824821UL, 824824827UL, new[] { 824824824UL }
            },
            new object[] {
                2121212118UL, 2121212124UL, new[] { 2121212121UL }
            },
        };
    }
}
