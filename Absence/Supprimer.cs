using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectezeze.Absence
{
    public partial class Supprimer : Form
    {
        int mov, movx, movy;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes Class = new ClassesDeProjet.GestionDesComptes();
        MainAbsence ma;
        int ida;
        string email, password;
        public Supprimer()
        {
            InitializeComponent();
        }
        public Supprimer(MainAbsence A, int IDA, string Email, string Password)
        {
            InitializeComponent();
            ma = A;
            ida = IDA;
            email = Email;
            password = Password;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            var req = gs.Absence.FirstOrDefault(x => x.IdAbsence == ida);
            gs.Absence.Remove(req);
            gs.SaveChanges();
            int idu = Class.user(email, password).IdUtilisateur;
            Class.ajouterAction("Suppression d'un absence ", idu);
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
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
