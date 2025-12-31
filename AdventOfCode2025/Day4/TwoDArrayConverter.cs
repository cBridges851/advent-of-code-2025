namespace Day4 {
    internal static class TwoDArrayConverter {
        public static char[][] ConvertTo2DArray(string grid) { 
            var rows = grid.Split('\n');
            return ConvertTo2DArray(rows);
        }

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