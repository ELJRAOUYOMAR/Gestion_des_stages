using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projectezeze.Stage
{
   
    public partial class PieceJointe : Form
    { 
        
        EntityFramework.GestionStage gs = new EntityFramework.GestionStage();
         int mov, movx, movy;
        int idstage; //id de dossier
        string imageUrl = null;
        OpenFileDialog f = new OpenFileDialog();
        Image imagePiece;
        public PieceJointe()
        {
            InitializeComponent();
        }
        public PieceJointe(int idS)
        {
            InitializeComponent();
            idstage = idS;
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {

            //try
            //{
                if (guna2TextBox1.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Taper le nom de la pièce", "");
                    m.ShowDialog();
                    guna2TextBox1.Focus();
                    return;
                }
                if (guna2TextBox2.Text == "")
                {
                    MessageForm.Message1 m = new MessageForm.Message1("Taper le type de la pièce", "");
                    m.ShowDialog();
                    guna2TextBox2.Focus();
                    return;
                }
                //if (guna2TextBox3.Text == "")
                //{
                //    MessageForm.Message1 m = new MessageForm.Message1("Taper le chemin du pièce", "");
                //    m.ShowDialog();
                //    guna2TextBox3.Focus();
                //    return;
                //}
                //Image img = guna2PictureBox1.Image;
                byte[] by;
                ImageConverter conv = new ImageConverter();
                by = (byte[])conv.ConvertTo(imagePiece, typeof(byte[]));
                gs.PieceJointe.Add(new EntityFramework.PieceJointe { PieceJointe1 = guna2TextBox1.Text, TypePiece = guna2TextBox2.Text, Chemin = f.FileName, DateCreation = DateTime.Now, IdStage = idstage, Photo = by });
                gs.SaveChanges();
                PieceJointe_Load(sender, e);
            //}
            //catch (Exception ex)
            //{
            //    MessageForm.Message1 m = new MessageForm.Message1(ex.Message, "");
            //    m.ShowDialog();
            //}
        }

        private void PieceJointe_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = gs.PieceJointe.Where(x=>x.IdStage==idstage). Select(x => new
            {
                x.IdPiece,
                 Piéce = x.PieceJointe1,
               Type =  x.TypePiece,
                x.Chemin,
                x.DateCreation,
                x.Photo
            }).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.Rows.Count > 0)
                {
                    int idPiece = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    var req = gs.PieceJointe.FirstOrDefault(x => x.IdPiece == idPiece);
                    if (req != null)
                    {
                        gs.PieceJointe.Remove(req);
                        gs.SaveChanges();
                        PieceJointe_Load(sender, e);
                    }
                }
            }
            catch
            {
                MessageForm.Message1 m = new MessageForm.Message1("!!!", "");
                m.ShowDialog();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.SelectedColumns != null)
                {

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                var req = gs.PieceJointe.FirstOrDefault(x => x.IdPiece == id);
                if (req != null)
                {
                    req.PieceJointe1 = guna2TextBox1.Text;
                    req.TypePiece = guna2TextBox2.Text;
                    req.Chemin = guna2TextBox3.Text;
                    byte[] by;
                    ImageConverter conv = new ImageConverter();
                    by = (byte[])conv.ConvertTo(imagePiece, typeof(byte[]));
                    req.Photo = by;
                    gs.SaveChanges();
                    PieceJointe_Load(sender, e);
                }
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f.ShowDialog() == DialogResult.OK)
            {
                imageUrl = f.FileName;
                pictureBox1.Image = Image.FromFile(imageUrl);
                imagePiece = Image.FromFile(f.FileName);
                guna2TextBox3.Text = f.FileName;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Form2 fr = new Form2((byte[])dataGridView1.CurrentRow.Cells[6].Value);
            //fr.Show();
            //try
            //{
                if (dataGridView1.Rows.Count > 0)
                {
                    if (pictureBox1.Image == null)
                    {
                        MessageForm.LongMessage m = new MessageForm.LongMessage("Séléctionnez une ligne à partir de la table ci-dessous");
                        m.ShowDialog(); return;
                    }
                    int idp = (int)dataGridView1.CurrentRow.Cells[0].Value;
                photo ps = new photo(idp);
                ps.ShowDialog();
            }
            //}
            //catch
            //{
            //    MessageForm.Message1 m = new MessageForm.Message1("!!!", "");m.ShowDialog();
            //}
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            guna2TextBox3.Enabled = true;
            guna2Button4.Enabled = true;
            guna2Button1.Enabled = true;
            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var req = gs.PieceJointe.FirstOrDefault(x => x.IdPiece == id);
            try
            {
                
                if (req != null)
                {
                    guna2TextBox1.Text = req.PieceJointe1;
                    guna2TextBox2.Text = req.TypePiece;
                    guna2TextBox3.Text = req.Chemin;
                    MemoryStream ms = new MemoryStream((byte[])dataGridView1.CurrentRow.Cells[5].Value);
                    pictureBox1.Image = new Bitmap(ms);
                }
            }
            catch
            {
                guna2TextBox1.Text = req.PieceJointe1;
                guna2TextBox2.Text = req.TypePiece;
                guna2TextBox3.Text = req.Chemin;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movx = e.X;
            movy = e.Y;
        }
    }
}
