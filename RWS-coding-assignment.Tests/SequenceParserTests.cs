using RWS_coding_assigment;
using System.IO;
using System.Reflection;

namespace RWS_coding_assignment.Tests
{
    public class SequenceParserTests
    { 
        private static string GetPathForFileName(string fileName)
        {
            return Path.Combine(".", "Resources", fileName + ".txt");
        }

        [Fact]
        public void Valid_NormalSequence_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_1");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_SequenceContainsZero_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_2");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_ContainsNegativeNumber_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_3");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_ContainsWords_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_4");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_MoreWhiteSpacesNextToEachOther_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_5");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_TabWhiteSpaces_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_6");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_NewLineWhiteSpace_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_7");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_BigNumbers_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8, 23456765432, 23012234345454, 1544674499551615, 18446744073709551615 };

            var filePath = GetPathForFileName("test_file_8");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_NumberStartingWithZero_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_9");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_DigitsNextToOtherCharacters_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 8 };

            var filePath = GetPathForFileName("test_file_10");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_SpecialCharacters_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4 };

            var filePath = GetPathForFileName("test_file_11");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_EmptyFile_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { };

            var filePath = GetPathForFileName("test_file_12");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_FileWithoutNumbers_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { };

            var filePath = GetPathForFileName("test_file_13");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_JustNegativeNumbers_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { };

            var filePath = GetPathForFileName("test_file_14");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_NegativeNumersWithMinusPlacedAfterNumber_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4 };

            var filePath = GetPathForFileName("test_file_15");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Valid_LargerFile_ReturnsExpectedResult()
        {
            var expectedSequence = new List<ulong> { 1, 2, 3, 4, 5, 6, 7, 8 };

            var filePath = GetPathForFileName("test_file_16");

            Assert.Equal(expectedSequence, SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_TooBigNumber_ReturnsExpectedResult()
        {
            var filePath = GetPathForFileName("test_file_17");

            Assert.Throws<OverflowException>(() => SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_EmptyStringPath_WriteErrorMessageToOutput()
        {
            string filePath = "";

            Assert.Throws<ArgumentException>(() => SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_NullPath_WriteErrorMessageToOutput()
        {
            string filePath = null;

            Assert.Throws<ArgumentNullException>(() => SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_NotExistingFile_WriteErrorMessageToOutput()
        {
            var filePath = GetPathForFileName("not_existing_file");

            Assert.Throws<FileNotFoundException>(() => SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_WhiteSpacePath_WriteErrorMessageToOutput()
        {
            string filePath = " ";
            Assert.Throws<ArgumentException>(() => SequenceParser.Parse(filePath));
        }

        [Fact]
        public void Invalid_NotExistingPath_WriteErrorMessageToOutput()
        {
            string filePath = "dir/dir/dir/test.txt";

            Assert.Throws<DirectoryNotFoundException>(() => SequenceParser.Parse(filePath));
        }
    }
}
