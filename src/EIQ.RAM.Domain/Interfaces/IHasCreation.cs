using System;

namespace EIQ.RAM.Domain.Interfaces;

public interface IHasCreation
{
    public DateTime CreatedAt { get; set; }
}
