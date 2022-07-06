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
    public partial class ModifierTache : Form
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        int mov, movx, movy;
        int idTache;
        string tache, remarque;
        DateTime db, df;
        Maintaches main;
        string email, password;
        public ModifierTache()
        {
            InitializeComponent();
        }
        public ModifierTache(Tache.Maintaches m, int id,string t, string r, DateTime b,DateTime f,string e,string p)
        {
            InitializeComponent();
            idTache = id;
            main = m;
            tache = t;
            remarque = r;
            db = b;
            df = f;
            email = e;
            password = p;
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
                this.SetDesktopLocation(MousePosition.X - movx , MousePosition.Y - movy);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ModifierTache_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = tache;
            guna2TextBox2.Text = remarque;
            guna2DateTimePicker1.Value = db;
            guna2DateTimePicker2.Value = df;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                var req = gs.Tache.FirstOrDefault(x => x.IdTache == idTache);
                if (req != null)
                {
                    if (guna2DateTimePicker1.Value > guna2DateTimePicker2.Value)
                    {
                        MessageForm.LongMessage m = new MessageForm.LongMessage("La date Début doit être inférieur à la date fin");
                        m.ShowDialog();return;
                    }
                    req.Tache1 = guna2TextBox1.Text;
                    req.Remarque = guna2TextBox2.Text;
                    req.DateDebut = guna2DateTimePicker1.Value;
                    req.DateFin = guna2DateTimePicker2.Value;
                    gs.SaveChanges();
                    main.dataGridView1.DataSource = gs.Tache.ToList();
                    main.dataGridView1.Columns[5].Visible = false;
                    main.dataGridView1.Columns[0].Visible = false;
                }
                int idUtilisateur = GC.user(email, password).IdUtilisateur;
                GC.ajouterAction("Modification d'une tâche", idUtilisateur);
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }
    }
}
