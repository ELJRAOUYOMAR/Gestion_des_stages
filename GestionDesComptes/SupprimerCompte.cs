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

namespace projectezeze.GestionDesComptes
{
    public partial class SupprimerCompte : Form
    {
        int id;
        MainCompte mc;
        string email, password;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes gestionComptes = new ClassesDeProjet.GestionDesComptes();
        public SupprimerCompte()
        {
            InitializeComponent();
        }
        public SupprimerCompte(MainCompte MC , int ID,string EM, string PS)
        {
            InitializeComponent();
            id = ID;
            mc = MC;
            email = EM;
            password = PS;
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //try
            //{
                var req = gs.TypeRole.Where(x => x.IdUtilisateur == id).ToList();
                foreach(var i in req)
                {
                    gs.TypeRole.Remove(i);
                    gs.SaveChanges();
                }
                ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
                GC.supprimerCompte(id);
               
                int idUtilisateur = gestionComptes.user(email, password).IdUtilisateur;
                gestionComptes.ajouterAction("Suppression d'un utilisateur", idUtilisateur);
                mc.dataGridView1.DataSource = gs.Utilisateur.ToList();
                mc.dataGridView1.Columns[8].Visible = false;
                mc.dataGridView1.Columns[9].Visible = false;
                mc.dataGridView1.Columns[6].Visible = false; 
                mc.dataGridView1.Columns[0].Visible = false;
                this.Close();
            //}
            //catch
            //{
                
            //    MessageForm.LongMessage m = new MessageForm.LongMessage("cet utilisateur ayant des action si vous voulez vraiment supprimer le ,il faut supprimer ses actions dans l'historique");
            //    m.ShowDialog();
            //    this.Close();
            //}
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
