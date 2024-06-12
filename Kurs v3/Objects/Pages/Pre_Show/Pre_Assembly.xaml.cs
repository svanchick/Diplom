using Kurs_v3.Objects.Classes;
using Kurs_v3.Objects.Pages.Add_Type;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Kurs_v3.Objects.Pages.Pre_Show
{
    /// <summary>
    /// Логика взаимодействия для Pre_Assembly.xaml
    /// </summary>
    public partial class Pre_Assembly : Page
    {
        private int ID;
        private string Name_of_Assembly;
        private string Name_of_Display;
        private string Name_of_Dial;
        private string Name_of_Plate;

        public Pre_Assembly(int id)
        {
            InitializeComponent();

            ID = id;
            var currentassemly = GetContext.context.Assemblies.Where(p => p.Id == id).FirstOrDefault();
            var currentuser = GetContext.context.Users.Where(p => p.Login == Manager.LoginedUser).FirstOrDefault();
            if (currentuser.Position == 3)
            {
                Edit_Assembly_Btn.Visibility =Visibility.Visible;
            }
            else
            {
                Edit_Assembly_Btn.Visibility = Visibility.Hidden;
            }
            
            if (currentassemly != null)
            {
                try
                {
                    Name_of_Display = GetContext.context.Displays.Where(p => p.Id == currentassemly.DisplayId).Select(p => p.Name).First();
                    Name_of_Dial = GetContext.context.Dials.Where(p => p.Id == currentassemly.DialId).Select(p => p.Name).First();
                    Name_of_Plate = GetContext.context.Plates.Where(p => p.Id == currentassemly.PlateId).Select(p => p.Name).First();
                    Name_of_Assembly = currentassemly.Name;

                   
                }
                catch
                {
                }
            }
        }
        

        private void Show_Display_Btn_Click(object sender, RoutedEventArgs e)
        {
            var current_Assembly = GetContext.context.Assemblies.Where(p => p.Id == ID).FirstOrDefault();
            var current_Display = GetContext.context.Displays.Where(p => p.Id == current_Assembly.DisplayId).FirstOrDefault();
            Manager._MainFrame.Navigate(new Pre_Display(current_Display.Name, current_Display.SerialNumber, current_Display.Id, current_Display.Description, current_Display.Cost));
        }

        private void Show_Dial_Btn_Click(object sender, RoutedEventArgs e)
        {
            var current_Assembly = GetContext.context.Assemblies.Where(p => p.Id == ID).FirstOrDefault();
            var current_Dial = GetContext.context.Dials.Where(p => p.Id == current_Assembly.DialId).FirstOrDefault();
            Manager._MainFrame.Navigate(new Pre_Dial(current_Dial.Name, current_Dial.SerialNumber, current_Dial.Id, current_Dial.Description, current_Dial.Cost));
        }

        private void Show_Plate_Btn_Click(object sender, RoutedEventArgs e)
        {
            var current_Assembly = GetContext.context.Assemblies.Where(p => p.Id == ID).FirstOrDefault();
            var current_Plate = GetContext.context.Plates.Where(p => p.Id == current_Assembly.PlateId).FirstOrDefault();
            Manager._MainFrame.Navigate(new Pre_Plate(current_Plate.Name, current_Plate.SerialNumber, current_Plate.Id, current_Plate.Description, current_Plate.Cost));
        }

        private void Edit_Assembly_Btn_Click(object sender, RoutedEventArgs e)
        {
            Manager._MainFrame.Navigate(new Add_Edit_Page(ID));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var currentassemly = GetContext.context.Assemblies.Where(p => p.Id == ID).FirstOrDefault();

            Name_of_Assembly_text.Text = GetContext.context.Assemblies.Where(p => p.Id == ID).Select(p => p.Name).FirstOrDefault();

            Name_of_Display_Text.Text = GetContext.context.Displays.Where(p => p.Id == currentassemly.DisplayId).Select(p => p.Name).FirstOrDefault();

            Name_of_Dial_Text.Text = GetContext.context.Dials.Where(p => p.Id == currentassemly.DialId).Select(p => p.Name).FirstOrDefault();

            Name_of_Plate_Text.Text = GetContext.context.Plates.Where(p => p.Id == currentassemly.PlateId).Select(p => p.Name).FirstOrDefault();

        }
    }
}
