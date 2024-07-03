using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS.Interface;

namespace SCTSMA.APPLICATION
{
    public interface IUserRepository
    {
        Task<IResult<bool>> CreateUser(UserModel userModel);
        Task<IResult<bool>> SignupUser(UserAuthModel userAuthModel);
        Task<IResult<bool>> SignupBusinessOwner(BusinessOwnerAuthModel businessOwnerAuthModel);
        Task<IResult<UserLoginResModel>> LoginUser(UserLoginRqModel userLoginRqModel);
        Task<IResult<List<UserModel>>> GetUsers();
        Task<IResult<List<UserModel>>> GetUsersByRole(int role_id);
        Task<IResult<UserModel>> UpdateUser(UserModel userModel);
        Task<IResult<bool>> DeleteUser(string phone_number);
    }
}
