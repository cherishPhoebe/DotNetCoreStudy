using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

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


            IConfigurationRoot configurationRoot = build.Build();

            //Console.WriteLine(configurationRoot["key1"]);
            //Console.WriteLine(configurationRoot["key2"]);

            //Console.WriteLine("Hello World!");


            Console.ReadKey();
        }


    }
}
