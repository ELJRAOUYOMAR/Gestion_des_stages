using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;
using BunifuLC;
using BunifuVSIX.forms;


namespace projectezeze.Tache
{
    public partial class Maintaches : UserControl
    {
        ClassesDeProjet.GestionDesComptes gestionComptes = new ClassesDeProjet.GestionDesComptes();
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        string seconnecter1, seconnecter2;   
        public Maintaches()
        {
            InitializeComponent();
        }
        public Maintaches(string email,string password)
        {
            InitializeComponent();
            seconnecter1 = email;
            seconnecter2 = password;
        }

        private void Maintaches_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gs.Tache.ToList();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[0].Visible = false;

            int idu = gestionComptes.user(seconnecter1, seconnecter2).IdUtilisateur;
            if (gestionComptes.user(seconnecter1, seconnecter2).Role == true)
            {
                guna2Button4.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button5.Enabled = true;
                guna2TextBox1.Enabled = true;
                guna2TextBox2.Enabled = true;
                guna2DateTimePicker1.Enabled = true;
                guna2DateTimePicker2.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button4.Enabled = true; 
                guna2Button5.Enabled = true;
                return;
            }
            DataTable dt = new DataTable();
            dt = gestionComptes.ReturnTableRole(idu, 5);
            int count = dt.Rows.Count;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row[3].ToString()) == 1)
                    {
                        guna2TextBox1.Enabled = true;
                        guna2TextBox2.Enabled = true;
                        guna2DateTimePicker1.Enabled = true;
                        guna2DateTimePicker2.Enabled = true;
                        guna2TextBox3.Enabled = true;
                        guna2Button3.Enabled = true;

                    }

                    if (int.Parse(row[3].ToString()) == 2)
                    {
                        guna2Button4.Enabled = true;


                    }
                    if (int.Parse(row[3].ToString()) == 3)
                    {
                        guna2Button5.Enabled = true;
                    }

                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2DateTimePicker1.Value < guna2DateTimePicker2.Value)
                {
                    gs.Tache.Add(new EntityFramework.Tache
                    {
                        Tache1 = guna2TextBox1.Text,
                        DateDebut = guna2DateTimePicker1.Value,
                        DateFin = guna2DateTimePicker2.Value,
                        Remarque = guna2TextBox2.Text

                    });
                    gs.SaveChanges();
                    dataGridView1.DataSource = gs.Tache.ToList();
                    dataGridView1.Columns[5].Visible = false;
                }
                else
                {
                    MessageForm.LongMessage m = new MessageForm.LongMessage("Attention sur les dates . la date début doit être inférieur à la date de fin");
                    m.ShowDialog();
                }
                int idUtilisateur = gestionComptes.user(seconnecter1, seconnecter2).IdUtilisateur;
                gestionComptes.ajouterAction("Addition d'une tâche", idUtilisateur);
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                int idTache = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Tache.SupprimerTache t = new SupprimerTache(this,idTache,seconnecter1,seconnecter2);
                t.ShowDialog();
            //}
            //catch
            //{
            //    MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
            //    m.ShowDialog();
            //}
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            int id= (int)dataGridView1.CurrentRow.Cells[0].Value;
            string tache = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string remarque=dataGridView1.CurrentRow.Cells[4].Value.ToString();
            DateTime db = (DateTime)dataGridView1.CurrentRow.Cells[2].Value;
            DateTime df = (DateTime)dataGridView1.CurrentRow.Cells[3].Value;
            Tache.ModifierTache m = new ModifierTache(this,id,tache,remarque,db,df,seconnecter1,seconnecter2);
            m.ShowDialog();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox3.Text != "") guna2Button2.Visible = true;
                else guna2Button2.Visible = false;
                guna2TextBox3.PlaceholderText = "Rechercher";
                var req = gs.Tache.Where(x => x.Tache1.StartsWith(guna2TextBox3.Text) || x.Remarque.StartsWith(guna2TextBox3.Text)).ToList();
                dataGridView1.DataSource = req.ToList();
                if (guna2TextBox3.Text == "")
                {
                    Maintaches_Load(sender, e);
                }

            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();


            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.Clear();
            guna2TextBox3.Focus();
            guna2TextBox3.PlaceholderText = "Rechercher";
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            guna2Button4.Visible = true;
            guna2Button5.Visible = true;
        }
    }
}
