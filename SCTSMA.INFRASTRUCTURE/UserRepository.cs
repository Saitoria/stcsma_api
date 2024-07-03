using SCTSMA.APPLICATION;
using SCTSMA.DOMAIN.Models.User;
using SCTSMA.UTILS.Interface;
using SCTSMA.UTILS;

namespace SCTSMA.INFRASTRUCTURE
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbService _dbService;

        public UserRepository(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResult<bool>> CreateUser(UserModel userModel)
        {
            var result = await _dbService.EditData(
                "INSERT INTO public.users (phone_number, password, role_id, first_name, last_name, email, national_id, tin_number, tin_certificate, tax_clearance, brela_document, postal_code, address, location, otp, status_id) VALUES (@PhoneNumber, @Password, @RoleId, @FirstName, @LastName, @Email, @NationalId, @TinNumber, @TinCertificate, @TaxClearance, @BrelaDocument, @PostalCode, @Address, @Location, @Otp, @StatusId)",
                new
                {
                    PhoneNumber = userModel.phone_number,
                    Password = userModel.password,
                    RoleId = userModel.role_id,
                    FirstName = userModel.first_name,
                    LastName = userModel.last_name,
                    Email = userModel.email,
                    NationalId = userModel.national_id,
                    TinNumber = userModel.tin_number,
                    TinCertificate = userModel.tin_certificate,
                    TaxClearance = userModel.tax_clearance,
                    BrelaDocument = userModel.brela_document,
                    PostalCode = userModel.postal_code,
                    Address = userModel.address,
                    Location = userModel.location,
                    Otp = userModel.otp,
                    StatusId = userModel.status_id
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to create user.");
        }

        public async Task<IResult<bool>> DeleteUser(string phone_number)
        {
            var result = await _dbService.EditData("DELETE FROM public.users WHERE phone_number=@phone_number", new { phone_number });
            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to delete user.");
        }

        public async Task<IResult<List<UserModel>>> GetUsers()
        {
            return await _dbService.GetAll<UserModel>("SELECT * FROM public.users", new { });
        }

        public async Task<IResult<List<UserModel>>> GetUsersByRole(int role_id)
        {
            var result = await _dbService.GetAll<UserModel>("SELECT * FROM public.users WHERE role_id = @RoleId", new { RoleId = role_id });
            if (result.data == null)
            {
                return Result<List<UserModel>>.Failure("Invalid role id.");
            }

            return Result<List<UserModel>>.Success(result.data);
        }

        public async Task<IResult<UserLoginResModel>> LoginUser(UserLoginRqModel userLoginRqModel)
        {
            var result = await _dbService.GetAsync<UserLoginResModel>(
                @"SELECT u.*, r.role_name
                  FROM public.users u
                  JOIN public.roles r ON u.role_id = r.role_id
                  WHERE u.phone_number = @PhoneNumber AND u.password = @Password",
                new
                {
                    PhoneNumber = userLoginRqModel.phone_number,
                    Password = userLoginRqModel.password
                }
            );

            if (result.data == null)
            {
                return Result<UserLoginResModel>.Failure("Invalid phone number or password.");
            }

            return Result<UserLoginResModel>.Success(result.data);
        }

        public async Task<IResult<bool>> SignupBusinessOwner(BusinessOwnerAuthModel businessOwnerAuthModel)
        {
            var result = await _dbService.EditData(
                "INSERT INTO public.users (phone_number, password, role_id, email, national_id, tin_number, tin_certificate, status_id, postal_code, first_name, last_name) VALUES (@PhoneNumber, @Password, @RoleId, @Email, @NationalId, @TinNumber, @TinCertificate, @StatusId, @PostalCode, @FirstName, @LastName)",
                new
                {
                    PhoneNumber = businessOwnerAuthModel.phone_number,
                    Password = businessOwnerAuthModel.password,
                    RoleId = businessOwnerAuthModel.role_id,
                    Email = businessOwnerAuthModel.email,
                    NationalId = businessOwnerAuthModel.national_id,
                    TinNumber = businessOwnerAuthModel.tin_number,
                    TinCertificate = businessOwnerAuthModel.tin_certificate,
                    StatusId = businessOwnerAuthModel.status_id,
                    PostalCode = businessOwnerAuthModel.postal_code,
                    FirstName = businessOwnerAuthModel.first_name,
                    LastName = businessOwnerAuthModel.last_name
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to sign up business owner.");
        }

        public async Task<IResult<bool>> SignupUser(UserAuthModel userAuthModel)
        {
            var result = await _dbService.EditData(
                "INSERT INTO public.users (phone_number, password, role_id, email, national_id, status_id, first_name, last_name) VALUES (@PhoneNumber, @Password, @RoleId, @Email, @NationalId, @StatusId, @FirstName, @LastName)",
                new
                {
                    PhoneNumber = userAuthModel.phone_number,
                    Password = userAuthModel.password,
                    RoleId = userAuthModel.role_id,
                    Email = userAuthModel.email,
                    NationalId = userAuthModel.national_id,
                    StatusId = userAuthModel.status_id,
                    FirstName = userAuthModel.first_name,
                    LastName = userAuthModel.last_name
                }
            );

            return result.succeeded ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to sign up user.");
        }

        public async Task<IResult<UserModel>> UpdateUser(UserModel userModel)
        {
            var result = await _dbService.EditData(
                @"UPDATE public.users SET 
                password = @Password, 
                role_id = @RoleId, 
                first_name = @FirstName, 
                last_name = @LastName, 
                email = @Email, 
                national_id = @NationalId, 
                tin_number = @TinNumber, 
                tin_certificate = @TinCertificate, 
                tax_clearance = @TaxClearance, 
                brela_document = @BrelaDocument, 
                postal_code = @PostalCode, 
                address = @Address, 
                location = @Location, 
                otp = @Otp, 
                status_id = @StatusId 
            WHERE phone_number = @PhoneNumber",
                new
                {
                    PhoneNumber = userModel.phone_number,
                    Password = userModel.password,
                    RoleId = userModel.role_id,
                    FirstName = userModel.first_name,
                    LastName = userModel.last_name,
                    Email = userModel.email,
                    NationalId = userModel.national_id,
                    TinNumber = userModel.tin_number,
                    TinCertificate = userModel.tin_certificate,
                    TaxClearance = userModel.tax_clearance,
                    BrelaDocument = userModel.brela_document,
                    PostalCode = userModel.postal_code,
                    Address = userModel.address,
                    Location = userModel.location,
                    Otp = userModel.otp,
                    StatusId = userModel.status_id
                }
            );

            return result.succeeded ? Result<UserModel>.Success(userModel) : Result<UserModel>.Failure("Failed to update user.");
        }
    }
}
