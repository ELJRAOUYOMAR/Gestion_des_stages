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

namespace projectezeze.GestionStagiaires
{
    public partial class SupprimerStagiaire : Form
    {
        int mov, movx, movy;
        GestionStagiaires.MainStagiaires Main;
        int id;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        string email, password;          //mainStagaire(supprimer)
        public SupprimerStagiaire()
        {
            InitializeComponent();
        }
        public SupprimerStagiaire(MainStagiaires ms,int ID,string e,string p)
        {
            InitializeComponent();
            id = ID;
            Main = ms;
            email = e;
            password = p;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var req = gs.Stagiaire.FirstOrDefault(x => x.IdStagiaire == id);
                var req1 = gs.Stage.Where(x => x.IdStagiaire == id);
                var req2 = gs.Absence.Where(x => x.Stage.Stagiaire.IdStagiaire == id);
                if (req != null)
                {
                    foreach (var i in req1)
                    {
                        gs.Stage.Remove(i);
                    }
                    foreach (var i in req2)
                    {
                        gs.Absence.Remove(i);
                    }
                    gs.Stagiaire.Remove(req);
                    gs.SaveChanges();
                    Main.dataGridView1.DataSource = gs.Stagiaire.ToList();
                    Main.dataGridView1.Columns[8].Visible = false;
                    this.Close();
                    int idUtilisateur = GC.user(email, password).IdUtilisateur;
                    GC.ajouterAction("Suppression d'un stagaire", idUtilisateur);
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", ""); m.ShowDialog();
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Main.dataGridView1.DataSource = gs.Stagiaire.ToList();
            Main.dataGridView1.Columns[7].Visible = false;
            this.Close();
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
    }
}
