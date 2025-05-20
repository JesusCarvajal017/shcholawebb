using Entity.Model.global;

namespace Entity.Model
{
    public class Module : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<ModuleForm> ModuleForm { get; set; } = new List<ModuleForm>();
    }
}
