using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GUIJ;
using MathWorks.MATLAB.NET.Arrays;
using System.Collections;
using GMap.NET.ObjectModel;
using System.Data.SqlTypes;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using Garbagemanage.Map;

namespace Garbagemanage.Map
{
    public partial class Map : Form
    {
        // 发起 http 请求，固定的格式不需要改动
        public int HttpGet(string url, out string result)
        {
            result = "";
            try
            {
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Proxy = null;
                wbRequest.Method = "GET";
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        result = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception e)
            {
                result = e.Message;     //输出捕获到的异常，用OUT关键字输出
                return -1;              //出现异常，函数的返回值为-1
            }
            return 0;
        }
        public Map()
        {
            InitializeComponent();
        }
        private List<PointLatLng> get_route(string type, PointLatLng start, PointLatLng end)
        {
            string url = "https://restapi.amap.com/v3/direction/" + type + "?origin="
                + Convert.ToString(start.Lng) + "," + Convert.ToString(start.Lat)
                + "&destination=" + Convert.ToString(end.Lng) + "," + Convert.ToString(end.Lat)
                + "&key=b63947d1bbd538da7dba740a09f28f45";

            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(start);

            string res = "";
            this.HttpGet(url, out res);                     // 调用 高德地图 api

            JObject json = JObject.Parse(res);
            //Console.WriteLine(json);

            JArray jarr = (JArray)json["route"]["paths"];   // 将每一步的坐标点放在 List 中
            foreach (var obj in jarr)
            {
                JObject json_object = (JObject)obj;
                JArray steps = (JArray)json_object["steps"];
                foreach (var step in steps)
                {
                    JObject json_step = (JObject)step;
                    string polyline = json_step["polyline"].ToString();
                    double lng = 0, lat = 0;
                    string ress = "";
                    // polyline -> "xx.xxxx,xx.xxxx; ...."
                    foreach (var ch in polyline)
                    {
                        if (ch == ' ') continue;
                        if (ch == ';')
                        {
                            lat = Double.Parse(ress);
                            points.Add(new PointLatLng(lat, lng));
                            lng = 0;
                            lat = 0;
                            ress = "";
                            continue;
                        }
                        if (ch == ',')
                        {
                            lng = Double.Parse(ress);
                            ress = "";
                            continue;
                        }
                        ress += ch;
                    }
                    if (!"".Equals(ress))
                    {
                        lat = Double.Parse(ress);
                        ress = "";
                        points.Add(new PointLatLng(lat, lng));
                    }
                }
            }

            points.Add(end);
            return points;
        }


        /**
          * @comment 地图缩放尺寸更改事件函数
          */
        private void OnMapZoomChanged()
        {
          
            // 更新 marker 数据
            _mutexLock.WaitOne();
            try
            {
                if (gMapControl1 == null || gMapControl1.Overlays == null) return;
                gMapControl1.Overlays.Clear();

                if(allDefaultMarker != null)
                    foreach (var x in allDefaultMarker)     // 将所有非自定义 marker 放回遮罩层
                    {
                        Overlay_default.Markers.Add(x);
                    }
                if (customMakersManagers != null)
                    foreach (var manager in customMakersManagers)
                    {
                        manager.refresh_markers(Overlay_custom, gMapControl1, 0);
                    }
                gMapControl1.Overlays.Add(Overlay_default);
                gMapControl1.Overlays.Add(Overlay_custom);
            }
            catch (Exception e)
            {
                throw e;

            }
            finally
            {
                _mutexLock.ReleaseMutex();
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.gMapControl1.MapProvider = AMapProvider.Instance;

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.MinZoom = 4;      //最小比例
            gMapControl1.MaxZoom = 18;     //最大比例
            gMapControl1.Zoom = 16;        //当前比例
            gMapControl1.ShowCenter = false;//不显示中心十字标记
            this.gMapControl1.DragButton = System.Windows.Forms.MouseButtons.Left;//左键拖拽地图
            gMapControl1.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;//鼠标缩放模式
            gMapControl1.Position = new PointLatLng(39.875357, 116.480595);//地图中心坐标，（纬度，经度）
            
            //将各个坐标加到数组中
            list.Add(start1);
            list.Add(start2);
            list.Add(start3);
            list.Add(start4);
            list.Add(start5);
            list.Add(start6);
            list.Add(start7);
            list.Add(start8);
            list.Add(start9);
            list.Add(start10);
            list.Add(start11);
            list.Add(start12);
            list.Add(start13);
            list.Add(start14);
            list.Add(start15);
            list.Add(start16);
            list.Add(start17);
            gMapMarker = new GMarkerGoogle(list[0], GMarkerGoogleType.green);
            
        }
        private void initActiveCustomMarker()
        {
            activeCustomMarker = new ActiveCustomMarker("./resources/static/car.png");
            activeCustomMarker.SetInterval(20);
            activeCustomMarker.SetTimeout(800);
            customMakersManagers[0].Add(activeCustomMarker);
        }
        private void initStaticCustomMarker()
        {
            staticCustomMarker = new StaticCustomMarker("./resources/static/car.png");        // 获取图片信息
            staticCustomMarker.setStart(list[0]);
            customMakersManagers[0].Add(staticCustomMarker);
        }
        /**
         * @create 2023-03-24
         * @comment 间隔一段事件刷新所有 marker 的数据
         */
        private void timer_tick(object sender, EventArgs e)
        {
            _mutexLock.WaitOne();
            try
            {
                Overlay_default.Markers.Clear();
                Overlay_custom.Markers.Clear();
                foreach (var x in allDefaultMarker)     // 将所有非自定义 marker 放回遮罩层
                {
                    Overlay_default.Markers.Add(x);
                }
                foreach (var manager in customMakersManagers)
                {
                    manager.refresh_markers(Overlay_custom, gMapControl1, timer_clock);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _mutexLock.ReleaseMutex();
            }

        }
        List<PointLatLng> list = new List<PointLatLng>();
        PointLatLng start1 = new PointLatLng(39.8790081762767, 116.479722261429);  //路径起点
        PointLatLng start2 = new PointLatLng(39.8784400755337, 116.478842496872);
        PointLatLng start3 = new PointLatLng(39.8790287595486, 116.478842496872);
        PointLatLng start4 = new PointLatLng(39.8773491442446, 116.478418707848);
        PointLatLng start5 = new PointLatLng(39.8773985452818, 116.480462551117);
        PointLatLng start6 = new PointLatLng(39.8769745185537, 116.478842496872);
        PointLatLng start7 = new PointLatLng(39.8747020199575, 116.479121446609);
        PointLatLng start8 = new PointLatLng(39.8752660347863, 116.481181383133);
        PointLatLng start9 = new PointLatLng(39.875274268545,  116.479690074921);
        PointLatLng start10 = new PointLatLng(39.8738456966063,116.482136249542);
        PointLatLng start11 = new PointLatLng(39.8733969459655,116.4788210392);
        PointLatLng start12 = new PointLatLng(39.8769580514434,116.48064494133);
        PointLatLng start13 = new PointLatLng(39.8762828965173,116.484099626541);
        PointLatLng start14 = new PointLatLng(39.8729152562307,116.483402252197);
        PointLatLng start15 = new PointLatLng(39.8746320323925,116.482393741608);
        PointLatLng start16 = new PointLatLng(39.8786459096799,116.482484936714);
        PointLatLng start17 = new PointLatLng(39.8721659543639,116.48200750351);
        private void button1_Click(object sender, EventArgs e)
        {
            //应用matlab算法
            //Class1 demo = new Class1();
            //demo.GUIJ();
            //调用算法生成的文件
            int u1 = 0;
            string tt1 = "";
            string tt2 = "";
            while(true)
            {
                for (int k = 0; k < arry[u1].Length-1; k++)
                {
                    if (u1 == 0)
                    {
                        tt1 += arry[u1][k] + "->";
                        label4.Text = "0->" + tt1 + "0";
                    }
                    if (u1 == 1)
                    {
                        tt2 += arry[u1][k] + "->";
                        label6.Text = "0->" + tt2 + "0";
                    }
                    label2.Text = u1 + 1 + "辆清运车";
                }
                u1++;
                if (u1 == j)
                    break;
            }
            //调取results1中的行驶距离数据
            string path = "./resources/results/results1.txt";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("GB2312"));
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return;
            }
            while (true)
            {
                // 从上到下读取每一行数据
                string line = sr.ReadLine();
                if (line == string.Empty || line == null) break;
                char[] separator = { '\t' };
                string[] data = line.Split(separator);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Trim() != string.Empty)
                    {
                        // 保存当前行的每一列数据
                        mydata1.Add(data[i].Trim());
                    }
                }
            }
            //行驶距离显示
            if(mydata1.Count==1)
            {
                label18.Text = mydata1[0] + "米";
                label12.Text = mydata1[0] + "米";
            }
            if(mydata1.Count==2)
            {
                label18.Text = mydata1[0] + "米";
                label20.Text = mydata1[1] + "米";
                label12.Text = Convert.ToInt32(mydata1[0]) + Convert.ToInt32(mydata1[1]) + "米";
            }
            if(mydata1.Count==3)
            {
                label18.Text = mydata1[0] + "米";
                label20.Text = mydata1[1] + "米";
                label22.Text = mydata1[2] + "米";
                label12.Text = Convert.ToInt32(mydata1[0]) + Convert.ToInt32(mydata1[1]) + Convert.ToInt32(mydata1[2])+ "米";
            }
            if (mydata1.Count == 4)
            {
                label18.Text = mydata1[0] + "米";
                label20.Text = mydata1[1] + "米";
                label22.Text = mydata1[2] + "米";
                label24.Text = mydata1[3] + "米";
                label12.Text = Convert.ToInt32(mydata1[0]) + Convert.ToInt32(mydata1[1]) +Convert.ToInt32(mydata1[2]) + Convert.ToInt32(mydata1[3])+"米";
            }
            //1辆清运车时lable显示
            if (j==1)
            {
                label3.Visible = true;
                label4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                button2.Visible = true;
            }
            //2辆清运车时lable显示
            if(j==2)
            {
                //路径1
                label3.Visible = true;
                label4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                button2.Visible = true;
                //路径二
                label5.Visible = true;
                label6.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                button3.Visible = true;
            }
            //3辆清运车时lable显示
            if(j==3)
            {
                //路径1
                label3.Visible = true;
                label4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                button2.Visible = true;
                //路径二
                label5.Visible = true;
                label6.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                button3.Visible = true;
                //路径三
                label7.Visible = true;
                label8.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                button4.Visible = true;
            }
            //4辆清运车时lable显示
            if(j==4)
            {
                //路径1
                label3.Visible = true;
                label4.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
                button2.Visible = true;
                //路径二
                label5.Visible = true;
                label6.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                button3.Visible = true;
                //路径三
                label7.Visible = true;
                label8.Visible = true;
                label21.Visible = true;
                label22.Visible = true;
                button4.Visible = true;
                //路径四
                label9.Visible = true;
                label10.Visible = true;
                label23.Visible = true;
                label24.Visible = true;
            }
            label11.Visible = true;
            label12.Visible = true;
        }
        /// <summary>
        /// 轨迹划线
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        public List<PointLatLng> get_routes(PointLatLng a1, PointLatLng a2, Color clr)
        {
            gMapMarker = new GMarkerGoogle(list[0], GMarkerGoogleType.green);
            allDefaultMarker.Add(gMapMarker);
            Overlay_default.Markers.Add(gMapMarker);
            gMapControl1.Overlays.Add(Overlay_default);
            List<PointLatLng> points = get_route("driving", a1, a2);
            GMapRoute r = new GMapRoute(points, null);
            Overlay_default.Routes.Add(r);           //向图层中添加道路
            gMapControl1.Overlays.Add(Overlay_default);      //向控件中添加图层   
            r.Stroke.Width = 3;                  //路径宽度
            r.Stroke.Color = clr;          //路径颜色
            return points;
        }
        
        /// <summary>
        /// 图标设置
        /// </summary>
        /// <param name="a"></param>
        public void get_TuBiao(PointLatLng a)
        {
            GMapMarker marker = new GMarkerGoogle(a, GMarkerGoogleType.red);
            Overlay_default.Markers.Add(marker);
            allDefaultMarker.Add(marker);
            GMapMarker gMapMarker = new GMarkerGoogle(start1, GMarkerGoogleType.pink);//垃圾中心标注
            Overlay_default.Markers.Add(gMapMarker);
            allDefaultMarker.Add(gMapMarker);
        }
        /// <summary>
        /// 图标设置
        /// </summary>
        /// <param name="a"></param>
        public void get_TB(PointLatLng a, GMarkerGoogleType clr)
        {
            GMapMarker marker1 = new GMarkerGoogle(a, clr);
            Overlay_default.Markers.Add(marker1);
            allDefaultMarker.Add(marker1);
            gMapControl1.Overlays.Add(Overlay_default);
        }
        
       
        /**
         * @create 2023-03-23
         * @comment 把一些变量从 form_load 中拿出来了，为了在监听函数中使用
         */
        
        private static int timer_clock = 20;                                    // 确定计时器的周期
        private ObservableCollectionThreadSafe<GMapMarker> allDefaultMarker;    // 保存非自定义 Marker 的 Marker
        private StaticCustomMarker staticCustomMarker;
        private GMapMarker gMapMarker;
        private Timer timer;
        private List<CustomMakersManager> customMakersManagers;
        private ActiveCustomMarker activeCustomMarker;
        protected readonly Mutex _mutexLock = new Mutex();
        ArrayList mydata = new ArrayList();
        ArrayList mydata1 = new ArrayList();
        List<int> arr1 = new List<int>();
        string[][] arry = new string[10][];
        int j = 0;
        int[] are = new int[10];
        private void routes_click(int a, int b, int ra, int rb, int _ra, int _rb)
        {
            Overlay_default.Clear();
            Overlay_custom.Clear();
            Overlay_custom.Markers.Clear();
            gMapControl1.Overlays.Clear();
            allDefaultMarker.Clear();
            List<PointLatLng> points = new List<PointLatLng>();
            while (true)
            {
                if (a >= j)
                {
                    break;
                }
                string C = arry[a][b];
                if (arry[a][b] == "")
                {
                    break;
                }
                else
                {
                    b++;
                }
                int d = Convert.ToInt32(C);
                are[b - 1] = d;
                if (b == rb && a == ra)
                {
                    get_TuBiao(list[d]);
                    points.AddRange(get_routes(list[0], list[d], Color.Blue));
                    if (arry[a][b] == "")
                    {
                        points.AddRange(get_routes(list[d], list[0], Color.Blue));
                        //a++;
                        b = 0;
                        break;
                    }
                }
                else if (b > _rb && a == _ra)
                {
                    get_TuBiao(list[d]);
                    points.AddRange(get_routes(list[are[b - 2]], list[d], Color.Blue));
                    if (arry[a][b] == "")
                    {
                        points.AddRange(get_routes(list[d], list[0], Color.Blue));
                        //a++;
                        b = 0;
                        break;
                    }
                }
            }
            customMakersManagers = new List<CustomMakersManager>();
            customMakersManagers.Add(new CustomMakersManager(points));
            initStaticCustomMarker();
            initActiveCustomMarker();


            gMapControl1.Overlays.Add(Overlay_default);
            foreach (var manager in customMakersManagers)
            {
                manager.refresh_markers(Overlay_custom, gMapControl1, 0);
            }
            gMapControl1.Overlays.Add(Overlay_custom);
            /**
             * @comment 计时器 
             */
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = timer_clock;
            timer.Tick += new EventHandler(timer_tick);
            timer.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            routes_click(1, 0, 1, 1, 1, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            routes_click(2, 0, 2, 0, 2, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            routes_click(3, 0, 3, 0, 3, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //应用matlab算法
            //调用算法生成的文件
            string path = "./resources/results/results.txt";
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("GB2312"));
            }catch(FileLoadException ex)
            {
                Console.WriteLine(ex.StackTrace);
                return;
            }
            
            char[] KG = { ' ' };
            while (true)
            {
                // 从上到下读取每一行数据
                string line = sr.ReadLine();
                if (line == string.Empty || line == null) break;
                char[] separator = { '\t' };
                string[] data = line.Split(separator);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i].Trim() != string.Empty)
                    {
                        // 保存当前行的每一列数据
                        mydata.Add(data[i].Trim());
                        arry[j] = data[0].Split(KG);
                        for(int a = 0; a < arry[j].Length - 1; a++)
                        {
                        arr1.Add(Convert.ToInt32(arry[j][a]));
                        }

                    }
                }
                j++;
            }
            //地图加载时显示各个站点的图标位置
            for (int i = 0; i < list.Count - 1; i++)
            {
                get_TB(list[i + 1], GMarkerGoogleType.red);
            }
            //删除数组中桶满的垃圾站点
            int[] arr2 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16};
            //将arr2数组中与arr1重复的删除
            for (int k = 0; k < arr1.Count; k++)
            {
                arr2 = Array.FindAll(arr2, i => i != arr1[k]).ToArray();
            }
            Random random = new Random();
            int R = random.Next(2, 5);
            int[] rand = Enumerable.Range(0, R).OrderBy(t => Guid.NewGuid()).Take(R).ToArray();
            for(int k = 0; k < rand.Length; k++)
            {
                get_TB(list[arr2[rand[k]]], GMarkerGoogleType.blue);           //蓝色标注显示
                arr2 = Array.FindAll(arr2, i => i != arr2[rand[k]]).ToArray();
            }
            for (int k = 0; k < arr2.Length; k++)
            {
                get_TB(list[arr2[k]], GMarkerGoogleType.green);             //绿色标注显示
            }
            //站点个数显示
            label14.Text = arr1.Count + "个";
            label15.Text = arr2.Length + "个";
            label16.Text = rand.Length + "个";

        }
        private void button2_Click(object sender, EventArgs e)
        {

            routes_click(0, 0, 0, 1, 0, 1);
        }

    }
}
