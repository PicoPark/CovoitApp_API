using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Model;

namespace DAL
{
    public class DPassager
    {
        private MReservation Mapping(Reservation reservation)
        {
            return new MReservation()
            {
             //   id = reservation.id,
             //   covoiturage_id = reservation.covoiturage_id,
             //   isValidate = reservation.isValidate
             //  
            };
        }

       // private app_reservation Mapping(MReservation reservation)
       // {
       //     return new app_reservation()
       //     {
       //         id = reservation.id,
       //         covoiturage_id = reservation.covoiturage_id,
       //         isValidate = reservation.isValidate
       //
       //     };
       // }




    }
}
