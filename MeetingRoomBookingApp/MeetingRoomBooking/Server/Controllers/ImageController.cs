using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomBooking.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {

        [HttpPost]
        public async Task<ActionResult> Save(IFormFile files) // must match SaveField
        {
            if (files != null)
            {
                try
                {
                    
                    if (files.Length > 0)
                    {
                        
                        byte[] fileBytes;
                        string fileString;

                        using (var ms = new MemoryStream())
                        {
                            files.CopyTo(ms);
                            fileBytes = ms.ToArray();
                            fileString = Convert.ToBase64String(fileBytes);
                            Console.WriteLine(fileString);
                        }
                        return Ok(fileString);
                    }

                }
                catch
                {
                    Response.StatusCode = 500;
                    await Response.WriteAsync("Upload failed.");
                }
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult Remove([FromForm] string files) // must match RemoveField
        {
            if (files != null)
            {
                return Ok("removed");
                
            } 

            return new EmptyResult();
        }
    }
}
