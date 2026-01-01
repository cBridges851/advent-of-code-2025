namespace Day4.Part1 {
    internal class NumberOfPaperRollLocationsPart1Calculator : NumberOfPaperRollLocationsCalculatorBase {
        public NumberOfPaperRollLocationsPart1Calculator(int maxAdjacentPaperRollsExclusive) : base(maxAdjacentPaperRollsExclusive) {
        }

        /// <summary>
        /// Counts accessible paper roll locations in a 2D layout.
        /// </summary>
        /// <param name="grid">A 2D character grid where '@' denotes a paper roll; other characters are ignored.</param>
        /// <returns>The count of '@' cells that have fewer than <see cref="MaximumAdjacentPaperRollsExclusive"/> adjacent '@' neighbours.</returns>
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