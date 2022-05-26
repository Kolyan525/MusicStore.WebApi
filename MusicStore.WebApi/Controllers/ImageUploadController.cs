using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MusicStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment env;

        private readonly ILogger<ImageUploadController> logger;

        public ImageUploadController(IWebHostEnvironment environment, ILogger<ImageUploadController> logger)
        {
            env = environment;
            this.logger = logger;
        }

        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }

        [HttpPost]
        public async Task<string> Post([FromForm] FileUploadAPI objFile)
        {
            if (objFile.files.Length > 0)
            {
                try
                {

                    if (!Directory.Exists(env.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(env.WebRootPath + "\\Upload\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(env.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        objFile.files.CopyTo(fileStream); ;
                        fileStream.Flush();
                        return "\\Upload\\" + objFile.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Something went wrong in the {nameof(Post)}");
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccesful";
            }
        }
    }
}
