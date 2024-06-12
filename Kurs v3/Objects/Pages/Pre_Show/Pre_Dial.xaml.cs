using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages.Add_Type;
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

namespace Kurs_v3.Objects.Pages.Pre_Show
{
    /// <summary>
    /// Логика взаимодействия для Pre_Dial.xaml
    /// </summary>
    public partial class Pre_Dial : Page
    {
        private string _Name;
        private string _Description;
        private int _Id;
        private string _SerialNumber;
        private int _Cost;
        public Pre_Dial(string Name, string SerialNumber, int Id, string Description, int Cost)
        {
            InitializeComponent();
            _Name = Name;
            _Description = Description;
            _Id = Id;
            _SerialNumber = SerialNumber;
            _Cost = Cost;

            var currentuser = GetContext.context.Users.Where(p => p.Login == Manager.LoginedUser).FirstOrDefault();
            if (currentuser.Position == 2 || Id == 0) 
            { 
                Edit_Btn.Visibility = Visibility.Visible;
            }
            else
            {
                Edit_Btn.Visibility = Visibility.Hidden;
            }
           
        }
       

        private void Edit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new New_Dial(_Name, _SerialNumber, _Id, _Description, _Cost));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var updateinformation = GetContext.context.Dials.Where(p => p.Id == _Id).FirstOrDefault();
            Name_of_dial_text.Text = updateinformation.Name;
            Serial_number_of_dial.Text = updateinformation.SerialNumber;
            Dials_cost.Text = Convert.ToString(updateinformation.Cost);
            Dials_Description.Text = updateinformation.Description;
        }
    }
}
