using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace StreamingMP4.Controllers
{
    public class VideoController : Controller
    {
        private IWebHostEnvironment _hostingEnviroment;

        public VideoController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnviroment = hostingEnvironment;
        }

        [HttpGet("Video/{id}")]
        public FileResult Video(int id)
        {
            var filename = $"video{id}.mp4";
            string path = Path.Combine(_hostingEnviroment.ContentRootPath, "videos/") + filename;

            var video = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, 1000, true);
            var file = File(video, "video/mp4", enableRangeProcessing: true);

            return file;
        }
    }
}