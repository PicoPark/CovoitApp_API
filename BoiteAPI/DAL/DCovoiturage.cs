using DAL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class DCovoiturage
    {

        internal static string dateFormat = "dd-MM-yyyy";


        internal static MCovoiturage Mapping(Covoiturage data)
        {
            return new MCovoiturage()
            {
                id = data.id_covoiturage,
                arrive = data.arrive,
                id_utilisateur =  (int)data.id_chauffeur,
                depart = data.depart,
                tarif = (int)data.tarif,
                date_creation = data.dateCreation.ToString(),

                annee = data.date_depart.Value.Year,
                mois = data.date_depart.Value.Month,
                jours = data.date_depart.Value.Day,
                heure = data.date_depart.Value.Hour,
                minutes = data.date_depart.Value.Minute,

                nb_place = (int)data.nb_place,
                isFull = (bool)data.is_full
            };

        }

        internal static Covoiturage Mapping(MCovoiturage data)
        {
            return new Covoiturage()
            {
                id_covoiturage = data.id,
                arrive = data.arrive,
                id_chauffeur = data.id_utilisateur,
                depart = data.depart,
                tarif = data.tarif,
                dateCreation = DateTime.Now,
                date_depart = new DateTime(data.annee, data.mois, data.jours, data.heure, (int)data.minutes, 0),

                nb_place = data.nb_place,
                is_full = data.isFull
            };


        }

        public List<MCovoiturage> getallCovoiturage(MCovoiturage data)
        {
            var result = new List<MCovoiturage>();
            using (var ctx = new CovoitEntities())
            {
                DateTime date = new DateTime(data.annee, data.mois, data.jours, 0, 0, 0);

                DateTime fin = date.AddDays(1);

                var covoiturages = ctx.Covoiturage.Where(x => x.depart == data.depart.Trim() &&
                                                              x.arrive == data.arrive.Trim() &&
                                                             (x.date_depart >= date &&
                                                              x.date_depart <= fin));
                foreach (var covoiturage in covoiturages)
                {
                    result.Add(Mapping(covoiturage));
                }
            }
            return result;

        }

        public MCovoiturage InsertOrUpdate(MCovoiturage covoiturage)
        {
            using (var ctx = new CovoitEntities())
            {
                var tmpCovoit = ctx.Covoiturage.FirstOrDefault(x => x.id_covoiturage == covoiturage.id);
                if (tmpCovoit != null)
                {
                    tmpCovoit.arrive = covoiturage.arrive;
                    tmpCovoit.depart = covoiturage.depart;
                    tmpCovoit.tarif = covoiturage.tarif;
                    try
                    {
                        tmpCovoit.dateCreation = DateTime.ParseExact(covoiturage.date_creation, dateFormat, CultureInfo.CurrentCulture);
                    }
                    catch { }
                    try
                    {
                        tmpCovoit.date_depart = new DateTime(covoiturage.annee, covoiturage.mois, covoiturage.jours, covoiturage.heure, covoiturage.minutes, 0);
                    }
                    catch { }
                    tmpCovoit.is_full = covoiturage.isFull;
                    ctx.SaveChanges();
                }
                else
                {
                    tmpCovoit = ctx.Covoiturage.Add(Mapping(covoiturage));
                    ctx.SaveChanges();
                    covoiturage.id = tmpCovoit.id_covoiturage;
                }
            }
            return covoiturage;
        }

        public MCovoiturage GetCovoiturageById(int idCovoiturage)
        {
            var result = new MCovoiturage();

            using (var ctx = new CovoitEntities())
            {
                var tmp = ctx.Covoiturage.FirstOrDefault(x => x.id_covoiturage == idCovoiturage);
                result = Mapping(tmp);
            }
            return result;
        }
        public List<MCovoiturage> GetCovoituragesByUtilisateur(int idUtilisateur)
        {
            var result = new List<MCovoiturage>();
            using (var ctx = new CovoitEntities())
            {
                var tmp = ctx.Covoiturage.FirstOrDefault(x => x.id_chauffeur == idUtilisateur);
                result.Add(Mapping(tmp));
            }
            return result;
        }


    }
}
