using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Role;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.INFRASTRUCTURE
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbService _dbService;

        public RoleRepository(IDbService dbService) 
        { 
            _dbService = dbService;
        }
        public async Task<IResult<List<RoleResponseModel>>> GetAllRoles()
        {
            return await _dbService.GetAll<RoleResponseModel>("SELECT * FROM public.roles", new { });
        }
    }
}
