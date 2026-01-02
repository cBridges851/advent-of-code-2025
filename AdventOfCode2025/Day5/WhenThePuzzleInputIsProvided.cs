namespace Day5 {
    public class WhenThePuzzleInputIsProvided {
        [TestCaseSource(nameof(TestCases))]
        public void ThenItIsSplitIntoFreshAndRequestedIngredients(string puzzleInput, HashSet<(long, long)> freshIngredientIds, HashSet<long> requestedIds) {
            var (actualFreshIngredients, actualRequestedIngredients) = new PuzzleInputParser().Parse(puzzleInput);
            Assert.Multiple(() => {
                Assert.That(actualFreshIngredients, Is.EquivalentTo(freshIngredientIds));
                Assert.That(actualRequestedIngredients, Is.EqualTo(requestedIds));
            });
        }

        private static readonly object[] TestCases = {
            new object[] {
                """
                3-5
                10-14
                16-20
                12-18

                1
                5
                8
                11
                17
                32
                """,
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (16,20),
                    (12,18)
                },
                new HashSet<long> {1,5,8,11,17,32}
            }
        };
    }
}
