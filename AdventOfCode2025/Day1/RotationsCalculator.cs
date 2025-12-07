namespace Day1 {
    public class RotationsCalculator { 
        /// <summary>
        /// Computes how many times position 0 is visited on a circular track numbered 0–99 after applying the given sequence of rotations starting from position 50.
        /// </summary>
        /// <param name="rotations">Sequence of rotation instructions; each string begins with 'L' or 'R' followed by a distance (for example, L10 or R5).</param>
        /// <returns>The total number of times position 0 was hit during the sequence of rotations.</returns>
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

        /// <summary>
        /// Moves left from the given position on a 0–99 circular track by the distance specified and counts how many times position 0 is crossed or landed on.
        /// </summary>
        /// <param name="position">Current position on the 0–99 track.</param>
        /// <param name="distanceAsString">A string representing the number of steps to move left.</param>
        /// <returns>
        /// A tuple where `NewPosition` is the resulting position (0–99) after the move, and `HowManyTimesZeroWasHit` is the number of times position 0 was crossed or landed on during the move.
        /// </returns>
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

        /// <summary>
        /// Calculates the final position after moving right by the given distance on a 0–99 circular track and counts how many times position 0 is crossed or landed on during that move.
        /// </summary>
        /// <param name="position">The starting position on the 0–99 track.</param>
        /// <param name="distanceAsString">The distance to move, provided as a decimal string.</param>
        /// <returns>
        /// A tuple where `NewPosition` is the resulting position (0–99) after the move, and `HowManyTimesZeroWasHit` is the number of times position 0 was crossed or landed on during the movement.
        /// </returns>
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