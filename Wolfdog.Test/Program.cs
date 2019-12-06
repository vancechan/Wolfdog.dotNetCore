using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.Util;
using System;

namespace Wolfdog.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            String QueuesNameESF = "queue://test.log";
            Uri _uri = new Uri(String.Concat("activemq:tcp://127.0.0.1:61616"));
            IConnectionFactory factory = new ConnectionFactory(_uri);
            using (IConnection conn = factory.CreateConnection("admin", "manager"))
            {
                using (ISession session = conn.CreateSession())
                {
                    IDestination destination = SessionUtil.GetDestination(session, QueuesNameESF);
                    using (IMessageProducer producer = session.CreateProducer(destination))
                    {
                        conn.Start();
                        //可以写入字符串，也可以是一个xml字符串等
                        ITextMessage request = session.CreateTextMessage("messsage");
                        producer.Send(request);

                    }
                }
            }

        }
    }
}
