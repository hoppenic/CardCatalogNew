
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Specialized;



namespace CardCatalogNew
{

    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter your file name");
            string userFile = Console.ReadLine();
            CardCatalog cardCatalog=new CardCatalog(userFile);
            Console.Clear();

            string userChoice = "";
            do
            {
                Console.WriteLine("1: List all Books");
                Console.WriteLine("2: Add a book");
                Console.WriteLine("3: Save and exit");
                userChoice = Console.ReadLine();
                Console.Clear();
                switch (userChoice)
                {

                    case "1":
                        foreach (Book book in cardCatalog.ListOfBooks())
                        {
                            Console.WriteLine($"{book.Author}, {book.Title}, {book.Year}");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter author");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter year");
                        int year = Convert.ToInt32(Console.ReadLine());
                        cardCatalog.AddBook(title, author, year);
                        Console.Clear();
                        break;
                    case "3":
                        cardCatalog.Save();
                        break;
                    default:
                        {
                            Console.WriteLine("Not a Valid Choice");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                }

            } while (userChoice != "3");


        }

    }

    public class CardCatalog
    {

        private string _fileName { get; set; }
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


        //method to Add a book
        public void AddBook(string bookAuthor,string bookTitle,int bookYear)
        {

            //nerwBook object of Book class
            Book newBook = new Book
            {
                Author = bookAuthor,
                Title = bookTitle,
                Year = bookYear
            };

            books.Add(newBook);

        }

        public void Save()
        {

            using(System.IO.FileStream stream = new System.IO.FileStream(this._fileName, System.IO.FileMode.OpenOrCreate))
            {


                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Book>));
                serializer.Serialize(stream, books);

                stream.Close();

            }


        }


    }


}  









   

