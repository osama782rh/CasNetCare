using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace tpCasNetCar
{
    class Program
    {
        public static bool IsNumerique(string chaineSaisie)
        {
            bool isNum = true;
            for (int i = 0; i < chaineSaisie.Length; i++)
            {
                if (!char.IsDigit(chaineSaisie, i))
                {
                    isNum = false;
                    Console.WriteLine("le caractère a la position " + (i + 1) + " n'est pas un chiffre");
                }
            }
            return isNum;
        }

        public static int SaisirEntier()
        {
            string valeurSaisie;
            do
            {
                valeurSaisie = Console.ReadLine();
            }
            while (!Program.IsNumerique(valeurSaisie));
            return Convert.ToInt32(valeurSaisie);
        }

        public static bool IsImmatriculation(string immatriculation)
        {
            bool isImmatriculation ;
            string pattern = @"^[A-Z]{2}[0-9]{3}[A-Z]{2}$";
            Regex regex = new Regex(pattern);
            isImmatriculation = regex.IsMatch(immatriculation);
            return isImmatriculation;
        }

        static void Main(string[] args)
        {

            List<EntretienType> collectionEntretienType = Persistance.ChargerDonnees("EntretienType") as List<EntretienType>;
            if (collectionEntretienType == null)
            {
                collectionEntretienType = new List<EntretienType>();
            }
            Atelier unAtelier = Persistance.ChargerObjet("Atelier") as Atelier;
            if (unAtelier == null)
            {
                unAtelier = new Atelier();
            }

            unAtelier.CollectionEntretienType = collectionEntretienType;
            int choix;
            bool continuer = true;
            do
            {

                Console.WriteLine(
                    "\n0- Sortir du programme " +
                    "\n1- Ajouter un véhicule" +
                    "\n2- Supprimer un véhicule" +
                    "\n3- Liste des véhicules" +
                    "\n4- Ajouter un type d'entretien" +
                    "\n5- Supprimer un type d'entretien" +
                    "\n6- Afficher les types d'entretien" +
                    "\n7- Vérifier les entretiens d'un véhicule" +
                    "\n");
                try
                {
                    choix = SaisirEntier();
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Saisir une valeur numérique");
                    choix = -1;
                }

                switch (choix)
                {
                    case 1:
                        Console.WriteLine("Saisir le numéro d'immatriculation au format AA-999-AA");
                        string immatriculation = Console.ReadLine();
                        Console.WriteLine("Saisir le Kilométrage");
                        int km = SaisirEntier();
                        unAtelier.AjouterVehicule(immatriculation, km);
                        break;

                    case 2:
                        Console.WriteLine("Saisir le numéro d'immatriculation");
                        immatriculation = Console.ReadLine();
                        unAtelier.SupprimerVehicule(immatriculation);
                        break;

                    case 3:
                        foreach (Vehicule v in unAtelier.CollectionVehicule)
                        {
                            Console.WriteLine("Immatriculation : " + v.ObtenirImmatriculation() + " Km : " + v.ObtenirNombreDekilometreAuCompteurDuVehicule() + " ");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Ajouter un type d'entretien");
                        Console.WriteLine("Saisir le code de l'entretien");
                        string code = Console.ReadLine();
                        Console.WriteLine("Kilométrage de référence de cet entretien");
                        int nbKm = SaisirEntier();
                        Console.WriteLine("Tolerence du kilométrage de référence de cet entretien");
                        int nbKmTolere = SaisirEntier();
                        EntretienType e = new EntretienType(code, nbKm, nbKmTolere);
                        unAtelier.CollectionEntretienType.Add(e);
                        break;

                    case 5:

                        Console.WriteLine("Saisir le code de l'entretien");
                        code = Console.ReadLine();
                        /*
                         * Partie à compléter
                         * */
                        break;

                    case 6:

                        foreach (EntretienType ent in unAtelier.CollectionEntretienType)
                        {
                            Console.WriteLine("Code entretien type : " +
                                ent.ObtenirCode() + " Km : " + ent.ObtenirNombreDeKilometreStandard() + " KmTolere " + ent.ObtenirMargeDeToleranceEnKilometre());
                        }
                        break;

                    case 7:

                        Console.WriteLine("Saisir l'immatriculation du véhicule");
                        immatriculation = Console.ReadLine();
                        bool necessaire = unAtelier.NecessiteEntretien(unAtelier.RechercheVehicule(immatriculation));
                        Console.WriteLine(necessaire);
                        break;

                    case 0:

                        Persistance.SauvegarderObjet("Atelier", unAtelier);
                        Persistance.SauvegarderDonnees("EntretienType", collectionEntretienType);
                        continuer = false;
                        break;

                    case -1: break;



                    default: break;
                }

            } while (continuer);

        }
    }
}
