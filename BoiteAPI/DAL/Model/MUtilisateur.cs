using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MUtilisateur
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public string profile_image { get; set; }

        public MUtilisateur()
        {

        }

        public MUtilisateur(int id)
        {
            this.id = id;
            
 
        }
    }
}
