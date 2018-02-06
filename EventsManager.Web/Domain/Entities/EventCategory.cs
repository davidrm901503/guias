using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsManager.Web.Domain.Entities
{
    public class EventCategory
    {
        public EventCategory()
        {
            Events = new HashSet<Event>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}