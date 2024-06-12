using Kurs_v3.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Kurs_v3.Objects.Classes
{
    public class Manager
    {
        public static Frame _MainFrame { get; set; }
        public static DataGrid DGrid { get; set; }
        public static string LoginedUser { get; set; }

        public static List<Dial> DialsForShow { get; set; }
        public static List<Display> DisplaysForShow { get; set; }
        public static List<Plate> PlatesForShow { get; set; }

    }
}
