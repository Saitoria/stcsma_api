using SCTSMA.DOMAIN.Models.Status;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IStatusRepository
    {
        Task<IResult<List<StatusResponseModel>>> GetAllStatuses();
    }
}
