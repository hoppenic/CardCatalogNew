using System;
using System.Collections.Generic;
using System.Text;

namespace CardCatalogNew
{
    public class CardCatalog
    {
        private string _fileName { get; set; }
        private List<Book> books { get; set; }


        //this is my constructor to initialize fileName
        public CardCatalog(string fileName)
        {


            _fileName = fileName;
            if (System.IO.File.Exists(fileName))
            {

                //using .NET to use filestream
                using (System.IO.FileStream stream = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                    books = serializer.Deserialize(stream) as List<Book>;

                    stream.Close();

                }
            }

            //if books null make new list of books
            if (books == null)
            {
                books = new List<Book>();
            }

            //CardCatalog ends here
        }


        //method to return book array in main program
        public Book[] ListOfBooks()
        {
            return books.ToArray();
        }


        //method to Add a book, called in main program
        public void AddBook(string bookAuthor, string bookTitle, int bookYear,int bookPages, int readTime)
        {

            //newBook object of Book class
            Book newBook = new Book
            {
                Author = bookAuthor,
                Title = bookTitle,
                Year = bookYear,
                Pages=bookPages,
                ReadTime=readTime
                
            };

            books.Add(newBook);

        }


        //save method to save a book when user enters it
        //This is using our serialization
        public void Save()
        {

            using (System.IO.FileStream stream = new System.IO.FileStream(this._fileName, System.IO.FileMode.OpenOrCreate))
            {


                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);

                stream.Close();

            }


        }


    }





}

