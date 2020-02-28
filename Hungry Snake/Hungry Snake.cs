using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hungry_Snake
{
    public partial class Hungry_Snake : Form
    {
        public Hungry_Snake()
        {
            InitializeComponent();
        }

        private void Hungry_Snake_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if(progressBar1.Value == 100)
            {
                this.timer1.Stop();
                Form1 fm = new Form1();
                fm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }
    }
}
