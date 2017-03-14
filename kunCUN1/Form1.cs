using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kunCUN1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rand;
        int shijian = 0; //时间
        int kuCun = 60; //库存
        int maxS = 60; //最大库存
        int minS = 20; //最小库存
        int xuqiuliang = 0; //需求量
        int dinghuoliang= 0; //订货量
        int yuechuKucun =60;//月初库存
        int p = 0;
        int sumKucunChengben; //总库存成本

        void KucunPandian()   //库存盘点
        {
            if (kuCun < minS)
            {
                dinghuoliang = maxS - kuCun;
                kuCun = maxS;
            }
            shijian += 1;
            yuechuKucun = kuCun;
        }

        void xuqiu() //需求
        {
           // shijian += 1;
            rand = new Random() ;
            int suijishu = rand.Next(0, 6);
            if (suijishu > 0 && suijishu < 1) { xuqiuliang = 1; }
            if (suijishu > 1 && suijishu < 3) { xuqiuliang = 2; }
            if (suijishu > 3 && suijishu < 5) { xuqiuliang = 3; }
            if (suijishu > 5 && suijishu < 6) { xuqiuliang = 4; }
        }

        void chuhuo() //出货
        {
            if (xuqiuliang < yuechuKucun)
            {
                kuCun = yuechuKucun - xuqiuliang;
            }
            if (xuqiuliang > yuechuKucun)
            {
                p = xuqiuliang - yuechuKucun;
            }
        }

        void kucunChengben() //库存成本
        {
            if (yuechuKucun > 0)
            {
                sumKucunChengben += yuechuKucun * 1;
            }
            if(yuechuKucun<0)
            {
                sumKucunChengben += p * 5;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           for (int i=0;i<200;i++)
            {
                KucunPandian();
                xuqiu();
                chuhuo();
                kucunChengben();
                StreamWriter sw = File.AppendText("d:\\zw.txt");
                string w = "时间:"+shijian.ToString() +"   " +"库存："+kuCun.ToString()+"   总库存成本"+sumKucunChengben.ToString()+"\r\n";
                sw.Write(w);
                sw.Close();
            }
        }
    }
}
