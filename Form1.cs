using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Bunifu.UI.WinForms;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;

namespace projectezeze
{
    public partial class Form1 : Form
    {

        int mov;
        int movx;
        int movy;
        ClassesDeProjet.GestionDesComptes GP = new ClassesDeProjet.GestionDesComptes();
        

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = guna2TextBox1;
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            


        }

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void guna2ControlBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ImageButton1_MouseDown(object sender, MouseEventArgs e)
        {
            guna2TextBox2.PasswordChar = '\0';
            guna2TextBox2.UseSystemPasswordChar = false;
        }

        private void guna2ImageButton1_MouseUp(object sender, MouseEventArgs e)
        {
            guna2TextBox2.PasswordChar = '*';
            guna2TextBox2.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            if (guna2TextBox1.Text == "")
            {
                MessageForm.Message1 M = new MessageForm.Message1("Saisir l'email", "");
                M.Show();
                return;
            }
            if (guna2TextBox2.Text == "")
            {
                MessageForm.Message1 M = new MessageForm.Message1("Saisir le mot de passe", "");
                M.Show();
                return;
            }
            if (GP.SeConnecter(guna2TextBox1.Text, guna2TextBox2.Text) != 0)
            {
                string text1 = guna2TextBox1.Text;
                string text2 = guna2TextBox2.Text;
                mainpage2 mp = new mainpage2(text1, text2);
                this.Hide();
                mp.Show();
            }
            else if(GP.Seconnecter2(guna2TextBox1.Text, guna2TextBox2.Text) != 0)
            {
                string text1 = GP.user2(guna2TextBox1.Text, guna2TextBox2.Text).Email.ToString();
                string text2 = guna2TextBox2.Text;
                mainpage2 mp = new mainpage2(text1, text2);
                this.Hide();
                mp.Show();
            }
            else
            {
                MessageForm.Message1 M = new MessageForm.Message1("Le mot de passe ou l'email est incorrecte", "");
                M.Show();
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
           
           
            if (GP.SeConnecter(guna2TextBox1.Text, guna2TextBox2.Text) != 0)
            {
                string text1 = guna2TextBox1.Text;
                string text2 = guna2TextBox2.Text;
                mainpage2 mp = new mainpage2(text1, text2);
                this.Hide();
                mp.Show();
            }
            else if (GP.Seconnecter2(guna2TextBox1.Text, guna2TextBox2.Text) != 0)
            {
                string text1 = GP.user2(guna2TextBox1.Text, guna2TextBox2.Text).Email.ToString();
                string text2 = guna2TextBox2.Text;
                mainpage2 mp = new mainpage2(text1, text2);
                this.Hide();
                mp.Show();
            }
        }
    }
}
