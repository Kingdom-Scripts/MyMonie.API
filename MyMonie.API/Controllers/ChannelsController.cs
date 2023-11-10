using Microsoft.AspNetCore.Mvc;
using MyMonie.Core.Models.App;
using MyMonie.Core.Models.Utilities;

namespace MyMonie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelsController : BaseController
    {
        private readonly MyMonieContext _context;

        public ChannelsController(MyMonieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult GetChannels(UserModel model)
        {
            var chs = _context.Channels.ToList();

            var result = new ErrorResult("Unable to return valid response"); // new SuccessResult(chs);
            return ProcessResponse(result);
        }
    }
}
