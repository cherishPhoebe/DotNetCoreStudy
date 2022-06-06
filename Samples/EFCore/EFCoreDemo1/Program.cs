using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreDemo1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 注入DBContext 到容器
            IServiceCollection service = new ServiceCollection();
            service.AddDbContext<MyDbContext>();

            using (var sp = service.BuildServiceProvider())
            {
                using (var dbContext = sp.GetService<MyDbContext>())
                {
                    var book = new Book();
                    book.Title = "yangzhongkejiangdotnetcore";
                    book.AuthorName = "yzk";
                    book.Price = 0;
                    book.PubTime = DateTime.Now;

                    await dbContext.Books.AddAsync(book);

                    await dbContext.SaveChangesAsync();
                }

            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
