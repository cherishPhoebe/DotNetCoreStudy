using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo1
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime PubTime { get; set; }//发布日期
        public double Price { get; set; }//单价
        public string AuthorName { get; set; }//作者名字
    }
}
