using System;


namespace tpCasNetCar
{
    /// <summary>
    /// Représente un entretien type d'un véhicule
    /// </summary>
    [Serializable]
    public class EntretienType
    {
        /// <summary>
        /// Le code de l'entretien type
        /// </summary>
        private string _code;

        /// <summary>
        /// Le nombre de kilomètre pour lequel l'entretien type doit avoir lieu
        /// exemple : Le changement du filtre à essence doit avoir lieu tous les 15000km
        /// </summary>
        private int _nombreDeKilometreStandard;


        /// <summary>
        /// Marge de tolérance en km majorant ou minorant (c'est à dire plus ou moins) le kilométrage standard
        /// exemple : le changement du filtre à essence peut être réalisé avec une marge de tolérance de 1000km
        /// </summary>
        private int _margeDeToleranceEnKilometre; 

        /// <summary>
        /// Obtient le code de l'entretien type courant
        /// </summary>
        /// <returns>Le code de l'entretien type</returns>
        public string ObtenirCode()
        {
            return _code;
        }

        /// <summary>
        /// Obtient la marge de tolérance en kilomètre de l'entretien type courant
        /// </summary>
        /// <returns>La marge de tolérance</returns>
        public int ObtenirMargeDeToleranceEnKilometre()
        {
            return _margeDeToleranceEnKilometre;
        }

        /// <summary>
        /// Le nombre de kilomètre standard de l'entretien type courant, c'est à dire le nombre de kilomètre à partir duquel l'entretien type doit être réalisé
        /// </summary>
        /// <returns>Le nombre de kilomètres</returns>
        public int ObtenirNombreDeKilometreStandard()
        {
            return _nombreDeKilometreStandard;
        }

        /// <summary>
        /// Initialise une entretien type à partir des informations transmises en paramètre
        /// </summary>
        /// <param name="code">Le code de l'entretien type</param>
        /// <param name="nbKm">Le nombre de kilomètres standard</param>
        /// <param name="nbKmTolere">la marge de tolérance en kilomètre</param>
        public EntretienType(string code, int nbKm, int nbKmTolere)
        {
            this._code = code;
            this._nombreDeKilometreStandard = nbKm;
            this._margeDeToleranceEnKilometre = nbKmTolere;
        }

    }
}
