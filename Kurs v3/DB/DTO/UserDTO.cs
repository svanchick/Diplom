using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kurs_v3.DB.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Position { get; set; }
    }
}
