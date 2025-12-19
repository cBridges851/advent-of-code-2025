public class PuzzleInputParser {
    public ulong[][] Parse(string productIdsAsString) {
        var allProductIdsRanges = new List<ulong[]>();
        var allRanges = productIdsAsString.Split(',');

        foreach (var range in allRanges) {
            var bounds = range.Split('-');
            var start = ulong.Parse(bounds[0]);
            var end = ulong.Parse(bounds[1]);
            allProductIdsRanges.Add([ start, end ]);
        }

        return allProductIdsRanges.ToArray();
    }
}