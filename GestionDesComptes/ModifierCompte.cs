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
namespace projectezeze.GestionDesComptes
{
    public partial class ModifierCompte : Form
    {
        int mov, movx, movy;
        int id,code;
        string cin, nom, email, tel, nomu, motdepasse;
        MainCompte mc;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        private void ModifierCompte_Load(object sender, EventArgs e)
        {
            if (code == 0)
            {
                guna2TextBox1.Text = cin;
                guna2TextBox2.Text = nom;
                guna2TextBox3.Text = email;
                guna2TextBox4.Text = tel;
                guna2TextBox5.Text = nomu;
                guna2TextBox6.Text = motdepasse;
            }
            else if (code == 1)
            {
                idUtilisateurMod = GC.user(email1, password1).IdUtilisateur;
                guna2TextBox1.Text = GC.user(email1, password1).Cin;
                guna2TextBox2.Text = GC.user(email1, password1).NomComplet;
                guna2TextBox3.Text = GC.user(email1, password1).Email;
                guna2TextBox4.Text = GC.user(email1, password1).Telephone;
                guna2TextBox5.Text = GC.user(email1, password1).NomUtilisateur;
                guna2TextBox6.Text = GC.user(email1, password1).MotDePasse;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (guna2TextBox5.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le nom d'utilisateur !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox4.Text == "")
            {
                MessageForm.Message1 m = new MessageForm.Message1("Le téléphone !", "");
                m.ShowDialog();
                return;
            }
            if (guna2TextBox6.Text == "")
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
            if (code == 0)
            {
                GC.ModifierCompte(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox5.Text, guna2TextBox6.Text, id);
                int idUtilisateur = GC.user(email1, password1).IdUtilisateur;
                GC.ajouterAction("Modification d'un utilisateur", idUtilisateur);
                mc.dataGridView1.DataSource = gs.Utilisateur.ToList();
                mc.dataGridView1.Columns[8].Visible = false;
                mc.dataGridView1.Columns[9].Visible = false;
                mc.dataGridView1.Columns[6].Visible = false;
                mc.dataGridView1.Columns[0].Visible = false;
            }
            else if (code == 1)
            {
                GC.ModifierCompte(guna2TextBox1.Text, guna2TextBox2.Text, guna2TextBox3.Text, guna2TextBox4.Text, guna2TextBox5.Text, guna2TextBox6.Text, idUtilisateurMod);
                int idUtilisateur = GC.user(email1, password1).IdUtilisateur;
                GC.ajouterAction(" Mise à jour", idUtilisateur);
                mc.dataGridView1.DataSource = gs.Utilisateur.ToList();
                mc.dataGridView1.Columns[8].Visible = false;
                mc.dataGridView1.Columns[9].Visible = false;
                mc.dataGridView1.Columns[6].Visible = false;
            }
        }

        int idUtilisateurMod;
        string email1, password1;

        public ModifierCompte()
        {
            InitializeComponent();
        }
        public ModifierCompte(MainCompte MC, int ID, string Cin, string Nom, string Email, string Tel, string Nomu, string Psw, string E, string P, int Code)
        {
            InitializeComponent();
            id = ID;
            cin = Cin; nom = Nom; email = Email; tel = Tel; nomu = Nomu; motdepasse = Psw;
            mc = MC;
            email1 = E;
            password1 = P;
            code = Code;

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
