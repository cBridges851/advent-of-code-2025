namespace Day4 {
    internal class NumberOfPaperRollLocationsCalculator {
        public int MaximumAdjacentPaperRollsExclusive { get; set; }

        public NumberOfPaperRollLocationsCalculator(int maxAdjacentPaperRollsExclusive) {
            this.MaximumAdjacentPaperRollsExclusive = maxAdjacentPaperRollsExclusive;
        }

        public int Calculate(char[][] grid) {
            var totalNumberOfRollsThatCanBeAccessed = 0;

            for (int currentRow = 0; currentRow < grid.Length; currentRow++) {
                for (int currentCol = 0; currentCol < grid[currentRow].Length; currentCol++) {
                    var cell = grid[currentRow][currentCol];

                    if (cell != '@') {
                        continue;
                    }

                    var topLeft = currentRow > 0 && currentCol > 0 ? grid[currentRow - 1][currentCol - 1] : ' ';
                    var topMiddle = currentRow > 0 ? grid[currentRow - 1][currentCol] : ' ';
                    var topRight = currentRow > 0 && currentCol < grid[currentRow].Length - 1 ? grid[currentRow - 1][currentCol + 1] : ' ';
                    var middleLeft = currentCol > 0 ? grid[currentRow][currentCol - 1] : ' ';
                    var middleRight = currentCol < grid[currentRow].Length - 1 ? grid[currentRow][currentCol + 1] : ' ';
                    var bottomLeft = currentRow < grid.Length - 1 && currentCol > 0 ? grid[currentRow + 1][currentCol - 1] : ' ';
                    var bottomMiddle = currentRow < grid.Length - 1 ? grid[currentRow + 1][currentCol] : ' ';
                    var bottomRight = currentRow < grid.Length - 1 && currentCol < grid[currentRow].Length - 1 ? grid[currentRow + 1][currentCol + 1] : ' ';

                    var surroundingCells = new[] {
                        topLeft, topMiddle, topRight,
                        middleLeft, middleRight,
                        bottomLeft, bottomMiddle, bottomRight
                    };

                    var numberOfRollsInAdjacentPositions = surroundingCells.Count(cell => cell == '@');

                    if (numberOfRollsInAdjacentPositions < this.MaximumAdjacentPaperRollsExclusive) {
                        totalNumberOfRollsThatCanBeAccessed++;
                    }
                }

            }
            
            return totalNumberOfRollsThatCanBeAccessed;
        }

    }
}