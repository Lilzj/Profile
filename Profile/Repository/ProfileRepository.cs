using ProfileManager.Data;
using ProfileManager.ViewModel;
using ProfileManager.Models;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProfileManager.Common;

namespace ProfileManager.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly ProfileContext _ctx;
        private readonly IMapper _mapper;
        private readonly IFileUpload _fileUpload;
        private readonly IMailService _mailService;


        public ProfileRepository(ProfileContext ctx, IMapper mapper, IFileUpload fileUpload, IMailService mailService)
        {
            _ctx = ctx;
            _mapper = mapper;
            _fileUpload = fileUpload;
            _mailService = mailService;
        }

        private async Task<bool> SavedAsync()
        {
            bool ValueToReturned;
            if (await _ctx.SaveChangesAsync() > 0)
                ValueToReturned = true;
            else
                ValueToReturned = false;

            return ValueToReturned;
        }


        public async Task<bool> Register(RegisterDTO register)
        {
            var reg = _mapper.Map<RegisterDTO, User>(register);

            var doc = await _fileUpload.UploadDocuments(register.Documents);

            foreach(var item in doc)
            {
                var docx = new Document
                {
                    User = reg,
                    DocumentName = item.ImageName,
                    DocumentURL = item.ImageUrl,
                    PublicId = item.PublicId
                };
                reg.Documents.Add(docx);
            }

            reg.TransactionNumber = Utilities.GenerateTransactionNumber();

            await _ctx.Users.AddAsync(reg);

            var mailrequest = new MailRequest
            {
                ToEmail = register.Email,
                Subject = "Registration Successful",
                Body = $"Hello {reg.FullName}, Thanks for registring on our platform, \n Find attached below your documents",
                Attachments = register.Documents
            };

            await _mailService.SendEmailAsync(mailrequest);

            return await SavedAsync();
        }

        public async Task<User> GetProfile(string email)
        {
            return await _ctx.Users.Where(x => x.Email == email).Include(x => x.Documents)
                .FirstOrDefaultAsync();
           
        }

      
    }
}
