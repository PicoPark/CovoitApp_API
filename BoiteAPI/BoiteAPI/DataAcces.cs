using BoiteAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoiteAPI.DAL
{
    public class DataAcces
    {
        private const string API_KEY = "N6UHFUHR/";
        private const string URL_BASE = "http://isbndb.com/api/v2/json/";
        private const string BOOK_REQUEST = "book/";
        private const string BOOKS_TITLE_REQUEST = "books?q=";
        //


        public DataAcces()
        {
          
        }



        public MLivre callApiISBN(string isbn)
        {
            using (var ctx = new modelEntities())
            {
                var json = callAPI(URL_BASE + API_KEY + BOOK_REQUEST + isbn);
                var data = json["data"].Children();
                var livre = parseBook(data.First());
 
                ctx.Livre.Add(DLivre.Mapping(livre));
                ctx.SaveChanges();
                return livre;
               
            }

        }

        public List<MLivre> callApiTitle(string title) {
            var result = new List<MLivre>();
            using (var ctx = new modelEntities())
            {
                title = title.Replace(" ", "+");
                var json = callAPI(URL_BASE + API_KEY + BOOKS_TITLE_REQUEST + title);
                var data = json["data"].Children().ToList();
                foreach (var item in data)
                {
                    var livre = parseBook(item);
                    if (ctx.Livre.FirstOrDefault(x => x.isbn == livre.isbn13) != null)
                    {
                        ctx.Livre.Add(DLivre.Mapping(livre));
                        ctx.SaveChanges();
                    }
                    result.Add(livre);
                }
            }
            return result;
        }

        public void callApiAuthor(string author) { }

        public void InsertBoxFile(string filename)
        {
            string line;
            using (var ctx = new modelEntities())
            {
                ctx.Database.Connection.Open();
                var file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    if (!line.Contains("Code"))
                    {
                        var data = line.Split(';');
                        if (data.Length > 1)
                        {
                            var item = new Boite()
                            {
                                adresse = data[0],
                                code_postal = data[1],
                                ville = data[2],
                                remarque = data[4]
                            };
                            if (!String.IsNullOrEmpty(data[3]) && data[3] != ",")
                            {
                                var coordonate = data[3].Split(',');

                                item.latitude = decimal.Parse(coordonate[0].Replace('.', ','));
                                item.longitude = decimal.Parse(coordonate[1].Replace('.', ','));
                            }
                            ctx.Boite.Add(item);
                            ctx.SaveChanges();
                        }
                    }
                }

            };

        }

        public void InsertBookFile(string filename)
        {
            string line;
            using (var ctx = new modelEntities())
            {
                ctx.Database.Connection.Open();
                var file = new StreamReader(filename);

                while ((line = file.ReadLine()) != null)
                {
                    if (!line.Contains("id"))
                    {
                        var data = line.Split(';');
                        if (data.Length > 1 && !String.IsNullOrEmpty(data[19]))
                        {
                            var item = new Livre()
                            {
                                titre = data[3].Split('[')[0],
                                auteur = data[14],
                                genre = data[18],
                                isbn = data[19]


                            };
                            ctx.Livre.Add(item);
                            ctx.SaveChanges();
                        }

                    }
                }
            }
        }

        private JObject callAPI(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = new StreamReader(request.GetResponse().GetResponseStream());
            return JObject.Parse(response.ReadToEnd());

        }

        private MLivre parseBook(JToken json) {
            var livre = json.ToObject<MLivre>();
            var auteur = json["author_data"].Children().Children().ToArray();
            if (auteur.Count() != 0)
                livre.Author = auteur[1].ToString();
            return livre;
        }

      
    }
}
