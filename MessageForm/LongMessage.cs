using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.UI.WinForms;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;

namespace projectezeze.MessageForm
{
    public partial class LongMessage : Form
    {
        int mov, movx, movy;
        string message;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public LongMessage(string M)
        {
            message = M;
            InitializeComponent();
        }

        private void LongMessage_Load(object sender, EventArgs e)
        {
            label1.Text = message;
        }
    }
}
