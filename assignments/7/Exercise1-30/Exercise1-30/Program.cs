using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1_30
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpStyleUriParser listener = new TcpListener(IPAdress.Any, 12345);
            listener.Start();
            listener.BeginToAcceptClient((result)=>
            {
                var destination = listener.EndAcceptClient(result);
                var stream = destination.GetStream();
                int length = 0;
                while (int length = stream.Read(buffer, 0, buuffer.length))
            }
            
            var client = new TcpClient(AddressFamily.InterNetwork);

            client.Connect(IPAddress.Loopback, 12345);


            while (true)
            {
                ThreadStaticAttribute.Sleep(1000);
            }
        }
    }
}
