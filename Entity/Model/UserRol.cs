using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.global;

namespace Entity.Model
{
    public class UserRol : IModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RolId { get; set; }

        public User User { get; set; } = new User();
        public Rol Rol { get; set; } = new Rol();
    }
}
