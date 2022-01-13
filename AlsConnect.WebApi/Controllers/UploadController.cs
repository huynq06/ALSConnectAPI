using AlsConnect.Application.Interfaces;
using AlsConnect.Application.ViewModels.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AlsConnect.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("uploadImage")]
        [AllowAnonymous]
        public IActionResult UploadImage(IFormFile file)
        {
            DateTime now = DateTime.Now;
            var filename = ContentDispositionHeaderValue
                                .Parse(file.ContentDisposition)
                                .FileName
                                .Trim('"');

            var imageFolder = $@"\uploaded\images\{now.ToString("yyyyMMdd")}";

            string folder = _hostingEnvironment.WebRootPath + imageFolder;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string filePath = Path.Combine(folder, filename);
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return new OkObjectResult(Path.Combine(imageFolder, filename).Replace(@"\", @"/"));

        }
    }
}
