using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Drawing;
using Guna.UI2.WinForms;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.UI.WinForms;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;

namespace projectezeze
{
    public partial class mainpage2 : Form
    {
        int mov;
        int movx;
        int movy;
        //Historique.MainHistorique H;
  
        string SeConnecterText1, SeConnecterText2;     //get texts of EmailText and passwordText
        ClassesDeProjet.GestionDesComptes gc = new ClassesDeProjet.GestionDesComptes();
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();


        public mainpage2(string text1,string text2)
        {

            InitializeComponent();
            this.SeConnecterText1 = text1;
            this.SeConnecterText2 =text2 ;
        }
        public mainpage2()
        {
            InitializeComponent();
        }

        public void addForm(UserControl F )
        {
            F.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(F);
            F.BringToFront();
        }
        private void mainpage2_Load(object sender, EventArgs e)
        {
            TableauBord.MaintableauBord2 tb = new TableauBord.MaintableauBord2();
            addForm(tb);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }


      
        
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            GestionStagiaires.MainStagiaires s = new GestionStagiaires.MainStagiaires();
            addForm(s);
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            Historique.MainHistorique m = new Historique.MainHistorique();
            addForm(m);
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            this.Close();     
            Application.Exit();

        }
     


        private void guna2Button3_Click(object sender, EventArgs e)
        {
            GestionStagiaires.MainStagiaires m = new GestionStagiaires.MainStagiaires(SeConnecterText1, SeConnecterText2);
            addForm(m);
            if (panel1.Width <100)
            {
                return;
            }
            if (panel1.Width >100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y= panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;



            
        }
        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            Historique.MainHistorique h = new Historique.MainHistorique(SeConnecterText1,SeConnecterText2);
            addForm(h);
            if (panel1.Width < 100)
            {
                return;
            }
            if (panel1.Width > 100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f = new Form1();
            f.guna2TextBox1.Text = SeConnecterText1;
            f.Show();
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel1.Width <100)
            {
                TableauBord.MaintableauBord2 m1 = new TableauBord.MaintableauBord2();
                addForm(m1);

            }
            else
            {
                
                //panel1.Width = 236;
                //int x = panel4.Size.Width;
                //int y = panel4.Size.Height;
                //panel4.Size = new Size(x - 162, y);
                //panel4.Location = new Point(panel4.Location.X + 162, panel4.Location.Y);
                //guna2ImageButton1.Visible = false;
            }


            //TableauBord.MaintableauBord m = new TableauBord.MaintableauBord();
            //addForm(m);
            //if (panel1.Width == 236)
            //{
            //    return;
            //}
            //panel1.Width = 236;
            //int x = panel4.Size.Width;
            //int y = panel4.Size.Height;
            //panel4.Size = new Size(x - 162, y);
            //panel4.Location = new Point(panel4.Location.X + 162, panel4.Location.Y);
            //guna2ImageButton1.Visible = false;


            //panel1.Width = 73;
            //int x = panel4.Size.Width;
            //int y = panel4.Size.Height;
            //panel4.Size = new Size(x + 162, y);
            //panel4.Location = new Point(panel4.Location.X - 162, panel4.Location.Y);
            //guna2ImageButton1.Visible = true;
        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {
            Tache.Maintaches m = new Tache.Maintaches(SeConnecterText1,SeConnecterText2);
            addForm(m);
            if (panel1.Width < 100)
            {
                return;
            }
            if (panel1.Width > 100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;
        }

        private void guna2Button9_Click_1(object sender, EventArgs e)
        {
            
            GestionDesComptes.MainCompte m = new GestionDesComptes.MainCompte(SeConnecterText1,SeConnecterText2);
            addForm(m);
            if (gc.SeConnecter(SeConnecterText1, SeConnecterText2) == 1)
            {
                guna2Button8.Visible = true;
            }
            if (panel1.Width < 100)
            {
                return;
            }
            if (panel1.Width > 100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Stage.MainStage ms = new Stage.MainStage(SeConnecterText1,SeConnecterText2);
            addForm(ms);
            if (panel1.Width < 100)
            {
                return;
            }
            if (panel1.Width > 100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            Absence.MainAbsence ma = new Absence.MainAbsence(SeConnecterText1,SeConnecterText2);
            addForm(ma);
            if (panel1.Width < 100)
            {
                return;
            }
            if (panel1.Width > 100)
            {
                guna2ImageButton1.Visible = false;
            }
            panel1.Width = 57;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x + 132, y);
            panel4.Location = new Point(panel4.Location.X - 132, panel4.Location.Y);
            guna2ImageButton1.Visible = true;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            if (panel1.Width >100)
            {
                return;
            }
            panel1.Width = 188;
            int x = panel4.Size.Width;
            int y = panel4.Size.Height;
            panel4.Size = new Size(x - 132, y);
            panel4.Location = new Point(panel4.Location.X + 132, panel4.Location.Y);
            guna2ImageButton1.Visible = false;
            guna2Button1.Checked = true;
          

        }

        private void guna2Button8_Click_2(object sender, EventArgs e)
        {
            Role.Role r = new Role.Role();
            r.ShowDialog();
        }

      

       



    }
}
