using System.Windows;
using System.Windows.Controls;
using Kurs_v3.DB.Model;
using Kurs_v3.Objects.Classes;



namespace Kurs_v3.Objects.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add_Edit_Page.xaml
    /// </summary>
    public partial class Add_Edit_Page : Page
    {
        private Kurs_v3.DB.Model.Assembly _assembly = new();

        public Add_Edit_Page(int id)
        {
            InitializeComponent();
            try
            {
                var selectedassembly = GetContext.context.Assemblies.First(p => p.Id == id);
                _assembly = selectedassembly;
            }
            catch
            {

            }
           
           
            Fill_ComboBoxes();
        }
        private void Fill_ComboBoxes()
        {
            #region LinQForDial
            // системная запись
           
            
                var zeroDial = GetContext.context.Dials.Where(p => p.Id == 1).ToList();

                var AllDials = GetContext.context.Dials.Select(p => p.Id).ToList();

                var AsseblesWithtDials = GetContext.context.Assemblies.Where(p => AllDials.Contains(p.DialId)).ToList();

                var DialsNotForShow = AsseblesWithtDials.Select(p => p.DialId);

                // Находим пересечение двух списков
                var intersection = AllDials.Intersect(DialsNotForShow).ToList();

                // Объединяем списки и удаляем значения из пересечения
                var RightDials = AllDials.Union(DialsNotForShow).Except(intersection).ToList();

                var DialsForShow = GetContext.context.Dials.Where(p => RightDials.Contains(p.Id)).ToList();

                var DialsForShowWithZero = DialsForShow.Union(zeroDial).ToList();
            if (_assembly == null)
            {
                Manager.DialsForShow = DialsForShowWithZero;
            }
            else
            {
                var CurrentDial = GetContext.context.Dials.Where(p => p.Id == _assembly.DialId).ToList();
                Manager.DialsForShow = DialsForShowWithZero.Union(CurrentDial).ToList();
            }
           
            #endregion

            #region LinQForDisplay
            // системная запись
            var zeroDisplay = GetContext.context.Displays.Where(p => p.Id == 1).ToList();

            var AllDisplays = GetContext.context.Displays.Select(p => p.Id).ToList();

            var AsseblesWithtDisplays = GetContext.context.Assemblies.Where(p => AllDisplays.Contains(p.DisplayId)).ToList();

            var DisplaysNotForShow = AsseblesWithtDisplays.Select(p => p.DisplayId);

            // Находим пересечение двух списков
            var intersectionForDisplay = AllDisplays.Intersect(DisplaysNotForShow).ToList();

            // Объединяем списки и удаляем значения из пересечения
            var RightDisplays = AllDisplays.Union(DisplaysNotForShow).Except(intersectionForDisplay).ToList();

            var DisplaysForShow = GetContext.context.Displays.Where(p => RightDisplays.Contains(p.Id)).ToList();

            var DisplaysForShowWithZero = DisplaysForShow.Union(zeroDisplay).ToList();

            if (_assembly == null)
            {
                Manager.DisplaysForShow = DisplaysForShowWithZero;
            }
            else
            {
                var CurrentDisplay = GetContext.context.Displays.Where(p => p.Id == _assembly.DisplayId).ToList();
                Manager.DisplaysForShow = DisplaysForShowWithZero.Union(CurrentDisplay).ToList();
            }
            #endregion

            #region LinQForPlate
            // системная запись
            var zeroPlate = GetContext.context.Plates.Where(p => p.Id == 1).ToList();

            var AllPlates = GetContext.context.Plates.Select(p => p.Id).ToList();

            var AsseblesWithPlates = GetContext.context.Assemblies.Where(p => AllPlates.Contains(p.PlateId)).ToList();

            var PlatesNotForShow = AsseblesWithPlates.Select(p => p.PlateId);

            // Находим пересечение двух списков
            var intersectionForPlate = AllPlates.Intersect(PlatesNotForShow).ToList();

            // Объединяем списки и удаляем значения из пересечения
            var RightPlates = AllPlates.Union(PlatesNotForShow).Except(intersectionForPlate).ToList();

            var PlatesForShow = GetContext.context.Plates.Where(p => RightPlates.Contains(p.Id)).ToList();

            var PlatesForShowWithZero = PlatesForShow.Union(zeroPlate).ToList();

            if (_assembly == null)
            {
                Manager.PlatesForShow = PlatesForShowWithZero;
            }
            else
            {
                var CurrentPlate = GetContext.context.Plates.Where(p => p.Id == _assembly.PlateId).ToList();
                Manager.PlatesForShow = PlatesForShowWithZero.Union(CurrentPlate).ToList();
            }
            #endregion

            #region(Displays_ComboBox)
            Display_ComboBox.ItemsSource = Manager.DisplaysForShow;
            Display_ComboBox.DisplayMemberPath = "Name";
            Display_ComboBox.SelectedValuePath = "Id";
            #endregion

            #region(Dial_ComboBox)
            Dial_ComboBox.ItemsSource = Manager.DialsForShow;
            Dial_ComboBox.DisplayMemberPath = "Name";
            Dial_ComboBox.SelectedValuePath = "Id";
            #endregion

            #region(Plates_ComboBox)
            Plate_ComboBox.ItemsSource = Manager.PlatesForShow;
            Plate_ComboBox.DisplayMemberPath = "Name";
            Plate_ComboBox.SelectedValuePath = "Id";
            #endregion

            if (_assembly.Id == 0)
            {
                Name_text.Text = "";
                Display_ComboBox.Text = "None";
                Dial_ComboBox.Text = "None";
                Plate_ComboBox.Text = "None";
            }
            else
            {
                Name_text.Text = _assembly.Name;
                Display_ComboBox.SelectedValue = _assembly.DisplayId;
                Dial_ComboBox.SelectedValue = _assembly.DialId;
                Plate_ComboBox.SelectedValue = _assembly.PlateId;
            }

        }
        private void Save_Btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Dial_ComboBox.Text == "None" && Plate_ComboBox.Text == "None" && Display_ComboBox.Text == "None") || string.IsNullOrEmpty(Name_text.Text))
                {
                    MessageBox.Show("Введите название сборки или Выбирете хотя-бы один компонент");
                }
                else
                {
                    try
                    {
                        _assembly.Name = Name_text.Text;
                        _assembly.DialId = Convert.ToInt32(Dial_ComboBox.SelectedValue);
                        _assembly.DisplayId = Convert.ToInt32(Display_ComboBox.SelectedValue);
                        _assembly.PlateId = Convert.ToInt32(Plate_ComboBox.SelectedValue);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Ошибка, Более подробно: {ex}");
                    }
                    

                    if(_assembly.Id != 0)
                    {
                        MessageBoxResult result = MessageBox.Show("Вы точно хотите перезаписать сборку?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if(result == MessageBoxResult.Yes) 
                        {
                            try
                            {
                                var currentAssembly = GetContext.context.Assemblies.First(p => p.Id == _assembly.Id);
                                currentAssembly.DialId = Convert.ToInt32(Dial_ComboBox.SelectedValue);
                                currentAssembly.DisplayId = Convert.ToInt32(Display_ComboBox.SelectedValue);
                                currentAssembly.PlateId = Convert.ToInt32(Plate_ComboBox.SelectedValue);
                                GetContext.context.Update(currentAssembly);
                                GetContext.context.SaveChanges();
                                MessageBox.Show("Данные успешно перезаписаны!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                                Manager._MainFrame.GoBack();
                            }
                            catch
                            {
                                MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        
                    }

                    if(_assembly.Id == 0 ) 
                    {
                        
                        try
                        {
                            GetContext.context.Assemblies.Add(_assembly);
                            GetContext.context.SaveChanges();
                            MessageBox.Show("Информация сохранена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                            Manager._MainFrame.GoBack();
                        }
                        catch
                        {
                            MessageBox.Show("Что-то пошло не так!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                   

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex}");
            }
        }

        private void Display_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Id_Display_To_Number = GetContext.context.Displays.Find(Display_ComboBox.SelectedValue);
            if (Id_Display_To_Number != null)
            {
                Display_number.Text = ($" С.Н.{Id_Display_To_Number.SerialNumber}");
            }
            else
            {
                MessageBox.Show("Ошибка отображения серийного номера");
            }
        }

        private void Dial_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Id_Dial_To_Number = GetContext.context.Dials.Find(Dial_ComboBox.SelectedValue);
            if (Id_Dial_To_Number != null)
            {
                Dial_number.Text = ($" С.Н.{Id_Dial_To_Number.SerialNumber}");
            }
            else
            {
                MessageBox.Show("Ошибка отображения серийного номера");
            }
        }

        private void Plate_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Id_Plate_To_Number = GetContext.context.Plates.Find(Plate_ComboBox.SelectedValue);
            if (Id_Plate_To_Number != null)
            {
                Plate_number.Text = ($" С.Н.{Id_Plate_To_Number.SerialNumber}");
            }
            else
            {
                MessageBox.Show("Ошибка отображения серийного номера");
            }
        }
    }
}
