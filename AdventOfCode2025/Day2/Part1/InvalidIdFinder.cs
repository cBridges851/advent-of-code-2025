namespace Day2.Part1;

using System.Text.RegularExpressions;

public class InvalidIdFinder {
    public ulong[][] GetInvalidIdsForRange(ulong[][] ranges) {
        var invalidIdsForRanges = new List<ulong[]>();

        foreach (ulong[] range in ranges) {
            var invalidIdsForRange = this.GetInvalidIds(range[0], range[1]);
            invalidIdsForRanges.Add(invalidIdsForRange);
        }

        return invalidIdsForRanges.ToArray();
    }

    public ulong[] GetInvalidIds(ulong start, ulong end) {
        var invalidIds = new List<ulong>();

        for (ulong i = start; i <= end; i++) {
            var currentNumberAsString = i.ToString();

            if (currentNumberAsString.Length % 2 != 0) {
                continue;
            }

            // Split the string into two equal halves
            int half = currentNumberAsString.Length / 2;
            var firstHalf = currentNumberAsString.Substring(0, half);
            var secondHalf = currentNumberAsString.Substring(half, half);

            if (firstHalf == secondHalf) {
                invalidIds.Add(i);
            }

            // If length of each half is odd number, split by 1
            // If length of each half is even number, split by 2
        }

        return invalidIds.ToArray();
    }

}
