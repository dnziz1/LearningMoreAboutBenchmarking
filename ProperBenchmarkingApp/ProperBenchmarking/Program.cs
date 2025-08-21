//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using System.Text;

//namespace ProperBenchmarking;

//[MemoryDiagnoser]

//public class Program
//{
//    int iterations = 1_000;
//    public static void Main()
//    {
//        var summary = BenchmarkRunner.Run<Program>();
//    }

//    [Benchmark]
//    public void SlowTool()
//    {
//        string name = "";
//        for (int i = 0; i < iterations; i++)
//        {
//            name += i;
//        }
//    }

//    [Benchmark]
//    public void QuickTool()
//    {
//        StringBuilder sb = new StringBuilder();
//        for (int i = 0; i < iterations; i++)
//        {
//            sb.Append(i);
//        }
//    }
//}
//// When benchmarking switch debug to release mode 