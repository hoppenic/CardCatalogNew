﻿
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

            //prompt user to enter a file, feed file int a string
            Console.WriteLine("Enter your file name");
            string userFile = Console.ReadLine();
            CardCatalog cardCatalog=new CardCatalog(userFile);
            Console.Clear();

            //this gives us the initial menu for user to look at, then allows them to make choice
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

                    //this looks at our ListOfBooks Array to see if anything is in there
                    //If something is there, it displays it in the prompt
                    case "1":
                        foreach (Book book in cardCatalog.ListOfBooks())
                        {
                            Console.WriteLine($"{book.Author}, {book.Title}, {book.Year}, {book.Pages},{book.ReadTime}");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                        //this allows me to add a book to our cardCatalog using our AddBookMethod
                    case "2":
                        Console.WriteLine("Enter title");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter author");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter year");
                        int year = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter length of book in pages");
                        int pages = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter read time in hours");
                        int readTime = Convert.ToInt32(Console.ReadLine());
                        cardCatalog.AddBook(title, author, year, pages, readTime);
                        
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

                //do the above UNTIL They choose 3
            } while (userChoice != "3");


        }

    }

   


}  









   

