using CK.Central.Core.Domain.DataObjects.CMS.Entity;

namespace CK.Central.Core.CMS.Auth.Abstract.Repositories
{
    public interface IIdentityRoleRepository
    {
        Task<List<AspNetRoleEntity>> GetAll();

        Task<AspNetRoleEntity> Get(string Id);
    }
}
