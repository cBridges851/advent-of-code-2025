
namespace Day5 {
    internal class PuzzleInputParser {

        internal (HashSet<long> freshIngredients, HashSet<long> requestedIngredients) Parse(string puzzleInput) {
            var sections = puzzleInput.Split(Environment.NewLine + Environment.NewLine);
            return (this.ParseRanges(sections[0]), this.ParseRequestedIngredients(sections[1]));
        }

        internal HashSet<long> ParseRanges(string rangesAsString) {
            var ranges = new HashSet<long>();
            var rangesAsArray = rangesAsString.Split(Environment.NewLine);

            Console.WriteLine("About to parse ranges");

            foreach ( var range in rangesAsArray ) {
                var bounds = range.Split('-');
                var lowerBound = long.Parse(bounds[0]);
                var upperBound = long.Parse(bounds[1]);
                for ( var i = lowerBound; i <= upperBound; i++ ) {
                    ranges.Add(i);
                    Console.WriteLine($"Added {i} to ranges");
                }
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