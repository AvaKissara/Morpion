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
    public partial class frmAccueil : Form
    {
        private Joueur leJoueur;
        private Match leMatch;
        public frmAccueil()
        {
            InitializeComponent();
            Button btnStart = new Button();
            btnStart.BackColor = Color.DarkGray;
            btnStart.ForeColor = Color.MintCream;
            btnStart.Size = new Size(190, 90);
            btnStart.Location = new Point(300, 180);
            btnStart.Font = new Font("Arial", 16);
            btnStart.Text = "Commencer une partie".ToUpper();
            btnStart.Click += new System.EventHandler(Button_Click); 
            Controls.Add(btnStart);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            frmInscription inscription = new frmInscription(this.leMatch);
            inscription.ShowDialog();
        }
    }
}
