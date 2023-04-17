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
    public partial class PlateauJeu : Form
    {
       
        private Joueur leJoueur;
        private Match leMatch;   
        Joueur.CocheCellule[,] plateau = new Joueur.CocheCellule[3, 3];
        private List<Match> historique;
        private Joueur joueur1;
        private Joueur joueur2;
        private Joueur joueurActif;
        private int j1Victoire;
        private int j2Victoire;
        private Button uneCase;
        

        public PlateauJeu(Match unMatch)
        {
            InitializeComponent();
            this.historique = new List<Match>();
            this.leMatch = unMatch;
            historique = new List<Match>();
            joueurActif = joueur1;
            InitializeBoard();
        }
        public void InitializeBoard()
        {        
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    uneCase = new Button();
                    uneCase.Size = new Size(70, 70);
                    uneCase.Location = new Point(col * 70, row * 70);
                    uneCase.Click += new System.EventHandler(this.uneCase_Click);              
                    Controls.Add(uneCase);
                }
            }
        }

        private void uneCase_Click(object sender, EventArgs e)
        {
            Button command = (Button)sender;
            int row = this.Location.X /70;
            int col = this.Location.Y /70;
            if (plateau[row, col]==Joueur.CocheCellule.Empty)
            {
                plateau[row, col] = Joueur.CocheCellule;
            }
        }
    }
}
