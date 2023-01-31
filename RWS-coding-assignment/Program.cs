using RWS_coding_assigment;

namespace RWS_coding_assignment
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string filepath;

            if (args.Length == 1)
            {
                filepath = args[0];
            }
            else
            {
                filepath = @"";     // need to specify the file path
            }

            List<ulong> shortestSquence;

            try
            {
                var sequence = SequenceParser.Parse(filepath);
                shortestSquence = SequenceFinder.Find(sequence, 4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (shortestSquence.Count > 0)
            {
                shortestSquence.ForEach(x => Console.Write(x + " "));
            }
            else
            {
                Console.WriteLine("No sequence found.");
            }
        }
    }
}