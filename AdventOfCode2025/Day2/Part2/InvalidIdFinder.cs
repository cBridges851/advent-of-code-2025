namespace Day2.Part2;

public class InvalidIdFinder : InvalidIdFinderBase {

    public override ulong[] GetInvalidIds(ulong start, ulong end) {
        var invalidIds = new List<ulong>();

        // TODO: Look at how this can be solved more efficiently

        for (ulong i = start; i <= end; i++) {
            var currentNumberAsString = i.ToString();

            for (var patternLength = 1; patternLength <= currentNumberAsString.Length / 2; patternLength++) { 
                var subStrings = new HashSet<string>();

                var canSplitEvenly = currentNumberAsString.Length % patternLength == 0;
                if (!canSplitEvenly) {
                    continue;
                }

                for (var index = 0; index < currentNumberAsString.Length; index += patternLength) {
                    var subString = currentNumberAsString.Substring(index, patternLength);
                    subStrings.Add(subString);
                }

                if (subStrings.All(x => x == subStrings.First())) {
                    invalidIds.Add(i);
                    break;
                }
            }
        }

        return invalidIds.ToArray();
    }

}
