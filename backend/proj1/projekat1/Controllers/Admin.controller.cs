using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/Admin")]
public class AdminEntityController:ControllerBase
{
    private readonly AdminService adminService;
    public AdminEntityController(AdminService asrv)
    {
        adminService=asrv;
    }
    
    [HttpPost]
    [Route("addAdmin")]

    public ActionResult<string> createAdmin([FromBody] AdminEntity newAdmin)
    {
        var result=adminService.createAdmin(newAdmin);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("getAdmin/{username}")]
    public ActionResult<AdminEntity?> getAdmin([FromRoute] string username)
    {
        var result=adminService.getAdmin(username);
        return Ok(result);
    }
}