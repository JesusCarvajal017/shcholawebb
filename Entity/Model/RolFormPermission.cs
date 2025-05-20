using Entity.Model.global;

namespace Entity.Model
{
    public class RolFormPermission : IModel
    {
        public int Id { get; set; }
        public int RolId { get; set; }
        public int FormId { get; set; }
        public int PermissionId { get; set; }

        public Rol Rol { get; set; }
        public Form Form { get; set; }
        public Permission Permission { get; set; }
    }
}
