using System;
using System.Collections.Generic;
using System.Text;

namespace Day4 {
    internal class NumberOfPaperRollLocationsCalculatorBase {
        public char[] GetSurroundingCells(int currentRow, int currentCol, char[][] grid) {
            var topLeft = currentRow > 0 && currentCol > 0 ? grid[currentRow - 1][currentCol - 1] : ' ';
            var topMiddle = currentRow > 0 ? grid[currentRow - 1][currentCol] : ' ';
            var topRight = currentRow > 0 && currentCol < grid[currentRow].Length - 1 ? grid[currentRow - 1][currentCol + 1] : ' ';
            var middleLeft = currentCol > 0 ? grid[currentRow][currentCol - 1] : ' ';
            var middleRight = currentCol < grid[currentRow].Length - 1 ? grid[currentRow][currentCol + 1] : ' ';
            var bottomLeft = currentRow < grid.Length - 1 && currentCol > 0 ? grid[currentRow + 1][currentCol - 1] : ' ';
            var bottomMiddle = currentRow < grid.Length - 1 ? grid[currentRow + 1][currentCol] : ' ';
            var bottomRight = currentRow < grid.Length - 1 && currentCol < grid[currentRow].Length - 1 ? grid[currentRow + 1][currentCol + 1] : ' ';

            return new[] {
                topLeft, topMiddle, topRight,
                middleLeft, middleRight,
                bottomLeft, bottomMiddle, bottomRight
            };
        }
    }
}
