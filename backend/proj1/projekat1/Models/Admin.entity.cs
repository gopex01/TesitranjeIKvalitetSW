
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


//[Index(nameof(AdminEntity.Username), IsUnique = true)]
public class AdminEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    
    public string Username { get; set; }

    public string Password { get; set; }
}
