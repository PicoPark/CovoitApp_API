using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoiteAPI.Model
{
    public class MCommentaire
    {
        public int Id { get; set; }
        public int Livre { get; set; }
        public string Login { get; set; }
        public string Texte { get; set; }
        public int Note { get; set; }

        public MCommentaire()
        {
                
        }
    }
}
