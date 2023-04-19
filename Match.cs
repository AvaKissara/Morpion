using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Match
    {
        private int numMatch;
        public int GetNum()
        {
            return numMatch;
        }
        private Joueur joueur;

        private int row;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        private int col; 
        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        private DateTime finPartie;
        public DateTime getTime()
        {
            finPartie= DateTime.Now;    
            return finPartie;
        }

        public List<Joueur> lesParticipants;

        public Match(int NumMatch, int Row, int Col, DateTime FinPartie)
        {
            this.numMatch = NumMatch;
            this.row = Row;
            this.col = Col;
            this.finPartie = FinPartie;
            this.lesParticipants = new List<Joueur>();
        }
        /// </summary>


        private DataTable dtJoueur;
        public Match(int NumMatch)
        {
            this.numMatch = NumMatch;
            lesParticipants = new List<Joueur>();
            dtJoueur = new DataTable();
            dtJoueur.Columns.Add(new DataColumn("Pseudo", typeof(string)));
            dtJoueur.Columns.Add(new DataColumn("Marqueur", typeof(string)));
            dtJoueur.Columns.Add(new DataColumn("Victoires", typeof(int)));

        }
        public DataTable ListerJoueur()
        {
            DataRow row;
            this.dtJoueur.Clear();

            // Remplir la DataTable avec les données des villes
            foreach (Joueur joueur in this.lesParticipants)
            {

                row = this.dtJoueur.NewRow();
                row[0] = joueur.Pseudo;
                row[1] = joueur.marqueur;
                row[2] = joueur.TotalVictoire;

                this.dtJoueur.Rows.Add(row);
            }
            return this.dtJoueur;
        }
        public void AjouterJoueur(Joueur unJoueur)
        {
            if (!lesParticipants.Contains(unJoueur))
            {
                this.lesParticipants.Add(unJoueur);
            }
        }

    }
}
