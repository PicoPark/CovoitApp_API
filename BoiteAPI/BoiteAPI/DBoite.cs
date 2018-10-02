using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoiteAPI.Model;

namespace BoiteAPI.DAL
{
    public class DBoite
    {

        private MBoite Mapping(Boite boite)
        {
            return new MBoite()
            {
                Id = boite.id_boite,
                Adresse = boite.adresse,
                CodePostal = boite.code_postal,
                Latitude = (float)boite.latitude,
                Longitude = (float)boite.longitude,
                Remarque = boite.remarque,
                Ville = boite.ville
            };

        }

        public List<MBoite> getBoxFromLocalisation(float longitude, float latitude)
        {
            var result = new List<MBoite>();
            using (var ctx = new modelEntities())
            {
                foreach (var box in ctx.Boite.ToList())
                {
                    if (Distance(latitude, longitude, (float)box.latitude, (float)box.longitude) < 10)
                    {
                        result.Add(Mapping(box));
                    }
                }
            }
            return result;
        }

        public List<MBoite> getBoxFromcity(string city)
        {
            var result = new List<MBoite>();
            using (var ctx = new modelEntities())
            {
                foreach (var box in ctx.Boite.Where(x => x.ville == city).ToList())
                {
                        result.Add(Mapping(box));
                }
            }
            return result;
        }

        public MBoite getBoxById(int idbox)
        {
            using(var ctx = new modelEntities())
            {
                var box = ctx.Boite.FirstOrDefault(x => x.id_boite == idbox);
                if (box != null)
                    return Mapping(box);
                return null;
            }
        }

        private float convertRad(float value)
        {
            return (float)(Math.PI * value) / 180f;
        }

        private double Distance(float lat_a_degre, float lon_a_degre, float lat_b_degre, float lon_b_degre)
        {
            //Rayon de la terre en mètre
            int R = 6378000;

            var lat_a = convertRad(lat_a_degre);
            var lon_a = convertRad(lon_a_degre);
            var lat_b = convertRad(lat_b_degre);
            var lon_b = convertRad(lon_b_degre);

            var d = R * (Math.PI / 2f - Math.Asin(Math.Sin(lat_b) * Math.Sin(lat_a) + Math.Cos(lon_b - lon_a) * Math.Cos(lat_b) * Math.Cos(lat_a)));
            return d;
        }

    }
}
