using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using System.Data.Entity.Validation;
using System.Data.SqlTypes;
using System.Windows;
using System.Windows.Controls;


namespace Kurs_v3.Objects.Pages.Add_Type
{
    /// <summary>
    /// Логика взаимодействия для New_Dial.xaml
    /// </summary>
    public partial class New_Dial : Page
    {
        private Dial _dials = new();
        public New_Dial(string Name, string SerialNumber, int id, string Description, int cost)
        {
            InitializeComponent();
            Name_Dial_Text.Text = Name;
            Serial_number_Dial_text.Text = SerialNumber;
            Dials_Discription.Text = Description;
            Dials_Cost_Text.Text = Convert.ToString(cost);
            _dials.Name = Name;
            _dials.SerialNumber = SerialNumber;
            _dials.Id = id;
            _dials.Cost = cost;
            _dials.Description = Description;
        }

        private void Dial_Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            var CheckDial = GetContext.context.Dials.Where(p => p.Name == Name_Dial_Text.Text && p.SerialNumber == Serial_number_Dial_text.Text).FirstOrDefault();

            // Проверка на правильный ввод
            if (string.IsNullOrEmpty(Name_Dial_Text.Text) || string.IsNullOrEmpty(Serial_number_Dial_text.Text))
            {
                MessageBox.Show("Введите корректно название датчика и его серийный номер");
            }

            // Перезапись выбранной записи
            if(_dials.Id != 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите перезаписать текущий датчик?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var current_dial = GetContext.context.Dials.First(p => p.Id == _dials.Id);

                        current_dial.Name = Name_Dial_Text.Text;
                        current_dial.SerialNumber = Serial_number_Dial_text.Text;
                        current_dial.Description = Dials_Discription.Text;
                        current_dial.Cost = Convert.ToInt32(Dials_Cost_Text.Text);
                        GetContext.context.Dials.Update(current_dial);
                        GetContext.context.SaveChanges();
                        MessageBox.Show("Данные успешно перезаписаны!","Успех!", MessageBoxButton.OK,MessageBoxImage.Asterisk);
                        Manager._MainFrame.GoBack();
                    }
                    catch
                    {
                        MessageBox.Show("Что то пошло не так!","Ошибка!",MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } 
            }

            // Создание новой записи
            else
            {
                if (_dials.Id == 0)
                {
                    try
                    {
                        _dials.Name = Name_Dial_Text.Text;
                        _dials.SerialNumber = Serial_number_Dial_text.Text;
                        _dials.Description = Dials_Discription.Text;
                        _dials.Cost = Convert.ToInt32(Dials_Cost_Text.Text);
                        GetContext.context.Dials.Add(_dials);
                        GetContext.context.SaveChanges();
                        MessageBox.Show("Информация сохранена!");
                        Manager._MainFrame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Проверте правильность заполнения всех полей! {ex}");
                    }
                }
            }
        }

        private void Dials_Cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(Dials_Cost_Text.Text))
            {
                Dials_Cost_Text.Text = "0";
            }
        }
    }
}
