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

namespace projectezeze.GestionStagiaires
{
    public partial class ModifierStagiaire : Form
    {
        int mov, movx, movy,id;
        string cin, nom, email, tel, adresse, sexe,etablissement;
        ClassesDeProjet.GestionStagiares gs = new ClassesDeProjet.GestionStagiares();
        EntityFramework.GestionStage GS = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        MainStagiaires mn;
        string email2, password2;  //parametres de la button modification

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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                MessageForm.Message1 m = new MessageForm.Message1("L'adresse !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox5.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le téléphone !", "");
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
            if (guna2CustomRadioButton1.Checked) sexe = "Homme";
            else sexe = "Femme";
            cin = guna2TextBox1.Text;
            nom = guna2TextBox2.Text;
            email = guna2TextBox3.Text;
            adresse = guna2TextBox4.Text;
            tel = guna2TextBox5.Text;
            etablissement = guna2TextBox6.Text;
            gs.modifierStagiaire(id, cin, nom, email, tel, adresse, sexe, etablissement);
            this.Close();
            mn.dataGridView1.DataSource = GS.Stagiaire.ToList();
            mn.dataGridView1.Columns[8].Visible = false;
            int idUtilisateur = GC.user(email2, password2).IdUtilisateur;
            GC.ajouterAction("Modification d'un stagaire", idUtilisateur);
        }

        public ModifierStagiaire(MainStagiaires m, int Id, string Cin, string Nom, string Email, string Tel, string Adresse, string Sexe,string e,string p,string etab)
        {
            InitializeComponent();
            id = Id;
            cin = Cin;
            nom = Nom;
            email = Email;
            adresse = Adresse;
            tel = Tel;
            sexe = Sexe;
            mn = m;
            email2 = e;
            password2 = p;
            etablissement = etab;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
          
            mn.dataGridView1.DataSource = GS.Stagiaire.ToList();
            mn.dataGridView1.Columns[7].Visible = false;  
            this.Close();
        }
        private void ModifierStagiaire_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = cin;
            guna2TextBox2.Text = nom;
            guna2TextBox3.Text = email;
            guna2TextBox4.Text = adresse;
            guna2TextBox5.Text = tel;
            guna2TextBox6.Text = etablissement;
            if (sexe == "Homme") guna2CustomRadioButton1.Checked = true;
            else guna2CustomRadioButton2.Checked = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
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
                MessageForm.Message1 m = new MessageForm.Message1("L'adresse !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox5.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le téléphone !", "");
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
            if (guna2CustomRadioButton1.Checked) sexe = "Homme";
            else sexe = "Femme";
            cin = guna2TextBox1.Text;
            nom = guna2TextBox2.Text;
            email = guna2TextBox3.Text;
            adresse = guna2TextBox4.Text;
            tel = guna2TextBox5.Text;
            etablissement = guna2TextBox6.Text;
            gs.modifierStagiaire(id, cin, nom, email, tel, adresse, sexe,etablissement);
            this.Close();
            mn.dataGridView1.DataSource = GS.Stagiaire.ToList();
            mn.dataGridView1.Columns[7].Visible = false;
            int idUtilisateur = GC.user(email2, password2).IdUtilisateur;
            GC.ajouterAction("Modification d'un stagaire", idUtilisateur);



        }

        private void label4_Click(object sender, EventArgs e)
        {
            guna2CustomRadioButton1.Checked = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            guna2CustomRadioButton2.Checked = true;
        }
    }
}
