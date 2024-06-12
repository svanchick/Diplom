using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using System.Data.Entity.Validation;
using System.Windows;
using System.Windows.Controls;

namespace Kurs_v3.Objects.Pages.Add_Type
{
    /// <summary>
    /// Логика взаимодействия для New_Display.xaml
    /// </summary>
    public partial class New_Display : Page
    {
        private Display _Displays = new Display();
        public New_Display(string Name, string SerialNumber, int id, string Description, int Cost)
        {
            InitializeComponent();
            Name_Display_Text.Text = Name;
            Serial_number_Display_text.Text = SerialNumber;
            DIsplays_Discription.Text = Description;
            Displays_Cost_Text.Text = Convert.ToString(Cost);
            _Displays.Name = Name;
            _Displays.SerialNumber = SerialNumber;
            _Displays.Id = id;
            _Displays.Description = Description;
            _Displays.Cost = Cost;
        }

        private void Display_Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            var CheckDial = GetContext.context.Dials.Where(p => p.Name == Name_Display_Text.Text && p.SerialNumber == Serial_number_Display_text.Text).FirstOrDefault();

            if (string.IsNullOrEmpty(Name_Display_Text.Text) || string.IsNullOrEmpty(Serial_number_Display_text.Text))
            {
                MessageBox.Show("Введите корректно название дисплея и его серийный номер");
            }
            
            if (_Displays.Id != 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите перезаписать текущий дисплей?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var CurrentDisplay = GetContext.context.Displays.First(p => p.Id == _Displays.Id);
                        CurrentDisplay.SerialNumber = Serial_number_Display_text.Text;
                        CurrentDisplay.Name = Name_Display_Text.Text;
                        CurrentDisplay.Description = DIsplays_Discription.Text;
                        CurrentDisplay.Cost = Convert.ToInt32(Displays_Cost_Text.Text);
                        GetContext.context.Update(CurrentDisplay);
                        GetContext.context.SaveChanges();
                        MessageBox.Show("Данные успешно перезаписаны!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        Manager._MainFrame.GoBack();
                    }
                    catch
                    {
                        MessageBox.Show("Что то пошло не так!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                if (_Displays.Id == 0)
                {
                    try
                    {
                        _Displays.Name = Name_Display_Text.Text;
                        _Displays.SerialNumber = Serial_number_Display_text.Text;
                        _Displays.Description = DIsplays_Discription.Text;
                        _Displays.Cost = Convert.ToInt32(Displays_Cost_Text.Text);
                        GetContext.context.Displays.Add(_Displays);
                        GetContext.context.SaveChanges();
                        MessageBox.Show("Информация сохранена!");
                        Manager._MainFrame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Что то пошло не так, подробнее:\t {ex}");
                    }
                }
               
            }
            
        }

        private void Displays_Cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Displays_Cost_Text.Text))
            {
                Displays_Cost_Text.Text = "0";
            }
        }
    }
}
