using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Morpion.Joueur;

namespace Morpion
{
    public partial class frmInscription : Form
    {
        private static int compteurJoueur = 0;
        private static int compteurMatch = 0;
        private Joueur leJoueur;
        private TextBox textBoxNomj1;
        private TextBox textBoxPrenomj1;
        private TextBox textBoxPseudoj1;
        private TextBox textBoxNomj2;
        private TextBox textBoxPrenomj2;
        private TextBox textBoxPseudoj2;
        private Match leMatch;

     
        public frmInscription(Match unMatch)
        {
            InitializeComponent();

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
            
            Button btnValider = new Button();
            btnValider.Size = new Size(180, 30);
            btnValider.Location = new Point(290, 360);
            btnValider.BackColor = Color.DarkGray;
            btnValider.ForeColor = Color.MintCream;
            btnValider.Font = new Font("Arial", 12);
            btnValider.Text = "Lancer la partie";
            btnValider.Click += new System.EventHandler(this.btnValider_Click);
            Controls.Add((Button)btnValider);
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
           
            if (this.instancie())
            {
                
                this.DialogResult = DialogResult.OK;
                PlateauJeu partie = new PlateauJeu(this.leMatch);
                partie.ShowDialog();
            }
        }
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
                j1 = new Joueur(textBoxPseudoj1.Text,Joueur.CocheJoueur.X, 0);
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


    }
}
