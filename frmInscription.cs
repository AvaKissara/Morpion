using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Morpion.Joueur;
using static System.Windows.Forms.DataFormats;

namespace Morpion
{
    public partial class frmInscription : Form
    {
        private static int compteurJoueur = 0;
        private static int compteurMatch = 0;
        private TextBox textBoxNomj1;
        private TextBox textBoxPrenomj1;
        private TextBox textBoxPseudoj1;
        private TextBox textBoxNomj2;
        private TextBox textBoxPrenomj2;
        private TextBox textBoxPseudoj2;
        private Button btnCancel;
        private Match leMatch;

        /// <summary>
        /// Constructeur pour le formulaire d'inscription qui prend un paramètre de type Match
        /// </summary>
        /// <param name="unMatch"></param>
        public frmInscription(Match unMatch)
        {
            InitializeComponent();
            //Création du label pour le choix du joueur (X ou O)
            Label labelj1 = new Label();
            labelj1.Text = "joueur X".ToUpper();
            labelj1.Location = new Point(250, 50);
            labelj1.Font = new Font("Arial", 12);
            Controls.Add((Label)labelj1);
            Label labelj2 = new Label();
            labelj2.Text = "joueur 0".ToUpper();
            labelj2.Location = new Point(420, 50);
            labelj2.Font = new Font("Arial", 12);
            Controls.Add((Label)labelj2);

            //Création du label et des textbox pour le nom, le prénom et le pseudo des deux joueurs
            Label labelNom = new Label();
            labelNom.Font = new Font("Arial", 10);
            labelNom.Text = "Nom";
            labelNom.Location = new Point(150, 130);
            Controls.Add((Label)labelNom);
            textBoxNomj1 = new TextBox();
            textBoxNomj1.Name = "textBoxNomj1";
            textBoxNomj1.Location = new Point(250, 130);
            Controls.Add((TextBox)textBoxNomj1);
            textBoxNomj2 = new TextBox();
            textBoxNomj2.Location = new Point(420, 130);
            Controls.Add((TextBox)textBoxNomj2);
            Label labelPrenom = new Label();
            labelPrenom.Font = new Font("Arial", 10);
            labelPrenom.Text = "Prénom";
            labelPrenom.Location = new Point(150, 180);
            Controls.Add((Label)labelPrenom);
            textBoxPrenomj1 = new TextBox();
            textBoxPrenomj1.Location = new Point(250, 180);
            Controls.Add((TextBox)textBoxPrenomj1);
            textBoxPrenomj2 = new TextBox();
            textBoxPrenomj2.Location = new Point(420, 180);
            Controls.Add((TextBox)textBoxPrenomj2);
            Label labelPseudo = new Label();
            labelPseudo.Font = new Font("Arial", 10);
            labelPseudo.Text = "Pseudo";
            labelPseudo.Location = new Point(150, 230);
            Controls.Add((Label)labelPseudo);
            textBoxPseudoj1 = new TextBox();
            textBoxPseudoj1.Location = new Point(250, 230);
            Controls.Add((TextBox)textBoxPseudoj1);
            textBoxPseudoj2 = new TextBox();
            textBoxPseudoj2.Location = new Point(420, 230);
            Controls.Add((TextBox)textBoxPseudoj2);

            //Création du bouton pour valider l'envoie des informations
            Button btnValider = new Button();
            btnValider.Size = new Size(180, 30);
            btnValider.Location = new Point(290, 360);
            btnValider.BackColor = Color.DarkGray;
            btnValider.ForeColor = Color.MintCream;
            btnValider.Font = new Font("Arial", 12);
            btnValider.Text = "Lancer la partie";
            btnValider.Click += new System.EventHandler(this.btnValider_Click);
            Controls.Add((Button)btnValider);

            //Création pour fermer le formulaire
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
        }

        /// <summary>
        /// Permet l'instanciation des joueurs après vérification des champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnValider_Click(object sender, EventArgs e)
        {
            if(this.controle())
            {
                if (this.instancie())
                {
                    this.Hide();
                    PlateauJeu partie = new PlateauJeu(this.leMatch);
                    partie.Closed += (jager, pastis) => this.Show();
                    partie.ShowDialog();
                }
            }
           
        }

        /// <summary>
        /// Retourne un booléen quant à la réussite de l'instanciation de l'objet
        /// </summary>
        /// <returns>Boolean</returns>
        private Boolean instancie()
        {
            Joueur joueur1;
            Joueur joueur2;
            Joueur j1;
            Joueur j2;
            Match unMatch;

            try
            {
                compteurJoueur++;
                joueur1 = new Joueur(compteurJoueur, textBoxNomj1.Text, textBoxPrenomj1.Text, textBoxPseudoj1.Text);
                j1 = new Joueur(textBoxPseudoj1.Text, Joueur.CocheJoueur.X, 0);
                compteurJoueur++;
                joueur2 = new Joueur(compteurJoueur, textBoxNomj2.Text, textBoxPrenomj2.Text, textBoxPseudoj2.Text);
                j2 = new Joueur(textBoxPseudoj2.Text, Joueur.CocheJoueur.O, 0);

                compteurMatch++;
                unMatch = new Match(compteurMatch);
                unMatch.AjouterJoueur(j1);
                unMatch.AjouterJoueur(j2);
                this.leMatch = unMatch;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private Boolean controle()
        {
            Boolean code = true;
            if (string.IsNullOrEmpty(textBoxNomj1.Text))
            {
                code = false;
                MessageBox.Show("Le j1 n'a pas renseigner le champs nom !", "ERREUR", MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(textBoxNomj2.Text))
            {
                code = false;
                MessageBox.Show("Le j2 n'a pas renseigner le champs nom !", "ERREUR", MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(textBoxPrenomj1.Text))
            {
                code = false;
                MessageBox.Show("Le j1 n'a pas renseigner le champs prénom !", "ERREUR", MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(textBoxPrenomj2.Text))
            {
                code = false;
                MessageBox.Show("Le j2 n'a pas renseigner le champs prénom !", "ERREUR", MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(textBoxPseudoj1.Text))
            {
                code = false;
                MessageBox.Show("Le j1 n'a pas renseigner le champs pseudo !", "ERREUR", MessageBoxButtons.OK);
            }
            if (string.IsNullOrEmpty(textBoxPseudoj2.Text))
            {
                code = false;
                MessageBox.Show("Le j2 n'a pas renseigner le champs pseudo !", "ERREUR", MessageBoxButtons.OK);
            }
            return code;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
