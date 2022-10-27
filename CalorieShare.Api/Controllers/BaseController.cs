using Microsoft.AspNetCore.Mvc;

namespace CalorieShare.Api.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : ControllerBase
{

    public BaseController()
    {
    }

}
