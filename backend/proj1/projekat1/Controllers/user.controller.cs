using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace projekat1.Controllers;

[ApiController]
[Route("[controller]/User")]
public class UserEntityConttoller : ControllerBase
{
   private readonly UserService userService;
   public UserEntityConttoller(UserService us)
   {
        userService=us;
   }
    [HttpGet]
    [Route("login/{username}/{password}")]
    public ActionResult<string?> login([FromRoute] string username, [FromRoute] string password)
    {
        var result=userService.login(username, password);
        return Ok(result);
    }
   [HttpPost]
   [Route("addUser")]
   public ActionResult<string> CreateUser([FromBody] UserEntity newUser)
   {
        var result=userService.createUser(newUser);
        return Ok(result);
   }

   [HttpGet]
   [Route("getOneUser/{username}")]
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

   [HttpPatch]
   [Route("updatePassword/{newPassword}/{username}")]
   public ActionResult<string> updatePassword([FromRoute]string newPassword,[FromRoute]string username)
   {
    var result=userService.updatePassword(newPassword,username);
    return Ok(result);
   }
  [HttpPatch]
   [Route("updatePhoneNumber/{newPhoneNumber}/{username}")]
   public ActionResult<string> updatePhoneNumber([FromRoute]string newPhoneNumber,[FromRoute]string username)
   {
    var result=userService.updatePhoneNumber(newPhoneNumber,username);
    return Ok(result);
   }
    [HttpPatch]
   [Route("updateUsername/{newUsername}/{username}")]
   public ActionResult<string> updateUsername([FromRoute]string newUsername,[FromRoute]string username)
   {
    var result=userService.updateUsername(newUsername,username);
    return Ok(result);
   }

  [HttpPatch]
   [Route("updateName/{newName}/{username}")]
   public ActionResult<string> updateName([FromRoute]string newName,[FromRoute]string username)
   {
    var result=userService.updateName(newName,username);
    return Ok(result);
   }

   [HttpGet]
   [Route("getNumOfUsers")]
   public ActionResult<int>getNumOfUsers()
   {
    var result=userService.getNumOfUsers();
    return Ok(result);
   }

   [HttpDelete]
   [Route("deactivateAccount/{username}/{password}")]
   public ActionResult<string>deactivateAccount([FromRoute]string username,[FromRoute] string password)
   {
    var result=userService.deactivateAccount(username,password);
    return Ok(result);
   }



}
