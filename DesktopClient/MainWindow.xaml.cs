using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BusinessLayer;
using DataLayer;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GenerateValues generate = new GenerateValues();
        private Storage storage = new Storage();
        StringBuilder result = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Email and Age Generated successfully");
            AgeField.Content = generate.GenerateAge(Convert.ToInt64(IDField.Text));
            EmailField.Content = generate.GenerateEmail(
                NameField.Text,
                SurnameField.Text
            );
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            storage.StoreData(
                NameField.Text,
                SurnameField.Text,
                generate.GenerateEmail(NameField.Text,SurnameField.Text),
                generate.GenerateAge(Convert.ToInt64(IDField.Text))
            );
            MessageBox.Show("Saved successfully");
            clearForm();
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            var list = generate.DisplayData();
  
            foreach(string row in list)
            {
                result.Append($"{row}\n");
            }
            DisplayProfilesTextbox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        public void clearForm()
        {
            NameField.Text = "";
            SurnameField.Text = "";
            IDField.Text = "";
            AgeField.Content = "";
            EmailField.Content = "";
        }
    }
}
