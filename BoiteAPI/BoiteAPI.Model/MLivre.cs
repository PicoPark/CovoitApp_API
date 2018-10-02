using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiteAPI.Model
{
    public class MLivre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Summary { get; set; }
        public string UrlImage { get; set; }
        public string isbn13 { get; set; }


        public MLivre()
        {

        }
    }
}
