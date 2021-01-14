using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConfigurationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var build = new ConfigurationBuilder();

            build.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "key1","value1"},
                { "key2","value2"},
                { "key3","value3"},
                { "key4","value4"},
                { "key5","value5"}
            });

            int[] arr = { 22, 23, 89, 90, 90, 67 };

            var secondValue = arr.ToList().Where(x => x < arr.Max()).OrderByDescending(x => x).FirstOrDefault();

            // Console.WriteLine(secondValue);

            IConfigurationRoot configurationRoot = build.Build();

            //Console.WriteLine(configurationRoot["key1"]);
            //Console.WriteLine(configurationRoot["key2"]);

            //Console.WriteLine("Hello World!");


            while (true)
            {
                try
                {
                    Console.WriteLine("请输入字符串：");
                    var str = Console.ReadLine();   //记录输入的数
                    if (str.ToUpper() == "Q")
                        break;

                    Console.WriteLine("字节长度:{0}", Encoding.UTF8.GetByteCount(str));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("请输入自然数,错误为{0}", ex.Message);
                }
            }

            Console.ReadKey();
        }


    }
}
