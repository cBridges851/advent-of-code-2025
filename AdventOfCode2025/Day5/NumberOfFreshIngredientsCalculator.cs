namespace Day5 {
    internal class NumberOfFreshIngredientsCalculator {
        private readonly HashSet<(long LowestNumber, long HighestNumber)> ranges;

        public NumberOfFreshIngredientsCalculator(HashSet<(long, long)> ranges) {
            this.ranges = ranges;
        }

        internal long Calculate(HashSet<long> requestedIngredients) {
            var numberOfFreshIngredients = 0L;

            foreach (var requestedIngredient in requestedIngredients) {
                foreach (var (LowestNumber, HighestNumber) in this.ranges) {
                    if (requestedIngredient >= LowestNumber && requestedIngredient <= HighestNumber) {
                        numberOfFreshIngredients++; 
                        break;
                    }
                }
            }

            return numberOfFreshIngredients;
        }
    }
}