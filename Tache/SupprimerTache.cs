using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectezeze.Tache
{
    public partial class SupprimerTache : Form
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        int mov, movx, movy;
        int idTache;   //dgv1(tache).cerrentRow.cell[0].value;
        Tache.Maintaches main;
        string email, password;
        public SupprimerTache(Tache.Maintaches m,int id,string s1,string s2)
        {
            InitializeComponent();
            idTache = id;
            main = m;
            email = s1;
            password = s2;
        }

        private void SupprimerTache_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                var req = gs.Tache.FirstOrDefault(x => x.IdTache == idTache);
                if (req != null)
                {
                    gs.Tache.Remove(req);
                    gs.SaveChanges();
                    main.dataGridView1.DataSource = gs.Tache.ToList();
                    main.dataGridView1.Columns[5].Visible = false;
                    main.dataGridView1.Columns[0].Visible = false;
                }
                int idUtilisateur = GC.user(email, password).IdUtilisateur;
                GC.ajouterAction("Suppression d'une tâche", idUtilisateur);
                this.Close();
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("Il y a un stage ayant cette tâche!", "");
                m.ShowDialog();
                this.Close();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
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
