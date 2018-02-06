using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsManager.Web.Domain.Entities
{
    public class Comment
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Required]
        public string Text { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public DateTimeOffset CommentDate { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Event Event { get; set; }
    }
}