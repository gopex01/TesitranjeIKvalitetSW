using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]/Notification")]
public class NotificationEntityController:ControllerBase
{
    private readonly NotificationService NotService;
    public NotificationEntityController(NotificationService notS)
    {
        NotService=notS;
    }

    [HttpPatch]
    [Route("readNot/{idNot}")]
    public void readNotification([FromRoute] int idNot)
    {
        NotService.readNotification(idNot);
    }
    [HttpGet]
    [Route("getNot/{username}")]
    public ActionResult<IEnumerable<NotificationEntity>?>getNot([FromRoute] string username)
    {
        var result=NotService.GetNotificationsAsync(username);
        return Ok(result);
    }
}