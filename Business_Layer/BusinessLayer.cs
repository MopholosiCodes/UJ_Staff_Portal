using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Business_Layer
{
    public class BusinessLayer
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public int IdNumber;
        public string Email;

        public BusinessLayer(string firstName, string lastName, int idNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IdNumber = idNumber;
        }

        // get age from user Id number
        public int GenerateAge(int idNumber)
        {
            var date = new DateTime();
            var Id = idNumber.ToString().Substring(0, 1);

            return date.Year - Convert.ToInt32(Id);
        }

        // create email with user name and surname
        public string GenerateEmail()
        {
            var name = FirstName.Substring(0).ToLower();
            var surname = LastName.ToLower();

            return $"{name}{surname}@uj.ac.za";
        }

        // pass data to data layer
        public void StoreData()
        {
            var store = new DataLayer();

        }
    }
}
