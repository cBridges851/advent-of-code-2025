namespace Day2.Part1;

public class InvalidIdFinder : InvalidIdFinderBase {
    
    public override ulong[] GetInvalidIds(ulong start, ulong end) {
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
