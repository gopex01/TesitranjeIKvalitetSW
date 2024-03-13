using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

 public class TermEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NumOfPassengers { get; set; }

        public string CarBrand { get; set; } = null!;

        public string NumOfRegistrationPlates { get; set; } = null!;

        public string ChassisNumber { get; set; } = null!;


        public int NumberOfDays { get; set; }
        public string PlaceOfResidence { get; set; } = null!;

        public DateTime? DateAndTime { get; set; }

        public bool IsPaid { get; set; }
        public bool IsCrossed { get; set; }
        public bool IsComeBack { get; set; }
        public string Irregularities { get; set; } = null!;
        public bool Accepted { get; set; }

       public UserEntity? user{get; set;}
       public BorderCrossEntity? borderCross{get;set;}

       public ICollection<NotificationEntity>? listOfNotifications{get;set;}

    }