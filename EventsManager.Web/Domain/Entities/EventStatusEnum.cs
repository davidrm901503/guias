using System;
using System.ComponentModel.DataAnnotations;

namespace EventsManager.Web.Domain.Entities
{
    [Flags]
    public enum EventStatusEnum : byte
    {
        [Display(Name = "Activo")]
        Active = 1,
        [Display(Name = "Finalizado")]
        Finish = 2
    }
}