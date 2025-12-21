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
            Assert.That(this.result, Is.EqualTo(4174379265));
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
                (ulong)11, (ulong)22, new[] { (ulong)11, (ulong)22 }
            },
            new object[] {
                (ulong)95, (ulong)115, new[] { (ulong)99, (ulong)111 }
            },
            new object[] {
                (ulong)998, (ulong)1012, new[] { (ulong)999, (ulong)1010 }
            },
            new object[] {
                (ulong)1188511880, (ulong)1188511890, new[] { (ulong)1188511885 }
            },
            new object[] {
                (ulong)222220, (ulong)222224, new[] { (ulong)222222 }
            },
            new object[] {
                (ulong)1698522, (ulong)1698528, Array.Empty<ulong>()
            },
            new object[] {
                (ulong)446443, (ulong)446449, new[] { (ulong)446446 }
            },
            new object[] {
                (ulong)38593856, (ulong)38593862, new[] { (ulong)38593859 }
            },
            new object[] {
                (ulong)565653, (ulong)565659, new[] { (ulong)565656 }
            },
            new object[] {
                (ulong)824824821, (ulong)824824827, new[] { (ulong)824824824 }
            },
            new object[] {
                (ulong)2121212118, (ulong)2121212124, new[] { (ulong)2121212121 }
            },
        };
    }
}
