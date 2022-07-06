using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.UI.WinForms;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;

namespace projectezeze.GestionDesComptes
{
    public partial class MainCompte : UserControl
    {
        ClassesDeProjet.GestionDesComptes gestionComptes = new ClassesDeProjet.GestionDesComptes();
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        string email1, password1;
        
        public MainCompte()
        {
            InitializeComponent();
        }
        public MainCompte(string EMAIL,string PASSWORD)
        {
            InitializeComponent();
            email1 = EMAIL;
            password1 = PASSWORD;
        }

        private void MainCompte_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gs.Utilisateur.ToList();
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            int idu =gestionComptes.user(email1,password1).IdUtilisateur;
            if (gestionComptes.user(email1, password1).Role == true)
            {
                guna2TextBox1.Enabled = true;
                guna2TextBox2.Enabled = true;
                guna2TextBox3.Enabled = true;
                guna2TextBox4.Enabled = true;
                guna2TextBox5.Enabled = true;
                guna2TextBox6.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button6.Enabled = true;
                guna2Button4.Enabled = true;
                return;
            }
            DataTable dt = new DataTable();
            dt= gestionComptes.ReturnTableRole(idu, 1);
            int count = dt.Rows.Count;
            if (dt.Rows.Count != 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if (int.Parse(row[3].ToString()) == 1)
                    {
                        guna2TextBox1.Enabled = true;
                        guna2TextBox2.Enabled = true;
                        guna2TextBox3.Enabled = true;
                        guna2TextBox4.Enabled = true;
                        guna2TextBox5.Enabled = true;
                        guna2TextBox6.Enabled = true;
                        guna2Button3.Enabled = true;
                    }
                    
                    if (int.Parse(row[3].ToString()) == 2)
                    {
                        guna2Button6.Enabled = true;


                    }
                    if (int.Parse(row[3].ToString()) == 3)
                    {
                        guna2Button4.Enabled = true;
                    }

                }
            }



        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string email = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string password = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dataGridView1.CurrentRow.DefaultCellStyle.BackColor = Color.Red;
            if (gestionComptes.SeConnecter(email, password) == 1)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Vous ne pouvez pas supprimer l'admin","");
                m.ShowDialog();
                dataGridView1.DataSource = gs.Utilisateur.ToList();
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                return;
            }
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            GestionDesComptes.SupprimerCompte s = new GestionDesComptes.SupprimerCompte(this,id,email1,password1);
            s.ShowDialog();
            dataGridView1.DataSource = gs.Utilisateur.ToList();
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2Button6.Visible = true;
            guna2Button4.Visible = true;
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox1.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Le cin !", "");
                    m.ShowDialog();
                    return;
                }
                if (guna2TextBox2.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Le nom !", "");
                    m.ShowDialog();
                    return;
                }
                if (guna2TextBox3.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("L'email !", "");
                    m.ShowDialog();
                    return;
                }
                if (guna2TextBox6.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Le nom d'utilisateur !", "");
                    m.ShowDialog();
                    return;
                }
                if (guna2TextBox5.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Le mot de passe !", "");
                    m.ShowDialog();
                    return;
                }
                string Regexmodel = @"\w*\@\w*";
                Regex r = new Regex(Regexmodel);
                if (!(r.IsMatch(guna2TextBox3.Text)))
                {
                    MessageForm.Message1 m = new MessageForm.Message1("La façon d'email n'est pas acceptable !", "");
                    m.ShowDialog();
                    return;
                }

                if (gestionComptes.AjouterCompte(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox6.Text, guna2TextBox5.Text) == true)
                {
                    int idUtilisateur = gestionComptes.user(email1, password1).IdUtilisateur;
                    gestionComptes.ajouterAction("Addition d'un utilisateur", idUtilisateur);
                    MainCompte_Load(sender, e);
                }
                else
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà exist", "");
                    m.ShowDialog();
                    return;
                }


            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("Il y a un probleme\nRépétez une autre fois", "");
                m.ShowDialog(); ;
            }
        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox7.Text != "") guna2Button2.Visible = true;
                else guna2Button2.Visible = false;
                guna2TextBox7.PlaceholderText = "Rechercher";
                var req = gs.Utilisateur.Where(x => x.Cin.StartsWith(guna2TextBox7.Text) || x.Telephone.StartsWith(guna2TextBox7.Text) || x.NomComplet.StartsWith(guna2TextBox7.Text)).ToList();
                dataGridView1.DataSource = req.ToList();
                if (guna2TextBox7.Text == "")
                {
                    MainCompte_Load(sender, e);
                }

            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();


            }
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            string email = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string password = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (gestionComptes.SeConnecter(email, password) == 1)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Vous ne pouvez pas supprimer l'admin", "");
                m.ShowDialog();
                dataGridView1.DataSource = gs.Utilisateur.ToList();
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[0].Visible = false;
                return;
            }
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            GestionDesComptes.SupprimerCompte s = new GestionDesComptes.SupprimerCompte(this, id, email1, password1);
            s.ShowDialog();
            dataGridView1.DataSource = gs.Utilisateur.ToList();
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            string email = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string password = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            if (gestionComptes.SeConnecter(email, password) == 1)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Vous ne pouvez pas modifier l'admin", "");
                m.ShowDialog();
                dataGridView1.DataSource = gs.Utilisateur.ToList();
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                return;
            }
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            string cin = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string nom = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            string email2 = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            string tel = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string nomu = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string motdepasse = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            GestionDesComptes.ModifierCompte md = new GestionDesComptes.ModifierCompte(this, id, cin, nom, email2, tel, nomu, motdepasse, email1, password1, 0);
            md.ShowDialog();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            GestionDesComptes.ModifierCompte md = new GestionDesComptes.ModifierCompte(this, 1, "", "", "", "", "", "", email1, password1, 1);
            md.ShowDialog();
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text)== true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox3_Click(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox4_Click(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox5_Click(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox6_Click(object sender, EventArgs e)
        {
            if (gestionComptes.rechercherCompte(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Ce cin déjà existe", "");
                m.ShowDialog();
            }
        }

      

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
