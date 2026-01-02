namespace Day5 {
    internal class NumberOfFreshIngredientsCalculator {
        private HashSet<long> ranges;

        public NumberOfFreshIngredientsCalculator(HashSet<long> ranges) {
            this.ranges = ranges;
        }

        internal long Calculate(HashSet<long> requestedIngredients) {
            return this.ranges.Count(requestedIngredients.Contains);
        }
    }
}