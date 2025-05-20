using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.global;

namespace Entity.Model
{
    public class ModuleForm : IModel
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public int FormId { get; set; }

        public Module Module { get; set; } = new Module();
        public Form Form { get; set; } = new Form();

    }
}
