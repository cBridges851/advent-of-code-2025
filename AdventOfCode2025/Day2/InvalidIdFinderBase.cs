namespace Day2 {
    public abstract class InvalidIdFinderBase {
        public ulong[][] GetInvalidIdsForRanges(ulong[][] ranges) {
            var invalidIdsForRanges = new List<ulong[]>();

            return ranges
                .Select(range => this.GetInvalidIds(range[0], range[1]))
                .ToArray();
        }

        public abstract ulong[] GetInvalidIds(ulong start, ulong end);
    }
}
