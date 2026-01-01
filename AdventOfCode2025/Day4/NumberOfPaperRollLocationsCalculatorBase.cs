using System;
using System.Collections.Generic;
using System.Text;

namespace Day4 {
    internal class NumberOfPaperRollLocationsCalculatorBase {
        /// <summary>
        /// Collects the eight neighbouring cells around the specified grid position.
        /// </summary>
        /// <param name="currentRow">Row index of the target cell within <paramref name="grid"/>.</param>
        /// <param name="currentCol">Column index of the target cell within <paramref name="grid"/>.</param>
        /// <param name="grid">Jagged 2D array of characters representing the grid.</param>
        /// <returns>
        /// A char array of eight elements containing the surrounding cells in this order:
        /// top-left, top-middle, top-right, middle-left, middle-right, bottom-left, bottom-middle, bottom-right.
        /// Out-of-bounds neighbours are returned as the space character (' ').
        /// </returns>
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