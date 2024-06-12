using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages.Add_Type;
using Microsoft.VisualBasic.Logging;
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

namespace Kurs_v3.Objects.Pages.Show_Type
{
    /// <summary>
    /// Логика взаимодействия для Show_Users.xaml
    /// </summary>
    public partial class Show_Users : Page
    {
        public Show_Users()
        {
            InitializeComponent();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GetContext.context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = GetContext.context.Users.ToList();
            }
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var UsersForRemoving = DGrid.SelectedItems.Cast<Users>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующего {UsersForRemoving.Count()} пользователя?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (DGrid.SelectedIndex != 0)
                {
                    try
                    {
                        GetContext.context.Users.RemoveRange((IEnumerable<Users>)UsersForRemoving);
                        GetContext.context.SaveChanges();
                        DGrid.ItemsSource = GetContext.context.Users.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Что-то пошло не так, подробности: {ex}");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не можете удалить первй элемент");
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Add_Users("", "", "", "","", 4));
        }

        private void IdInputbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var IdUser = GetContext.context.Users.FirstOrDefault(p => p.Id == Convert.ToInt32(ID_input_text.Text));
                Manager._MainFrame.Navigate(new Add_Users(IdUser.Name, IdUser.Surname, IdUser.Patronymic, IdUser.Login, IdUser.Password, IdUser.Position));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Данный пользователь не найден");
            }

        }

        private void ID_input_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(ID_input_text.Text))
            {
                ID_input_text.Text = "Введите ID пользователя";
            }
        }
    }
}
