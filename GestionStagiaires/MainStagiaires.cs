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
namespace projectezeze.GestionStagiaires
{
    public partial class MainStagiaires : UserControl
    {
        string email, password;
        public MainStagiaires()
        {
            InitializeComponent();
        }
        public MainStagiaires(string e,string p)
        {
            InitializeComponent();
            email = e;
            password = p;
        }
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionStagiares GS = new ClassesDeProjet.GestionStagiares();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            
            int ID;
            if (dataGridView1.CurrentRow.Cells[0].Value == null)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Selctionner un ligne", "");
                m.ShowDialog();
                return;
            }
            else
            {
                   ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            }
            dataGridView1.DataSource = gs.Stagiaire.ToList();
            dataGridView1.Columns[7].Visible = false;

        }

        private void MainStagiaires_Load_1(object sender, EventArgs e)
        {

            dataGridView1.DataSource = gs.Stagiaire.ToList();
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[0].Visible = false;
            guna2TextBox6.Focus();
            int idu = GC.user(email, password).IdUtilisateur;
            if (GC.user(email, password).Role == true)
            {
                guna2TextBox1.Enabled = true;
                guna2TextBox2.Enabled = true;
                guna2TextBox3.Enabled = true;
                guna2TextBox5.Enabled = true;
                guna2TextBox4.Enabled = true;
                guna2RadioButton1.Enabled = true;
                guna2RadioButton2.Enabled = true;
                guna2Button4.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button5.Enabled = true;
                return;
            }
            DataTable dt = new DataTable();
            dt = GC.ReturnTableRole(idu, 2);
            int count = dt.Rows.Count;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row[3].ToString()) == 1)
                    {
                        guna2TextBox1.Enabled = true;
                        guna2TextBox2.Enabled = true;
                        guna2TextBox3.Enabled = true;
                        guna2TextBox5.Enabled = true;
                        guna2TextBox4.Enabled = true;
                        guna2RadioButton1.Enabled = true;
                        guna2RadioButton2.Enabled = true;
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
        //private void bunifuButton3_Click(object sender, EventArgs e)
        //{
        //    dataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Green;
        //    string sexe, cin, nom, tel, adresse, email1,etablissement;
        //    cin = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        //    nom = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        //    sexe = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        //    adresse = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        //    tel = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        //    email1 = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        //    etablissement = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        //    dataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Green;
        //    if (guna2RadioButton1.Checked) sexe = "Homme";
        //    else sexe = "Femme";
        //    int id = GS.stagiaire(dataGridView1.CurrentRow.Cells[1].Value.ToString()).IdStagiaire;
        //    GestionStagiaires.ModifierStagiaire md = new GestionStagiaires.ModifierStagiaire(this,id, cin, nom, email1, tel, adresse, sexe,email,password,etablissement);
        //    md.ShowDialog();
            

        //}

        private void bunifuButton2_Click(object sender, EventArgs e)
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
            if (guna2TextBox4.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le téléphone !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox5.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("L'adresse !", "");
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


            string sexe;
            if (guna2RadioButton1.Checked) sexe = "Homme";
            else sexe = "Femme";
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.Show();
                return;
            }
            GS.AjouterStagiaire(guna2TextBox1.Text, guna2TextBox2.Text, sexe, guna2TextBox4.Text, guna2TextBox3.Text, guna2TextBox5.Text,guna2TextBox7.Text);
            dataGridView1.DataSource = gs.Stagiaire.ToList();
            dataGridView1.Columns[7].Visible = false;
            MainStagiaires_Load_1(sender, e);
            int idUtilisateur = GC.user(email, password).IdUtilisateur;
            GC.ajouterAction("Addition d'un stagaire", idUtilisateur);
            

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2TextBox6.Clear();
            guna2TextBox6.Focus();
            guna2TextBox6.PlaceholderText="Rechercher Par CIN";
        }

        private void bunifuTextBox7_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "") guna2Button2.Visible = true;
            else guna2Button2.Visible = false;
            guna2TextBox6.PlaceholderText = "Rechercher";
            dataGridView1.DataSource = gs.Stagiaire.Where(x => x.Cin.StartsWith(guna2TextBox6.Text) || x.NomComplet.StartsWith(guna2TextBox6.Text) || x.Sexe.StartsWith(guna2TextBox6.Text)).ToList();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2Button4.Visible = true;
            guna2Button5.Visible = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Red;
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            GestionStagiaires.SupprimerStagiaire s = new SupprimerStagiaire(this,id,email,password);
            s.ShowDialog();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
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
            if (guna2TextBox4.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le téléphone !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox5.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("L'adresse !", "");
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
            string sexe;
            if (guna2RadioButton1.Checked) sexe = "Homme";
            else sexe = "Femme";
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.Show();
                return;
            }
            GS.AjouterStagiaire(guna2TextBox1.Text, guna2TextBox2.Text, sexe, guna2TextBox4.Text, guna2TextBox3.Text, guna2TextBox5.Text,guna2TextBox7.Text);
            dataGridView1.DataSource = gs.Stagiaire.ToList();
            dataGridView1.Columns[8].Visible = false;
            MainStagiaires_Load_1(sender, e);
            int idUtilisateur = GC.user(email, password).IdUtilisateur;
            GC.ajouterAction("Addition d'un stagaire", idUtilisateur);
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != "") guna2Button2.Visible = true;
            else guna2Button2.Visible = false;
            guna2TextBox6.PlaceholderText = "Rechercher";
            dataGridView1.DataSource = gs.Stagiaire.Where(x => x.Cin.StartsWith(guna2TextBox6.Text) || x.NomComplet.StartsWith(guna2TextBox6.Text) || x.Sexe.StartsWith(guna2TextBox6.Text)||x.Telephone.StartsWith(guna2TextBox6.Text)).ToList();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox6.Clear();
            guna2TextBox6.Focus();
            guna2TextBox6.PlaceholderText = "Rechercher";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            GestionStagiaires.SupprimerStagiaire s = new SupprimerStagiaire(this, id, email, password);
            s.ShowDialog();
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox4_Click(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox5_Click(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox7_Click(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2TextBox3_Click(object sender, EventArgs e)
        {
            if (GS.rechercherstagiaire(guna2TextBox1.Text) == true)
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le cin de stagiaire déja existe", "");
                m.ShowDialog();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string sexe, cin, nom, tel, adresse, email1, etablissement;
            cin = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            nom = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            sexe = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            adresse = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            tel = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            email1 = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            etablissement = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            int id = GS.stagiaire(dataGridView1.CurrentRow.Cells[1].Value.ToString()).IdStagiaire;
            GestionStagiaires.ModifierStagiaire md = new GestionStagiaires.ModifierStagiaire(this, id, cin, nom, email1, tel, adresse, sexe, email, password,etablissement);
            md.ShowDialog();
        }
    }
}
