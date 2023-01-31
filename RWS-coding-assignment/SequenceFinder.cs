namespace RWS_coding_assigment
{
    /// <summary>
    /// <c>SequenceFinder</c> represents class that is intended for finding the shortest sequence in the given sequence
    /// of the numbers whose sum is divisible by given <c>divider</c> and the number of elements is at least two. If more 
    /// than one specified sequences are found, the sequence with lower sum of the numbers is returned. If more than one 
    /// specified sequences witch the same sum of numbers are found, the first of them is retunred. The class 
    /// <c>SequenceFinder</c> works with the numbers of type <c>ulong</c> that means that with positive numbers. The process
    /// of finding specified sequence is started by calling the public method <c>Find</c>.
    /// </summary>
    public static class SequenceFinder
    {
        /// <summary>
        /// Public method <c>Find</c> starts the process of the finding specified sequence. It contains whole funkcionality
        /// of the process of finding the shortest sequence divisible by given <c>divider</c>. 
        /// </summary>
        /// <param name="sequence">
        /// Parameter <c>sequence</c> of the type <c>List<ulong></c> represents original sequence that is going to be 
        /// beeing examined.
        /// </param>
        /// <param name="divider">
        /// Parameter <c>divider</c> of type <c>int</c> represents the divider by which the sum of specified sequence
        /// must be divisible.
        /// </param>
        /// <returns>
        /// Return value is the found shortest sequence of type <c>List<ulong></c> divisble by given <c>divider</c>, or
        /// empty sequence if the shortest seqence was not found.
        /// </returns>
        /// <exception cref="OverflowException">
        /// <c>OverflowException</c> is raised if overflow of the type <c>ulong</c> occures while computing the sum of 
        /// elements in subsequence.
        /// </exception>
        public static List<ulong> Find(List<ulong> sequence, int divider)
        {
            int shortestStartIndex = 0;
            int shortestCount = 0;
            ulong? shortestSum = null;

            ulong newSum;
            int newCount;

            for (int i = 0; i < sequence.Count - 1; ++i)
            {
                newSum = 0;
                newCount = 0;

                for (int j = i; j < sequence.Count; ++j)
                {
                    ++newCount;
                    try
                    {
                        checked { newSum += sequence.ElementAt(j); }
                    }
                    catch (OverflowException)
                    {
                        throw new OverflowException("Number or numbers in the file are too big for the process of finding shortest path.");
                    }
                    // checking if shortest sequence was already found
                    if (shortestSum != null)
                    {
                        // if the new sequence is not "shorter" than the already found shortest sequence, there is no reason to continue
                        if (shortestCount < newCount || shortestCount == newCount && shortestSum <= newSum)
                            break;
                    }

                    // checking if new sequence has more than one element and if sum of elements is divisible by given divider
                    if (newCount > 1 && newSum % (ulong)divider == 0)
                    {
                        shortestSum = newSum;
                        shortestCount = newCount;
                        shortestStartIndex = i;
                        break;
                    }
                }
            }
            return shortestSum == null ? new List<ulong>() : sequence.GetRange(shortestStartIndex, shortestCount);
        }
    }
}
