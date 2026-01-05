namespace SharedUtilities.Test.UsingTheTwoDArrayConverter {
    public class WhenAStringIsPassedIn {

        [Test]
        public void ThenItIsConvertedToA2DCharArray() {
            var grid = "ABC\nDEF\nGHI";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
            Assert.That(result[2], Is.EqualTo(new[] { 'G', 'H', 'I' }));
        }

        [Test]
        public void ThenItHandlesCarriageReturnLineFeed() {
            var grid = "ABC\r\nDEF";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItTrimsWhitespaceFromRows() {
            var grid = "  ABC  \n  DEF  ";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItHandlesSingleRow() {
            var grid = "ABCDE";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C', 'D', 'E' }));
        }

        [Test]
        public void ThenItHandlesUnevenRowLengths() {
            var grid = "AB\nCDEF\nG";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'C', 'D', 'E', 'F' }));
            Assert.That(result[2], Is.EqualTo(new[] { 'G' }));
        }

        [Test]
        public void ThenItHandlesEmptyStringInput() {
            var grid = "";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ThenItHandlesGridWithOnlyNewlines() {
            var grid = "\n\n\n";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ThenItHandlesExcessiveLeadingNewlines() {
            var grid = "\n\n\nABC\nDEF";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItHandlesExcessiveTrailingNewlines() {
            var grid = "ABC\nDEF\n\n\n";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItHandlesExcessiveLeadingAndTrailingNewlines() {
            var grid = "\n\nABC\nDEF\n\n";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItThrowsOnNullInput() {
            string grid = null;

            Assert.Throws<ArgumentNullException>(() => TwoDArrayConverter.ConvertTo2DArray(grid));
        }

        [Test]
        public void ThenItHandlesNumericCharacters() {
            var grid = "123\n456\n789";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { '1', '2', '3' }));
            Assert.That(result[1], Is.EqualTo(new[] { '4', '5', '6' }));
            Assert.That(result[2], Is.EqualTo(new[] { '7', '8', '9' }));
        }

        [Test]
        public void ThenItHandlesSpecialCharacters() {
            var grid = "!@#\n$%^";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { '!', '@', '#' }));
            Assert.That(result[1], Is.EqualTo(new[] { '$', '%', '^' }));
        }

        [Test]
        public void ThenItHandlesMixedCharacters() {
            var grid = "A1!\nB2@";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', '1', '!' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'B', '2', '@' }));
        }
    }
}