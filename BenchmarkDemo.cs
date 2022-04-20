using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

namespace BenchmarkExample
{
    // To get the benchmarks you need to select the "Start Without Debugging" menu option from the Debug menu.
    [MemoryDiagnoser]
    public class BenchmarkDemo
    {
        // Constant interpolation.
        private const String CompanyName  = "Enrich Others";
        private const String Products = "unwanted stuff:";
        private const String CompanyDescription = $"The {CompanyName} app finds a second home for your {Products}.";

        [Benchmark(Baseline = true)]
        public string GetFullStringNormally()
        {
            string output = "";
            for(int i = 0; i < 100; ++i)
            {
                output += i;
            }
            return output;
        }

        [Benchmark]
        public string GetFullStringWithStringBuilder()
        {
            StringBuilder output = new(CompanyDescription);
            for (int i = 0; i < 100; ++i)
            {
                output.Append(i);
            }
            return output.ToString();
        }

        public static void Main() => _ = BenchmarkRunner.Run<BenchmarkDemo>();
    }
}
