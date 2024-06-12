using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_v3.DB.Model
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string NameOfPosition { get; set; }
       
    }
}
