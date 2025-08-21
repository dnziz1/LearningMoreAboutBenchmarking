using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace ProperBenchmarking;
// This class is used to benchmark the performance of parsing numbers from a string.
// It uses more benchmarking attributes to measure the performance of different parsing methods.
public class ParsingNumbers
{
    private string[] numbers; // An array of numbers as a string.

    public static void Main()
    {
        var summary = BenchmarkRunner.Run<ParsingNumbers>();
    }

    [GlobalSetup]
    public void Setup()
    {
        // We need to initialize the numbers in the array
        numbers = new string[10];
        // Then we fill the array with strings of numbers
        var randomNumbers = new Random(10);
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i.ToString();
        }
    }

    [Benchmark]
    public int ParseInt()
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            sum += int.Parse(number);
        }
        return sum;
    }

    [Benchmark]
    public int TryParseInt()
    {
        int sum = 0;
        foreach (var number in numbers)
        {
            if (int.TryParse(number, out int result))
                sum += result;
        }
        return sum;
    }

}
