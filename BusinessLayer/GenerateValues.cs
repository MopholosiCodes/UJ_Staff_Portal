using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace BusinessLayer
{
    public class GenerateValues
    {
        public Storage storage = new Storage();

        // generate age not working
        public int GenerateAge(long idNumber)
        {
            var date = new DateTime();
            var Id = idNumber.ToString().Substring(0, 1);

            return date.Year - Convert.ToInt32(Id);
        }

        // email
        public string GenerateEmail(string fname, string lname)
        {
            var name = fname.Substring(0).ToLower();
            var surname = lname.ToLower();

            return $"{name}{surname}@uj.ac.za";
        }

        public void DisplayData()
        {
            var list = storage.ReadData();
            var StaffInfo = from element in list
                            orderby element.Age
                            select element;

            foreach(var element in StaffInfo)
                Console.WriteLine($"{element.FirstName} {element.LastName} {element.Email} {element.Age}");
        }
    }
}
