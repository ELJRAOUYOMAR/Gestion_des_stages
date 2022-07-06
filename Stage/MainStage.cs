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
    public partial class MainStage : UserControl
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes gestionComptes = new ClassesDeProjet.GestionDesComptes();
        string seconnecter1, seconnecter2;
        public MainStage()
        {
            InitializeComponent();
        }
        public MainStage(string t1,string t2)
        {
            InitializeComponent();
            seconnecter1 = t1;
            seconnecter2 = t2;
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainStage_Load(object sender, EventArgs e)
        {
            
            var req = gs.Stage.Select(x => new { x.IdStage ,x.Stagiaire.Cin, Type_de_stage = x.Type, x.Formation, Projet=x.IntituleProjet,  Duree= x.Duree.ToString()}).ToList();
            dataGridView1.DataSource= req;
          
            dataGridView1.Columns[0].Visible = false;
           
            int idu = gestionComptes.user(seconnecter1, seconnecter2).IdUtilisateur;
            if (gestionComptes.user(seconnecter1, seconnecter2).Role == true)
            {
                guna2Button2.Enabled = true;
                guna2Button5.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button6.Enabled = true;
                //return;
            }
            else
            {

            DataTable dt = new DataTable();
            dt = gestionComptes.ReturnTableRole(idu, 3);
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row[3].ToString()) == 1)
                    {
                        guna2Button2.Enabled = true;
                    }

                    if (int.Parse(row[3].ToString()) == 2)
                    {
                        guna2Button5.Enabled = true;
                    }
                    if (int.Parse(row[3].ToString()) == 3)
                    {
                        guna2Button3.Enabled = true;
                    }

                }
            }
            }
        }

      
       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            guna2Button4.Enabled = true;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "") guna2Button1.Visible = true;
            else guna2Button1.Visible = false;
            var req = gs.Stage.Where(x=> x.Stagiaire.Cin.StartsWith(guna2TextBox1.Text) || x.Type.StartsWith(guna2TextBox1.Text) || x.IntituleProjet.StartsWith(guna2TextBox1.Text)).Select(x => new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation,Projet=x.IntituleProjet,Duree = x.Duree.ToString() }).ToList();
            dataGridView1.DataSource = req;
            dataGridView1.Columns[0].Visible = false;

        }

       

       

      

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.FromArgb(129, 74, 81);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                Stage.Form2 f = new Stage.Form2(this, id, 1,seconnecter1,seconnecter2);
                f.ShowDialog();
            }
            
               
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2Button3.Visible = true;
            guna2Button5.Visible = true;
            guna2Button4.Enabled = true;
        }

        private void guna2DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            var req = gs.Stage.Where(x=> x.DateDebut>=guna2DateTimePicker4.Value && x.DateFin<=guna2DateTimePicker3.Value).Select(x=> new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation,Projet=x.IntituleProjet,Duree = x.Duree,}).ToList();
            dataGridView1.DataSource= req;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            var req = gs.Stage.Where(x => x.DateDebut >= guna2DateTimePicker4.Value && x.DateFin <= guna2DateTimePicker3.Value).Select(x => new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation,Projet=x.IntituleProjet,Duree = x.Duree, }).ToList();
            dataGridView1.DataSource = req;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            MainStage_Load(sender, e);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                 Stage.FormStage fs = new FormStage(this,2,seconnecter1,seconnecter2);
                 fs.ShowDialog();
            }
          
        }
       

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            Stage.FormStage fs = new FormStage(this, 1,seconnecter1,seconnecter2);
            fs.ShowDialog();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            int ids = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Attestation f = new Attestation(ids);
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int ids = (int)dataGridView1.CurrentRow.Cells[0].Value;
            PieceJointe pj = new PieceJointe(ids);
            pj.ShowDialog();
        }

        

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ids=(int)dataGridView1.CurrentRow.Cells[0].Value;
            InformationStage infs = new InformationStage(ids);
            infs.ShowDialog();
        }
    }
}
