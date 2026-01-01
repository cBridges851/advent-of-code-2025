namespace Day4.Part1 {
    internal class NumberOfPaperRollLocationsPart1Calculator : NumberOfPaperRollLocationsCalculatorBase {
        public int MaximumAdjacentPaperRollsExclusive { get; set; }

        public NumberOfPaperRollLocationsPart1Calculator(int maxAdjacentPaperRollsExclusive) {
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

                    var surroundingCells = this.GetSurroundingCells(currentRow, currentCol, grid);

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