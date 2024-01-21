using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;


[ApiController]
[Route("[controller]/BorderCross")]
public class BorderCrossEntityController: ControllerBase
{
    private readonly BorderCrossService BCService;

    public BorderCrossEntityController(BorderCrossService bcs)
    {
        BCService=bcs;
    }

    [HttpPost]
    [Route("addBC")]
    public ActionResult<string> addBorderCross([FromBody] BorderCrossEntity newBC)
    {
        var result= BCService.createBorderCross(newBC);
        return Ok(result);
    }


    [HttpGet]
    [Route("getBorderCross/{name}")]
    public ActionResult<BorderCrossEntity?> getBorderCross([FromRoute] string name)
    {
        var result= BCService.getBorderCross(name);
        return Ok(result);

    }

    [HttpGet]
    [Route("getALLBCS")]
    public ActionResult<BorderCrossEntity?> getALLBCS()
    {
        var result= BCService.getALLBCS();
        return Ok(result);

    }
    [HttpGet]
    [Route("getOneBC/{username}")]
    public ActionResult<BorderCrossEntity?>getOneBC([FromRoute]string username)
    {
        var result=BCService.getOneBC(username);
        return Ok(result);
    }
    [HttpGet]
    [Route("getNumOfBC")]
    public ActionResult<int>getNumOfBC()
    {
        var result=BCService.getNumOfBC();
        return Ok(result);
    }

    [HttpDelete]
    [Route("deleteBC/{name}")]
    public ActionResult<string>deleteBC([FromRoute]string name)
    {
        var result=BCService.deleteBC(name);
        return Ok(result);
    }


}