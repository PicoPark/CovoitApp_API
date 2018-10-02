using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using DAL.Model;
using DAL;
using System.Globalization;
using System.Threading;

namespace BoiteAPI.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public DUtilisateur DalUser;
        public DCovoiturage DalCovoiturage;
        public DReservation DalReservation;

        public Service1()
        {
            DalUser = new DUtilisateur();
            DalCovoiturage = new DCovoiturage();
            DalReservation = new DReservation();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
        }

        public MCovoiturage addCovoiturage(MCovoiturage covoiturages)
        {
            return DalCovoiturage.InsertOrUpdate(covoiturages);
        }

        public MReservation addReservation(MReservation reservation)
        {
            return DalReservation.InsertOrUpdate(reservation);
        }

        public MUtilisateur addUtilisateur(MUtilisateur utilisateur)
        {
            return DalUser.InsertOrUpdate(utilisateur);
        }

        public MUtilisateur Connexion(MUtilisateur utilisateur)
        {
            if (DalUser.isExist(utilisateur.mail, utilisateur.password))
                return DalUser.GetUtilisateur(utilisateur.mail);
            else
                return new MUtilisateur(-1);
        }


        public MCovoiturage getCovoiturage(string id)
        {
            return DalCovoiturage.GetCovoiturageById(Int32.Parse(id));
        }


        public List<MCovoiturage> getListCovoiturage(MCovoiturage covoiturage)
        {
            return DalCovoiturage.getallCovoiturage(covoiturage);
        }

        public List<MReservation> GetReservationbyUser(string id)
        {
            return DalReservation.GetReservationbyUser(Convert.ToInt32(id));
        }

        public MUtilisateur GetUtilisateur(string id)
        {
            return DalUser.GetAppUtilisateur(Convert.ToInt32(id));
        }

        public bool Verification(string mail)
        {
            return DalUser.Verification(mail);
        }


        /*
public MBoite GetBoiteFromId(string id)
{
   return boite.getBoxById(Int32.Parse(id));
}


public List<MLivre> getBooksFromBox(string idBox)
{
   return livre.getBooksFromBox(Int32.Parse(idBox));
}

public List<MBoite> getBoxFromcity(string city) {
   return boite.getBoxFromcity(city);
}

public List<MLivre> getBooks()
{
   return livre.getBooks();

}


public List<MBoite> getBoxFromLocalisation(string latitude, string longitude)
{ 

   return boite.getBoxFromLocalisation( float.Parse(latitude), float.Parse(longitude));
}

public int addBook(MLivre livres)
{
   return livre.addBook(livres);
}


public MLivre getBook(string id)
{
   return livre.getBookById(Int32.Parse(id));
}


public string GetData(string value)
{
   return "message recu : " + value;
}

*/
    }
}
