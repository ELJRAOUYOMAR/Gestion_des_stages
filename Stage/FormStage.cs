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
    public partial class FormStage : Form
    {
        int mov, movx, movy ,id ,idds;
        MainStage ms;
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
        ClassesDeProjet.GestionDesComptes GC = new ClassesDeProjet.GestionDesComptes();
        string email, password;
        public FormStage(MainStage MS ,int ID,string e,string p)
        {
            InitializeComponent();
            ms = MS;
            id = ID;
            password = p;
            email = e;
        }
         private void FormStage_Load(object sender, EventArgs e)
         {
            if (id == 1)
            {
               
                var req = gs.Tache.Where(x => x.Tache1.StartsWith(guna2TextBox11.Text)).Select(x => new { IDTACHE = x.IdTache, Tache = x.Tache1 }).ToList();
                guna2ComboBox1.DisplayMember = "Tache";
                guna2ComboBox1.ValueMember = "IDTACHE";
                guna2ComboBox1.DataSource = req;
                guna2ComboBox1.SelectedIndex = -1;
                var req1 = gs.Stagiaire.Where(x => x.Cin.StartsWith(guna2TextBox12.Text) || x.NomComplet.StartsWith(guna2TextBox12.Text)).Select(x => new { CinNom = x.Cin + " " + x.NomComplet, x.IdStagiaire }).ToList();
                guna2ComboBox2.DisplayMember = "CinNom";
                guna2ComboBox2.ValueMember = "IdStagiaire";
                guna2ComboBox2.DataSource = req1;
                guna2ComboBox2.SelectedIndex = -1;


            }
            else if (id == 2)
            {  
                guna2Button8.Text = "Modiffier";
                int ids = (int)ms.dataGridView1.CurrentRow.Cells[0].Value;
                var req = gs.Stage.FirstOrDefault(x => x.IdStage == ids);
                var req1 = gs.Tache.Where(x => x.Tache1.StartsWith(guna2TextBox11.Text)).Select(x => new { IDTACHE = x.IdTache, Tache = x.Tache1 }).ToList();
                guna2ComboBox1.DisplayMember = "Tache";
                guna2ComboBox1.ValueMember = "IDTACHE";
                guna2ComboBox1.DataSource = req1;
                var req2 = gs.Taches.Where(x => x.IdStage == ids).Select(x => new { Tache = x.Tache.Tache1, x.IdStage, x.IdTache });
                listBox1.DisplayMember = "Tache";
                listBox1.ValueMember = "IdTache";
                listBox1.DataSource = req2.ToList();
                guna2ComboBox1.SelectedIndex = -1;
                if (req != null)
                {
                    guna2TextBox7.Text = req.Type.ToString();
                    guna2TextBox8.Text = req.Formation.ToString();
                    guna2TextBox9.Text = req.IntituleProjet.ToString();
                    guna2TextBox10.Text = req.DecriptionDeProjet.ToString();
                    guna2DateTimePicker4.Value=(DateTime)req.DateDebut.Value;
                    guna2DateTimePicker1.Value=(DateTime)req.DateFin.Value;
                    guna2TextBox12.Text = req.Stagiaire.NomComplet.ToString();


                }


                  

            }

           



        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }

      

        private void guna2Button8_Click_1(object sender, EventArgs e)
        {
            
            if (id == 1)
            {
                ///
                if (guna2TextBox7.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Type ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox8.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Formation ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox9.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Projet ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox10.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Description ?", "");
                    ms.ShowDialog();
                }
                if (listBox1.Items.Count == 0)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Tache ?", "");
                    ms.ShowDialog();
                }
                if (guna2ComboBox2.SelectedIndex==-1)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Stagaire ?", "");
                    ms.ShowDialog();
                }
                ///

                if (guna2DateTimePicker4.Value >= guna2DateTimePicker1.Value)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("date de début doit être inférieur à date fin ","");
                    ms.ShowDialog();
                    return;

                }
                int idTache = (int)guna2ComboBox1.SelectedValue;
                int idstagiaire = int.Parse(guna2ComboBox2.SelectedValue.ToString());
                gs.Stage.Add(new EntityFramework.Stage
                {
                    Type = guna2TextBox7.Text,
                    Formation = guna2TextBox8.Text,
                    IntituleProjet = guna2TextBox9.Text,
                    DecriptionDeProjet = guna2TextBox10.Text,
                    DateFin = guna2DateTimePicker1.Value
                ,
                    DateDebut = guna2DateTimePicker4.Value,
                    IdStagiaire = idstagiaire
                });
                gs.SaveChanges();
                var req = gs.Stage.Select(x => new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation, Projet = x.IntituleProjet, Duree = x.Duree.ToString()}).ToList();
                ms.dataGridView1.DataSource = req;
                int idUtilisateur = GC.user(email, password).IdUtilisateur;
                GC.ajouterAction("Addition d'un stage", idUtilisateur);

                guna2TextBox7.Text = "";
                guna2TextBox8.Text = "";
                guna2TextBox9.Text = "";
                guna2TextBox10.Text = "";
                guna2TextBox11.Text = "";
                guna2TextBox12.Text = "";
                guna2ComboBox1.SelectedIndex = -1;
                guna2ComboBox2.SelectedIndex = -1;

            }
            if (id == 2)
            {

                ///
                if (guna2TextBox7.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Type ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox8.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Formation ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox9.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Projet ?", "");
                    ms.ShowDialog();
                }
                if (guna2TextBox10.Text == null)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Description ?", "");
                    ms.ShowDialog();
                }
                if (listBox1.Items.Count == 0)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Tache ?", "");
                    ms.ShowDialog();
                }
                if (guna2ComboBox2.SelectedIndex == -1)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Stagaire ?", "");
                    ms.ShowDialog();
                }
                ///

                if (guna2DateTimePicker4.Value >= guna2DateTimePicker1.Value)
                {
                    MessageForm.Message1 ms = new MessageForm.Message1("Date de début doit être inférieur à date fin ", "");
                    ms.ShowDialog();
                    return;

                }
                int ids = (int)ms.dataGridView1.CurrentRow.Cells[0].Value;

                var req1 = gs.Stage.FirstOrDefault(x => x.IdStage == ids);
                req1.Type = guna2TextBox7.Text;
                req1.Formation = guna2TextBox8.Text;
                req1.IntituleProjet = guna2TextBox9.Text;
                req1.DecriptionDeProjet = guna2TextBox10.Text;
                req1.IdStagiaire = (int)guna2ComboBox2.SelectedValue;
                req1.DateDebut = guna2DateTimePicker4.Value;
                req1.DateFin = guna2DateTimePicker1.Value;
                gs.SaveChanges();
                var req = gs.Stage.Select(x => new { x.IdStage, x.Stagiaire.Cin, x.Type, x.Formation, Projet = x.IntituleProjet, Duree = x.Duree.ToString() }).ToList();
                ms.dataGridView1.DataSource = req;
                int idUtilisateur = GC.user(email, password).IdUtilisateur;
                GC.ajouterAction("Modification d'un stage", idUtilisateur);
            }
       
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            var req = gs.Tache.Where(x => x.Tache1.StartsWith(guna2TextBox11.Text )).Select(x=> new {IDTACHE =x.IdTache, Tache=x.Tache1}).ToList();
            guna2ComboBox1.DisplayMember = "Tache";
            guna2ComboBox1.ValueMember = "IDTACHE";
            guna2ComboBox1.DataSource = req;

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void guna2ComboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            if (id == 1)
            {

            var req = gs.Stage.OrderByDescending(x => x.IdStage).ToList();
            idds= req[0].IdStage + 1;
            int idtache = (int)guna2ComboBox1.SelectedValue;
            gs.Tache.Add(new EntityFramework.Tache { IdTache = idtache, IdStage = idds });
            gs.SaveChanges();
            var req1 = gs.Tache.Where(x => x.IdStage == idds).Select(x => new { Tache = x.Tache.Tache1, x.IdStage  ,x.IdTache});
            listBox1.DisplayMember = "Tache";
            listBox1.ValueMember = "IdTache";
            listBox1.DataSource = req1.ToList();
            }
            if (id == 2)
            {
                int ids = (int)ms.dataGridView1.CurrentRow.Cells[0].Value;
                int idtache = (int)guna2ComboBox1.SelectedValue;
                gs.Tache.Add(new EntityFramework.Tache { IdTache = idtache, IdStage = ids });
                gs.SaveChanges();
                var req1 = gs.Tache.Where(x => x.IdStage == ids).Select(x => new { Tache = x.Tache.Tache1, x.IdStage, x.IdTache });
                listBox1.DisplayMember = "Tache";
                listBox1.ValueMember = "IdTache";
                listBox1.DataSource = req1.ToList();

            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            if (id == 1)
            {
                if (listBox1.Items.Count != 0)
                {
                    
                    var req1 = gs.Stage.OrderByDescending(x => x.IdStage).ToList();
                    if (req1[0].IdStage != idds)
                    {
                            var req = gs.Stage.OrderByDescending(x => x.IdStage).ToList();
                                            int ids = req[0].IdStage + 1;
                                            var req2 = gs.Tache.Where(x => x.IdStage == ids).ToList();
                                            foreach(var i in req2)
                                            {
                                                gs.Tache.Remove(i);
                                                gs.SaveChanges();
                                            }
                    }
                }
                         
              
           
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                if (id == 1)
                {

            var req2 = gs.Stage.OrderByDescending(x => x.IdStage).ToList();
            int ids = req2[0].IdStage + 1;
            int idtache = (int)listBox1.SelectedValue;
            var req = gs.Taches.FirstOrDefault(x => x.IdTache == idtache);
            gs.Taches.Remove(req);
            gs.SaveChanges();
            var req1 = gs.Taches.Where(x => x.IdStage == ids).Select(x => new { Tache = x.Tache.Tache1, x.IdStage, x.IdTache });
            listBox1.DisplayMember = "Tache";
            listBox1.ValueMember = "IdTache";
            listBox1.DataSource = req1.ToList();
                }

            if (id == 2)
            {
                    int ids = (int)ms.dataGridView1.CurrentRow.Cells[0].Value;
                    int idtache = (int)listBox1.SelectedValue;
                    var req = gs.Taches.FirstOrDefault(x =>  x.IdStage==ids);
                    gs.Taches.Remove(req);
                    gs.SaveChanges();
                    var req1 = gs.Taches.Where(x => x.IdStage == ids).Select(x => new { Tache = x.Tache.Tache1, x.IdStage, x.IdTache });
                    listBox1.DisplayMember = "Tache";
                    listBox1.ValueMember = "IdTache";
                    listBox1.DataSource = req1.ToList();

                }
            }


        }

       

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            var req = gs.Stagiaire.Where(x => x.Cin.StartsWith(guna2TextBox12.Text) || x.NomComplet.StartsWith(guna2TextBox12.Text)).Select(x => new { CinNom = x.Cin + " " + x.NomComplet, x.IdStagiaire }).ToList();
            guna2ComboBox2.DisplayMember = "CinNom";
            guna2ComboBox2.ValueMember = "IdStagiaire";
            guna2ComboBox2.DataSource = req;
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
