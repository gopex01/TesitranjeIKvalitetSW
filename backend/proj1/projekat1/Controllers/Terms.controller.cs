using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


[ApiController]
[Route("[controller]/Terms")]
public class TermEntityController:ControllerBase
{
    private readonly TerminService terminService;

    public TermEntityController(TerminService ts)
    {
        terminService=ts;
    }


    [HttpPost]
    [Route("addTermin/{username}")]
    public ActionResult<string> addTerm([FromBody] TermEntity newTerm, [FromRoute] string username)
    {
        var result= terminService.createTermin(newTerm,username);
        return Ok(result);
    }
}