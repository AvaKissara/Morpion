using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Morpion
{
    public partial class frmHallOfFame : Form
    {
        private Label labelHailYou;
        private Button btnRestart;
        private Match leMatch;
        public frmHallOfFame()
        {
            InitializeComponent();
            this.labelHailYou = new Label();
            this.labelHailYou.Text = "Bravo";
            this.labelHailYou.Name = "labelHailYou";
            this.labelHailYou.Location = new Point(300, 130);
            this.Controls.Add((Label)labelHailYou);
            this.btnRestart= new Button();
            this.btnRestart.Location = new Point(280, 280);
            this.btnRestart.Size = new Size(190, 100);
            this.btnRestart.BackColor = Color.DarkGray;
            this.btnRestart.ForeColor = Color.MintCream;

            this.btnRestart.Font = new Font("Arial", 16);
            this.btnRestart.Text = "Recommencer une partie".ToUpper();
            this.btnRestart.Click += new System.EventHandler(btnRestart_Click);
            Controls.Add(this.btnRestart);
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            frmInscription inscription = new frmInscription(this.leMatch);
            inscription.ShowDialog();
        }
    }
}
