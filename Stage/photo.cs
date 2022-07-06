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
    public partial class photo : Form
    {
        public photo()
        {
            InitializeComponent();
        }
        int IDS;
        public photo(int ids)
        {
            InitializeComponent();
            IDS = ids;
        }

        private void photo_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.DataTable1'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.DataTable1TableAdapter.Fill(this.DataSet1.DataTable1,IDS);

            this.reportViewer1.RefreshReport();
          
        }
        int mov, movx, movy;
        private void photo_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1; movx = e.X; movy = e.Y;
        }

        private void photo_MouseMove(object sender, MouseEventArgs e)
        {
             if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - movy);
            }
        }

        private void photo_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;

        }
    }
}
