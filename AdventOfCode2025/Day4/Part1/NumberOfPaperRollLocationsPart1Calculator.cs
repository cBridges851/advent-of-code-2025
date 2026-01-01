namespace Day4.Part1 {
    internal class NumberOfPaperRollLocationsPart1Calculator : NumberOfPaperRollLocationsCalculatorBase {
        public int MaximumAdjacentPaperRollsExclusive { get; set; }

        /// <summary>
        /// Initializes the calculator with the exclusive threshold for adjacent paper rolls.
        /// </summary>
        /// <param name="maxAdjacentPaperRollsExclusive">The exclusive threshold for adjacent '@' cells; a paper roll is considered accessible if it has fewer adjacent '@' cells than this value.</param>
        public NumberOfPaperRollLocationsPart1Calculator(int maxAdjacentPaperRollsExclusive) {
            this.MaximumAdjacentPaperRollsExclusive = maxAdjacentPaperRollsExclusive;
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