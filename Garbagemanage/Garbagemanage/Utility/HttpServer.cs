using HttpListenerPost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HttpServer
{
    public class HttpServer
    {
        public delegate void respNoticeDelegate(Dictionary<string, string> data, HttpListenerResponse resp, string route, string request_type = "get");

        public event respNoticeDelegate respNotice;

        private HttpListener listener = new HttpListener();

        private Dictionary<string, string> actionDict = new Dictionary<string, string>();

        private ReturnDataBase respObj;

        public string curr_path = "";

        public Dictionary<string, string> data_rec = new Dictionary<string, string>();

        public HttpServer(Dictionary<string, string> routes = null)
        {
            if (routes != null)
            {
                foreach(KeyValuePair<string, string> kvp in routes)
                {
                    AddPrefixes(kvp.Key, kvp.Value);
                }
            }
        }

        public void AddPrefixes(string url, string action)
        {
            actionDict.Add(url, action);
        }

        public void close()
        {
            listener.Stop();
        }

        public void Start(int port)
        {
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("无法在当前系统上运行服务(Windows XP SP2 or Server 2003)。" + DateTime.Now.ToString());
                return;
            }

            if(actionDict.Count <= 0)
            {
                Console.WriteLine("没有监听端口");
            }

            foreach(var item in actionDict)
            {
                var url = string.Format("http://127.0.0.1:{0}{1}", port, item.Key + "/");
                Console.WriteLine(url);
                listener.Prefixes.Add(url);
            }

            listener.Start();
            listener.BeginGetContext(Result, null);
            respObj = new ReturnDataBase();

            Console.WriteLine("开始监听");
            Console.Read();
        }

        private void Result(IAsyncResult asy)
        {
            if (!listener.IsListening) return;

            listener.BeginGetContext(Result, null);
            var context = listener.EndGetContext(asy);
            var req = context.Request;
            var rsp = context.Response;


            string route = HandlerReq(req.RawUrl);


            Dictionary<string, string> data = new Dictionary<string, string>();

            data = HandleHttpMethod(context, rsp, route);

            dataNoticeEvent(data, rsp, route, context.Request.HttpMethod);

        }

        public string responseData(string content, HttpListenerResponse rsp)
        {
            try
            {
                using (var stream = rsp.OutputStream)
                {
                    rsp.StatusCode = 200;
                    rsp.ContentType = "text/html;charset=UTF-8";//告诉客户端返回的ContentType类型为纯文本格式，编码为UTF-8
                    rsp.AddHeader("Content-type", "application/json");//添加响应头信息
                    rsp.ContentEncoding = Encoding.UTF8;
                    rsp.AppendHeader("Access-Control-Allow-Origin", "*");//允许跨域
                    rsp.AppendHeader("Access-Control-Allow-Credentials", "true");
                    //后台跨域请求;//允许跨域
                    //后台跨域请求，必须配置
                    rsp.AppendHeader("Access-Control-Allow-Headers", "Authorization,Content-Type,Accept,Origin,User-Agent,DNT,Cache-Control,X-Mx-ReqToken,X-Requested-With");
                    rsp.AppendHeader("Access-Control-Max-Age", "86400");

                    byte[] dataByte = Encoding.UTF8.GetBytes(content);
                    stream.Write(dataByte, 0, dataByte.Length);

                    stream.Close();
                }
            }
            catch (Exception e) {
                rsp.Close();
                return e.Message;
            }

            rsp.Close();
            return "";
        }

        private string HandlerReq(string url)
        {
            try
            {
                Console.WriteLine("url: " + url);

                string[] arr_str = url.Split('?');

                if(arr_str.Length > 0)
                {
                    return curr_path = arr_str[0];
                }

                return "";
            }
            catch
            {
                return "";
            }
        }

        private Dictionary<string, string> HandleHttpMethod(HttpListenerContext context, HttpListenerResponse resp, string route)
        {
            Dictionary<string, string> return_data = new Dictionary<string, string>();
            data_rec.Clear();
            string contentType = context.Request.ContentType == null ? "" : context.Request.ContentType;

            if (contentType.Contains("multipart/form-data"))
            {
                HttpListenerPostParamHelper parse = new HttpListenerPostParamHelper(context);
                List<HttpListenerPostValue> list = parse.GetHttpListenerPostValue();

                foreach(HttpListenerPostValue item in list)
                {
                    string k = item.name;
                    string value = "";
                    if(item.type == 0)
                    {
                        value = Encoding.UTF8.GetString(item.datas).Replace("\r\n", "");
                    }
                    else
                    {
                        File.WriteAllBytes(@"\test.png", item.datas);
                        value = @"\text.png";
                    }
                    dataRecAdd(k, value);
                }
                return_data = data_rec;

                return return_data;
            }

            if (contentType.Contains("application/json"))
            {
                try
                {
                    Stream stream = context.Request.InputStream;
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    string json = reader.ReadToEnd();
                    Dictionary<string, string> DicContent = new Dictionary<string, string>();
                    if (string.IsNullOrEmpty(json)) return return_data;
                    if (json == "[]" || json == "") return return_data;
                    data_rec = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    return_data = data_rec;//返回的数据

                }
                catch
                {
                    return return_data;
                }
                return return_data;
            }

            switch (context.Request.HttpMethod)
            {
                case "GET":
                    var data = context.Request.QueryString;
                    // 没解决乱码问题，用url进行解析正常
                    string url = context.Request.Url.ToString();
                    string[] pars = url.Split('?');
                    string content = "";
                    if (pars.Length == 0)
                    {
                        return return_data;
                    }
                    if (pars.Length <= 1) return return_data;
                    string canshus = pars[1];
                    if (canshus.Length > 0)
                    {
                        string[] canshu = canshus.Split('&');

                        foreach (string i in canshu)
                        {
                            string[] messages = i.Split('=');
                            dataRecAdd(messages[0], messages[1]);
                            //content += "参数为：" + messages[0] + " 值为：" + messages[1];
                        }
                        return_data = data_rec;
                    }
                    return return_data;
            }

            return return_data;
        }

        public void dataRecAdd(string k, string v)
        {
            if (data_rec.ContainsKey(k))
            {
                data_rec[k] = v;
            }
            else
            {
                data_rec.Add(k, v);
            }
        }
        public void dataNoticeEvent(Dictionary<string, string> data, HttpListenerResponse rsp, string route, string method = "unknown")
        {
            respNotice?.Invoke(data, rsp, route, method);
        }
    }

    
    class ReturnDataBase
    {
        public string GetDataMain(string class_method, Dictionary<string, string> rec_data)
        {
            string[] class_arr = class_method.Split('.');

            string class_name, method;

            if (class_arr.Length == 1) class_name = class_arr[0];
            if (class_arr.Length == 2) method = class_arr[1];
            if (class_arr.Length == 0) return "";

            return "cesh";
        }
    }
}
