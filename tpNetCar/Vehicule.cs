using System;
using System.Collections.Generic;

namespace tpCasNetCar
{
    /// <summary>
    /// Représente un véhicule
    /// </summary>
    [Serializable]
    public class Vehicule
    {
        private string _numeroImmatriculationDuVehicule;
        private int _nombreDeKilometresAuCompteurDuVehicule;
        private List<Entretien> _colletionDesEntretiensDuVehicule;

        /// <summary>
        /// Initialise un véhicule
        /// </summary>
        /// <param name="numImmatriculation">Le numéro d'immatriculation du véhicule</param>
        /// <param name="nbKilometreAuCompteur">Le nombre de kilomètre au compteur</param>
        public Vehicule(string numImmatriculation, int nbKilometreAuCompteur)
        {
            this._numeroImmatriculationDuVehicule = numImmatriculation;
            this._nombreDeKilometresAuCompteurDuVehicule = nbKilometreAuCompteur;
            _colletionDesEntretiensDuVehicule = new List<Entretien>();
        }      

        /// <summary>
        /// retourne l'immatriculation du véhicule
        /// </summary>
        /// <returns></returns>
        public string ObtenirImmatriculation()
        {
            return _numeroImmatriculationDuVehicule;
        }

        /// <summary>
        /// retourne le nombre de kilomètre au compteur du véhicule courant
        /// </summary>
        /// <returns></returns>
        public int ObtenirNombreDekilometreAuCompteurDuVehicule()
        {
            return _nombreDeKilometresAuCompteurDuVehicule; 
        }

        /// <summary>
        /// retourne le nombre d'entretiens réalisés sur le véhicule
        /// </summary>
        /// <returns></returns>
        public int ObtenirNombreDesEntretiensRealisesSurLeVehicule()
        {
            return _colletionDesEntretiensDuVehicule.Count;
        }        

        /// <summary>
        /// retourne un entretien positionné à l'index fourni en paramètre
        /// </summary>
        /// <param name="index">L'index représentant la position dans la collection d'entretien du véhicule</param>
        /// <returns>Un entretien.</returns>
        public Entretien ObtenirEntretien(int index)
        {
            Entretien unEntretien = null;
            if(_colletionDesEntretiensDuVehicule.Count <= index && index >=0)
            {
                unEntretien = _colletionDesEntretiensDuVehicule[index];
            }
            return unEntretien;
        }

        /// <summary>
        /// Ajoute un entretien à la collection d'entretien du véhicule courant
        /// </summary>
        /// <param name="uneDate">La date de l'entretien</param>
        /// <param name="unCommentaire">Un commentaire associé à cet entretien </param>
        /// <param name="entretienType">Le type d'entretien concerné</param>
        public void AjouterUnEntretien(DateTime uneDate, string unCommentaire, EntretienType entretienType)
        {
            Entretien unEntretien = new Entretien(uneDate, _nombreDeKilometresAuCompteurDuVehicule, unCommentaire, entretienType);
            _colletionDesEntretiensDuVehicule.Add(unEntretien);
        }
                
        
    }
}
