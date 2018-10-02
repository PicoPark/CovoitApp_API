using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiteAPI.Model
{
    public class MBoite
    {

        public int Id { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Remarque { get; set; }

        public MBoite()
        {

        }

    }
}
