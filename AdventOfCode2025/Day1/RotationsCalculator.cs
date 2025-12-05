namespace Day1 {
    public class RotationsCalculator { 
        public int CalculateNumberOfTimesZeroWasHit(string[] rotations) {
            // Set initial position as 50
            var position = 50;
            var howManyTimesZeroWasHit = 0;

            // For each rotation
            foreach (var rotation in rotations) { 
                // Split, so we have L/R and the number
                var direction = rotation[0];
                var distance = rotation.Substring(1);

                // If L, subtract the number from position
                if (direction == 'L') {
                    position = this.CalculateLeftPosition(position, distance);
                }

                // If R, add the number to position
                if (direction == 'R') {
                    position = this.CalculateRightPosition(position, distance);
                }

                // If the position is 0, increment a counter
                if (position == 0) {
                    howManyTimesZeroWasHit++;
                }
            }

            // Return the counter
            return howManyTimesZeroWasHit;
        }

        private int CalculateLeftPosition(int position, string distanceAsString) {
            var distance = int.Parse(distanceAsString);

            // 100 is essentially a full rotation, so we can reduce the distance by 100 until it's less than 100
            while (distance > 99) {
                distance -= 100;
            }

            position -= distance;

            // If the position is less than 0, add it to 99
            if (position < 0) {
                position += 100;
            }

            return position;
        }

        private int CalculateRightPosition(int position, string distanceAsString) {
            var distance = int.Parse(distanceAsString);

            // 100 is essentially a full rotation, so we can reduce the distance by 100 until it's less than 100
            while (distance > 99) {
                distance -= 100;
            }

            position += distance;

            // If the position is greater than 99, subtract 99
            if (position > 99) {
                position -= 100;
            }

            return position;
        }
    }
}
