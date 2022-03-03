using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace UJ_Staff_Portal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var name = firstName.Text;
            var surname = lastName.Text;
            var idnumber = Id_Number.Text;

            var businessLayer = new BusinessLayer(name,surname, Convert.ToInt32(idnumber));
            
        }

        private void DisplayField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
