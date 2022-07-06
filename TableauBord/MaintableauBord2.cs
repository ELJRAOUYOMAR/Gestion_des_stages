using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projectezeze.TableauBord
{
    public partial class MaintableauBord2 : UserControl
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|GestionStage.mdf;Integrated Security=True");
        SqlDataReader rd;
        public MaintableauBord2()
        {
            InitializeComponent();
        }

        private void MaintableauBord2_Load(object sender, EventArgs e)
        {
            var req = gs.Stagiaire.Count();
            label3.Text = req.ToString();
            var req1 = gs.Stage.Where(x => x.DateDebut.Value.Month == DateTime.Now.Month).Count();
            label2.Text = req1.ToString();
            var req2 = gs.Stage.Where(x => x.DateDebut.Value.Month == (DateTime.Now.Month + 1) && x.DateDebut.Value.Year==DateTime.Now.Year).Count();
            var req3 = gs.Stage.Where(x => x.DateDebut.Value.Month == (DateTime.Now.Month - 1) && x.DateDebut.Value.Year == DateTime.Now.Year).Count();
            label7.Text = req3.ToString();
            label8.Text = req2.ToString(); 
            SqlCommand cmd = new SqlCommand("select Month(datedebut) as Mois , count(IdStage)  from Stage  where year(datedebut)=year(getdate()) group by Month(datedebut)  ", cn);
            cn.Open();
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                this.chart2.Series["Mois"].Points.AddXY(rd[0], rd[1]);
            }
            rd.Close();
            cn.Close();
            SqlCommand cmd1 = new SqlCommand("select Month(datedebut) as Mois ,count(idabsence) from Absence  where year(datedebut)=year(getdate()) group by month(datedebut) ", cn);
            cn.Open();
            rd = cmd1.ExecuteReader();
            while (rd.Read())
            {
                this.chart1.Series["Nombre d'absence"].Points.AddXY(rd[0], rd[1]);
            }
            rd.Close();
            cn.Close();
            label9.Text = DateTime.Now.ToShortDateString();
            label10.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
