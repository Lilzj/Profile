using ProfileManager.ViewModel;
using ProfileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileManager.Repository
{
    public interface IProfileRepository
    {
        Task<bool> Register(RegisterDTO register);
        Task<User> GetProfile(string email);
    }
}
