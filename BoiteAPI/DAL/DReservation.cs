using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;


namespace DAL
{
    public class DReservation
    {

        public List<MReservation> GetReservationbyUser(int id_utilisateur) {
            var result = new List<MReservation>();

            using(var ctx = new CovoitEntities())
            {
                var covoiturages = ctx.Covoiturage.Where(x => x.id_chauffeur == id_utilisateur);
                foreach(var covoit in covoiturages)
                {
                    var reservations = ctx.Reservation.Where(x => x.id_covoiturage == covoit.id_covoiturage);
                    foreach(var reservation in reservations)
                    {
                        var user = ctx.Utilisateur.FirstOrDefault(x => x.id_utilisateur == reservation.id_utilisateur);
                        if(user != null)
                        {
                            result.Add(Mapping(reservation,covoit, user));
                        }
                    } 
                }
            }
            return result;
        }

        public MReservation InsertOrUpdate(MReservation resevation)
        {
            using (var ctx = new CovoitEntities())
            {
                var tmp = ctx.Reservation.FirstOrDefault(x => x.id_reservation == resevation.Id);
                if(tmp != null)
                {
                    tmp.id_covoiturage = resevation.covoiturage.id;
                    tmp.id_utilisateur = resevation.utilisateur.id;
                    tmp.is_validate = resevation.isValidate;

                }
                else
                {
                   tmp = ctx.Reservation.Add(Mapping(resevation));
                }
                ctx.SaveChanges();
                resevation = Mapping(tmp, resevation.covoiturage, resevation.utilisateur);
                
            }
            return resevation;
        }

        internal static MReservation Mapping(Reservation resa, MCovoiturage covoit, MUtilisateur user)
        {
            return new MReservation()
            {
                Id = resa.id_reservation,
                isValidate = (bool) resa.is_validate,
                utilisateur = user,
                covoiturage = covoit
            };

        }

        internal static MReservation Mapping(Reservation resa, Covoiturage covoit, Utilisateur user)
        {
            return new MReservation()
            {
                Id = resa.id_reservation,
                isValidate = (bool)resa.is_validate,
                utilisateur = DUtilisateur.Mapping(user),
                covoiturage = DCovoiturage.Mapping(covoit)
            };

        }

        internal static Reservation Mapping(MReservation resa)
        {

            return new Reservation()
            {
                id_covoiturage = resa.covoiturage.id,
                id_utilisateur = resa.utilisateur.id,
                is_validate = resa.isValidate
            };
        }

    }
}
