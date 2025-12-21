public class SumOfInvalidProductIdFinder {
    public ulong Calculate(ulong[][] invalidIds) {
        return invalidIds.SelectMany(x => x).Aggregate<ulong, ulong>(0, (current, id) => current + id);
    }
}
