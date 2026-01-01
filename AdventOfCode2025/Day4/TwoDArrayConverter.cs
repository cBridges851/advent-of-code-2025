namespace Day4 {
    internal static class TwoDArrayConverter {
        /// <summary>
        /// Convert a newline-delimited string representation of a grid into a jagged 2D char array.
        /// </summary>
        /// <param name="grid">The grid as a single string with rows separated by the newline character ('\n').</param>
        /// <returns>A jagged char[][] where each element is the characters of the corresponding input row (trimmed of surrounding whitespace).</returns>
        public static char[][] ConvertTo2DArray(string grid) { 
            var rows = grid.Split('\n');
            return ConvertTo2DArray(rows);
        }

        /// <summary>
        /// Convert an array of row strings into a jagged two-dimensional char array.
        /// </summary>
        /// <param name="gridRows">Array of strings where each element represents a row; leading and trailing whitespace is removed from each row before conversion.</param>
        /// <returns>A jagged char[][] where each element is the sequence of characters of the corresponding trimmed input row.</returns>
        public static char[][] ConvertTo2DArray(string[] gridRows) {
            var twoDArray = new char[gridRows.Length][];

            for (var currentRowIndex = 0; currentRowIndex < gridRows.Length; currentRowIndex++) {
                var currentRow = gridRows[currentRowIndex];
                twoDArray[currentRowIndex] = currentRow.Trim().ToCharArray();
            }

            return twoDArray;
        }
    }
}