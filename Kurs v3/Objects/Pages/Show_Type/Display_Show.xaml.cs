using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages.Add_Type;
using Kurs_v3.Objects.Pages.Pre_Show;
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
    /// Логика взаимодействия для Display_Show.xaml
    /// </summary>
    public partial class Display_Show : Page
    {
        public Display_Show()
        {
            InitializeComponent();
            var LoginedUser = GetContext.context.Users.Where(p => p.Login == Manager.LoginedUser).FirstOrDefault();
            if (LoginedUser.Position == 2)
            {
                AddBtn.Visibility = Visibility.Visible;
                Delete_Btn.Visibility = Visibility.Visible;
            }
            else
            {
                AddBtn.Visibility = Visibility.Hidden;
                Delete_Btn.Visibility = Visibility.Hidden;
            }
        }
        private void IdInputbtn_Click(object sender, RoutedEventArgs e)
        {
            if (ID_input_text.Text != "1")
            {
                try
                {
                    //Поиск нужной строки
                    var Name_to_TextBox = GetContext.context.Displays.Where(u => u.Id.ToString() == ID_input_text.Text).First();
                    Manager._MainFrame.Navigate(new Pre_Display(Name_to_TextBox.Name, Name_to_TextBox.SerialNumber, Name_to_TextBox.Id, Name_to_TextBox.Description, Name_to_TextBox.Cost));

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данного дисплея не существует, или вы ввели не число, подробнеее:{ex}");
                }
            }
            else
            {
                MessageBox.Show("Нельзя взаимодействовать с системной строкой!");
            }

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new New_Display(string.Empty, string.Empty, 0, string.Empty, 0));
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var DisplaysForRemoving = DGrid.SelectedItems.Cast<Display>().ToList();
            var currentuser = GetContext.context.Users.Where(p => p.Login == Manager.LoginedUser).FirstOrDefault();
            if(currentuser.Position == 2)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующие {DisplaysForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (DGrid.SelectedIndex != 0)
                    {
                        try
                        {
                            GetContext.context.Displays.RemoveRange(DisplaysForRemoving);
                            GetContext.context.SaveChanges();
                            DGrid.ItemsSource = GetContext.context.Displays.ToList();
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
            else
            {
                MessageBox.Show("У вас нет прав удалять записи");
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GetContext.context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = GetContext.context.Displays.ToList();
            }
        }

        private void ID_input_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ID_input_text.Text))
            {
                ID_input_text.Text = "Введите ID дисплея";
            }
        }
    }
}
