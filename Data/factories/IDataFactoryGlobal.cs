using Data.interfaces.Auth;
using Data.interfaces.global;
using Entity.Model;

namespace Data.factories
{
    public interface IDataFactoryGlobal
    {
        CrudGeneric<Person> CreatePersonData();
        CrudGeneric<User> CreateUserData();

        CrudGeneric<RolFormPermission> CreateRolFormPermissionData();
        Auth CreateAuth();

    }
}
