
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

            Console.WriteLine("Enter name of file");
            string newFile = Console.ReadLine();
            //cardcatalog class
            CardCatalog cardCatalog = new CardCatalog(newFile);
            Console.Clear();


            //initialize what user wants
            string userChoice = "";

            do
            {
                Console.WriteLine("List all books");
                Console.WriteLine("Add a book");
                Console.WriteLine("Save + Exit");
                Console.Clear();

                switch (userChoice)
                {
                    case "1":
                        foreach (Book book in cardCatalog.ListOfBooks())
                        {
                            Console.WriteLine($"{book.Title}, {book.Author}, {book.Year}");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("Enter your title");
                        string bookTitle = Console.ReadLine();
                        Console.WriteLine("Enter an author");
                        string bookAuthor = Console.ReadLine();
                        Console.WriteLine("Enter a year");
                        int bookYear = Convert.ToInt32(Console.ReadLine());
                        CardCatalog.AddBook(bookAuthor, bookTitle, bookYear);
                        Console.Clear();
                        break;
                    case "3":
                        cardCatalog.Save();
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid, press enter");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }

                }

            } while (userChoice != "3");
        




        }
    }




   
}
