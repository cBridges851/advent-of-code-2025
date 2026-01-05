using SharedUtilities;

namespace SharedUtilities.Test.UsingTheTwoDArrayConverter {
    public class WhenAStringIsPassedInWithASeparator {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void ThenItIsConvertedToA2DArray() {
            var grid = "1,2,3\n4,5,6\n7,8,9";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { "1", "2", "3" }));
            Assert.That(result[1], Is.EqualTo(new[] { "4", "5", "6" }));
            Assert.That(result[2], Is.EqualTo(new[] { "7", "8", "9" }));
        }

        [Test]
        public void ThenItHandlesMultipleCharacterSeparators() {
            var grid = "apple||banana||cherry\ndog||elephant||fox";
            var separator = "||";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { "apple", "banana", "cherry" }));
            Assert.That(result[1], Is.EqualTo(new[] { "dog", "elephant", "fox" }));
        }

        [Test]
        public void ThenItTrimsWhitespaceFromRows() {
            var grid = "  1,2,3  \n  4,5,6  ";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result[0], Is.EqualTo(new[] { "1", "2", "3" }));
            Assert.That(result[1], Is.EqualTo(new[] { "4", "5", "6" }));
        }

        [Test]
        public void ThenItHandlesCarriageReturnLineFeed() {
            var grid = "a,b,c\r\nd,e,f";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { "a", "b", "c" }));
            Assert.That(result[1], Is.EqualTo(new[] { "d", "e", "f" }));
        }

        [Test]
        public void ThenItHandlesSingleRow() {
            var grid = "1,2,3,4,5";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(new[] { "1", "2", "3", "4", "5" }));
        }

        [Test]
        public void ThenItHandlesUnevenRowLengths() {
            var grid = "1,2\n3,4,5,6\n7";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(3));
            Assert.That(result[0], Is.EqualTo(new[] { "1", "2" }));
            Assert.That(result[1], Is.EqualTo(new[] { "3", "4", "5", "6" }));
            Assert.That(result[2], Is.EqualTo(new[] { "7" }));
        }

        [Test]
        public void ThenItHandlesStringArrayInput() {
            var gridRows = new[] { "10|20|30", "40|50|60" };
            var separator = "|";

            var result = TwoDArrayConverter.ConvertTo2DArray(gridRows, separator);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { "10", "20", "30" }));
            Assert.That(result[1], Is.EqualTo(new[] { "40", "50", "60" }));
        }

        [Test]
        public void ThenItRemovesEmptyEntriesFromSplit() {
            var grid = "1,,2,3\n4,5,,6";
            var separator = ",";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result[0], Is.EqualTo(new[] { "1", "2", "3" }));
            Assert.That(result[1], Is.EqualTo(new[] { "4", "5", "6" }));
        }

        [Test]
        public void ThenItHandlesSpaceSeparator() {
            var grid = "one two three\nfour five six";
            var separator = " ";

            var result = TwoDArrayConverter.ConvertTo2DArray(grid, separator);

            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(new[] { "one", "two", "three" }));
            Assert.That(result[1], Is.EqualTo(new[] { "four", "five", "six" }));
        }
    }
}
