using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.Status;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.INFRASTRUCTURE
{
    public class StatusRepository : IStatusRepository
    {
        private readonly IDbService _dbService;
        public StatusRepository(IDbService dbService) 
        { 
            _dbService = dbService;
        }

        public async Task<IResult<List<StatusResponseModel>>> GetAllStatuses()
        {
            return await _dbService.GetAll<StatusResponseModel>("SELECT * FROM public.statuses", new { });
        }
    }
}
