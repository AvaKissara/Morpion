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
        private CocheCellule jeton;
        public enum CocheCellule
        {
            Empty,
            X,
            O
        }
        private Joueur leJoueur;
        private Match leMatch;   
        CocheCellule[,] plateau = new CocheCellule[3, 3];
        //CocheCellule joueurActif = CocheCellule.X;
        private List<Match> historique;
        private Joueur j1;
        private Joueur j2;
        private Joueur joueurActif;
        private int j1Victoire;
        private int j2Victoire;
        private Button uneCase;
        public DataGridView recapMatch;
        

        public PlateauJeu(Match unMatch)
        {
            InitializeComponent();
            this.historique = new List<Match>();
            this.leMatch = unMatch;
            j1= unMatch.lesParticipants[0];
            j2= unMatch.lesParticipants[1];
            joueurActif = j1;
            InitializeBoard();
            AfficheJoueur();
        }


        public void AfficheJoueur()
        {
            recapMatch = new DataGridView();
            this.recapMatch.AutoGenerateColumns = false;
            this.recapMatch.Location = new Point(300,200);
            //this.recapMatch.Dock = DockStyle.Fill;
            Controls.Add(recapMatch);
            // Ajouter une colonne pour le pseudo
            DataGridViewTextBoxColumn pseudoColumn = new DataGridViewTextBoxColumn();
            pseudoColumn.DataPropertyName = "Pseudo";
            pseudoColumn.HeaderText = "Pseudo";
            recapMatch.Columns.Add(pseudoColumn);

            // Ajouter une colonne pour le marqueur
            DataGridViewTextBoxColumn marqueurColumn = new DataGridViewTextBoxColumn();
            marqueurColumn.DataPropertyName = "Marqueur";
            marqueurColumn.HeaderText = "Marqueur";
            recapMatch.Columns.Add(marqueurColumn);

            this.recapMatch.DataSource = leMatch.ListerJoueur();
            this.recapMatch.Refresh();
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
                    //j1 = new Joueur(, CocheCellule.X);
                }
            }
        }

        private void uneCase_Click(object sender, EventArgs e)
        {
            Button command = (Button)sender;
            int row = this.Location.X /70;
            int col = this.Location.Y /70;
            if (plateau[row, col]==CocheCellule.Empty)
            {
                plateau[row, col] = (CocheCellule)joueurActif.marqueur;
                command.Text = joueurActif.marqueur.ToString();
                if(GagnerBataille(joueurActif))
                {
                    MessageBox.Show(joueurActif.Pseudo + " est vainqueur!");
                    //                    // Afficher l'historique des victoires
                    //                    ShowWinsHistory();
                    //                    ResetBoard();
                }
                else
                {
                    joueurActif = joueurActif == j1 ? j2 : j1;
                }
            }
        }

        private bool GagnerBataille(Joueur unJoueur)
        {
            bool victoire = false;

            // Vérifier les lignes
            for (int row = 0; row < 3; row++)
            {
                if (plateau[row, 0] == (CocheCellule)unJoueur.marqueur &
                    plateau[row, 1] == (CocheCellule)unJoueur.marqueur &
                    plateau[row, 2] == (CocheCellule)unJoueur.marqueur)
                {
                    victoire = true;
                    break;
                }
            }

            // Vérifier les colonnes
            for (int col = 0; col < 3; col++)
            {
                if (plateau[0, col] == (CocheCellule)unJoueur.marqueur &&
                    plateau[1, col] == (CocheCellule)unJoueur.marqueur &&
                    plateau[2, col] == (CocheCellule)unJoueur.marqueur)
                    {
                        victoire = true;
                        break;
                    }
            }

            // Vérifier la diagonale principale
            if (plateau[0, 0] == (CocheCellule)unJoueur.marqueur &&
                plateau[1, 1] == (CocheCellule)unJoueur.marqueur &&
                plateau[2, 2] == (CocheCellule)unJoueur.marqueur)
            {
                victoire = true;
            }

            // Vérifier la diagonale secondaire
            if (plateau[0, 2] == (CocheCellule)unJoueur.marqueur &&
                plateau[1, 1] == (CocheCellule)unJoueur.marqueur &&
                plateau[2, 0] == (CocheCellule)unJoueur.marqueur)
            {
                victoire = true;
            }
            if (victoire)
            {
                if (unJoueur == j1)
                {
                    j1Victoire++;
                }
                else
                {
                    j2Victoire++;
                }
            }

            return victoire;
        }
    }
}
