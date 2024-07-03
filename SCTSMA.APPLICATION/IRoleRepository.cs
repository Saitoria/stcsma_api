using SCTSMA.DOMAIN.Models.Product;
using SCTSMA.DOMAIN.Models.Role;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IRoleRepository
    {
        Task<IResult<List<RoleResponseModel>>> GetAllRoles();
    }
}
