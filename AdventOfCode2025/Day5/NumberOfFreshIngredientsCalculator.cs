namespace Day5 {
    internal class NumberOfFreshIngredientsCalculator {
        private readonly HashSet<(long LowestNumber, long HighestNumber)> ranges;

        public NumberOfFreshIngredientsCalculator(HashSet<(long, long)> ranges) {
            this.ranges = this.ConsolidateRanges(ranges);
        }

        private HashSet<(long, long)> ConsolidateRanges(HashSet<(long, long)> originalRanges) {
            var consolidatedRanges = new List<(long LowestNumber, long HighestNumber)>();

            foreach (var range in originalRanges) {
                var (currentLowest, currentHighest) = range;
                var rangesCurrentCrossesOverWith = new List<(long LowestNumber, long HighestNumber)>();

                for (var i = 0; i < consolidatedRanges.Count; i++) {
                    var consolidatedRangeLowest = consolidatedRanges[i].LowestNumber;
                    var consolidatedRangeHighest = consolidatedRanges[i].HighestNumber;

                    if (currentLowest >= consolidatedRangeLowest && currentLowest <= consolidatedRangeHighest
                        || currentHighest >= consolidatedRangeLowest && currentHighest <= consolidatedRangeHighest) {
                        rangesCurrentCrossesOverWith.Add(consolidatedRanges[i]);
                    } else if (consolidatedRangeLowest >= currentLowest && consolidatedRangeLowest <= currentHighest
                        || consolidatedRangeHighest >= currentLowest && consolidatedRangeHighest <= currentHighest) {
                        rangesCurrentCrossesOverWith.Add(consolidatedRanges[i]);
                    }
                }

                if (rangesCurrentCrossesOverWith.Count > 0) {
                    var lowestNumber = Math.Min(currentLowest, rangesCurrentCrossesOverWith.Min(r => r.LowestNumber));
                    var highestNumber = Math.Max(currentHighest, rangesCurrentCrossesOverWith.Max(r => r.HighestNumber));

                    if (!consolidatedRanges.Contains((lowestNumber, highestNumber))) {
                        consolidatedRanges.Add((lowestNumber, highestNumber));
                        consolidatedRanges.RemoveAll(r => rangesCurrentCrossesOverWith.Contains(r));
                    }
                } else {
                    consolidatedRanges.Add(range);
                }

            }

            return consolidatedRanges.ToHashSet();
        }

        internal long CalculateNumberOfRequestedIngredientsThatAreFresh(HashSet<long> requestedIngredients) {
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

        internal long TotalNumberOfFreshIngredientsInInventory() {
            var totalFreshIngredients = 0L;

            foreach (var (LowestNumber, HighestNumber) in this.ranges) {
                totalFreshIngredients += (HighestNumber - LowestNumber + 1);
            }

            return totalFreshIngredients;
        }
    }
}