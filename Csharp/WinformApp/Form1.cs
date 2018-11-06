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

namespace WinformApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();  // Run Main UI Thread
        }

        // async가 없으면 디폴트로 sync라고 보면 됨. 실제로 그렇게 write하는 건 없지만.
        private async void Run()
        {
            // task1 is running in other worker thread
            var task1 = Task<int>.Run(() => LongCalcAsync(10));

            // await은 async메소드를 쓸 때 쓰임. 사실 await 안 붙여도 잘 돌아가긴 하는데.. 메쏘드에 async는 무조건 들어감.. 좀더 조사하라.
            // 계산이 끝날 때 까지 기다린 후 끝나고 나면 진행함
            // await for task1 to be finished. Once finished, then it is back to original main UI thread, then process next line
            int sum = await task1;

            // UI thread
            this.label1.Text = "Sum is " + sum;            
            this.button1.Enabled = true;
        }

        private int LongCalcAsync(int times)
        {
            // Get Worker Thread from ThreadPool to execute
            int result = 0;
            for (int i = 0; i < times; i++)
            {
                result += i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
}
