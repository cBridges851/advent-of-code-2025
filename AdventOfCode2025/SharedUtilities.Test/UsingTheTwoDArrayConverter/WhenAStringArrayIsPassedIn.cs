namespace SharedUtilities.Test.UsingTheTwoDArrayConverter {
    public class WhenAStringArrayIsPassedIn {

        [Test]
        public void ThenItIsConvertedToA2DCharArray() {
            var gridRows = new[] { "ABC", "DEF", "GHI" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
            Assert.That(result[2], Is.EqualTo(new[] { 'G', 'H', 'I' }));
        }

        [Test]
        public void ThenItTrimsWhitespaceFromRows() {
            var gridRows = new[] { "  ABC  ", "  DEF  " };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItHandlesSingleRow() {
            var gridRows = new[] { "ABCDE" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C', 'D', 'E' }));
        }

        [Test]
        public void ThenItHandlesUnevenRowLengths() {
            var gridRows = new[] { "AB", "CDEF", "G" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B' }));
            Assert.That(result[1], Is.EqualTo(new[] { 'C', 'D', 'E', 'F' }));
            Assert.That(result[2], Is.EqualTo(new[] { 'G' }));
        }

        [Test]
        public void ThenItHandlesEmptyArray() {
            var gridRows = new string[0];

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void ThenItHandlesEmptyStringElements() {
            var gridRows = new[] { "ABC", "", "DEF" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new char[0]));
            Assert.That(result[2], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItHandlesWhitespaceOnlyElements() {
            var gridRows = new[] { "ABC", "   ", "DEF" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { 'A', 'B', 'C' }));
            Assert.That(result[1], Is.EqualTo(new char[0]));
            Assert.That(result[2], Is.EqualTo(new[] { 'D', 'E', 'F' }));
        }

        [Test]
        public void ThenItThrowsOnNullInput() {
            string[] gridRows = null;

            Assert.Throws<ArgumentNullException>(() => TwoDArrayConverter.ConvertTo2DArray(gridRows));
        }

        [Test]
        public void ThenItHandlesNumericCharacters() {
            var gridRows = new[] { "123", "456", "789" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { '1', '2', '3' }));
            Assert.That(result[1], Is.EqualTo(new[] { '4', '5', '6' }));
            Assert.That(result[2], Is.EqualTo(new[] { '7', '8', '9' }));
        }

        [Test]
        public void ThenItHandlesSpecialCharacters() {
            var gridRows = new[] { "!@#", "$%^" };

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { '!', '@', '#' }));
            Assert.That(result[1], Is.EqualTo(new[] { '$', '%', '^' }));
        }

        [Test]
        public void ThenItThrowsOnNullElementInArray() {
            var gridRows = new[] { "ABC", null, "DEF" };

            Assert.Throws<ArgumentException>(() => TwoDArrayConverter.ConvertTo2DArray(gridRows));
        }
    }
}