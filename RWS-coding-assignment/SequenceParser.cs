namespace RWS_coding_assigment
{
    /// <summary>
    /// <c>SequenceParser</c> is a static class for parsing sequence of numbers from file located at given <c>path</c>.
    /// Only positive numbers (0 excluded) from the file are included in the result sequence. Numbers has to
    /// be separated by whitespace and cannot be located right next to any character other than digit (otherwise
    /// are skipped by parser). Just numbers of the size <c>ulong</c> are supported. If overflow of <c>ulong</c> is
    /// detected, <c>OverflowException</c> exception is raised. The process of parsng is started by calling the public
    /// method <c>Parse</c>.
    /// </summary>
    public static class SequenceParser
    {
        /// <summary>
        /// Static method <c>Parse</c> is the public method intended for the start of the parsing process. 
        /// It reads the file with help of <c>StreamReader</c> character by character. It uses other private methods for
        /// type detection of the read character (e.g. digit, whitespace, others). If the valid number has been parsed,
        /// it is added to the resulting seuquence.
        /// </summary>
        /// <param name="path">
        /// String argument <c>path</c> represents path of the file to be parsed.
        /// </param>
        /// <returns>
        /// Return value is <c>List</c> cotaining every valid number of type <c>ulong</c> located in the file.
        /// </returns>
        public static List<ulong> Parse(string path)
        {
            var streamReader = new StreamReader(path);

            List<ulong> sequence = new();
            ulong number = 0;

            while (true)
            {
                int value = streamReader.Read();

                if (value < 0)
                {
                    if (number > 0)
                        sequence.Add(number);

                    return sequence;
                }

                char character = (char)value;

                if (IsDigit(ref number, character))
                    continue;

                if (IsWhiteSpace(ref number, sequence, character))
                    continue;

                IsOtherCharacter(ref number, streamReader);
            }
        }

        /// <summary>
        /// Private method <c>IsDigit</c> is intended for detection of the digit character read from the file.
        /// If the given character is digit, it is added at the end of the currently read number from the file.
        /// </summary>
        /// <param name="number">
        /// Reference of the <c>ulong</c> parameter <c>number</c> represents actual number that is currently 
        /// beeing parsed from the file.
        /// </param>
        /// <param name="character">
        /// Parameter <c>character</c> of type <c>char</c> represents last read character from the file.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if digit character was detected, <c>false</c> otherwise.
        /// </returns>
        /// <exception cref="OverflowException">
        /// <c>OverflowException</c> is raised if parameter <c>number</c> is overflown while performing arithmetic
        /// operations for adding new digit at the end of the number.
        /// </exception>
        private static bool IsDigit(ref ulong number, char character)
        {
            if (char.IsDigit(character))
            {
                try
                {
                    checked { number = number * 10 + ulong.Parse(character.ToString()); }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Number/numbers in sequence are too big for process of finding shortest sequence.");
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method <c>IsWhiteSpace</c> is intended for the detection of the whitespace character read from the
        /// file. If whitespace character was detected and the currently read number from the file is greater 
        /// than zero (zeroes are excluded), it is added to the resulting sequence.
        /// </summary>
        /// <param name="number">
        /// Reference of the <c>ulong</c> parameter <c>number</c> represents actual number that is currently 
        /// beeing parsed from the file.
        /// </param>
        /// <param name="sequence">
        /// Parameter <c>sequence</c> of type <c>List<ulong></c> represents resulting sequence of numbers.
        /// </param>
        /// <param name="character">
        /// <c>Char</c> type parameter <c>character</c> represents last read character from the file.
        /// </param>
        /// <returns>
        /// Returns <c>true</c> if whitespace character was detected, <c>false</c> otherwise.
        /// </returns>
        private static bool IsWhiteSpace(ref ulong number, List<ulong> sequence, char character)
        {
            if (char.IsWhiteSpace(character))
            {
                if (number > 0)
                {
                    sequence.Add(number);
                    number = 0;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method <c>IsOtherCharacter</c> is called if currently read character from the file differs from
        /// digit and whitespace. <c>number</c> representing number that is beeing currently parsed form the
        /// file, is set to 0 (because numbers located in the file right next to any character other than digit
        /// or whitespace are not valid). Then all the following characters from the file are skipped till the 
        /// next occurance of the whitespace character.
        /// </summary>
        /// <param name="number">
        /// Reference of the <c>ulong</c> parameter <c>number</c> represents actual number that is currently 
        /// beeing parsed from the file.
        /// </param>
        /// <param name="streamReader">
        /// <StreamReader> object with which the file is beeing read.
        /// </param>
        private static void IsOtherCharacter(ref ulong number, StreamReader streamReader)
        {
            number = 0;

            // skips substring till next whitespace character (or end of the file)
            while (streamReader.Peek() != -1 && !char.IsWhiteSpace((char)streamReader.Peek()))
            {
                streamReader.Read();
            }
        }
    }
}
