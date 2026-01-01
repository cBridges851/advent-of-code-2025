namespace Day4.Part2 {
    internal class NumberOfPaperRollLocationsPart2Calculator : NumberOfPaperRollLocationsCalculatorBase {
        public int MaximumAdjacentPaperRollsExclusive { get; set; }

        /// <summary>
        /// Initialises the calculator with the exclusive threshold for adjacent paper rolls used to determine accessibility.
        /// </summary>
        /// <param name="maxAdjacentPaperRollsExclusive">The exclusive upper bound on adjacent '@' cells; a roll with fewer adjacent rolls than this value is considered accessible.</param>
        public NumberOfPaperRollLocationsPart2Calculator(int maxAdjacentPaperRollsExclusive) {
            this.MaximumAdjacentPaperRollsExclusive = maxAdjacentPaperRollsExclusive;
        }

        /// <summary>
        /// Calculate the total number of paper rolls that become accessible and are removed from the grid according to the configured adjacency threshold.
        /// </summary>
        /// <param name="grid">A 2D character grid where '@' denotes a paper roll and 'x' denotes an empty/removed cell; the grid is modified in place as rolls are removed.</param>
        /// <returns>The total count of paper rolls removed from the grid.</returns>
        public int Calculate(char[][] grid) {
            var totalNumberOfRollsThatCanBeAccessed = 0;
            var numberOfRollsThatCanBeAccessedCurrently = 0;

            do {
                numberOfRollsThatCanBeAccessedCurrently = 0;
                var cellsToRemove = new List<(int row, int col)>();

                for (int currentRow = 0; currentRow < grid.Length; currentRow++) {
                    for (int currentCol = 0; currentCol < grid[currentRow].Length; currentCol++) {
                        var cell = grid[currentRow][currentCol];

                        if (cell != '@') {
                            continue;
                        }

                        var surroundingCells = this.GetSurroundingCells(currentRow, currentCol, grid);

                        var numberOfRollsInAdjacentPositions = surroundingCells.Count(cell => cell == '@');

                        if (numberOfRollsInAdjacentPositions < this.MaximumAdjacentPaperRollsExclusive) {
                            numberOfRollsThatCanBeAccessedCurrently++;
                            cellsToRemove.Add((currentRow, currentCol));
                        }
                    }
                }

                this.RemoveRollsInGrid(ref grid, cellsToRemove);
                totalNumberOfRollsThatCanBeAccessed += numberOfRollsThatCanBeAccessedCurrently;
            } while (numberOfRollsThatCanBeAccessedCurrently > 0);

            return totalNumberOfRollsThatCanBeAccessed;
        }

        /// <summary>
        /// Mark the specified cells in the grid as removed by setting them to 'x'.
        /// </summary>
        /// <param name="grid">Reference to the 2D character grid representing paper roll locations; cells listed in <paramref name="cellsToRemove"/> will be updated.</param>
        /// <param name="cellsToRemove">List of (row, column) coordinates to mark as removed.</param>
        private void RemoveRollsInGrid(ref char[][]grid, List<(int, int)> cellsToRemove) { 
            foreach (var (row, col) in cellsToRemove) {
                grid[row][col] = 'x';
            }
        }
    }
}