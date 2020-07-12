using System;

namespace LevenshteinDistanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string str1 = "北京奔驰";
            string str12 = "奔驰(进口)";
            string str2 = "奔驰E级";
            Console.WriteLine("字符串1 {0}", str1);

            Console.WriteLine("字符串2 {0}", str2);

            Console.WriteLine("相似度 {0} %", new LevenshteinDistance().LevenshteinDistancePercent(str1,str2) * 100);
            Console.WriteLine("相似度 {0} %", new LevenshteinDistance().LevenshteinDistancePercent(str12, str2) * 100);

            Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str1,str2) * 100);
            Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str12,str2) * 100);

            Console.ReadKey();

        }
    }
}
