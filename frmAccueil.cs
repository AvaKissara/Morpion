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
            Button button = new Button();
            button.Size = new Size(170, 70);
            button.Location = new Point(300, 180);
            button.Text = "Commencer une partie".ToUpper();
            button.Click += new System.EventHandler(Button_Click); 
            Controls.Add(button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            frmInscription inscription = new frmInscription(this.leMatch);
            inscription.ShowDialog();
        }
    }
}
