using System.Linq;

public class SumOfInvalidProductIdFinder {
    public ulong Calculate(ulong[][] invalidIds) {
        // Cast to long to use LINQ Sum extension method
        return (ulong)invalidIds.SelectMany(x => x).Select(id => (long)id).Sum();
    }
}
