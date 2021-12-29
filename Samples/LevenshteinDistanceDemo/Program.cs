using System;
using System.Text.RegularExpressions;

namespace LevenshteinDistanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //string str1 = "北京奔驰";
            //string str12 = "奔驰(进口)";
            //string str2 = "奔驰E级";
            //Console.WriteLine("字符串1 {0}", str1);

            //Console.WriteLine("字符串2 {0}", str2);

            //Console.WriteLine("相似度 {0} %", new LevenshteinDistance().LevenshteinDistancePercent(str1, str2) * 100);
            //Console.WriteLine("相似度 {0} %", new LevenshteinDistance().LevenshteinDistancePercent(str12, str2) * 100);

            //Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str1, str2) * 100);
            //Console.WriteLine("相似度 {0} %", SimilarityTool.CompareStrings(str12, str2) * 100);

            // 正则替换
            var inputStr = "15款/日产贵士/3.5/SL版";

            Regex r = new Regex(@"\d{2}[改]?款");
            Regex r2 = new Regex(@"/");
            var replaceStr = r.Replace(inputStr, "");
            replaceStr = r2.Replace(replaceStr, " ");
            Console.WriteLine(inputStr);
            Console.WriteLine(replaceStr);

            var inputStr2 = "19改款/奔驰E300L/2.0T/豪华版";
            var replaceStr2 = r.Replace(inputStr2, "");
            replaceStr2 = r2.Replace(replaceStr2, " ");
            Console.WriteLine(inputStr2);
            Console.WriteLine(replaceStr2);
            Console.ReadKey();

        }
    }
}
