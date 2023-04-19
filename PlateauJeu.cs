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
    public partial class PlateauJeu : Form
    {
        public CocheCellule jeton;
        public enum CocheCellule
        {
            Empty,
            X,
            O
        }
        private Joueur leJoueur;
        private Match leMatch;   
        public CocheCellule[,] plateau = new CocheCellule[3, 3];
        private List<Match> historique;
        private Joueur j1;
        private Joueur j2;
        private Joueur joueurActif;
        private int j1Victoire;
        private int j2Victoire;
        private Button uneCase;
        public DataGridView recapMatch;
        private Label phaseJeu;
        private Label phaseMortSubite;
        public int compteurManche = 6;
        private Button btnEgalite;
        private Button btnCancel;

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
            this.phaseJeu= new Label();
            this.phaseJeu.Text = "Match n°" + leMatch.GetNum().ToString();
            this.phaseJeu.Location = new Point(420, 210);
            this.phaseJeu.Size = new Size(220, 50);
            this.phaseJeu.Font = new Font("Arial", 20);
            this.Controls.Add((Label)phaseJeu);
            this.recapMatch = new DataGridView();
            this.recapMatch.AutoGenerateColumns = false;
            this.recapMatch.AllowUserToAddRows = false;
            this.recapMatch.ForeColor = Color.Black;
            this.recapMatch.Location = new Point(420,270);
            this.recapMatch.Size = new Size(344, 76);
            this.recapMatch.Font = new Font("Arial", 9);
            this.recapMatch.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.recapMatch.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.Controls.Add(recapMatch);

            this.btnCancel = new Button();
            this.btnCancel.Font = new Font("Arial", 10);
            this.btnCancel.Location = new Point(600, 380);
            this.btnCancel.Size = new Size(160, 40);
            this.btnCancel.BackColor = Color.DarkGray;
            this.btnCancel.ForeColor = Color.MintCream;
            this.btnCancel.Text = "Quitter".ToUpper();
            this.btnCancel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            this.Controls.Add(this.btnCancel);

            DataGridViewTextBoxColumn pseudoColumn = new DataGridViewTextBoxColumn();
            pseudoColumn.DataPropertyName = "Pseudo";
            pseudoColumn.HeaderText = "Pseudo";
            recapMatch.Columns.Add(pseudoColumn);

            DataGridViewTextBoxColumn marqueurColumn = new DataGridViewTextBoxColumn();
            marqueurColumn.DataPropertyName = "Marqueur";
            marqueurColumn.HeaderText = "Marqueur";
            recapMatch.Columns.Add(marqueurColumn);

            DataGridViewTextBoxColumn victoireColumn = new DataGridViewTextBoxColumn();
            victoireColumn.DataPropertyName = "Victoires";
            victoireColumn.HeaderText = "Victoires";
            recapMatch.Columns.Add(victoireColumn);

            this.recapMatch.DataSource = leMatch.ListerJoueur();
            this.recapMatch.Refresh();
        }
        public void InitializeBoard()
        {
            for (int row = 0; row <=2; row++)
            {
                for (int col = 0; col <=2; col++)
                {
                    this.uneCase = new Button();
                    this.uneCase.Size = new Size(80, 80);
                    this.uneCase.Location = new Point(50 + col * 85, 100 + row * 85);
                    this.uneCase.Tag = new Point(row, col);
                    this.uneCase.Font = new Font("Arial", 40);
                    this.uneCase.Click += new EventHandler(uneCase_Click);              
                    this.Controls.Add(uneCase);
                }
            }
        }

        private void uneCase_Click(object sender, EventArgs e)
        {
            
            phaseJeu.Text = "Partie en cours";
            Button command = (Button)sender;
            Point position = (Point)command.Tag;
            int row = (command.Location.Y - 100) / 85;
            int col = (command.Location.X - 50) / 85;
            if (compteurManche != 0)
            {
                if (plateau[row, col] == CocheCellule.Empty)
                {
                    plateau[row, col] = (CocheCellule)joueurActif.marqueur;
                    command.Text = joueurActif.marqueur.ToString();
                    if (GagnerBataille(joueurActif))
                    {
                        compteurManche--;
                      
                        MessageBox.Show(joueurActif.Pseudo + " a gagné cette manche!");
                        if (compteurManche == 0 && j1Victoire == j2Victoire)
                        {
                            this.BackColor = Color.Black;
                            this.ForeColor = Color.White;

                            this.phaseMortSubite = new Label();
                            this.phaseMortSubite.Location = new Point(420, 50);
                            this.phaseMortSubite.Size = new Size(200, 50);
                            this.phaseMortSubite.Font = new Font("Arial", 18);
                            this.phaseMortSubite.ForeColor = Color.Red;
                            this.Controls.Add((Label)phaseMortSubite);
                            this.phaseMortSubite.Text = "MORT SUBITE";

                            this.btnEgalite = new Button();
                            this.btnEgalite.Location = new Point(420, 120);
                            this.btnEgalite.Size = new Size(200, 50);
                           
                            this.btnEgalite.Text = "Déclarer une égalité".ToUpper();
                            this.btnEgalite.Click += new EventHandler(egalite_Click);
                            this.Controls.Add((Button)btnEgalite);

                        }
                        else if (compteurManche ==0)
                        {
                            AfficherVictoire();
                        }
                        Reset();
                        joueurActif = joueurActif == j1 ? j2 : j1;
                    }
                    else if (DefinirEgalite())
                    {
                        compteurManche--;
                        MessageBox.Show("Match nul!");
                        Reset();
                        joueurActif = joueurActif == j1 ? j2 : j1;
                    }
                    else
                    {
                        joueurActif = joueurActif == j1 ? j2 : j1;
                    }
                }
            }
            else if (j1Victoire == j2Victoire)
            {
                if (plateau[row, col] == CocheCellule.Empty)
                {
                    plateau[row, col] = (CocheCellule)joueurActif.marqueur;
                    command.Text = joueurActif.marqueur.ToString();
                    if (GagnerBataille(joueurActif))
                    {
                        if (joueurActif == j1)
                        {
                            j1.TotalVictoire++;
                        }
                        else
                        {
                            j2.TotalVictoire++;
                        }
                        AfficherVictoire();
                    }
                    else if (DefinirEgalite())
                    {
                        MessageBox.Show("Match nul!");
                        Reset();
                    }
                    else
                    {
                        joueurActif = joueurActif == j1 ? j2 : j1;
                    }
                }
            }
            //else
            //{
            //    AfficherVictoire();
            //}
        }

        private void egalite_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Félicitations, vous êtes sexy !");
            frmHallOfFame celebration = new frmHallOfFame();
            celebration.ShowDialog();
        }

        private bool GagnerBataille(Joueur unJoueur)
        {
            bool victoire = false;
            
            for (int row = 0; row < 3; row++)
            {
                if (plateau[row, 0] == (CocheCellule)unJoueur.marqueur &&
                   plateau[row, 1] == (CocheCellule)unJoueur.marqueur &&
                   plateau[row, 2] == (CocheCellule)unJoueur.marqueur)
                {
                    victoire = true;

                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (plateau[0,col] == (CocheCellule)unJoueur.marqueur&&
                    plateau[1, col] == (CocheCellule)unJoueur.marqueur &&
                    plateau[2, col] == (CocheCellule)unJoueur.marqueur)
                    {
                       victoire = true;
                    }
            }

            if (plateau[0, 0] == (CocheCellule)unJoueur.marqueur &&
                plateau[1, 1] == (CocheCellule)unJoueur.marqueur &&
                plateau[2, 2] == (CocheCellule)unJoueur.marqueur)
            {
                victoire = true;
            }

            if (plateau[0, 2] == (CocheCellule)unJoueur.marqueur &&
                plateau[1, 1] == (CocheCellule)unJoueur.marqueur &&
                plateau[2, 0] == (CocheCellule)unJoueur.marqueur)
            {
                victoire = true;
            }

            if (victoire)
            {
                if (joueurActif == j1)
                {
                    j1Victoire++;
                    j1.TotalVictoire++;
                }
                else
                {
                    j2Victoire++;
                    j2.TotalVictoire++;
                }
                AfficheJoueur();
            }

            return victoire;
        }

         public bool DefinirEgalite()
         {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (plateau[row, col] == CocheCellule.Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
         }

        public void Reset()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    plateau[row, col] = CocheCellule.Empty;
                    Controls[row * 3 + col].Text = "";
                }
            }
            historique.Clear();
        }

        public void AfficherVictoire()
        {           
            MessageBox.Show(joueurActif.Pseudo + " est le grand vainqueur!");
            this.Hide();
            frmHallOfFame celebration = new frmHallOfFame();

            celebration.Closed += (whisky, perrier) => this.Show();
            celebration.ShowDialog();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

