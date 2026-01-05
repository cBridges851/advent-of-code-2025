using System;

namespace SharedUtilities {
    public static class TwoDArrayConverter {
        /// <summary>
        /// Converts a newline-delimited string representation of a grid into a jagged 2D char array.
        /// </summary>
        /// <param name="grid">The grid as a single string with rows separated by the newline character ('\n').</param>
        /// <returns>A jagged char[][] where each element is the characters of the corresponding input row (trimmed of surrounding whitespace).</returns>
        public static char[][] ConvertTo2DArray(string grid) {
            if (grid == null) {
                throw new ArgumentNullException(nameof(grid), "Input grid string cannot be null.");
            }

            var rows = grid.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
            return ConvertTo2DArray(rows);
        }

        /// <summary>
        /// Converts an array of row strings into a jagged two-dimensional char array.
        /// </summary>
        /// <param name="gridRows">Array of strings where each element represents a row; leading and trailing whitespace is removed from each row before conversion.</param>
        /// <returns>A jagged char[][] where each element is the sequence of characters of the corresponding trimmed input row.</returns>
        public static char[][] ConvertTo2DArray(string[] gridRows) {
            if (gridRows == null) {
                throw new ArgumentNullException(nameof(gridRows), "Input grid rows cannot be null.");
            }

            var twoDArray = new char[gridRows.Length][];

            for (var currentRowIndex = 0; currentRowIndex < gridRows.Length; currentRowIndex++) {
                var currentRow = gridRows[currentRowIndex];
                twoDArray[currentRowIndex] = currentRow.Trim().ToCharArray();
            }

            return twoDArray;
        }

        /// <summary>
        /// Converts a newline-delimited string representation of a grid into a jagged 2D string array.
        /// </summary>
        /// <param name="grid">The grid as a single string with rows separated by newline characters ('\r' or '\n').</param>
        /// <param name="columnSeparator">The string used to separate columns within each row.</param>
        /// <returns>A jagged string[][] where each element is an array of column values from the corresponding input row (trimmed of surrounding whitespace).</returns>
        public static string[][] ConvertTo2DArray(string grid, string columnSeparator) { 
            if (grid == null) {
                throw new ArgumentNullException(nameof(grid), "Input grid string cannot be null.");
            }

            if (columnSeparator == null) {
                throw new ArgumentNullException(nameof(columnSeparator), "Column separator cannot be null.");
            }

            var rows = grid.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);
            return ConvertTo2DArray(rows, columnSeparator);
        }

        /// <summary>
        /// Converts an array of row strings into a jagged two-dimensional string array.
        /// </summary>
        /// <param name="gridRows">Array of strings where each element represents a row; leading and trailing whitespace is removed from each row before conversion.</param>
        /// <param name="columnSeparator">The string used to separate columns within each row.</param>
        /// <returns>A jagged string[][] where each element is an array of column values split by the separator from the corresponding trimmed input row.</returns>
        public static string[][] ConvertTo2DArray(string[] gridRows, string columnSeparator) {
            if (gridRows == null) {
                throw new ArgumentNullException(nameof(gridRows), "Input grid string cannot be null.");
            }

            if (columnSeparator == null) {
                throw new ArgumentNullException(nameof(columnSeparator), "Column separator cannot be null.");
            }

            var twoDArray = new string[gridRows.Length][];

            for (var currentRowIndex = 0; currentRowIndex < gridRows.Length; currentRowIndex++) {
                var currentRow = gridRows[currentRowIndex];
                twoDArray[currentRowIndex] = currentRow.Trim().Split(columnSeparator, StringSplitOptions.RemoveEmptyEntries);
            }

            return twoDArray;
        }
    }
}