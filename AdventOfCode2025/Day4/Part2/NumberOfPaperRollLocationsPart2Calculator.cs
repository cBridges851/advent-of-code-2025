namespace Day4.Part2 {
    internal class NumberOfPaperRollLocationsPart2Calculator : NumberOfPaperRollLocationsCalculatorBase {
        public int MaximumAdjacentPaperRollsExclusive { get; set; }

        public NumberOfPaperRollLocationsPart2Calculator(int maxAdjacentPaperRollsExclusive) {
            this.MaximumAdjacentPaperRollsExclusive = maxAdjacentPaperRollsExclusive;
        }

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

        private void RemoveRollsInGrid(ref char[][]grid, List<(int, int)> cellsToRemove) { 
            foreach (var (row, col) in cellsToRemove) {
                grid[row][col] = 'x';
            }
        }
    }
}