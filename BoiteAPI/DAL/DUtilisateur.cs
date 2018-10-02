using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Model;

namespace DAL
{
    public class DUtilisateur
    {

        internal static MUtilisateur Mapping( Utilisateur data)
        {
            return new MUtilisateur()
            {
                id=data.id_utilisateur,
                mail = data.mail,
                nom = data.nom,
                password = data.password,
                prenom = data.prenom,
                profile_image = data.profil_image
               
            };

        }

        private Utilisateur Mapping(MUtilisateur data)
        {
            return new Utilisateur()
            {
                id_utilisateur = data.id,
                mail = data.mail,
                nom = data.nom,
                password = data.password,
                prenom = data.prenom,
                profil_image = data.profile_image

            };

        }

        public bool isExist(string mail, string password)
        {
            var result = false;
            using (var ctx = new CovoitEntities())
            {
                result = ctx.Utilisateur.FirstOrDefault(x => x.mail == mail && x.password == password) != null ;
            }
            return result;
        }

        public MUtilisateur GetUtilisateur(string mail)
        {
            var result = new MUtilisateur();
            using (var ctx = new CovoitEntities())
            {
                var user = ctx.Utilisateur.FirstOrDefault(x => x.mail == mail);
                if (user !=null)
                    result = Mapping(user);
            }
            return result;
        }

        public MUtilisateur GetAppUtilisateur(int id)
        {
            var result = new MUtilisateur();
            using (var ctx = new CovoitEntities())
            {
                var user = ctx.Utilisateur.FirstOrDefault(x => x.id_utilisateur == id);
                if (user != null)
                    result = Mapping(user);
            }
            return result;
        }

        public bool Verification(string mail)
        {
            using (var ctx = new CovoitEntities())
            {
                return ctx.Utilisateur.FirstOrDefault(x => x.mail == mail) != null;
            }
        }

        public MUtilisateur InsertOrUpdate(MUtilisateur user)
        {
           
            using (var ctx = new CovoitEntities())
            {
                if (isExist(user.mail, user.password))
                {
                    var tmpUser = GetAppUtilisateur(user.id);
                    tmpUser.mail = user.mail;
                    tmpUser.nom = user.nom;
                    tmpUser.password = user.password;
                    tmpUser.profile_image = user.profile_image;
                    ctx.SaveChanges();
                }
                else
                {
                    var tmpUser = ctx.Utilisateur.Add(Mapping(user));
                    ctx.SaveChanges();
                    user.id = tmpUser.id_utilisateur;
                }
            }
            return user;

        }


    }
}
