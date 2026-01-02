namespace Day5 {
    public class WhenRequestedIngredientIdsAreProvided {
        [Test]
        public void ThenTheCorrectNumberOfFreshIngredientsAreReturned() {
            var ranges = new HashSet<long> { 3, 4, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            var requestedIngredients = new HashSet<long> { 1,5,8,11,17,32 };
            var result = new NumberOfFreshIngredientsCalculator(ranges).Calculate(requestedIngredients);
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
