using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProfileManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileManager.Repository
{
    public class FileUpload : IFileUpload
    {
        private readonly Cloudinary _cloudinary;
        private readonly IConfiguration _config;


        public FileUpload(IConfiguration configuration)
        {
            _config = configuration;

            Account account = new Account
            {
                Cloud = _config["CloudinarySettings:CloudName"],
                ApiKey = _config["CloudinarySettings:ApiKey"],
                ApiSecret = _config["CloudinarySettings:ApiSecret"],
            };
            _cloudinary = new Cloudinary(account);
        }

        public async Task<List<DocumentUploadResult>> UploadDocuments(List<IFormFile> files)
        {
            var uploadResults = new List<DocumentUploadResult>();
            
                foreach (var file in files)
                {
                    var imageUploadResult = new ImageUploadResult();


                    if (file.Length <= 0)
                        throw new InvalidOperationException("Invalid file size");

                    using (var fs = file.OpenReadStream())
                    {
                        var imageUploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(file.FileName, fs),
                            Transformation = new Transformation().Width(300).Height(300).Crop("fill")
                        };
                        imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);

                    }
                    var res = new DocumentUploadResult
                    {
                        PublicId = imageUploadResult.PublicId,
                        ImageUrl = imageUploadResult.Url.ToString(),
                        ImageName = file.FileName
                    };
                    uploadResults.Add(res);

                }

            

            return uploadResults;
        }
    }
    
}
