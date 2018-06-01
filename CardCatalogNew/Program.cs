
using System.Linq;
using System.Collections.Generic;
using CardCatalogNew;

using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the name of a file");
        string filename = Console.ReadLine();
        CardCatalog cardCatalog = new CardCatalog(filename);
        Console.Clear();
        string choice = "";
        do
        {
            Console.WriteLine("1.\tList All Books");
            Console.WriteLine("2.\tAdd A Book");
            Console.WriteLine("3.\tSave And Exit");
            choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    foreach (Book book in cardCatalog.ListBooks())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}", book.Title, book.Author, book.Year);
                    }
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                case "2":
                    Console.WriteLine("Enter a Title");
                    string title = Console.ReadLine();
                    Console.WriteLine("Enter an Author");
                    string author = Console.ReadLine();
                    int year;
                    Console.WriteLine("Enter a year");
                    string yearAsString = Console.ReadLine();
                    int.TryParse(yearAsString, out year);
                    cardCatalog.AddBook(author, title, year);
                    Console.Clear();
                    break;
                case "3":
                    cardCatalog.Save();
                    break;
                default:
                    {
                        Console.WriteLine("Not a Valid Choice, press enter to continue");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
            }

        } while (choice != "3");
    }
}



//[Serializable]    //Only needed if I use BinaryFormatter
public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
}