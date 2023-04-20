using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HttpServer;
using Newtonsoft.Json;

namespace MyHttpServer
{
    class Http
    {
        Dictionary<string, string> routes = new Dictionary<string, string>
        {
            { "/index", "IndexController" }
        };
        HttpServer.HttpServer httpServer;
        private string resp_json;

        public void init()
        {
            //启动http服务
            httpServer = new HttpServer.HttpServer(routes);//初始化，传入路由
            httpServer.respNotice += dataHandle;//回调方法，接收到http请求时触发
            httpServer.Start(12333);//端口
        }
        public void dataHandle(Dictionary<string, string> data, HttpListenerResponse resp, string route = "", string request_type = "get")
        {

            string controller = routes.ContainsKey(route) ? routes[route] : "";

            //预定义返回的json数据
            Dictionary<string, string> resp_data = new Dictionary<string, string>();
            resp_data.Add("code", "1");
            resp_data.Add("data", "");
            resp_data.Add("time", "12345");
            resp_data.Add("msg", "ok ");

            //根据路由key的val匹配相应的算法,以下是自己的逻辑
            switch (controller)
            {
                case "IndexController":
                    resp_json = JsonConvert.SerializeObject(resp_data);
                    //输出结果
                    httpServer.responseData(resp_json, resp);
                    break;
                default:
                    httpServer.responseData("404", resp);
                    break;
            }
            Console.WriteLine(resp_json);
        }

    }
}
