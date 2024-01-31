using System;

namespace EIQ.RAM.Domain.Interfaces;

public interface IHasUpdate
{
    public DateTime? UpdatedAt { get; set; }
}
