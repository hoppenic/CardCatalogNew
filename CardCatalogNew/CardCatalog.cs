using System;
using System.Collections.Generic;
using System.Text;

namespace CardCatalogNew
{
    public class CardCatalog
    {
        private string _filename;
        private List<Book> books;

        public CardCatalog(string fileName)
        {
            _filename = fileName;
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                {

                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                    books = serializer.Deserialize(stream) as List<Book>;

                    //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    //books = binaryFormatter.Deserialize(stream) as List<Book>;
                    stream.Close();
                }
            }
            if (books == null)
            {
                books = new List<Book>();
            }
        }
        public Book[] ListBooks()
        {
            return books.ToArray();
        }
        public void AddBook(string author, string title, int year)
        {
            Book newBook = new Book
            {
                Author = author,
                Title = title,
                Year = year
            };
            books.Add(newBook);
        }
        public void Save()
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(this._filename, System.IO.FileMode.OpenOrCreate))
            {

                //System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                //binaryFormatter.Serialize(stream, books);

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);

                stream.Close();
            }




        }



    }
}
