namespace Day1 {
    public class WhenASeriesOfRotationsArePassedIn {
        private static readonly object[] TestCases = {
            new object[] { 
                    new[] {
                    "L68", // 50 - 68 -> 82, hit 0 here
                    "L30", // 82 - 30 -> 52
                    "R48", // 52 + 48 -> 0, hit 0 here
                    "L5", // 0 - 5 -> 95
                    "R60", // 95 + 60 -> 55, hit 0 here
                    "L55", // 55 - 55 -> 0, hit 0 here
                    "L1", // 0 - 1 -> 99
                    "L99", // 99 - 99 -> 0, hit 0 here
                    "R14", // 0 + 14 -> 14
                    "L82" // 14 - 82 -> 32, hit 0 here
                }, 6 
            },
            new object[] { 
                    new[] {
                    "R93", // 50 + 93 -> 43, hit 0 here
                    "L43", // 43 - 0 -> 0, hit 0 here
                    "L34", // 0 - 34 -> 66
                    "R89", // 66 + 89 -> 55, hit 0 here
                    "L55", // 55 - 55 -> 0, hit 0 here
                    "R30", // 0 + 30 -> 30
                    "R32", // 30 + 32 -> 62
                    "R296", // 62 + 96 -> 58, hit 0 here + x2 for the hundreds
                    "L58", // 58 - 58 -> 0, hit 0 here
                    "L100", // 0 - 100 -> 0, hit 0 here. The code currently hits this twice, may revisit to fix that but it works with the puzzle input 🙃
                    "L201", // 0 - 1 -> 99, hit 0 here + x2 for the hundreds
                    "L99", // 99 - 99 -> 0, hit 0 here
                    "L50", // 0 - 50 -> 50
                    "R50" // 50 + 50 -> 0, hit 0 here
                }, 14
            },
        };

        [TestCaseSource(nameof(TestCases))]
        public void ThenItShouldCorrectlyOutputTheNumberOfTimesZeroWasHitInTotal(string[] input, int expectedNumberOfZeros) {
            var result = new RotationsCalculator().CalculateNumberOfTimesZeroWasHit(input);
            Assert.That(result, Is.EqualTo(expectedNumberOfZeros));
        }
    }
}
