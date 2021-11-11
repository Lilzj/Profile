using AutoMapper;
using ProfileManager.ViewModel;
using ProfileManager.Models;

namespace ProfileManager.Mapping
{
    public class map : Profile
    {
        public map()
        {
            CreateMap<RegisterDTO, User>().ForMember(x => x.Documents, opt=>opt.Ignore()).ReverseMap();
            CreateMap<ProfileViewModel, User>();
        }
    }
}
