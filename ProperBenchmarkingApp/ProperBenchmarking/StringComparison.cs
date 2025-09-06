using BenchmarkDotNet.Attributes;

namespace ProperBenchmarking;
// This class is intended to benchmark the performance of different methods of string comparison
// 
public class StringComparison
{
    private string word1;
    private string word2;

    private string[] storedStrings;
    public static void Main()
    {
        var summary = BenchmarkDotNet.Running.BenchmarkRunner.Run<StringComparison>();
    }

    [GlobalSetup]
    public void Setup()
    {
        // Initialize the strings to be compared
        word1 = "HelloWorld!";
        word2 = "helloworld!";
    }

    // Benchmarking method for comparing strings using ToLower
    [Benchmark]
    public bool EqualsToLower()
    {
        return word1.ToLower() == word2.ToLower();
    }

    // Benchmarking method for comparing strings using ToUpper
    [Benchmark]
    public bool EqualsToUpper()
    {
        return word1.ToUpper() == word2.ToUpper();
    }


    // Benchmarking method for comparing strings using OrdinalIgnoreCase
    [Benchmark]
    public bool EqualsOrdinal()
    {
        return string.Equals(word1, word2, System.StringComparison.OrdinalIgnoreCase);
    }

    // Benchmarking method for comparing strings using array of stored strings, array.sort and binary search
    [Benchmark]
    public bool EqualsUsingArray()
    {
        storedStrings = new string[] { "Derek", "Scott", "Lydia", "Alison", "Peter" };
        Array.Sort(storedStrings, StringComparer.OrdinalIgnoreCase);
        return Array.BinarySearch(storedStrings, word1, StringComparer.OrdinalIgnoreCase) >= 0;
    }

    [Benchmark]
    public bool EqualsUsingHashSet()
    {
        storedStrings = new string[] { "Derek", "Scott", "Lydia", "Alison", "Peter" };
        var hashSet = new HashSet<string>(storedStrings, StringComparer.OrdinalIgnoreCase);
        return hashSet.Contains(word1);
    }
}
