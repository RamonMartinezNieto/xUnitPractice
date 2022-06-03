namespace TestinWithDependencies.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersServices _userService;
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger, UsersServices userServices)
    {
        _logger = logger;
        _userService = userServices;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("Getting all users");
        return Ok(await _userService.GetAllAsync());
    }
}
