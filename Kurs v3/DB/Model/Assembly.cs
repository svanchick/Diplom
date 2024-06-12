using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_v3.DB.Model
{
    public class Assembly
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlateId { get; set; }
        public int DialId { get; set; }
        public int DisplayId { get; set; }

        [ForeignKey("DialId")]
        public Dial Dial { get; set; }
        [ForeignKey("DisplayId")]
        public Display Display { get; set; }
        [ForeignKey("PlateId")]
        public Plate Plate { get; set; }
    }
}
