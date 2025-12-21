namespace Day3 {
    public static class JoltageCalculator {
        public static int CalculateAllPacks(string[] batteryPacks) { 
            return batteryPacks.Sum(CalculateIndividualPack);
        }

        public static int CalculateIndividualPack(string batteryPack) {
            var integers = 
                batteryPack.ToCharArray()
                .Select(x => {
                    int.TryParse(x.ToString(), out var number);
                    return number;
                })
                .ToArray();

            // Find largest number
            var largestNumber = integers.Max();
            // Find position of largest number
            var largestNumberPosition = Array.IndexOf(integers, largestNumber);
            // Split integers array in two - left and right of largest number
            var left = integers[..largestNumberPosition];
            var right = integers[(largestNumberPosition + 1)..];
            // Find largest number in left array
            int? largestNumberOnLeft = null;

            if (left.Length > 0) { 
                largestNumberOnLeft = left.Max();
            }

            int? largestNumberOnRight = null;
            // Find largest number in right array
            if (right.Length > 0) {
                largestNumberOnRight = right.Max();
            }
            
            // Put together largest number on the left with the overall largest number
            var leftCombination = 0;
            if (largestNumberOnLeft.HasValue) { 
                leftCombination = int.Parse($"{largestNumberOnLeft}{largestNumber}");
            }

            // Put together largest number on the right with the overall largest number
            var rightCombination = 0;
            if (largestNumberOnRight.HasValue) { 
                rightCombination = int.Parse($"{largestNumber}{largestNumberOnRight}");
            }

            // If left largest number combination is larger, return that, or right combination
            return leftCombination > rightCombination ? leftCombination : rightCombination;
        }
    }
}