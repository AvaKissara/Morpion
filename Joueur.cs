using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Joueur
    {
        private int idJoueur;
        public int GetId()
        {
            return idJoueur;
        }
        private string nomJoueur;
        public string NomJoueur
        {
            get { return nomJoueur; }
            set { nomJoueur = value; }
        }

        private string prenomJoueur;
        public string PrenomJoueur
        {
            get { return prenomJoueur; }
            set { prenomJoueur = value; }
        }

        private string pseudo;
        public string Pseudo
        {
            get { return pseudo; }
            set { pseudo = value; }
        }
        public CocheJoueur marqueur;
        public enum CocheJoueur
        {
            X,
            O
        }


        public Joueur(int IdJoueur, string PrenomJoueur, string NomJoueur, string Pseudo)
        {
            this.idJoueur= IdJoueur;
            this.prenomJoueur= PrenomJoueur;
            this.nomJoueur= NomJoueur;
            this.pseudo = Pseudo;
            //this.marqueur = Marqueur;
        }

        public Joueur(string Pseudo, CocheJoueur Marqueur)
        {
            this.pseudo = Pseudo;
            this.marqueur = Marqueur;   
        }
        

    }


}
