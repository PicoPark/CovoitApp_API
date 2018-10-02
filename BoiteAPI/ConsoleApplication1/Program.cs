using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoiteAPI.Model;
using BoiteAPI.DAL;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            DLivre data = new DLivre();
            var boite = new DBoite();
            // data.InsertBookFile(@"F:\- Download\tous-les-documents-des-bibliotheques-de-pret.csv");

            //var res = data.getByTitle("le petit", true);

            var res = boite.getBoxFromcity("Paris");

            foreach (var item in res)
                Console.WriteLine(item.Adresse);
            Console.ReadLine();

        }
    }
}
