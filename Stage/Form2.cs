using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectezeze.Stage
{
    public partial class Form2 : Form
    {
        int mov, movx, movy, id, id2;

        EntityFramework.GestionStage eg = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes gestionComptes = new ClassesDeProjet.GestionDesComptes();

        MainStage ms;
        string email, password;
        public Form2(MainStage MS, int ID, int ID2,string e,string p)
        {
            InitializeComponent();
            id = ID;
            ms = MS;
            id2 = ID2;
            password = p;
            email = e;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (id2 == 1)
            {
                label1.Text = "Voulez-vous vraiment supprimer ce stage ?";
            }

            //this.reportViewer1.RefreshReport();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (id2 == 1)
            {
                var req = eg.Stage.FirstOrDefault(x => x.IdStage == id);
                var req1 = eg.Absence.Where(x => x.IdStage == id);
                var req2 = eg.PieceJointe.Where(x => x.IdStage == id);
                foreach (var i in req1)
                {
                    eg.Absence.Remove(i);
                }
                foreach (var i in req2)
                {
                    eg.PieceJointe.Remove(i);
                }
                eg.Stage.Remove(req);
                eg.SaveChanges();
                ms.dataGridView1.DataSource = eg.Stage.Select(x => new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation, Projet = x.IntituleProjet, Duree = x.Duree.ToString() }).ToList();
                ms.dataGridView1.Columns[0].Visible = false;
                int idUtilisateur = gestionComptes.user(email, password).IdUtilisateur;
                gestionComptes.ajouterAction("Suppression d'un stage", idUtilisateur);
                this.Close();
            }
         
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       



        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1; movx = e.X; movy = e.Y;
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
            mov=0;
        }
    }
}
