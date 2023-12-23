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
    [Route("addTermin/{username}/{bcname}")]
    public ActionResult<string> addTerm([FromBody] TermEntity newTerm, [FromRoute] string username,[FromRoute] string bcname)
    {
        var result= terminService.createTermin(newTerm,username,bcname);
        return Ok(result);
    }
}