using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace GarbageDataManage.Delivery_show
{
    public partial class Delivery_show : Form
    {
        SqlConnection myCon = new SqlConnection("Data Source=49.233.5.44;Initial Catalog=personInfo;Integrated Security=false;Pooling=False;uid=sa;password=BJUTbjut1234;database=CGQDataCenter");
        int cycleIndex = 0;
        //private Plc myPLC = null;

        public Delivery_show()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            myCon.Open();
            TimerData.Enabled = true;
        }

        private void PBoxExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PBoxExport_Click(object sender, EventArgs e)
        {
            
        }

        private void TimerData_Tick(object sender, EventArgs e)
        {
            //从数据库中获取站点垃圾桶数据
            SqlDataAdapter mySDA1 = new SqlDataAdapter("select * from garbage1 order by 投放时间 desc", myCon);
            DataSet ds = new DataSet();
            //DataTable myDT1 = new DataTable();
            mySDA1.Fill(ds);
            //int a = 0;


            try
            {
                object[] arr1 = ds.Tables[0].Rows[0].ItemArray;
                LabelName1.Text = Convert.ToString(arr1[0]);
                LabelType1.Text = Convert.ToString(arr1[1]);
                LabelWeight1.Text = Convert.ToString(arr1[2]) + "kg";
                LabelTime1.Text = Convert.ToString(arr1[3]);
                string sdd = Convert.ToString(arr1[1]);
                if (sdd == "厨余垃圾      ")
                {
                    LabelFoodRate.Text = Convert.ToString(arr1[4]) + "%";
                    LabelFoodWeight.Text = Convert.ToString(arr1[5]) + "kg";
                    LabelFoodAmount.Text = Convert.ToString(arr1[6]) + "次";
                }
                else
                {
                    LabelResidualRate.Text = Convert.ToString(arr1[4]) + "%";
                    LabelResidualWeight.Text = Convert.ToString(arr1[5]) + "kg";
                    LabelResidualAmount.Text = Convert.ToString(arr1[6]) + "次";
                }
                if (LabelName1.Text == "王小五       ")
                {
                    PBoxUser1.Image = Garbagemanage.Properties.Resources.王小五;
                }
                else
                {
                    PBoxUser1.Image = Garbagemanage.Properties.Resources.张大强;
                }
                if (LabelType1.Text == "厨余垃圾      ")
                {
                    PBoxType1.Image = Garbagemanage.Properties.Resources.厨余垃圾图标;
                }
                else
                {
                    PBoxType1.Image = Garbagemanage.Properties.Resources.其他垃圾图标;
                }
            }
            catch
            {

            }
            try
            {
                object[] arr2 = ds.Tables[0].Rows[1].ItemArray;
                LabelName2.Text = Convert.ToString(arr2[0]);
                LabelType2.Text = Convert.ToString(arr2[1]);
                LabelWeight2.Text = Convert.ToString(arr2[2]) + "kg";
                LabelTime2.Text = Convert.ToString(arr2[3]);

                if (LabelName2.Text == "王小五       ")
                {
                    PBoxUser2.Image = Garbagemanage.Properties.Resources.王小五;
                }
                else
                {
                    PBoxUser2.Image = Garbagemanage.Properties.Resources.张大强;
                }
                if (LabelType2.Text == "厨余垃圾      ")
                {
                    PBoxType2.Image = Garbagemanage.Properties.Resources.厨余垃圾图标;
                }
                else
                {
                    PBoxType2.Image = Garbagemanage.Properties.Resources.其他垃圾图标;
                }
            }
            catch
            {

            }
            try
            {
                object[] arr3 = ds.Tables[0].Rows[2].ItemArray;
                LabelName3.Text = Convert.ToString(arr3[0]);
                LabelType3.Text = Convert.ToString(arr3[1]);
                LabelWeight3.Text = Convert.ToString(arr3[2]) + "kg";
                LabelTime3.Text = Convert.ToString(arr3[3]);

                if (LabelName3.Text == "王小五       ")
                {
                    PBoxUser3.Image = Garbagemanage.Properties.Resources.王小五;
                }
                else
                {
                    PBoxUser3.Image = Garbagemanage.Properties.Resources.张大强;
                }
                if (LabelType3.Text == "厨余垃圾      ")
                {
                    PBoxType3.Image = Garbagemanage.Properties.Resources.厨余垃圾图标;
                }
                else
                {
                    PBoxType3.Image = Garbagemanage.Properties.Resources.其他垃圾图标;
                }
            }
            catch
            {

            }
            try
            {
                object[] arr4 = ds.Tables[0].Rows[3].ItemArray;
                LabelName4.Text = Convert.ToString(arr4[0]);
                LabelType4.Text = Convert.ToString(arr4[1]);
                LabelWeight4.Text = Convert.ToString(arr4[2]) + "kg";
                LabelTime4.Text = Convert.ToString(arr4[3]);

                if (LabelName4.Text == "王小五       ")
                {
                    PBoxUser4.Image = Garbagemanage.Properties.Resources.王小五;
                }
                else
                {
                    PBoxUser4.Image = Garbagemanage.Properties.Resources.张大强;
                }
                if (LabelType4.Text == "厨余垃圾      ")
                {
                    PBoxType4.Image = Garbagemanage.Properties.Resources.厨余垃圾图标;
                }
                else
                {
                    PBoxType4.Image = Garbagemanage.Properties.Resources.其他垃圾图标;
                }
            }
            catch
            {

            }


        }

        /// <summary>
        /// 延迟函数
        /// </summary>
        /// <param name="milliSecond"></param>
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            int d = 0;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                d++;
            }
        }


    }
}
