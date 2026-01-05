namespace Day5 {
    public class WhenRequestedIngredientIdsAreProvided {
        [Test]
        public void ThenTheCorrectNumberOfFreshIngredientsAreReturned() {
            var ranges = new HashSet<(long, long)> { 
                (3,5),
                (10,14),
                (16,20),
                (12,18)
            };
            var requestedIngredients = new HashSet<long> { 1,5,8,11,17,32 };
            var result = new NumberOfFreshIngredientsCalculator(ranges).CalculateNumberOfRequestedIngredientsThatAreFresh(requestedIngredients);
            Assert.That(result, Is.EqualTo(3));
        }
    }

    public class WhenRequestingTheTotalNumberOfFreshIds {
        [TestCaseSource(nameof(TestCases))]
        public void ThenTheCorrectValueIsReturned(HashSet<(long, long)> ranges, long expectedResult) { 
            var result = new NumberOfFreshIngredientsCalculator(ranges).TotalNumberOfFreshIngredientsInInventory();
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        private static readonly object[] TestCases = {
            new object[] {
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (16,20),
                    (12,18)
                },
                14L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (12,18),
                    (16,20)
                },
                14L
            }, 
            new object[] {
                new HashSet<(long, long)> {
                    (16,20),
                    (3,5),
                    (10,14),
                    (12,18)
                },
                14L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (16,20),
                    (10,14),
                    (12,18),
                    (3,5)
                },
                14L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (16,20),
                    (12,18),
                    (10,14),
                    (3,5)
                },
                14L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (16,20),
                    (12,18),
                    (10,14),
                    (3,5)
                },
                14L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (3,5)
                },
                3L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (16,20),
                    (12,18),
                    (9,21)
                },
                16L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (16,20),
                    (12,18),
                    (9,21),
                    (1,25)
                },
                25L
            },
            new object[] {
                new HashSet<(long, long)> {
                    (3,5),
                    (10,14),
                    (16,20),
                    (12,18),
                    (9,21),
                    (13,14)
                },
                16L
            },
        };
    }
}
