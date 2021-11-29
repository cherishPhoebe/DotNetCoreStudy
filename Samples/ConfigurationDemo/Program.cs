using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

            //var deductionList = new List<deduction>();
            //// {\"feiyongleixing\":\"维修费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"},{\"feiyongleixing\":\"违章处理费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"},{\"feiyongleixing\":\"配钥匙费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"}
            //deductionList.Add(new deduction(){ feiyongleixing = "维修费用" , feiyongjinexiaoxie  = "1000.00", feiyongjinedaxie = "壹仟元整" });
            //deductionList.Add(new deduction() { feiyongleixing = "违章处理费用", feiyongjinexiaoxie = "1000.00", feiyongjinedaxie = "壹仟元整" }); 
            //deductionList.Add(new deduction() { feiyongleixing = "配钥匙费用", feiyongjinexiaoxie = "1000.00", feiyongjinedaxie = "壹仟元整" });
            //var deductionString = JsonConvert.SerializeObject(deductionList);
            //Console.WriteLine(JsonConvert.SerializeObject(deductionList));

            var dd = JsonConvert.DeserializeObject<DeductionAgreementFormDto>("{\"yuanxieyiqiandingriqi\":\"2021-07-29\",	\"hetongbianhao\":\"合同编号\",    \"shengyuchekuandaxie\":\"贰拾壹万捌仟元整\",    \"shengyuchekuanxiaoxie\":\"218000.00\",    \"chexingyi\":\"C180L\",    \"chepai\":\"粤B09S23\",    \"ranyouleixing\":\"汽油\",    \"fadongjihaoma\":\"10632000\",    \"chejiahaoma\":\"LE4WG4AB0HL248413\",    \"jiafangxuchengdanfeiyongxiaoxie\":\"贰拾壹万捌仟\",    \"jiafangxuchengdanfeiyongdaxie\":\"218000.00\",    \"koukuanmingxi\":[{\"feiyongleixing\":\"维修费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"},{\"feiyongleixing\":\"违章处理费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"},{\"feiyongleixing\":\"配钥匙费用\",\"feiyongjinexiaoxie\":\"1000.00\",\"feiyongjinedaxie\":\"壹仟元整\"}] }");
            


            var build = new ConfigurationBuilder();

            build.AddInMemoryCollection(new Dictionary<string, string>()
            {
                { "key1","value1"},
                { "key2","value2"},
                { " key3","value3"},
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

    public class DeductionAgreementFormDto
{
    /// <summary>
    /// 车型
    /// </summary>
    public string chexingyi { get; set; }

    /// <summary>
    /// 车牌
    /// </summary>
    public string chepai { get; set; }
    /// <summary>
    /// 车架号码
    /// </summary>
    public string chejiahaoma { get; set; }
    /// <summary>
    /// 原协议签订日期
    /// </summary>
    public string yuanxieyiqiandingriqi { get; set; }
    /// <summary>
    /// 合同编号
    /// </summary>
    public string hetongbianhao { get; set; }
    /// <summary>
    /// 剩余车款小写
    /// </summary>
    public string shengyuchekuanxiaoxie { get; set; }
    /// <summary>
    /// 剩余车款大写
    /// </summary>
    public string shengyuchekuandaxie { get; set; }
    /// <summary>
    /// 甲方需承担费用小写
    /// </summary>
    public string jiafangxuchengdanfeiyongxiaoxie { get; set; }
    /// <summary>
    /// 甲方需承担费用大写
    /// </summary>
    public string jiafangxuchengdanfeiyongdaxie { get; set; }

    /// <summary>
    /// 扣款明细
    /// </summary>
    public List<DeductionDetail> koukuanmingxi { get; set; }

    /// <summary>
    /// 扣款明细文本内容
    /// </summary>
    public string koukuanmingxiwenben { get; set; }

    /// <summary>
    /// 补充协议日期
    /// </summary>
    public string buchongxieyiriqi { get; set; }

    /// <summary>
    /// 扣款明细转换
    /// </summary>
    /// <param name="koukuanmingxi"></param>
    /// <returns></returns>
    public string ConverterDeductionDetail(List<DeductionDetail> koukuanmingxi)
    {
        if (koukuanmingxi == null || koukuanmingxi.Count == 0)
            return string.Empty;

        var index = 1;
        var result = "";
        foreach (var k in koukuanmingxi)
        {
            result += $"{index++} {k.ToString()}";
        }
        return result;
    }

}

/// <summary>
/// 扣款明细实体
/// </summary>
public class DeductionDetail
{
    /// <summary>
    /// 费用类型
    /// </summary>
    public string feiyongleixing { get; set; }
    /// <summary>
    /// 费用金额（小写）
    /// </summary>
    public decimal feiyongjinexiaoxie { get; set; }
    /// <summary>
    /// 费用金额（大写）
    /// </summary>
    public string feiyongjinedaxie { get; set; }

    /// <summary>
    /// 重写ToString 方法
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return $"{this.feiyongleixing} 人民币:{this.feiyongjinedaxie} ({this.feiyongjinexiaoxie.ToString("#.00")})";
    }
}
}
