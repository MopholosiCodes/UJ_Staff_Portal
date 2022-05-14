using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataLayer
{
    public class Storage
    {
        private string filePath = "StaffMembers.txt";
        public List<StaffMember> staffMembers = new List<StaffMember>();

        // Create
        public void StoreData(string fname, string lname, string email, int age)
        {
            using (StreamWriter sw = new StreamWriter(filePath,true))
            {
                sw.WriteLine($"{fname},{lname},{email},{age}");
                sw.Close();
            }
        }

        // Read
        public List<StaffMember> ReadData()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    var data = sr.ReadLine().Split(',');
                    staffMembers.Add(new StaffMember
                    {
                        FirstName = data[0],
                        LastName = data[1],
                        Email = data[2],
                        Age = Convert.ToInt32(data[3])
                    });
                }
                sr.Close();
            }
            return staffMembers;
        }
    }
}
