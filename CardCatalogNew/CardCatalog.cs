using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CardCatalogNew;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;



namespace CardCatalogNew
{
    public class CardCatalog
    {
        private string _fileName { get; set; }
        private List<Book> books { get; set; }


        //this is my constructor
        public CardCatalog(string fileName)
        {
            //feeding file in
            _fileName = fileName;
            if (System.IO.File.Exists(fileName))
            {
                using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serialier = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));

                    stream.Close();
                }
            }

            if (books == null)
            {
                books = new List<Book>();
            }

        }
        public Book[] ListOfBooks()
        {
            return books.ToArray();
        }

        //has to match up with your Book class
        //method to allow to add book to our library
        public void AddBook(string author,string title,int year)
        {
            Book newBook = new Book
            {
                Author = author,
                Title = title,
                Year = year

            };

            books.Add(newBook);

        }


        // method to save book to our library
        public void Save()
        {
            using (System.IO.FileStream stream = new System.IO.FileStream(this._fileName,System.IO.FileMode.OpenOrCreate))
            {

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);

                stream.Close();

            }


        }


    }

    

        
 }





