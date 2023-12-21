using Microsoft.AspNetCore.Mvc;

namespace projekat1.Controllers;

[ApiController]
[Route("[controller]/user")]
public class UserEntityConttoller : ControllerBase
{
   private readonly UserService userService;
   public UserEntityConttoller(UserService us)
   {
        userService=us;
   }

   [HttpPost]
   [Route("addUser")]
   public ActionResult<string> CreateUser([FromBody] UserEntity newUser)
   {
        var result=userService.createUser(newUser);
        return Ok(result);
   }
}
