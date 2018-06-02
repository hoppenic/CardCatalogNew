
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using CardCatalogNew;



namespace CardCatalogNew
{

    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your file name");
            string userFile = Console.ReadLine();











        }

    }

    public class CardCatalog
    {

        public string _fileName { get; set; }
        private List<Book> books { get; set; }


        //this is my constructor
        public CardCatalog(string fileName)
        {

            _fileName = fileName;
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                    books = serializer.Deserialize(stream) as List<Book>;

                    stream.Close();

                }
            }

            if (books == null)
            {
                books = new List<Book>();
            }

            //CardCatalog ends here
        }


        //method to return book array
        public Book[] ListOfBooks()
        {
            return books.ToArray();
        }


        public void AddBook(string bookAuthor,string bookTitle,int bookyear)
        {

            a

        }






    }


}  









   

