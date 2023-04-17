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
        private CocheCellule marqueur;
        private Match leMatch;

     
        public frmInscription(Match unMatch)
        {
            InitializeComponent();

            Label labelj1 = new Label();
            labelj1.Text = "joueur X".ToUpper();
            labelj1.Location = new Point(250, 50);
            Controls.Add((Label)labelj1);
            Label labelj2 = new Label();
            labelj2.Text = "joueur 0".ToUpper();
            labelj2.Location = new Point(420, 50);
            Controls.Add((Label)labelj2);

            Label labelNom = new Label();
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
            labelPseudo.Text = "Pseudo";
            labelPseudo.Location = new Point(150, 230);
            Controls.Add((Label)labelPseudo);
            textBoxPseudoj1 = new TextBox();
            textBoxPseudoj1.Location = new Point(250, 230);
            Controls.Add((TextBox)textBoxPseudoj1);
            textBoxPseudoj2 = new TextBox();
            textBoxPseudoj2.Location = new Point(420, 230);
            Controls.Add((TextBox)textBoxPseudoj2);
            

            //ComboBox selectMarqueurJ1 = new ComboBox();
            //selectMarqueurJ1.Location = new Point(250, 290);
            //selectMarqueurJ1.Size = new Size(100, 20);
            //Controls.Add((ComboBox)selectMarqueurJ1);
            //ComboBox selectMarqueurJ2 = new ComboBox();
            //selectMarqueurJ2.Location = new Point(420, 290);
            //selectMarqueurJ2.Size = new Size(100, 20);
            //selectMarqueurJ2.Items.Add("hi");
            //Controls.Add((ComboBox)selectMarqueurJ2);

            Button btnValider = new Button();
            btnValider.Size = new Size(120, 30);
            btnValider.Location = new Point(330, 360);
            btnValider.Text = "Lancer la partie";
            btnValider.Click += new System.EventHandler(this.btnValider_Click);
            Controls.Add((Button)btnValider);

            //selectMarqueurJ1.DataSource = Enum.GetValues(typeof(CocheCellule));
            //selectMarqueurJ2.DataSource = Enum.GetValues(typeof(CocheCellule));
            //CocheCellule cocheCellule;
            //Enum.TryParse(selectMarqueurJ1.SelectedValue.ToString(), out cocheCellule);
            //Enum.TryParse(selectMarqueurJ2.SelectedValue.ToString(), out cocheCellule);

            this.leMatch = unMatch;

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
            Match unMatch;
                    
            try
            {
                compteurJoueur++;
                joueur1 = new Joueur(compteurJoueur, textBoxNomj1.Text, textBoxPrenomj1.Text, textBoxPseudoj1.Text, Joueur.CocheCellule.X);
                compteurJoueur++;
                joueur2 = new Joueur(compteurJoueur, textBoxNomj2.Text, textBoxPrenomj2.Text, textBoxPseudoj2.Text, Joueur.CocheCellule.O);
                unMatch= new Match();
                compteurMatch++;
                unMatch.AjouterJoueur(joueur1);
                unMatch.AjouterJoueur(joueur2);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
