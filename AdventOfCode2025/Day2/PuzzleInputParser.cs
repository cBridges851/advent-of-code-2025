public class PuzzleInputParser {
    public ulong[][] Parse(string productIdsAsString) {
        return productIdsAsString
            .Split(',')
            .Select(range => { 
                var bounds = range.Split('-');
                var start = ulong.Parse(bounds[0]);
                var end = ulong.Parse(bounds[1]);
                return new[] { start, end };
            })
            .ToArray();
    }
}