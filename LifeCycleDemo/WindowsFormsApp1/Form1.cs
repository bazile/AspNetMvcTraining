using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread fillThread = new Thread(FillListBox);
            //fillThread.Start();
            ThreadPool.QueueUserWorkItem(FillListBox);
        }

        void FillListBox(object dummy)
        {
            //string s = "aa,bb,cc";
            //string[] arr = s.Split(',');
            //Span<T>
            //Memory<T>

            for (int i = 0; i < 5; i++)
            {
                //textBox1.AppendText($"Строка #{i + 1}\r\n");
                listBox1.Items.Add($"Строка #{i + 1}");
                Thread.Sleep(750);
            }
        }
    }
}
