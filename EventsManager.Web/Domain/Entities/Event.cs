using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsManager.Web.Domain.Entities
{
    public class Event
    {
        public Event()
        {
            Categories = new HashSet<EventCategory>();
            Tickets = new HashSet<Ticket>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public virtual ICollection<EventCategory> Categories { get; set; }
        // Location
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Coordinate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ScheduleDate { get; set; }
        [Required]
        public TimeSpan DepatureTime { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Conditions { get; set; }
        [Required]
        public EventTypeEnum EventType { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        [Required]
        public int TicketCapacity { get; set; }
        public EventStatusEnum EventStatus { get; set; }
        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public bool IsOrganizer { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
