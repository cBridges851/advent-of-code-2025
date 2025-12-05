namespace Day1 {
    public class WhenASeriesOfRotationsArePassedIn {
        private static readonly object[] testCases = {
            new object[] { 
                    new[] {
                    "L68",
                    "L30",
                    "R48",
                    "L5",
                    "R60",
                    "L55",
                    "L1",
                    "L99",
                    "R14",
                    "L82"
                }, 3 
            },
            new object[] { 
                    new[] {
                    "R93",
                    "L43",
                    "L34",
                    "R89",
                    "L55",
                    "R30",
                    "R32",
                    "R296",
                    "L58",
                    "L100",
                    "L201",
                    "L99"
                }, 5
            },
        };

        [TestCaseSource(nameof(this.testCases))]
        public void ThenItShouldCorrectlyOutputTheNumberOfTimesZeroWasHit(string[] input, int expectedNumberOfZeros) {
            var result = new RotationsCalculator().CalculateNumberOfTimesZeroWasHit(input);
            Assert.That(result, Is.EqualTo(expectedNumberOfZeros));
        }
    }
}
