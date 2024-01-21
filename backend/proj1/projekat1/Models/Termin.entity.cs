using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

 public class TermEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NumOfPassengers { get; set; }

        public string CarBrand { get; set; }
        public string NumOfRegistrationPlates { get; set; }
        public string ChassisNumber { get; set; }
        public int NumberOfDays { get; set; }
        public string PlaceOfResidence { get; set; }
        public DateTime? DateAndTime { get; set; }

        public bool IsPaid { get; set; }
        public bool IsCrossed { get; set; }
        public bool IsComeBack { get; set; }
        public string Irregularities { get; set; }
        public bool Accepted { get; set; }

       public UserEntity? user{get; set;}
       public BorderCrossEntity? borderCross{get;set;}

       public ICollection<NotificationEntity>? listOfNotifications{get;set;}

    }