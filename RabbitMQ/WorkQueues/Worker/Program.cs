using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1.创建基于本地连接的工厂
            var factory = new ConnectionFactory() { HostName = "localhost" };
            // 2.建立连接
            using (var connection = factory.CreateConnection())
            {
                // 3.创建频道
                using (var channel = connection.CreateModel())
                {
                    // 4.声明队列（指定durable:true，告知rabbitmq对消息进行持久化）
                    channel.QueueDeclare(queue: "work_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                    // 设置perfetchCount:1 告知rabbitmq，在未收到消费端的消息确认时，不再分发消息，也就确保了当消费端处于忙绿状态时，不再分配任务。
                    channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                    // 5.构造消费者实例
                    var consumer = new EventingBasicConsumer(channel);
                    // 6.绑定消息接收后的委托事件
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine(" [x] Received {0}", message);

                        // 7.模拟耗时
                        var dots = message.Split('.').Length - 1;
                        Thread.Sleep(dots * 1000);
                        Console.WriteLine(" [x] Done");

                        // 8.发送消息确认信号（手动消息确认）
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    };

                    // 9.启动消费者
                    // autoAck:true 自动消息确认，当消费端接收到消息后，自动发送ack信号，不管消息是否正确处理完成
                    // autoAck:false 管子自动消息确认。通过调用BasicAck方法手动进行消息确认
                    channel.BasicConsume(queue: "work_queue", autoAck: false, consumer: consumer);

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }

        }
    }
}
