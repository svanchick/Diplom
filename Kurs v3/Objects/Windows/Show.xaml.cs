using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages;
using Kurs_v3.Objects.Pages.Show_Type;
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
using System.Windows.Shapes;

namespace Kurs_v3.Objects.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Show : Window
    {
        public Show()
        {
            InitializeComponent();
            Manager._MainFrame = MainFrame;
            Manager._MainFrame.Navigate(new MainPage());
            
            CheckUser();
        }
        private void CheckUser()
        {
            var checkuser = GetContext.context.Users.FirstOrDefault( p => p.Login == Manager.LoginedUser);
            if(checkuser.Position == 1)
            {
                CheckUserBtn.Visibility = Visibility.Visible;
            }
            else
            {
                CheckUserBtn.Visibility = Visibility.Hidden;
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.GoBack();
        }

        private void Show_Display_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Display_Show());
        }

        private void Show_Dial_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Dial_Show());
        }

        private void Show_Plate_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Plate_Show());
        }

        private void To_MainPage_btn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new MainPage());
        }

        private void CloseAppBtn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                BackBtn.Visibility = Visibility.Visible;
            }
            else
            {
                BackBtn.Visibility = Visibility.Hidden;
            }

            object currentPage = MainFrame.Content;
            if (currentPage is MainPage)
            {
                To_MainPage_btn.Visibility = Visibility.Hidden;
            }
            else
            {
                To_MainPage_btn.Visibility = Visibility.Visible;
            }
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CheckUserBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Show_Users());
        }

        private void GetOutBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

       
    }
}
