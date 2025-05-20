using Entity.Model.global;

namespace Entity.Model
{
    public class Form : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<RolFormPermission> RolFormPermission { get; set; } = new List<RolFormPermission>();
        public ICollection<ModuleForm> ModuleForm { get; set; } = new List<ModuleForm>();

    }
}
