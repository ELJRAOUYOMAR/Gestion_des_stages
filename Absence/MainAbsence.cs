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

namespace projectezeze.Absence
{
    public partial class MainAbsence : UserControl
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes Class = new ClassesDeProjet.GestionDesComptes();
        string email, password;
        public MainAbsence()
        {
            InitializeComponent();
        }
        public MainAbsence(string e,string p)
        {
            InitializeComponent();
            email = e;
            password = p;
        }
        private void MainAbsence_Load(object sender, EventArgs e)
        {
            guna2TextBox6.Focus();
            guna2ComboBox1.Text = "Cin des stagiaire";
            guna2TextBox1.Text = "";
            guna2DateTimePicker1.Text = "";
            guna2DateTimePicker1.Text = "";
            //remplir datagridviw
            var req = gs.Absence.Select(x => new
            {
                x.IdAbsence,
                x.Stage.Stagiaire.Cin,
                x.Stage.Stagiaire.NomComplet,
                x.DateDebut,
                x.DateFin,
                x.NombreJours,
                x.Cause
            });

            dataGridView1.DataSource = req.ToList();
            dataGridView1.Columns[0].Visible = false;
            //remplir les stagiaire qu'ont des stage en combobox
            var reqC = gs.Stage.Select(x => new { CIN = x.Stagiaire.Cin + " " + x.Stagiaire.NomComplet, x.IdStage }).Distinct().ToList();
            guna2ComboBox1.DisplayMember = "CIN";
            guna2ComboBox1.ValueMember = "IdStage";
            guna2ComboBox1.DataSource = reqC;
            //les rôles d'utilisateur
            int idu = Class.user(email, password).IdUtilisateur;
            if (Class.user(email, password).Role == true)
            {
                guna2Button3.Enabled = true;
                guna2DateTimePicker1.Enabled = true;
                guna2DateTimePicker2.Enabled = true;
                guna2TextBox1.Enabled = true;
                guna2ComboBox1.Enabled = true;
                guna2Button1.Enabled = true;
                guna2Button6.Enabled = true;
                return;
            }
            DataTable dt = new DataTable();
            dt = Class.ReturnTableRole(idu, 4);
            int count = dt.Rows.Count;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row[3].ToString()) == 1)
                    {
                        guna2Button3.Enabled = true;
                        guna2DateTimePicker1.Enabled = true;
                        guna2DateTimePicker2.Enabled = true;
                        guna2TextBox1.Enabled = true;
                        guna2ComboBox1.Enabled = true;
                        return;
                    }

                    if (int.Parse(row[3].ToString()) == 2)
                    {

                        guna2Button1.Enabled = true;

                    }
                    if (int.Parse(row[3].ToString()) == 3)
                    {
                        guna2Button6.Enabled = true;

                    }
                }
            }
        }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                guna2Button1.Visible = true;
                guna2Button6.Visible = true;
            }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker1.Value > guna2DateTimePicker2.Value)
            {
                MessageForm.Message1 m = new MessageForm.Message1("La date début doit être inférieur à la date fin", "");
                m.ShowDialog();
                return;
            }
            int ida = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var req = gs.Absence.FirstOrDefault(x => x.IdAbsence == ida);
            req.Stage.Stagiaire.Cin = guna2ComboBox1.SelectedValue.ToString();
            req.Cause = guna2TextBox1.Text;
            req.DateDebut = guna2DateTimePicker1.Value;
            req.DateFin = guna2DateTimePicker1.Value;
            gs.SaveChanges();
            int idu = Class.user(email, password).IdUtilisateur;
            Class.ajouterAction("Modification d'un absence ", idu);
            MainAbsence_Load(sender, e);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            int ida = (int)dataGridView1.CurrentRow.Cells[0].Value;


            Supprimer s = new Supprimer(this, ida, email, password);
            s.ShowDialog();

            MainAbsence_Load(sender, e);
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text == "") guna2Button2.Visible = false;
            else guna2Button2.Visible = true;
            var req = gs.Absence.Where(x => x.Stage.Stagiaire.Cin.StartsWith(guna2TextBox6.Text) || x.Stage.Stagiaire.NomComplet.StartsWith(guna2TextBox6.Text) ).Select(x => new
            {
                x.IdAbsence,
                x.Stage.Stagiaire.Cin,
                x.Stage.Stagiaire.NomComplet,
                x.DateDebut,
                x.DateFin,
                x.NombreJours,
                x.Cause
            }).ToList();
            dataGridView1.DataSource = req;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox6.Clear();
            guna2TextBox6.Focus();
            guna2TextBox6.PlaceholderText = "Rechercher";
        }

        private void guna2DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            var req = gs.Absence.Where(x => x.DateDebut >= guna2DateTimePicker4.Value && x.DateFin <= guna2DateTimePicker3.Value).Select(x => new
            {
                x.IdAbsence,
                x.Stage.Stagiaire.Cin,
                x.Stage.Stagiaire.NomComplet,
                x.DateDebut,
                x.DateFin,
                x.NombreJours,
                x.Cause

            }).ToList();
            dataGridView1.DataSource = req;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            var req = gs.Absence.Where(x => x.DateDebut >= guna2DateTimePicker4.Value && x.DateFin <= guna2DateTimePicker3.Value).Select(x => new
            {
                x.IdAbsence,
                x.Stage.Stagiaire.Cin,
                x.Stage.Stagiaire.NomComplet,
                x.DateDebut,
                x.DateFin,
                x.NombreJours,
                x.Cause

            }).ToList();
            dataGridView1.DataSource = req;
            dataGridView1.Columns[0].Visible = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (guna2DateTimePicker1.Value > guna2DateTimePicker2.Value)
            {
                MessageForm.Message1 m = new MessageForm.Message1("La date début doit être inférieur à la date fin","");
                m.ShowDialog();
                return;
            }
            string CinStagiaire = guna2ComboBox1.Text;
            //int IdStagee = (int)guna2ComboBox1.SelectedValue;
            var req = gs.Absence.FirstOrDefault(x => x.Stage.Stagiaire.Cin == CinStagiaire && guna2DateTimePicker1.Value >= x.Stage.DateDebut && guna2DateTimePicker2.Value <= x.Stage.DateFin);
            gs.Absence.Add(new EntityFramework.Absence
            {
                IdStage = (int)guna2ComboBox1.SelectedValue,
                DateDebut = guna2DateTimePicker1.Value,
                DateFin = guna2DateTimePicker2.Value,
                Cause = guna2TextBox1.Text,
            });
            gs.SaveChanges();
            int idu = Class.user(email, password).IdUtilisateur;
            Class.ajouterAction("Addition d'un absence ", idu);
            MainAbsence_Load(sender, e);
            
        }
    }
}
