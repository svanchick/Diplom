using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_v3.DB.Model
{
    public class Plate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SerialNumber { get; set; }
        [AllowNull]
        public int Cost { get; set; }
        [AllowNull]
        public string Description { get; set; }
    }
}
