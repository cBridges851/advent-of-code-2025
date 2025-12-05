namespace Day1 {
    public class RotationsCalculator { 
        public int CalculateNumberOfTimesZeroWasHit(string[] rotations) {
            // Set initial position as 50
            var position = 50;
            var howManyTimesZeroWasHit = 0;
            Console.WriteLine(position);

            // For each rotation
            foreach (var rotation in rotations) { 
                // Split, so we have L/R and the number
                var direction = rotation[0];
                var distance = rotation.Substring(1);

                // If L, subtract the number from position
                if (direction == 'L') {
                    var calculationResult = this.CalculateLeftPosition(position, distance);
                    position = calculationResult.NewPosition;
                    howManyTimesZeroWasHit += calculationResult.HowManyTimesZeroWasHit;
                    Console.WriteLine($"""
                            {rotation}
                            Position: {calculationResult.NewPosition}
                            How Many Times Zero Was Hit: {calculationResult.HowManyTimesZeroWasHit}
                            ---
                        """);
                }

                // If R, add the number to position
                if (direction == 'R') {
                    var calculationResult = this.CalculateRightPosition(position, distance);
                    position = calculationResult.NewPosition;
                    howManyTimesZeroWasHit += calculationResult.HowManyTimesZeroWasHit;
                    Console.WriteLine($"""
                            {rotation}
                            Position: {calculationResult.NewPosition}
                            How Many Times Zero Was Hit: {calculationResult.HowManyTimesZeroWasHit}
                            ---
                        """);
                }

            }

            // Return the counter
            return howManyTimesZeroWasHit;
        }

        private (int NewPosition, int HowManyTimesZeroWasHit) CalculateLeftPosition(int position, string distanceAsString) {
            var originalPosition = position;
            var distance = int.Parse(distanceAsString);
            var howManyTimesZeroWasHit = 0;

            // 100 is essentially a full rotation, so we can reduce the distance by 100 until it's less than 100
            while (distance > 99) {
                distance -= 100;
                howManyTimesZeroWasHit++;
            }

            position -= distance;

            // If the position is less than 0, add it to 99
            if (position < 0) {
                position += 100;

                if (originalPosition != 0) {
                    howManyTimesZeroWasHit++;
                }
            }

            if (position == 0) {
                howManyTimesZeroWasHit++;
            }

            return (position, howManyTimesZeroWasHit);
        }

        private (int NewPosition, int HowManyTimesZeroWasHit) CalculateRightPosition(int position, string distanceAsString) {
            var originalPosition = position;
            var distance = int.Parse(distanceAsString);
            var howManyTimesZeroWasHit = 0;

            // 100 is essentially a full rotation, so we can reduce the distance by 100 until it's less than 100
            while (distance > 99) {
                distance -= 100;
                howManyTimesZeroWasHit++;
            }

            position += distance;

            // If the position is greater than 99, subtract 100
            if (position > 99) {
                position -= 100;

                if (originalPosition != 0) {
                    howManyTimesZeroWasHit++;
                }
            }

            return (position, howManyTimesZeroWasHit);
        }
    }
}
