using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages.Add_Type;
using Kurs_v3.Objects.Pages.Pre_Show;
using System.Windows;
using System.Windows.Controls;

namespace Kurs_v3.Objects.Pages.Show_Type
{
    /// <summary>
    /// Логика взаимодействия для Plate_Show.xaml
    /// </summary>
    public partial class Plate_Show : Page
    {
        public Plate_Show()
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
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GetContext.context.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGrid.ItemsSource = GetContext.context.Plates.ToList();
            }
        }

        private void IdInputbtn_Click(object sender, RoutedEventArgs e)
        {
            if (ID_input_text.Text != "1")
            {
                try
                {
                    //Поиск нужной строки
                    var Name_to_TextBox = GetContext.context.Plates.Where(u => u.Id.ToString() == ID_input_text.Text).First();
                    Manager._MainFrame.Navigate(new Pre_Plate(Name_to_TextBox.Name, Name_to_TextBox.SerialNumber, Name_to_TextBox.Id, Name_to_TextBox.Description, Name_to_TextBox.Cost));

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Данной платы не существует, или вы ввели не число, подробнеее:{ex}");
                }
            }
            else
            {
                MessageBox.Show("Нельзя взаимодействовать с системной строкой!");
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new New_Plate("","",0, "", 0));
        }

        private void Delete_Btn_Click(object sender, RoutedEventArgs e)
        {
            var PlatesForRemoving = DGrid.SelectedItems.Cast<Plate>().ToList();
            var currentuser = GetContext.context.Users.Where(p => p.Login == Manager.LoginedUser).FirstOrDefault();
            if(currentuser.Position == 2)
            {
                if (MessageBox.Show($"Вы точно хотите удалить следующие {PlatesForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (DGrid.SelectedIndex != 0)
                    {
                        try
                        {
                            GetContext.context.Plates.RemoveRange(PlatesForRemoving);
                            GetContext.context.SaveChanges();
                            DGrid.ItemsSource = GetContext.context.Plates.ToList();
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

        private void ID_input_text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(ID_input_text.Text))
            {
                ID_input_text.Text = "Введите ID платы";
            }
        }

        
    }
}

