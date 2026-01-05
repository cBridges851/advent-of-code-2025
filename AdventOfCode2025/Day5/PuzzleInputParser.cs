
namespace Day5 {
    internal class PuzzleInputParser {

        internal (HashSet<(long, long)> freshIngredientRanges, HashSet<long> requestedIngredients) Parse(string puzzleInput) {
            var sections = puzzleInput.Split(Environment.NewLine + Environment.NewLine);
            return (this.ParseRanges(sections[0]), this.ParseRequestedIngredients(sections[1]));
        }

        internal HashSet<(long, long)> ParseRanges(string rangesAsString) {
            var rangesAsArray = rangesAsString.Split(Environment.NewLine);

            return rangesAsArray.Select(range => { 
                var bounds = range.Trim().Split('-');
                var lowerBound = long.Parse(bounds[0]);
                var upperBound = long.Parse(bounds[1]);
                return (lowerBound, upperBound);
            }).ToHashSet();
        }

        internal HashSet<long> ParseRequestedIngredients(string requestedIngredientsAsString) {
            return requestedIngredientsAsString
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToHashSet();
        }
    }
}