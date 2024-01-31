using System;

namespace EIQ.RAM.Domain.Interfaces;

public interface IHasDeletion
{
    public DateTime? DeletedAt { get; set; }
}
