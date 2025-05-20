using Data.interfaces.crud;

namespace Data.interfaces.global
{
    public interface CrudGeneric<T> : IQueryAll<T>, IQueryById<T>, IInsert<T>, IUpdate<T>, IDelete, IDeleteLogical<T>
    {
    }
}
