using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/App")]
public class AppController:ControllerBase
{
    private readonly AppService appService;

    public AppController(AppService appS)
    {
        appService=appS;
    }

    [HttpPost]
    [Route("login/{username}/{password}")]

    public ActionResult<LoginResult>login([FromRoute]string username,[FromRoute]string password)
    {
        var result=appService.login(username,password);
        return Ok(result);
    }
}