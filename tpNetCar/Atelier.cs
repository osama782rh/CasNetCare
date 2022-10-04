using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace tpCasNetCar
{
    /// <summary>
    /// Représente un atelier
    /// </summary>
    [Serializable]
    public class Atelier
    {
        private List<Vehicule> _collectionVehicule;

        /// <summary>
        /// Obtient la collection de véhicule de l'atelier
        /// </summary>
        public ReadOnlyCollection<Vehicule> CollectionVehicule
        {
            get
            {
                return new ReadOnlyCollection<Vehicule>(this._collectionVehicule);
            }
        }

        public List<EntretienType> CollectionEntretienType { get ; set ; }

        /// <summary>
        /// Initialise un objet de type Atelier
        /// </summary>
        public Atelier()
        {
            _collectionVehicule = new List<Vehicule>();
            CollectionEntretienType = new List<EntretienType>();
        }

        /// <summary>
        /// Indique si le véhicule passé en paramètre doit bénéficier d'un entretien
        /// </summary>
        /// <param name="unVehicule">Véhicule à vérifier</param>
        /// <returns>Vrai si le véhicule doit être soumis à un entretien, faux dans le cas contraire</returns>
        public bool NecessiteEntretien(Vehicule unVehicule)
        {
            bool neccessaire = false;
            int nbKmActuel = unVehicule.ObtenirNombreDekilometreAuCompteurDuVehicule();//kilométrage du véhicule
            Entretien dernierEntretien = unVehicule.ObtenirEntretien(unVehicule.ObtenirNombreDesEntretiensRealisesSurLeVehicule());
            int nbKilometreDernierEntretien = dernierEntretien.ObtenirNombreKilometreCompteur();
            int kmParcouruDepuisDernierEntretien = nbKmActuel - nbKilometreDernierEntretien;//Kilométrage parcouru depuis le dernier entretien
            foreach (EntretienType e in CollectionEntretienType)
            {//on parcourt les entretiens
                int kmEntretien = e.ObtenirNombreDeKilometreStandard();
                int kmTolerance = e.ObtenirMargeDeToleranceEnKilometre();
                //si le nombre de kilomètre parcouru se situe dans la tranche du kilométrage de l'entretien (avec les marges de tolérance)
                if (kmParcouruDepuisDernierEntretien >= kmEntretien - kmTolerance && kmParcouruDepuisDernierEntretien <= kmEntretien + kmTolerance)
                {
                    neccessaire = true; //l'entretien est à réalisé
                    break;
                }
            }
            return neccessaire;
        }

        /// <summary>
        /// Retourne une collection de véhicules devant bénéficier d'un entretien
        /// </summary>
        /// <returns>Une collection de véhicules à entretenir</returns>
        public List<Vehicule> VehiculeAEntretenir()
        {
            List<Vehicule> listeVehiculeAEntretenir = new List<Vehicule>();
            foreach (Vehicule v in _collectionVehicule)
            {
                if(NecessiteEntretien(v))
                {
                    listeVehiculeAEntretenir.Add(v);
                }
            }
            return listeVehiculeAEntretenir;
        }

        /// <summary>
        /// Ajoute un véhicule à l'atelier
        /// </summary>
        /// <param name="immatriculation">L'immatriculation du véhicule</param>
        /// <param name="nbKm">Le nombre de kilomètre au compteur</param>
        public void AjouterVehicule(string immatriculation, int nbKm)
        {
            Vehicule vehicule = new Vehicule(immatriculation, nbKm);
            this._collectionVehicule.Add(vehicule);
        }

        /// <summary>
        /// recherche un véhicule dans l'atelier à partir de son numéro d'immatriculation
        /// </summary>
        /// <param name="immatriculation">Le numéro d'immatriculation du véhicule recherché</param>
        /// <returns>Le véhicule recherché</returns>
        public Vehicule RechercheVehicule(string immatriculation)
        {
            Vehicule vehiculeRecherche = null;
            foreach (Vehicule unVehicule in _collectionVehicule)
            {
                if(unVehicule.ObtenirImmatriculation()==immatriculation)
                {
                    vehiculeRecherche = unVehicule;
                    break;
                }
            }
            return vehiculeRecherche;
        }

        /// <summary>
        /// Supprime un véhicule de la collection de véhicule
        /// </summary>
        /// <param name="immatriculation">Le numéro d'immatriculation du véhicule supprimé</param>
        /// <returns>True si le véhicule a été supprimé, false dans le cas contraite</returns>
        public bool SupprimerVehicule(string immatriculation)
        {
            return this._collectionVehicule.Remove(RechercheVehicule(immatriculation));
        }

        /// <summary>
        /// Vérifie l'existance d'un véhicule dans l'atelier
        /// </summary>
        /// <param name="immatriculation">L'immatriculation du véhicule recherché</param>
        /// <returns>Vrai si le véhicule est déja présent dans l'atelier, Faux dans le cas contraire</returns>
        public bool VehiculeExiste(string immatriculation)
        {
            bool existe = true;
            if (RechercheVehicule(immatriculation) == null)
            {
                existe = false;
            }
            return existe;
        }

        /// <summary>
        /// retourne le nombre de véhicule présent dans l'atelier
        /// </summary>
        /// <returns>le nombre de véhicule présent dans l'atelier</returns>
        public int NombreDeVehiculePresentDansAtelier()
        {
            return this._collectionVehicule.Count;
        }
    }
}
