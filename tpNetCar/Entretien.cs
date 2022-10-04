using System;


namespace tpCasNetCar
{
    /// <summary>
    /// Représente un entretien
    /// </summary>
    [Serializable]
    public class Entretien
    {
        /// <summary>
        /// la date de l'entretien
        /// </summary>
        private DateTime _dateEntretien;

        /// <summary>
        /// Le nombre de kilomètre au compteur au moment de l'entretien
        /// </summary>
        private int _nbKmCompteur;

        /// <summary>
        /// Un commentaire associé à l'entretien courant
        /// </summary>
        private string _commentaire;

        /// <summary>
        /// Le type d'entretien concerné par l'entretien courant
        /// </summary>
        private EntretienType _leType;

        /// <summary>
        /// Retourne le nombre de kilomètre au compteur au moment de l'entretien
        /// </summary>
        /// <returns>le nombre de kilomètre au compteur au moment de l'entretien</returns>
        public int ObtenirNombreKilometreCompteur()
        {
            return _nbKmCompteur;
        }

        /// <summary>
        /// Initialise un objet de type Entretien à partir des informations transmises en paramètres
        /// </summary>
        /// <param name="dateEntretien">la date d'entretien</param>
        /// <param name="nbKmCompteur">le nombre de kilomètre au compteur au moment de l'entretien</param>
        /// <param name="commentaire">le commentaire associé à l'entretien</param>
        /// <param name="leType">le type d'entretien concerné par l'entretien courant</param>
        public Entretien(DateTime dateEntretien, int nbKmCompteur, string commentaire, EntretienType leType)
        {
            this._dateEntretien = dateEntretien;
            this._nbKmCompteur = nbKmCompteur;
            this._commentaire = commentaire;
            this._leType = leType;
        }

    }
}
