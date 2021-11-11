using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using ProfileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileManager.Repository
{
    public interface IFileUpload
    {
        Task<List<DocumentUploadResult>> UploadDocuments(List<IFormFile> file);
    }
}
