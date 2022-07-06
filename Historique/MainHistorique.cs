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
namespace projectezeze.Historique
{
    public partial class MainHistorique : UserControl
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes cl = new ClassesDeProjet.GestionDesComptes();
        string seconnecter1, seconnecter2;
        public MainHistorique()
        {
            InitializeComponent();
        }
        public MainHistorique(string t1,string t2)
        {
            InitializeComponent();
            seconnecter1 = t1;
            seconnecter2 = t2;
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void MainHistorique_Load(object sender, EventArgs e)
        {
            try
            {
                guna2TextBox6.Focus();
                if (cl.SeConnecter(seconnecter1, seconnecter2) == 2)
                {
                    var req = gs.Historique.Where(x => x.Utilisateur.Email == seconnecter1 && x.Utilisateur.MotDePasse == seconnecter2).Select(x => new
                    {
                        x.IdAction,
                        x.Utilisateur.Cin,
                        x.Utilisateur.NomUtilisateur,
                        x.Action,
                        x.Date
                    });
                    dataGridView1.DataSource = req.ToList();
                    guna2Button4.Enabled = false;
                }
                else if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
                {
                    var req = gs.Historique.Select(x => new
                    {
                        x.IdAction,
                        x.Utilisateur.Cin,
                        x.Utilisateur.NomUtilisateur,
                        x.Action,
                        x.Date
                    });
                    dataGridView1.DataSource = req.ToList();
                    dataGridView1.Columns[0].Visible = false;
                    guna2Button4.Enabled = false;
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cl.SeConnecter(seconnecter1, seconnecter2) == 2)
                {
                    var req = gs.Historique.Where(x => x.Utilisateur.Email == seconnecter1 &&
                      x.Utilisateur.MotDePasse == seconnecter2 && x.Date < guna2DateTimePicker2.Value &&
                      x.Date > guna2DateTimePicker1.Value).Select(x => new
                      {
                          x.IdAction,
                          x.Utilisateur.Cin,
                          x.Utilisateur.NomUtilisateur,
                          x.Action,
                          x.Date
                      });
                    dataGridView1.DataSource = req.ToList();
                }
                else if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
                {
                    var req = gs.Historique.Where(x => x.Date < guna2DateTimePicker2.Value &&
                        x.Date > guna2DateTimePicker1.Value).Select(x => new
                        {
                            x.IdAction,
                            x.Utilisateur.Cin,
                            x.Utilisateur.NomUtilisateur,
                            x.Action,
                            x.Date
                        });
                    dataGridView1.DataSource = req.ToList();
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cl.SeConnecter(seconnecter1, seconnecter2) == 2)
                {
                    var req = gs.Historique.Where(x => x.Utilisateur.Email == seconnecter1 &&
                      x.Utilisateur.MotDePasse == seconnecter2 && x.Date < guna2DateTimePicker2.Value &&
                      x.Date > guna2DateTimePicker1.Value).Select(x => new
                      {
                          x.IdAction,
                          x.Utilisateur.Cin,
                          x.Utilisateur.NomUtilisateur,
                          x.Action,
                          x.Date
                      });
                    dataGridView1.DataSource = req.ToList();
                }
                else if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
                {
                    var req = gs.Historique.Where(x => x.Date < guna2DateTimePicker2.Value &&
                        x.Date > guna2DateTimePicker1.Value).Select(x => new
                        {
                            x.IdAction,
                            x.Utilisateur.Cin,
                            x.Utilisateur.NomUtilisateur,
                            x.Action,
                            x.Date
                        }) ;
                    dataGridView1.DataSource = req.ToList();
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             
            if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
            {
                guna2Button4.Enabled = true;
                guna2Button2.Enabled = true;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            ////    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            ////    DataGridViewTextBoxCell cht = (DataGridViewTextBoxCell)row.Cells[1].Value;
            ////    if (chk.Value == chk.TrueValue)
            ////    {
            ////        //int id = int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            ////        //int id = int.Parse(row.Cells[1].Value.ToString());
            ////        int id = int.Parse(cht.ToString());
            ////        var req = gs.Historique.FirstOrDefault(x => x.IdAction == id);
            ////        if (req != null)
            ////        {
            ////            gs.Historique.Remove(req);
            ////            gs.SaveChanges();

            ////        }
            ////    }
            ////}
            ////MainHistorique_Load(sender, e);
            //for(int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            //{
            //    bool del=dataGridView1.
            //}
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    var req = gs.Historique.FirstOrDefault(x => x.IdAction == id);
                    if (req != null)
                    {
                        gs.Historique.Remove(req);
                        gs.SaveChanges();

                    }
                    MainHistorique_Load(sender, e);
                }

            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("Erreur", "");
                m.ShowDialog();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
                {
                    var rows = from o in gs.Historique select o;
                    foreach (var row in rows)
                    {
                        gs.Historique.Remove(row);
                    }
                    gs.SaveChanges();
                    MainHistorique_Load(sender, e);
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();

            }
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            MainHistorique_Load(sender, e);
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox6.Text != "") guna2Button3.Visible = true;
                else guna2Button3.Visible = false;
                guna2TextBox6.PlaceholderText = "Rechercher";
                if (cl.SeConnecter(seconnecter1, seconnecter2) == 2)
                {
                    var req = gs.Historique.Where(x => x.Utilisateur.Email == seconnecter1 &&
                    x.Utilisateur.MotDePasse == seconnecter2 &&
                    (x.Utilisateur.Cin.StartsWith(guna2TextBox6.Text) || x.Utilisateur.NomUtilisateur.StartsWith(guna2TextBox6.Text) || x.Action.StartsWith(guna2TextBox6.Text))).Select(x =>
                     new
                     {
                         x.IdAction,
                         x.Utilisateur.Cin,
                         x.Utilisateur.NomUtilisateur,
                         x.Action,
                         x.Date
                     });
                    if (guna2TextBox6.Text == "")
                    {
                        MainHistorique_Load(sender, e);
                    }
                }
                else if (cl.SeConnecter(seconnecter1, seconnecter2) == 1)
                {
                    var req = gs.Historique.Where(x => x.Utilisateur.Cin.StartsWith(guna2TextBox6.Text) || x.Utilisateur.NomUtilisateur.StartsWith(guna2TextBox6.Text) || x.Action.StartsWith(guna2TextBox6.Text)).Select(x => new { x.Utilisateur.Cin, x.Utilisateur.NomUtilisateur, x.Action, x.Date });
                    dataGridView1.DataSource = req.ToList();
                    if (guna2TextBox6.Text == "")
                    {
                        MainHistorique_Load(sender, e);
                    }
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox6.Clear();
            guna2TextBox6.Focus();
            guna2TextBox6.PlaceholderText = "Rechercher";
        }
    }
}
