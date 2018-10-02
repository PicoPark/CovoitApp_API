using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class MReservation
    {
        public int Id { get; set; }
        public MUtilisateur utilisateur { get; set; }
        public MCovoiturage covoiturage { get; set; }

        public bool isValidate { get; set; }


        public MReservation()
        {
            utilisateur = new MUtilisateur();
            covoiturage = new MCovoiturage();
        }

    }
}
