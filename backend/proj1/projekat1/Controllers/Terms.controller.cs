using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


[ApiController]
[Route("[controller]/Term")]
public class TermEntityController:ControllerBase
{
    private readonly TerminService terminService;

    public TermEntityController(TerminService ts)
    {
        terminService=ts;
    }


    [HttpPost]
    [Route("addTerm/{username}/{bcname}")]
    public ActionResult<string> addTerm([FromBody] TermEntity newTerm, [FromRoute] string username,[FromRoute] string bcname)
    {
        var result= terminService.createTermin(newTerm,username,bcname);
        return Ok(result);
    }
    [HttpGet]
    [Route("getTerms/{username}")]
    public ActionResult<TermEntity[]> getTerms([FromRoute]string username)
    {
        var result=terminService.GetTermsAsync(username);
        return Ok(result);
    }
    [HttpGet]
    [Route("getNumOfTerms")]
    public ActionResult<int>getNumOfTerms()
    {
        var result=terminService.getNumOfTerms();
        return Ok(result);
    }

    [HttpGet]
    [Route("getPersonalTerms/{username}")]
    public ActionResult<TermEntity[]> getPersonalTerms([FromRoute] string username)
    {
        var result=terminService.GetPersonalTermsAsync(username);
        return Ok(result);
    }
    [HttpPatch]
    [Route("updateTerm/{termId}/{isCrossed}/{isComeBack}/{irregularities}")]
    public ActionResult<string> updateTerm([FromRoute] int termId,[FromRoute] bool isCrossed,[FromRoute] bool isComeBack,[FromRoute] string irregularities)
    {
        var result=terminService.updateTerm(termId,isCrossed,isComeBack,irregularities);
        return Ok(result);
    }


    [HttpDelete]
    [Route("deleteTerm/{termId}")]
    public ActionResult<string> deleteTerm([FromRoute] int termId)
    {
        var result= terminService.deleteTerm(termId);
        return Ok(result);

    }

}