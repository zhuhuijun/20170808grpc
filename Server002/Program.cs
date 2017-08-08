using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Public;
using Grpc.Core;

namespace Server002
{
    public class GetUserI : GetUserList.GetUserListBase
    {
        public override Task<Userlist> GetList(pharm request, ServerCallContext context)
        {
            var users = new user();
            users.Name = "姓名";
            users.Detail = "描述";
            return Task.FromResult(new Userlist
            {
                Userinfo = users,
                No = 1
            });
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.GetEncoding("GB2312");
            Console.InputEncoding = Encoding.GetEncoding("GB2312");
            const int Port = 50051;
            Server server = new Server
            {
                Services = {
                     GetUserList.BindService(new GetUserI())
                },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            Console.WriteLine("服务已经启动!");
            server.Start();
            Console.ReadLine();
        }
    }
}