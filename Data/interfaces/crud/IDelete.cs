namespace Data.interfaces.crud
{
    public interface IDelete
    {
        Task<Object> DeleteAsync(int id);
    }
}
