using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAL;
using DAL.Model;

namespace BoiteAPI.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
     

        [OperationContract]
        [WebGet(UriTemplate = "Reservation/{id}",
                 ResponseFormat = WebMessageFormat.Json)]
        List<MReservation> GetReservationbyUser(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "Reservation",
                  RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        MReservation addReservation(MReservation reservation);


        [OperationContract]
        [WebInvoke(UriTemplate = "Connexion",
              RequestFormat = WebMessageFormat.Json,
              ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        MUtilisateur Connexion(MUtilisateur utilisateur);


        [OperationContract]
        [WebInvoke(UriTemplate = "Utilisateur",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        MUtilisateur addUtilisateur(MUtilisateur utilisateur);

        [OperationContract]
        [WebGet(UriTemplate = "Utilisateur/{id}",
           ResponseFormat = WebMessageFormat.Json)]
        MUtilisateur GetUtilisateur(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Verification/{mail}",
          ResponseFormat = WebMessageFormat.Json)]
        bool Verification(string mail);


        [OperationContract]
        [WebGet(UriTemplate = "Covoiturage/{id}",
                  ResponseFormat = WebMessageFormat.Json)]
        MCovoiturage getCovoiturage(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "ListCovoiturage",
             RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        List<MCovoiturage> getListCovoiturage(MCovoiturage covoiturage);


        [OperationContract]
        [WebInvoke(UriTemplate = "Covoiturage",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        MCovoiturage addCovoiturage(MCovoiturage covoiturages);
/*
        [OperationContract]
        [WebGet(UriTemplate = "data/{value}",
             ResponseFormat = WebMessageFormat.Json)]
        string GetData(string value);

        [OperationContract]
        [WebGet( UriTemplate = "Box/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        MBoite GetBoiteFromId(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Book/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        MLivre getBook(string id);

        [OperationContract]
        [WebGet(UriTemplate = "Books",
           ResponseFormat = WebMessageFormat.Json)]
        List<MLivre> getBooks();

        [OperationContract]
        [WebGet(UriTemplate = "Book/Box/{idBox}",
            ResponseFormat = WebMessageFormat.Json)]
        List<MLivre> getBooksFromBox(string idBox);


        [OperationContract]
        [WebGet(UriTemplate = "Geolocalisation/{latitude}/{longitude}",
            ResponseFormat = WebMessageFormat.Json)]
        List<MBoite> getBoxFromLocalisation(string latitude, string longitude);

        [OperationContract]
        [WebGet(UriTemplate = "City/{city}",
           ResponseFormat = WebMessageFormat.Json)]
        List<MBoite> getBoxFromcity(string city);

        [OperationContract]
        [WebInvoke(UriTemplate = "Book",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        int addBook(MLivre livre);

        // TODO: Add your service operations here
        */
    }


     
}
