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
    public partial class InformationStage : Form
    {
        int ids , mov , movx ,movy;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();

        private void InformationStage_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void InformationStage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        public InformationStage(int IDS )
        {
            InitializeComponent();
            ids = IDS;
        }

        private void InformationStage_Load(object sender, EventArgs e)
        {

            // TODO: cette ligne de code charge les données dans la table 'DataSet1.DataTable1'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            var req = gs.Stage.FirstOrDefault(x => x.IdStage == ids);
            var req1 = gs.Taches.Where(x => x.IdStage == ids).Select(x => new { x.Tache.Tache1 }).ToList();
            label18.Text = req.Stagiaire.Cin.ToString() + " " + req.Stagiaire.NomComplet.ToString();
            label17.Text = req.Type.ToString();
            label16.Text = req.DateDebut.ToString();
            label15.Text = req.DateFin.ToString();
            label14.Text = req.Formation.ToString();
            label13.Text = req.Formation.ToString();
            label13.Text = req.IntituleProjet.ToString();
            label12.Text = req.DecriptionDeProjet.ToString();
            label10.Text = req.Duree.ToString();
           
        }

        private void InformationStage_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }
    }
}
