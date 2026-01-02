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
            var result = new NumberOfFreshIngredientsCalculator(ranges).Calculate(requestedIngredients);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
