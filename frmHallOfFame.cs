using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Morpion
{
    public partial class frmHallOfFame : Form
    {
        private Label labelHailYou;
        private Button btnRestart;
        private Button btnCancel;
        private Match leMatch;
        public frmHallOfFame()
        {
            InitializeComponent();
            this.BackColor = Color.DimGray;
            this.ForeColor = Color.White;
            this.labelHailYou = new Label();
            this.labelHailYou.Text = "Bravo";
            this.labelHailYou.Name = "labelHailYou";
            this.labelHailYou.Location = new Point(320, 130);
            this.Controls.Add((Label)labelHailYou);
            this.btnRestart= new Button();
            this.btnRestart.Location = new Point(280, 200);
            this.btnRestart.Size = new Size(200, 100);
            this.btnRestart.BackColor = Color.DarkGray;
            this.btnRestart.ForeColor = Color.MintCream;
            this.btnRestart.Font = new Font("Arial", 15);
            this.btnRestart.Text = "Recommencer une partie".ToUpper();
            this.btnRestart.Click += new System.EventHandler(btnRestart_Click);
            Controls.Add(this.btnRestart);

            this.btnCancel= new Button();   
            this.btnCancel.Font = new Font("Arial", 10);
            this.btnCancel.Location = new Point(600, 380);
            this.btnCancel.Size= new Size(170, 50);
            this.btnCancel.Text = "Quitter".ToUpper();
            this.btnCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            this.Controls.Add(this.btnCancel);

            
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmInscription inscription = new frmInscription(this.leMatch);
            inscription.Closed += (baileys, citron) => this.Show();
            inscription.ShowDialog();
        }
    }
}
