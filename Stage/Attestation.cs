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
    public partial class Attestation : Form
    {
        int Ids;
        public Attestation(int ids)
        {
            InitializeComponent();
            Ids = ids;
        }

        private void Attestation_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.DataTable2'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.DataTable1'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1,Ids);
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.DataTable1'. Vous pouvez la déplacer ou la supprimer selon les besoins.



            this.reportViewer1.RefreshReport();
        }
        int mov, movx, movy;
        private void Attestation_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1; movx = e.X; movy = e.Y;
        }

        private void Attestation_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void Attestation_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }
    }
}
