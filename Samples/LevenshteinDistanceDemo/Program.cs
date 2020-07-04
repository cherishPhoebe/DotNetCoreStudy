using System;

namespace LevenshteinDistanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string str1 = "2009款 宝马X5自动G特别版 1.6L";
            string str12 = "2009款 X5自动G特别版 1.6L";
            string str2 = "X509款";
            Console.WriteLine("字符串1 {0}", str1);

            Console.WriteLine("字符串2 {0}", str2);

            Console.WriteLine("相似度 {0} %", new LevenshteinDistance().LevenshteinDistancePercent(str2, str1) * 100);

            Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str2, str1) * 100);
            Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str2, str12) * 100);

            Console.ReadKey();

        }
    }
}
