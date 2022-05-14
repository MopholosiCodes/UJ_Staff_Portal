using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateValues generate = new GenerateValues();
            Storage file = new Storage();

            var age = generate.GenerateAge(19061295563080);
            var email = generate.GenerateEmail("Mopholosi", "Monyollo");
            file.StoreData("Mopholosi", "Monyollo", email, age);
            generate.DisplayData();

            Console.ReadKey();
        }
    }
}
