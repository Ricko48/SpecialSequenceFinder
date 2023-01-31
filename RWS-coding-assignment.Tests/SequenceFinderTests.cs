using RWS_coding_assigment;

namespace RWS_coding_assignment.Tests
{
    public class SequenceFinderTests
    {
        private readonly int _divider = 4;

        [Fact]
        public void Valid_Empty_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>();

            var expectedResult = new List<ulong>();

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_SingleNonDivisibleNumber_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 1 };

            var expectedResult = new List<ulong>() { };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_SingleDivisibleNumber_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 4 };

            var expectedResult = new List<ulong>() { };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_TwoNumbersNonDivisible_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 1, 1 };

            var expectedResult = new List<ulong>() { };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_TwoNumbersDivisible_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 1, 3 };

            var expectedResult = new List<ulong>() { 1, 3};

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_MoreDivisibleSubsequeces_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var expectedResult = new List<ulong>() { 3, 4, 5 };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_MoreDivisibleSubsequecesWithSameLength_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 3, 4, 3, 1, 2, 2 };

            var expectedResult = new List<ulong>() { 3, 1 };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_ShortestSequenceAtTheEnd_WritesExpectedResult()
        {
            var sequence = new List<ulong>() { 3, 4, 3, 2, 2 };

            var expectedResult = new List<ulong>() { 2, 2 };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Valid_ShortestSequenceAtTheStart_ReturnsExpectedResult()
        {
            var sequence = new List<ulong>() { 2, 2, 3, 4, 2 };

            var expectedResult = new List<ulong>() { 2, 2 };

            Assert.Equal(expectedResult, SequenceFinder.Find(sequence, _divider));
        }

        [Fact]
        public void Invalid_TooBigNumber_ThrowsException()
        {
            var sequence = new List<ulong>() { 3, 4, 3, 1, 2, 18446744073709551615 };

            Assert.Throws<OverflowException>(() => SequenceFinder.Find(sequence, _divider));
        }
    }
}
