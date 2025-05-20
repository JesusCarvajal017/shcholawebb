using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;

namespace Entity.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Por seguridad
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
        public int Status { get; set; }
    }
}
