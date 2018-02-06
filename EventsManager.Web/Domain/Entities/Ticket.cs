namespace EventsManager.Web.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public virtual Event Event { get; set; }
    }
}