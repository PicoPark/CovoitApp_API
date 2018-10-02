using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MCovoiturage
    {
        public int id { get; set; }
        public string depart { get; set; }
        public string arrive { get; set; }
        public int annee { get; set; }
        public int mois { get; set; }
        public int jours { get; set; }
        public int heure { get; set; }
        public int minutes { get; set; }
        public int tarif { get; set; }
        public string date_creation { get; set; }
        public int nb_place { get; set; }
        public bool isFull { get; set; }
        public int id_utilisateur { get; set; }

    }
}
