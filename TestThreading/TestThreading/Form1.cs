using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace TestThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ترد من به اشیا روی فرمم دسترسی داشته باشه
            CheckForIllegalCrossThreadCalls = false; 
        }
        private void MyThread()
        {
            while (true)
            {
                listBox1.Items.Add("Item" + listBox1.Items.Count.ToString());
                Thread.Sleep(100);
            }
        }
        private void MyThread2()
        {
            while (true)
            {
                listBox2.Items.Add("Item" + listBox2.Items.Count.ToString());
                Thread.Sleep(100);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(MyThread);
            Thread tr = new Thread(ts);
            tr.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(MyThread2);
            Thread tr = new Thread(ts);
            tr.Start();
        }
        private void txtinput(object o)
        {
            TextBox tx =(TextBox)o;
            tx.Text = "hiii";
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Thread tr = new Thread(txtinput);
            tr.Start(textBox1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
            Application.Exit();
        }
    }
}
