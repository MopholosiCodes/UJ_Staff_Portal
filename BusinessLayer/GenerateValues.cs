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
        public FileStorage storage = new FileStorage();
        public DatabaseStorage dbStorage = new DatabaseStorage();
        List<string> result = new List<string>();

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

        // File system
        public List<string> DisplayData()
        {
            var list = storage.ReadData();
            var StaffInfo = from element in list
                            orderby element.Age
                            select element;

            foreach (var element in StaffInfo)
            {
                result.Add($"{element.FirstName} {element.LastName} {element.Email} {element.Age}");
            }
            return result;
        }

        // Database
        public List<StaffMember> DisplayListFromDB()
        {
            var list = dbStorage.ReadData();
            List<StaffMember> resultList = new List<StaffMember>();

            var staffInfo = from element in list
                            orderby element.Age
                            select element;

            foreach (var element in staffInfo)
            {
                resultList.Add(new StaffMember{
                    FirstName = element.FirstName,
                    LastName = element.LastName,
                    Email = element.Email,
                    Age = element.Age
                });
            }

            return resultList;
        }
    }
}
