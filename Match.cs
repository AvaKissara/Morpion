using System;
using System.Collections.Generic;
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
            return finPartie;
        }
        private List<Joueur> lesParticipants;

        public Match(int NumMatch, Joueur Joueur, int Row, int Col, DateTime FinPartie)
        {
            this.numMatch = NumMatch;
            this.joueur = Joueur;
            this.row = Row;
            this.col = Col;
            this.finPartie = FinPartie;
            lesParticipants = new List<Joueur>();
        }

        public Match()
        {
            lesParticipants= new List<Joueur>();
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
