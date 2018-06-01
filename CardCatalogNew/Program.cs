
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
u
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







        }
    }
    

}
