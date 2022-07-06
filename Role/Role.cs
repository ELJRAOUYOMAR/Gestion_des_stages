using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.Core.Drawing;
using BunifuAnimatorNS;
using Bunifu.Framework.LICENSE;
using Bunifu.Framework.UI;
using Bunifu.Framework.Lib;
using Bunifu.Core.forms;
using Bunifu.Core.forms.licensing;

namespace projectezeze.Role
{
    public partial class Role : Form
    {
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes gc = new ClassesDeProjet.GestionDesComptes();
        int mov, movx, movy;
        public Role()
        {
            InitializeComponent();
        }
        private void Role_Load(object sender, EventArgs e)
        {
            TxtSearch.Focus();
            guna2ComboBox1.DisplayMember = "Cin";
            guna2ComboBox1.ValueMember = "IdUtilisateur";
            guna2ComboBox1.DataSource = gs.Utilisateur.ToList();
        }

        private void guna2CustomCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox1.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 1);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type=1,
                    Role=1
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type==1 && x.Role == 1);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }
                
            }
        }

        private void guna2CustomCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox2.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 2);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 1,
                    Role = 2
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 2);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }
        private void guna2CustomCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox6.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 2);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 2,
                    Role = 2
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 2);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox5.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 3);
                if (req == null)
                {
                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 2,
                    Role = 3
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 3);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox8_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox8.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 1);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 3,
                    Role = 1
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 1);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox7_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox7.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 2);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 3,
                    Role = 2
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 2);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox9_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox9.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 3);
                if (req == null)
                {
                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 3,
                    Role = 3
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 3);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox11_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox11.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 1);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 4,
                    Role = 1
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 1);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox10_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox10.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 2);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 4,
                    Role = 2
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 2);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox12_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox12.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 3);
                if (req ==null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 4,
                    Role = 3
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 3);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox14_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox14.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 1);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 5,
                    Role = 1
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 1);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox13_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox13.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 2);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 5,
                    Role = 2
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 2);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox15_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox15.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 3);
                if (req == null)
                {

                gs.TypeRole.Add(new EntityFramework.TypeRole
                {
                    IdUtilisateur = idUtilisateurCombo,
                    Type = 5,
                    Role = 3
                });
                gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 3);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
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

        private void guna2CustomCheckBox16_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox16.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 1);
                if (req == null)
                {

                    gs.TypeRole.Add(new EntityFramework.TypeRole
                    {
                        IdUtilisateur = idUtilisateurCombo,
                        Type = 2,
                        Role = 1
                    });
                    gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 1);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2CustomCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            if (guna2CustomCheckBox4.Checked == true)
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 3);
                if (req == null)
                {

                    gs.TypeRole.Add(new EntityFramework.TypeRole
                    {
                        IdUtilisateur = idUtilisateurCombo,
                        Type = 1,
                        Role = 3
                    });
                    gs.SaveChanges();
                }
            }
            else
            {
                var req = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 3);
                if (req != null)
                {
                    gs.TypeRole.Remove(req);
                    gs.SaveChanges();
                }

            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (TxtSearch.Text != "") guna2Button2.Visible = true;
            else guna2Button2.Visible = false;
            TxtSearch.PlaceholderText = "Rechercher";
            guna2ComboBox1.DisplayMember = "Cin";
            guna2ComboBox1.DataSource = gs.Utilisateur.Where(x => x.Cin.StartsWith(TxtSearch.Text) || x.NomComplet.StartsWith(TxtSearch.Text)).ToList();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            TxtSearch.Focus();
            TxtSearch.PlaceholderText = "Rechercher";
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idUtilisateurCombo = (int)guna2ComboBox1.SelectedValue;
            var compteAjouter = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 1);
            if (compteAjouter != null)
            {
                guna2CustomCheckBox1.Checked = true;
            }
            else
            {
                guna2CustomCheckBox1.Checked = false;
            }

            var compteSupprimer = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 2);
            if (compteSupprimer != null)
            {
                guna2CustomCheckBox2.Checked = true;
            }
            else
            {
                guna2CustomCheckBox2.Checked = false;
            }

            var CompteModifier = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 1 && x.Role == 3);
            if (CompteModifier != null)
            {
                guna2CustomCheckBox4.Checked = true;
            }
            else
            {
                guna2CustomCheckBox4.Checked = false;
            }

            var StagiaireAjouter = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 1);
            if (StagiaireAjouter != null)
            {
                guna2CustomCheckBox16.Checked = true;
            }
            else
            {
                guna2CustomCheckBox16.Checked = false;
            }

            var StagiaireSupprimer = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 2);
            if (StagiaireSupprimer != null)
            {
                guna2CustomCheckBox6.Checked = true;
            }
            else
            {
                guna2CustomCheckBox6.Checked = false;
            }
            var StagiaireModifier = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 2 && x.Role == 3);
            if (StagiaireModifier != null)
            {
                guna2CustomCheckBox5.Checked = true;
            }
            else
            {
                guna2CustomCheckBox5.Checked = false;
            }

            var StageAjouter = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 1);
            if (StageAjouter != null)
            {
                guna2CustomCheckBox8.Checked = true;
            }
            else
            {
                guna2CustomCheckBox8.Checked = false;
            }
            var StageSupprimer = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 2);
            if (StageSupprimer != null)
            {
                guna2CustomCheckBox7.Checked = true;
            }
            else
            {
                guna2CustomCheckBox7.Checked = false;
            }
            var StageModifier = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 3 && x.Role == 3);
            if (StageModifier != null)
            {
                guna2CustomCheckBox9.Checked = true;
            }
            else
            {
                guna2CustomCheckBox9.Checked = false;
            }

            var AbsenceAjouter = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 1);
            if (AbsenceAjouter != null)
            {
                guna2CustomCheckBox11.Checked = true;
            }
            else
            {
                guna2CustomCheckBox11.Checked = false;
            }

            var AbsenceSupprimer = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 2);
            if (AbsenceSupprimer != null)
            {
                guna2CustomCheckBox10.Checked = true;
            }
            else
            {
                guna2CustomCheckBox10.Checked = false;
            }

            var AbsenceModifier = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 4 && x.Role == 3);
            if (AbsenceModifier != null)
            {
                guna2CustomCheckBox12.Checked = true;
            }
            else
            {
                guna2CustomCheckBox12.Checked = false;
            }

            var TacheAjouter = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 1);
            if (TacheAjouter != null)
            {
                guna2CustomCheckBox14.Checked = true;
            }
            else
            {
                guna2CustomCheckBox14.Checked = false;
            }

            var TacheSupprimer = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 2);
            if (TacheSupprimer != null)
            {
                guna2CustomCheckBox13.Checked = true;
            }
            else
            {
                guna2CustomCheckBox13.Checked = false;
            }

            var TacheModifier = gs.TypeRole.FirstOrDefault(x => x.IdUtilisateur == idUtilisateurCombo && x.Type == 5 && x.Role == 3);
            if (TacheModifier != null)
            {
                guna2CustomCheckBox15.Checked = true;
            }
            else
            {
                guna2CustomCheckBox15.Checked = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
