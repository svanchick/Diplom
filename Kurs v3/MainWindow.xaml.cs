using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Windows;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kurs_v3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            

        }
        private void CloseApp_btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LogIn_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentUser = GetContext.context.Users.Where(u => u.Login == LogIn_text.Text && u.Password == Password_text.Password).FirstOrDefault();
                if (currentUser != null)
                {
                    Manager.LoginedUser = LogIn_text.Text;
                    Show show = new Show();
                    show.Show();
                    this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Не правильно введён логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}