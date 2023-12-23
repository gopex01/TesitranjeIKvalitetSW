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
}