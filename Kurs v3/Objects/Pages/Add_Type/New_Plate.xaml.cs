using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;
using System.Data.Entity.Validation;
using System.Windows;
using System.Windows.Controls;


namespace Kurs_v3.Objects.Pages.Add_Type
{
    /// <summary>
    /// Логика взаимодействия для New_Plate.xaml
    /// </summary>
    public partial class New_Plate : Page
    {
        private Plate _Plates = new();

        public New_Plate(string Name, string SerialNumber, int id, string Description, int Cost)
        {
            InitializeComponent();
            Name_Plate_Text.Text = Name;
            Serial_number_Plate_text.Text = SerialNumber;
            Plates_Discription.Text = Description;
            Plates_Cost_Text.Text = Convert.ToString(Cost);
            _Plates.Name = Name;
            _Plates.SerialNumber = SerialNumber;
            _Plates.Id = id;
            _Plates.Description = Description;
            _Plates.Cost = Cost;

        }
        private void Plate_Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            var check_plate = GetContext.context.Plates.Where(p => p.Name == Name_Plate_Text.Text && p.SerialNumber == Serial_number_Plate_text.Text).FirstOrDefault();
            if (string.IsNullOrEmpty(Name_Plate_Text.Text) || string.IsNullOrEmpty(Serial_number_Plate_text.Text))
            {
                MessageBox.Show("Введите корректно название платы и её серийный номер");
            }
            else
            {
                if (_Plates.Id != 0)
                {
                    MessageBoxResult result = MessageBox.Show("Вы точно хотите перезаписать данные о плате?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var currentPlate = GetContext.context.Plates.First(p => p.Id == _Plates.Id);
                            currentPlate.Name = Name_Plate_Text.Text;
                            currentPlate.SerialNumber = Serial_number_Plate_text.Text;
                            currentPlate.Description = Plates_Discription.Text;
                            currentPlate.Cost = Convert.ToInt32(Plates_Cost_Text.Text);

                            GetContext.context.Plates.Update(currentPlate);
                            GetContext.context.SaveChanges();
                            MessageBox.Show("Данные успешно перезаписаны!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            Manager._MainFrame.GoBack();
                        }
                        catch
                        {
                            MessageBox.Show("Что-то пошло не так", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                }
                if (_Plates.Id == 0)
                {
                    try
                    {
                        _Plates.Name = Name_Plate_Text.Text;
                        _Plates.SerialNumber = Serial_number_Plate_text.Text;
                        _Plates.Description = Plates_Discription.Text;
                        _Plates.Cost = Convert.ToInt32(Plates_Cost_Text.Text);
                        GetContext.context.Plates.Add(_Plates);
                        GetContext.context.SaveChanges();
                        MessageBox.Show("Информация сохранена!");
                        Manager._MainFrame.GoBack();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Что то пошло не так, подробнее: {ex}");
                    }
                }
                
                
               
            }
        }

        private void Plates_Cost_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Plates_Cost_Text.Text))
            {
                Plates_Cost_Text.Text = "0";
            }
        }
    }
}
