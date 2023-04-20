using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;
namespace WebSocket
{
    class Server
    {
        public void init()
        {
            var server = new WebSocketServer("ws://49.233.5.44:8080");
            Console.WriteLine("close");
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("open");
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("close");
                };
                socket.OnMessage = message =>
                {
                    Console.WriteLine(message);
                };
            });

        }
    }
}
