using Microsoft.AspNetCore.Mvc;

namespace TestTask.Backend.Web.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class ApiController : ControllerBase
	{
	}
}
