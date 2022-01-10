using AlsConnect.Application.ViewModels.API;
using AlsConnect.Application.ViewModels.System;
using AlsConnect.Utilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AlsConnect.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddAsync(AppUserViewModel userVm);

        Task DeleteAsync(string id);

        Task<List<AppUserViewModel>> GetAllAsync();

        PagedResult<AppUserViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<AppUserViewModel> GetById(string id);


        Task UpdateAsync(AppUserViewModel userVm);
        Task<UserViewModel> Authencate(LoginRequest request);
        Task<ApiResult<bool>> Register(RegisterRequest request);
        Task<ApiResult<bool>> ChangePassword(ChangePasswordRequest request);
        Task<ApiResult<bool>> ChangeAvatar(ChangeAvatarRequest request);
    }
}
