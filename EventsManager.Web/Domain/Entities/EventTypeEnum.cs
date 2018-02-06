using System;
using System.ComponentModel.DataAnnotations;

namespace EventsManager.Web.Domain.Entities
{
    [Flags]
    public enum EventTypeEnum : byte
    {
        [Display(Name = "Público")]
        Public = 1,
        [Display(Name = "Privado")]
        Private = 2,
        [Display(Name = "Privado Visible")]
        PrivateVisible = 3
    }
}