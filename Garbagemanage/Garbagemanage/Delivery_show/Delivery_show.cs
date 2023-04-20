using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Websocket.Client;

namespace Garbagemanage.Delivery_show
{
    public partial class Delivery_show : Form
    {
        public Delivery_show()
        {
            InitializeComponent();

        }

        public static void get_parent(frmMain frm)
        {
            f = frm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string new_str = "向清运人员发送清运任务" + "具体内容：前往 x 站点进行垃圾清运工作\n";
            textBox1.Text += new_str;
           
            JObject json = new JObject();
            json["origin"] = "platform";
            json["message"] = new_str;
            
            Console.WriteLine(json.ToString());
            f.FunStartmain(json.ToString(), "platform");

        }
        private static frmMain f;






    }
}
