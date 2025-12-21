namespace Day2.Part1;

public class InvalidIdFinder {
    public ulong[][] GetInvalidIdsForRanges(ulong[][] ranges) {
        var invalidIdsForRanges = new List<ulong[]>();

        return ranges
            .Select(range => this.GetInvalidIds(range[0], range[1]))
            .ToArray();
    }

    public ulong[] GetInvalidIds(ulong start, ulong end) {
        var invalidIds = new List<ulong>();

        for (ulong i = start; i <= end; i++) {
            var currentNumberAsString = i.ToString();

            if (currentNumberAsString.Length % 2 != 0) {
                continue;
            }

            int half = currentNumberAsString.Length / 2;
            var firstHalf = currentNumberAsString.Substring(0, half);
            var secondHalf = currentNumberAsString.Substring(half, half);

            if (firstHalf == secondHalf) {
                invalidIds.Add(i);
            }
        }

        return invalidIds.ToArray();
    }

}
