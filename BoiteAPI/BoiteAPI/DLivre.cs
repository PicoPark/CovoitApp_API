using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.SqlClient;
using BoiteAPI.Model;

namespace BoiteAPI.DAL
{
    public class DLivre
    {
        private DataAcces data;
        public DLivre()
        {
            data = new DataAcces();
        }

        public List<MLivre> getBooksFromBox(int idBox)
        {
            var result = new List<MLivre>();
            using (var ctx = new modelEntities())
            {
                var listLivre = ctx.Boite_Livre.Where(x => x.id_boite == idBox).ToList();
                foreach (var item in listLivre)
                {
                    var livre = ctx.Livre.FirstOrDefault(y => y.id_livre == item.id_livre);
                    result.Add(Mapping(livre));
                }
            }
            return result;
        }

        public MLivre getByISBN(string isbn)
        {
            using (var ctx = new modelEntities())
            {
                var livre = ctx.Livre.FirstOrDefault(x => x.isbn == isbn);
                if (livre != null)
                    return Mapping(livre);
                else
                    return data.callApiISBN(isbn);
            }
        }

        public List<MLivre> getByTitle(string title, bool lazy = false)
        {
            var result = new List<MLivre>();
            using (var ctx = new modelEntities())
            {
                title = title.Replace(" ", "%");
                //todo : modifier
                if (!lazy)
                {
                    var livres = ctx.Livre.Where(x => SqlMethods.Like(x.titre, title));
                    if (livres.Count() != 0)
                        foreach (var item in livres)
                            result.Add(Mapping(item));
                    else
                        return data.callApiTitle(title);
                }
                else
                    return data.callApiTitle(title);

            }
            return result;
        }

        public int addBook(MLivre livre)
        {
            using (var ctx = new modelEntities())
            {
                ctx.Livre.Add(new Livre()
                {
                    titre = livre.Title,
                    auteur = livre.Author,
                    isbn = livre.isbn13,
                    description = livre.Summary,
                    genre = livre.Genre,
                    url_image = livre.UrlImage
                });
                return ctx.SaveChanges();
            }
            return -1;
        }

        public MLivre getBookById(int id)
        {
            return Mapping(
                new modelEntities().Livre.FirstOrDefault(x => x.id_livre == id));
        }

        public List<MLivre> getBooks()
        {
            var result = new List<MLivre>();
            using (var ctx = new modelEntities())
            {
              
                foreach (var item in ctx.Livre.ToList())
                     result.Add( Mapping(item));
            }
            return result;
        }

        internal static MLivre Mapping(Livre livre)
        {

            return new MLivre()
            {
                Author = livre.auteur,
                Summary = livre.description,
                Genre = livre.genre,
                Id = livre.id_livre,
                isbn13 = livre.isbn,
                Title = livre.titre,
                UrlImage = livre.url_image

            };
        }
        internal static Livre Mapping(MLivre livre)
        {
            return new Livre()
            {
                auteur = livre.Author,
                titre = livre.Title,
                description = livre.Summary,
                isbn = livre.isbn13,
                url_image = livre.UrlImage,
                genre = livre.Genre

            };

        }
    }

}
