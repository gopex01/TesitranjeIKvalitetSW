using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic;
public class NotificationEntity{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int Id{get;set;}
    public string Content{get;set;}
    public bool IsRead{get;set;}=false;
    public DateTime date{get;set;}

    public UserEntity? User{get;set;}
    public TermEntity? Term{get;set;}
}