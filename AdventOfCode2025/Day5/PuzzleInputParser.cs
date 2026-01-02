
namespace Day5 {
    internal class PuzzleInputParser {

        internal (HashSet<(long, long)> freshIngredientRanges, HashSet<long> requestedIngredients) Parse(string puzzleInput) {
            var sections = puzzleInput.Split(Environment.NewLine + Environment.NewLine);
            return (this.ParseRanges(sections[0]), this.ParseRequestedIngredients(sections[1]));
        }

        internal HashSet<(long, long)> ParseRanges(string rangesAsString) {
            var ranges = new HashSet<(long, long)>();
            var rangesAsArray = rangesAsString.Split(Environment.NewLine);

            Console.WriteLine("About to parse ranges");

            foreach ( var range in rangesAsArray ) {
                var bounds = range.Split('-');
                var lowerBound = long.Parse(bounds[0]);
                var upperBound = long.Parse(bounds[1]);
                ranges.Add((lowerBound, upperBound));
            }

            Console.WriteLine("Finished parsing ranges");

            return ranges;
        }

        internal HashSet<long> ParseRequestedIngredients(string requestedIngredientsAsString) {
            Console.WriteLine("About to parse requested ingredients");
            return requestedIngredientsAsString
                .Split(Environment.NewLine)
                .Select(long.Parse)
                .ToHashSet();
        }
    }
}