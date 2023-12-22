using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

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

   [HttpGet]
   [Route("getUser/{username}")]
   public ActionResult<UserEntity?> getUser([FromRoute] string username)
   {
     var result=userService.getUser(username);
     return Ok(result);
   }

   [HttpGet]
   [Route("getAllUsers")]
   public ActionResult<UserEntity[]?>getAllUsers()
   {
     var result=userService.getAllUsers();
     return Ok(result);
   }
}
