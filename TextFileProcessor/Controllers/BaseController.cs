using System.Web.Http;
using System.Web.Http.Description;

namespace TextFileProcessor.Web.Controllers
{

    [Route("api/[controller]")]
    public abstract class BaseApiController : ApiController
    {
    }
}
