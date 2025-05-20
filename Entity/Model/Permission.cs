using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.global;

namespace Entity.Model
{
    public class Permission : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<RolFormPermission> RolFormPermission { get; set; } = new List<RolFormPermission>();
    }
}
